-- SQL SYNTAX 
 --IS A LINE COMMENT CTRL K+C COMMENT, CTRL K+U UNCOMMNET

 --THERES ONLY ONE SQL COMMAND THAT HAS A RETURN VALUE
 --SELECT STATEMENT

 SELECT 'HELLO WORLD';

 -- SQL IS NOT CASE SENSITIVE, WHITESPACE DOES NOT MATTER
 -- BIT LIKE JS IN THAT THE ; ARE CONVESTOION BUT OPTIONAL

 SELECT 1;

 -- HIGHLIGHT THE TEXT YOU WANT TO RUN INSTEAD OF THE WHOLE TEXT FILE AND THEN RUN WITH F5 

 Select * from SalesLT.Product;

 -- the selct statement has mant clauses
-- we hacve seen the select clause and the from clause

--from: which ravke to access
--select which columns ro return from that table *- all
select name from SalesLT.Product;
--names of all products
--case-insensitive

--all objects including tables in a database are in a particular namespace called scheme
--salesLT is the scheme and the product is the table name

select * from SalesLT.Customer;
select Firstname + ' ' + LastName from SalesLT.Customer;

--column aliases using AS
--in T-sql we have two ways to quote identifiers - [] and "".
--single quotes '' are for actual string data
select Firstname + ' ' + LastName as [Full Name] from SalesLT.Customer;

select Firstname from SalesLT.Customer; --847

select Distinct Firstname from SalesLT.Customer; --315 results

--where clause of the select statement 
--filter the returned rows based on any condition

--every customer whose first name is abigail
select * from SalesLT.Customer where FirstName = 'Abigail';

--comparison operators
-- > < >= <=
--simply for equality check
--two options for not equals: <> or !=
--compare strings in lexicographic order (dictionary order)



--like for pattern matching strinf in a simpler way then fill regex
--% means any number of extra characters including 0
--_ means exactly one character
--[abc] menas exactly one a b or c

--everyone whos last name starts with b
select * from SalesLT.Customer where LastName like 'B%';

--starts with any vowel Like '[aeiou]%'

--another way, using boolean operators and string ordering 
--boolean operators and or not xor
select * from SalesLT.Customer where LastName <'C' AND LastName >='B';