--DDL

--Dataa Definition Language

--we no longer see anything so specific as rows
--we operarte on whole tables (or columns) or other objects or functions

-- create alter drop
--for creating editing and deleting any of these db objects)


CREATe SCHEMA Poke;
GO -- some statements want to be in their own batch
-- so we can write Go to seperate batches or comands

CREATE TABLE Poke.Pokemon(
	--in here : colimn definitions and constraints
	PokemonId INT
);

Select * From Poke.Pokemon;

Alter Table Poke.Pokemon ADD
	Name nvarchar(100);

Drop Table Poke.Pokemon;

--Drop Table deletes the whole table including any columns, constraints, etc
--Truncate Table delets ther rows but leaves all colimns etc intact

--constraints

--NOT NULL
	--Null is not allowed as a value in this column
--Null
	--Null is allowed (default)
--Primary Key
	--There can only be one
	-- it will server to identify this row for any foreign key that point to it
	--enforces uniquness
	--adds clustered index by default
	--implies not null
--UNIQUE
	--no duplicates allowed
--Default
	-- you give it some expresion or value while will be the default
	--if someone inserts without providing a value
--CHeck
	--we can put any boolean expression for this, checking any condition we want across the data of one row
	--validate the values of a row in any way needed
--Foreign Key
	--this column can only contain the values of some primay key column somewhere
--Identity
	--set up a column to have auto-incremented integer values
	--is parameterized, we can say Identity(2,4) and that will count 2,6,10
	--counts 1,2,3,4,5,6

	CREATE TABLE Poke.Pokemon(
	PokemonId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NAME NVARCHAR(50) NOT NULL UNIQUE,
	TypeId INT NOT NULL,
	Height Int Not NUll,
	EvolutionId INT NULL,
	DateModified DATETIME2(7) NOT NULL Default GETDATE()
);

CREATE TABLE Poke.Type(
	TypeId Int NOT NULL Identity(1,1) Primary Key,
	Name Nvarchar(20) Not NUll Unique
);

Alter Table Poke.Pokemon Add
	Constraint FK_Pokemon_Type_TypeId Foreign Key (TypeId)
		References Poke.Type (TypeId)

Alter Table Poke.Pokemon Add
	Constraint FK_Pokemon_Pokemon_EvolutionId Foreign Key (Evolutionid)
		References Poke.Pokemon (PokemonId)

Insert Into Poke.Type (Name) Values
	('Grass');

Insert Into Poke.Pokemon(Name, TypeId, Height) Values
	('Bulbasaur', 
	(SELECT TypeId From Poke.Type Where Name = 'Grass'), 
	28
);

Insert Into Poke.Pokemon(Name, TypeId, Height) Values
	('Venusaur', 
	(SELECT TypeId From Poke.Type Where Name = 'Grass'), 
	79
);

Update Poke.Pokemon
set EvolutionId = (Select PokemonId From Poke.Pokemon Where Name = 'Venusaur')
Where Name = 'Bulbasaur';

SELECT p1.Name, p1.Height, t.Name AS Type, p2.Name AS Evolution
FROM Poke.Pokemon AS p1
	LEFT JOIN Poke.Type AS t ON p1.TypeId = t.TypeId
	LEFT JOIN Poke.Pokemon AS p2 ON p1.EvolutionId = p2.PokemonId;

-- add an active column ro a table with existing rows

Alter Table Poke.Pokemon ADD
	Active Bit Not NUll Default(1);

	--when adding new column where there are already rows, must have some default to have in those rows
	--either null or default or identity
	--can delete that default after the fact if desired

	--Alter table poke.pokemon drop constraint DF_Pokemon_Active_4989348i3; --fake look up real name later

	select * from Poke.Pokemon;
