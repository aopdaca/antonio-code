-- other DDL things

-- computed columns
-- can't insert, can't update, the value is generated when read.
ALTER TABLE Poke.Type ADD
	Initial AS SUBSTRING(Name, 1, 1) PERSISTED;
--ALTER TABLE Poke.Type DROP COLUMN Initial;

-- with PERSISTED, the computed value will be stored with the other columns
-- and updated when needed (use space, but save time when reading)

SELECT * FROM Poke.Type;

-- views
-- like computed tables

GO
CREATE VIEW Poke.ActivePokemon AS
	SELECT * FROM Poke.Pokemon WHERE Active = 1;

SELECT * FROM Poke.ActivePokemon;

-- views support insert/update/delete, only on actual columns,
-- not computed select-list stuff.

-- we can create views WITH SCHEMABINDING
-- this locks any underlying tables
-- and prevents any changes to their definition that would alter the view

-- we have temporary variables
DECLARE @maxid AS INT;
SET @maxid = (SELECT MAX(TypeId) FROM Poke.Type);
SELECT @maxid;
-- we also have table-valued variables
DECLARE @mytable AS TABLE (
	col1 INT, col2 INT
);
INSERT INTO @mytable
	SELECT TypeId, TypeId + 2
	FROM Poke.Type;
SELECT * FROM @mytable;

-- user-defined functions
GO
CREATE FUNCTION Poke.TotalNumberOfPokemon()
RETURNS INT
AS
BEGIN
	DECLARE @result INT;

	SELECT @result = COUNT(*) FROM Poke.Pokemon;

	RETURN @result;
END

SELECT Poke.TotalNumberOfPokemon();

GO
CREATE FUNCTION Poke.PokemonWithNameOfLength(@length INT)
RETURNS TABLE
AS
	RETURN (SELECT * FROM Poke.Pokemon
		WHERE LEN(Name) = @length);

SELECT * FROM Poke.PokemonWithNameOfLength(8);

-- table-valued user-defined functions

-- functions cannot modify the DB at all. only read.

-- write a function to return the initials of a customer based on his ID.
GO
CREATE FUNCTION CustomerInitials(@id INT)
RETURNS
NVARCHAR(2)
AS
BEGIN
	DECLARE @result NVARCHAR(2);
	SELECT @result = SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1)
	FROM Customer
	WHERE CustomerId = @id;
	RETURN @result;
END
GO
SELECT dbo.CustomerInitials(20);

-- triggers
-- we can add commands to run before, instead of, or after
-- an insert, update, or delete to a given table.
GO
CREATE TRIGGER Poke.PokemonDateModified ON Poke.Pokemon
AFTER UPDATE
AS
BEGIN
	-- in a trigger, you have access to two special table variables
	-- Inserted and Deleted
	-- one or the other or both will be relevant depending on if this
	-- is insert, update or delete.
	UPDATE Poke.Pokemon
	SET DateModified = GETDATE()
	WHERE PokemonId IN (SELECT PokemonId FROM Inserted);
	-- trigger recursion is disabled by default.
END

SELECT * FROM Poke.Pokemon;
UPDATE Poke.Pokemon SET Active = 0
WHERE PokemonId = 2;
SELECT * FROM Poke.Pokemon;

-- stored procedures
-- like functions, except
-- 1. they can make changes to the database
-- 2. you can't call them as part of any other statement like SELECT;
--    you call them with EXECUTE procudure_name param1 param2;
-- 3. they don't return anything directly, but they can have "output" params.

GO
CREATE PROCEDURE Poke.UpdateAllDateModified(@rowschanged INT OUTPUT)
AS
BEGIN
	-- we have flow control like IF, WHILE loops, TRY CATCH
	BEGIN TRY
		IF (NOT EXISTS (SELECT * FROM Poke.Pokemon))
		BEGIN
			SET @rowschanged = 0;
			RAISERROR ('No values in table.', 15, 1);
			-- THROW is another way to raise errors with different syntax
		END
		SET @rowschanged = (SELECT COUNT(*) FROM Poke.Pokemon);
		UPDATE Poke.Pokemon
		SET DateModified = GETDATE();
	END TRY
	BEGIN CATCH
		PRINT 'Error found!';
		PRINT ERROR_MESSAGE();
		PRINT ERROR_SEVERITY();
	END CATCH
END

DECLARE @rowschanged INT;
EXECUTE Poke.UpdateAllDateModified @rowschanged OUTPUT;
SELECT @rowschanged;

DELETE FROM Poke.Pokemon;

SELECT * FROM Poke.Pokemon;