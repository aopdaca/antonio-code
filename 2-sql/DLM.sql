--DML
--Data Manipulation Language
--Set of SQL commans which operate on individual rows of tables

--Select, Insert, Update, Delete, Truncate Table

--Crud Createm Read, Update, Delete
--DMl does CRUD on table rows

--Select is for read access, for queries

Select * from Genre Order By GenreId DESC;

Insert into Genre Values (200, 'Misc');

INSERT INTO Genre(GenreId, Name) Values (201, 'Misc2');
--(Name column has a name default so i can do)
INSERT INTO Genre(GenreId) Values (202);

INSERT INTO Genre(GenreId, Name) Values 
	(203, 'Misc 3')
	(204, 'Misc 4')
	(205, 'Misc 5');

INSERT INTO Genre(GenreId, Name) Values (
	Select Top(1) (GenreId From Genre Order By GenreId DESC) + 1, 'Misc 6');

--you can load a cvs file and insert all of its data as rows
--you can insert the resulr of a whole query
	
--insert copies of all my "misc" to m
Insert Into Genre(GenreId, Name)
	Select GenreId + 100, Name + '2'
	From Genre
	Where Name Like 'Misc%'

-- UPDATE

--change misc to micellaneous in all my genre

--	123456 (1-based indexing in SQL)
--	Misc 1

Update Genre
SET
	Name = 'Miscellaneous ' + SUBSTRING(Name, 6, 1),
	GenreId = GenreId + 20
Where Name Like 'Misc _';

--change one column
Update Genre
Set Name = 'Rock Music'
Where Name = 'Rock';

--Delete
Delete From Genre
Where Name Like 'Miscellaneous%';

Delete From Genre
Where GenreId > 30;

--Delete from genre without ant where wpould delete