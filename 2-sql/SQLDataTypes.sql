--Data Types in SQL Server

--Numeric 
	--Whole Numbers
		-- TinyInt -1 byte
		-- SmallInt -2 byte
		-- Int		-4 byte
		--Big int	-8 byte
	-- floating-point numbers
		--Float, Real
		--Decimal/Numberic(n,p)
			--highest percision, custom persiceion
			--n number of digits of percision
			--p means number of those that are after the decimal
			--e.g. Numberic(10,2) - 10 digits, with 2 after the decimal point
		-- currency
			--Money
				--formats nicely, stores high percision
		--boolean
			--bit	-1 bit (0 or 1)
		--String
			--CHAR(n)
				--ficed length string
			--VARCHAR(n)
				-- dynamic length string up to the size n (can say max)
					-- when we do 'abc', thats a varchar
			--NCHAR(n)
				--like char, but allows Unicode
			--NVARCHAR(n)
				--like varchar, but allows unicode (use this one)
				--when we do N'abc' thats ab nvarchar
			-- the collation affects the encoding of the non-N string types
			--should learn some of the string functions available
			--(indexing is 1 based)
				--LEN
				--SubString
				--Replace
				--CHARINDEX
				--LOWER, UPPER
		--date/time
		--DATEa for dates
		--Time for time
		--DateTime(n) for dates with times
		--DateTime2(n) instead of datetime
			--higher precision, wider range of possible dates
			--ajustible precision, can use max
		--DATETIMEOFFSET
			--interval of time e.g. 80 mins
		--can get the year of the date like YEAR(date)
		--can also use Exactly: exactly (YEAR from DATE)

-- we have Convert Function
	--CONVERT(bigint, 34)

Select * from Invoice;

Update Invoice
Set InvoiceDate = GetDate()
where InvoiceId = 1;


Update Invoice
Set InvoiceDate = GetDate()
where InvoiceId = 1;