--sub-queries

--every track that has never been purchased

Select t.*
from Track as T
Left Join InvoiceLine AS il on t.TrackId = il.TrackId
where il.InvoiceLineId is NULL;

Select * from Track Where TrackId NOT IN (
	Select TrackId from InvoiceLine);

--we can put "inner queries" in parts of the select statement
-- and compare against them with operators like IN, NOT IN, Exists, Any , All, (SOME?)
-- get the rtist who made the album with the longest title
Select *
From Artist
Where ArtistId = (
	Select ArtistId
	From Album
	Where Len(Title) >= All(Select LEN(Title) From Album)
	);

	--similar to subquery, "comon table expression" (CTE)

With Purchased_tracks AS (
	Select Distinct TrackId From InvoiceLine
)
Select *
From Track
Where TrackId NOT IN (
	Select * from Purchased_tracks
	);