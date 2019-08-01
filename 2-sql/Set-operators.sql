--SQL supports some standard mathematical set operations on table / result set

-- Union
--Concatenates two result sets (the columns have to match up)
-- (removes duplicates)

--Union ALl
--same as union but does not remove duplicates.
-- all first names of either employees or customers
select FirstName from Customer
Union
Select FirstName from Employee;

--Intercect
--Filter out all rows that are not in both the left hand query and the right

--all first names in both customer and employee
Select FirstName from Customer
Intersect
Select FirstName from Employee

--Except
--all rows from the first query except for any that are also in the second query
--first query minus second
Select FirstName from Employee
Except
Select FirstName from Customer;



