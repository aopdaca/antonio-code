--1. insert two new records into the employee table.
INSERT INTO Employee(EmployeeId, LastName, FirstName) Values 
	(2030, 'Garcia', 'Antonio'),
	(2040, 'Lopez', 'Juan')
--2. insert two new records into the tracks table.
INSERT INTO Track(TrackId, Name, UnitPrice, Milliseconds, MediaTypeId) Values 
	(20310, 'Antonios', 1, 5000,1),
	(20510, 'Ant', 2, 5000,1)
--3. update customer Aaron Mitchell's name to Robert Walter
Update Customer
SET
	FirstName = 'Robert',
	LastName = 'Walter'
Where FirstName = 'Aaron' AND LastName = 'Mitchell' ;
--4. delete one of the employees you inserted.
Delete From Employee
Where EmployeeId = 2030;
--5. delete customer Robert Walter.
Delete From Invoice
Where CustomerId = (Select CustomerId from Customer where FirstName = 'Robert' AND LastName = 'Walter');

Delete From InvoiceLine
Where InvoiceId IN (
	Select InvoiceId From Invoice
	Where CustomerId = (
		Select CustomerId From Customer
		Where FirstName = 'Robert' AND LastName = 'Walter')
		);


Delete From Invoice
	Where CustomerId = (
		Select CustomerId From Customer
		Where FirstName = 'Robert' AND LastName = 'Walter')

Delete From Customer
	Where CustomerId = (
		Select CustomerId From Customer
		Where FirstName = 'Robert' AND LastName = 'Walter')
		