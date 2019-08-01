--1. show all invoices of customers from brazil (mailing address not billing)
select *
from Invoice AS i  INNER JOIN Customer AS c ON (i.CustomerId = c.CustomerId)
Where c.Country = 'Brazil'; --35

--2. show all invoices together with the name of the sales agent of each one
select e.*
from Invoice AS i  
JOIN Customer AS c ON (i.CustomerId = c.CustomerId)
JOIN Employee AS e ON  c.SupportRepId = e.EmployeeId; --412

--3. show all playlists ordered by the total number of tracks they have
select *
from Playlist AS p 
JOIN PlaylistTrack AS pt ON (p.PlaylistId = pt.PlaylistId);

--4. which sales agent made the most in sales in 2009?
select Sum(i.total)
from employee as e
	inner join customer as c on c.SupportRepID = e.EmployeeID
	inner join Invoice as i on i.CustomerID = c.CustomerID
where Year(i.InvoiceDate) = 2009
Group By e.EmployeeId, e.LastName, e.FirstName
Order by Sum(i.total) DESC
--5. how many customers are assigned to each sales agent?
--6. which track was purchased the most since 2010?
--7. show the top three best-selling artists.
--8. which customers have the same initials as at least one other customer?