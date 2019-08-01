--1. list all customers (full names, customer ID, and country) who are not in the US
select Firstname + '' + Lastname AS [Full Name], CustomerId, Country from dbo.Customer where Country != 'USA'; --46

--2. list all customers from brazil
select * from dbo.Customer where Country = 'Brazil'; --5

--3. list all sales agents
select * from dbo.Employee where Title = 'Sales Support Agent'; --3

--4. show a list of all countries in billing addresses on invoices.
select distinct BillingCountry from dbo.Invoice; --24

--5. how many invoices were there in 2009, and what was the sales total for that year? 
select count(InvoiceID), SUM(Total) from dbo.Invoice where YEAR(InvoiceDate) = 2009; --83 total = 449.46

--aggregate functions combine a whole sequence of values into one value
--AVG, SUM, COUNT, MIN, MAX
--One way to extract parts of a date/time from a datetime is functions like year(), minute etc.


--
--Group By is another clause of select statement
--Group By lets you apply the aggregate functions not to all the rows at once
--(which would always give you only one result row)
-- but to groups of rows, based on having the same value of what you putin the GROUP By list.

--(extra challenge: find the invoice count sales total for every year, using one query)
select count(InvoiceID), SUM(Total), YEAR(InvoiceDate) from dbo.Invoice Group By YEAR(InvoiceDate); --2009&2010&2011&2012 = 83 2013 80

--6. how many line items were there for invoice #37?
select Count(quantity) AS [Total line items] from dbo.InvoiceLine where InvoiceId=37; --4

--7. how many invoices per country?
select Count(BillingCountry) AS [count of billing], BillingCountry from dbo.Invoice Group by BillingCountry; --7,7,7,7,35,56

--8. show total sales per country, ordered by highest sales first.
select SUM(Total) AS [Total Sales], BillingCountry from dbo.Invoice Group by BillingCountry Order By SUM(Total) DESC, BillingCountry; --523.06 usa

--Order BY is another selct clause which sorts the result set
--defaults to asc order, switch with DESC for decending
--can have list so there will be a second comp to break ties

--if no order by sql will return whatever
--order is most convinient for it (fastest) put order by to guarantee sotred 