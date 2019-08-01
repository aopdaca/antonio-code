-- DDL
-- Data Definition Language

-- we no longer see anything so specific as rows
-- we operate on whole tables (or columns) or other objects like functions

-- CREATE, ALTER, DROP
-- for creating, editing, and deleting any of these DB objects

CREATE SCHEMA Poke;
GO -- some statements want to be in their own batch
-- so we can write GO to separate batches of commands

CREATE TABLE Poke.Pokemon (
	-- in here go: column definitions and constraints
	PokemonId INT
);

SELECT * FROM Poke.Pokemon;

ALTER TABLE Poke.Pokemon ADD
	Name NVARCHAR(50);

DROP TABLE Poke.Pokemon;

-- DROP TABLE deletes the whole table including any columns, constraints, etc
-- TRUNCATE TABLE deletes the rows, but leaves all the columns etc intact

-- constraints

-- NOT NULL
--   NULL is not allowed as a value in this column.
-- NULL
--   NULL is allowed (default)
-- PRIMARY KEY
--   there can only be one
--   this column will serve to identify this row for any
--      foreign keys that point to it
--   enforces uniqueness, NOT NULL
--   adds clustered index by default
-- UNIQUE
--   no duplicates in the column allowed
-- DEFAULT
--   you give it some expression or value while will be the default
--   if someone inserts without providing a value.
-- CHECK
--   we can put any boolean expression for this, checking any
--   condition we want across the data of one row
--   validate the values of a row in any way needed
-- FOREIGN KEY
--   this column can only contain the values of some primary key column somewhere
-- IDENTITY
--   set up a column to have auto-incremented integer values.
--   (is parameterized, we can say IDENTITY(2,4) and that would count 2, 6, 10)
--   counts 1, 2, 3, 4, 5...

--DROP TABLE Poke.Pokemon;
CREATE TABLE Poke.Pokemon (
	PokemonId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL UNIQUE,
	TypeId INT NOT NULL,
	Height INT NOT NULL,
	EvolutionId INT NULL,
	DateModified DATETIME2(7) NOT NULL DEFAULT GETDATE()
);

--DROP TABLE Poke.Type;
CREATE TABLE Poke.Type (
	TypeId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL UNIQUE
);

ALTER TABLE Poke.Pokemon ADD
	CONSTRAINT FK_Pokemon_Type_TypeId FOREIGN KEY (TypeId)
		REFERENCES Poke.Type (TypeId);

ALTER TABLE Poke.Pokemon ADD
	CONSTRAINT FK_Pokemon_Pokemon_EvolutionId FOREIGN KEY (EvolutionId)
		REFERENCES Poke.Pokemon (PokemonId);

INSERT INTO Poke.Type (Name) VALUES
	('Grass');

INSERT INTO Poke.Pokemon (Name, TypeId, Height) VALUES (
	'Bulbasaur',
	(SELECT TypeId FROM Poke.Type WHERE Name = 'Grass'),
	28
);

INSERT INTO Poke.Pokemon (Name, TypeId, Height) VALUES (
	'Venusaur',
	(SELECT TypeId FROM Poke.Type WHERE Name = 'Grass'),
	79
);

UPDATE Poke.Pokemon
SET EvolutionId = (SELECT PokemonId FROM Poke.Pokemon WHERE Name = 'Venusaur')
WHERE Name = 'Bulbasaur';

SELECT p1.Name, p1.Height, t.Name AS Type, p2.Name AS Evolution
FROM Poke.Pokemon AS p1
	LEFT JOIN Poke.Type AS t ON p1.TypeId = t.TypeId
	LEFT JOIN Poke.Pokemon AS p2 ON p1.EvolutionId = p2.PokemonId;

-- add an Active column to a table with existing rows
ALTER TABLE Poke.Pokemon ADD
	Active BIT NOT NULL DEFAULT(1);
-- when adding new column where there are already rows...
-- must have some default to put in those rows, either NULL or DEFAULT or IDENTITY etc.
-- can delete that default after the fact if desired

--ALTER TABLE Poke.Pokemon DROP CONSTRAINT DF__Pokemon__Active__534D60F1;

SELECT * FROM Poke.Pokemon WHERE Active = 1;
