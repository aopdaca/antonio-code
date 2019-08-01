--Joins combine data back together in a query
--that was spread out into many tables by the database's design.

--pair every employee with every other employee
--(joins do not have to be beetween two different tables)
--must give tables aliesas if the have the same name
select e1.*, e2.* from Employee as e1 cross join Employee as e2;
-- cross joins are not always very useful
--one example: combine toppings, toppings, crusts, and cheeses to make all possible combinations
--length of result is the product of the length of the two input tables


--INNER JOIN
--like cross join, but discard all result rows except those matching on a condition
--each track name and genre
Select t.Name, g.Name from Track as t INNER JOIN Genre as g on t.GenreId = g.GenreId

-- if we ised left join instead we would see any tracks that have no genere with null in the second column

-- all rock songs in the database showing the name in this format Artist - Song Name
--think about how to handle any possible null values

Select ar.Name + '-' + t.Name
From Genre as g 
LEFT JOIN Track as t on g.GenreId = t.GenreId 
LEFT JOIN Album as a on t.AlbumId = a.AlbumId
LEFT JOIN Artist as ar on a.ArtistId = ar.ArtistId
where g.Name = 'Rock';

--Equivalent, but writing the joins in different order:
--(and using COALESCE to handle cases of tracking missing Artist (NULL).)
Select COALESCE(ar.Name, 'Unknown Artist') + ' - ' + t.Name AS [Artist and Title]
From Track as t 
LEFT JOIN Album as a on t.AlbumId = a.AlbumId 
LEFT JOIN Artist as ar on ar.ArtistId = a.ArtistId
LEFT JOIN Genre as g on g.GenreId = t.GenreId
where g.Name = 'Rock';


-- i dont care if there are albums without artist, or artist without tracks

Select Firstname + ' ' + Lastname + ' (' + COALESCE(Company, 'N/A')+ ')'
from Customer;