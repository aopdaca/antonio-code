--Select statement clause....

--Select: list of columns to compute and run in the result set
--From: what table to access
--where: filter the rows into one row per set of unique values
--group by: combine the rows into one row per set of unique values
--		for the items
--			group by compares strings case insensitve like all of sql
--		(the collection can change that)
--Having: to apply filtering conditions after grouping
--order by: sort the rows of the result set by asc or desc values

--logical processing order of select statement 
--From, where, group by, having
--select
--order by

Select Name, Count(*) from Genre group by Name;
Insert into Genre(GenreId, Name) Values (1000, 'rock');

--all the first names of customers that have duplicates
Select FirstName from customer group by FirstName;

--you cant put aything in the select list that is not in the group by list
--unless it has an aggregate around it

--WHERE runs before group by
--Having runs after group by

--Top
Select top(1) Firstname from Customer order by FirstName;