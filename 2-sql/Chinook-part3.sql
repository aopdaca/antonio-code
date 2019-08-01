--1. which artists did not make any albums at all?
Select Name fromSelect ArtistId from Artist
Except
Select ArtistId from Album;

Select * from artist where ArtistId Not In (
	Select ArtistId from Album
);

Select ar.Name
From Artist as ar 
Except
Select ar.Name
From Artist AS ar
	Left Join Album AS al ON al.ArtistId = ar.ArtistId
where AlbumId Is Not NUll;

Select ar.Name
From Artist As ar
	Left Join

--2. which artists did not record any tracks of the Latin genre?
--3. which video track has the longest length? (use media type table)
--4. find the names of the customers who live in the same city as the boss employee (the one who reports to nobody)
--5. how many audio tracks were bought by German customers, and what was the total price paid for them?
--6. list the names and countries of the customers supported by an employee who was hired younger than 35.