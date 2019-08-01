-- Other DDL things

--computed columns
--can't insert, can't update, the value is generated when read

Alter Table Poke.Type ADD
	Inital AS Substring(Name, 1,1) Persisted;

--Alter Table Poke.Type Drop Column Inital;

--with persisted the computed value will be stored with other columns
--and updated when needed (use space, but save time when reading)


	
Select * from Poke.Type;


-- views
--like computed tables
go

Create View Poke.ActivePokemon As 
	Select * from Poke.Pokemon Where Active = 1;

Select * from Poke.ActivePokemon;
	
-- views support insert/update/delete, only on actual columns,
--not computed select-list stuff

--we can create views with schemabinding
--locks any underlying tables and prevent any changes to their definition that would alter the view

--we have temporary variables
Declare @maxid As INT;
Set @maxid = (Select Max(TypeId) From Poke.Type)
Select @maxid;

-- we also have table value variabels
Declare @myTable as Table (
	col1 INT, col2 int
);

Insert Into @myTable
	Select TypeId, TypeId +2
	From Poke.Type;
Select * from @myTable

--User defined functions
Go
Create Function Poke.TotalNumberOfPoke()
Returns INT
As Begin
	Declare @result Int;

	Select @result = Count(*) from Poke.Pokemon;

	Return @result;
End

Select Poke.TotalNumberOfPoke();

Go
Create Function Poke.TotalNumberOfPoke1(@length int)
Returns table
As 
	
	Return (Select * from Poke.Pokemon where LEN(Name) = @length);
	

Select * from Poke.TotalNumberOfPoke1(8);

--table valued user defined functions

--functions can not modify the db at all only read


--triggers
--we can add commands to run before, instead of, or afte
--an insert, update, or delet to a given table

Go
Create Trigger Poke.PokemonDateModified ON Poke.Pokemon
After Update
As Begin

	-- a trigger, you have access to two special talbe variables
	--inserted and deleted
	--one or the other or both will be relevant depending on if thid
	--is indert, update, or delete

	Update Poke.Pokemon 
	SET DateModified = GETDATE()
	Where PokemonId in (Select PokemonId from Inserted);
	--trigger recursion is disables by default

end

Select * from Poke.Pokemon;
Update Poke.Pokemon Set Active = 0
Where PokemonId = 2;

-- Stored Procedures
--Like functions except
--1.they can make changes to the database
--2. you cant call them as part of any other statement like select;
	--you call them with execute procedure_name paramq param2;
--3. they dont return anything directly, but they can have "output" params


Go
Create Procedure Poke.UpdateAllDateModified(@rowsChanged INT OUTPUT)
As
Begin
		-- we have flow control like if, while loops. try catch
		Begin Try
			If(Not Exists (Select * From Poke.Pokemon))
			Begin
				Set @rowsChanged = 0;
				Raiserror ('No Values in table', 15, 1);
			End
			Set @rowsChanged = (Select Count(*) FROM  Poke.Pokemon);
			Update Poke.Pokemon
			Set DateModified = GetDate();
		End Try
		Begin Catch
			Print 'Error Found!!!!!';
			Print Error_Message();
			Print Error_Severity();
		End Catch
End

Declare @rowsChanged int;
Execute Poke.UpdateAllDateModified @rowsChanged Output;
Select @rowsChanged;

Delete From Poke.Pokemon;

Select * from Poke.Pokemon;


