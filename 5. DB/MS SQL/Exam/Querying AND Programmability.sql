
-- 5. Books By Year of Publication
SELECT 
Title AS [Book Title],
ISBN,
YearPublished AS [YearReleased]
FROM Books
ORDER BY YearReleased DESC, Title ASC

-- 6. Books By Genre
SELECT 
Books.Id, 
Books.Title, 
Books.ISBN,
Genres.[Name] AS [Genre]
FROM Books
JOIN Genres ON Books.Id = Genres.Id
ORDER BY Genre, Title ASC

-- 7. Libraries Missing Specific Genre
SELECT 
[Name] AS [Library],
c.Email AS [Email]
FROM Libraries AS l
INNER JOIN Contacts AS c ON c.Id = l.Id
WHERE l.Id NOT IN 
(
 SELECT DISTINCT lB.LibraryId
    FROM LibrariesBooks lb
    JOIN Books b ON lb.BookId = b.Id
    JOIN Genres g ON b.GenreId = g.Id
    WHERE g.[Name] = 'Mystery'
)
ORDER BY l.Name ASC

-- 8. First 3 Books
SELECT TOP(3)
Title,
YearPublished AS [Year],
g.[Name] AS [Genre]
FROM Books AS b
INNER JOIN Genres AS g ON b.GenreId = g.Id
WHERE
   (b.YearPublished > 2000 AND b.Title LIKE '%a%')
   OR
   (b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy')
ORDER BY
b.Title ASC,
b.YearPublished DESC	

-- 9. Authors from the UK
SELECT
a.[Name] AS [Author],
c.PostAddress 
FROM Authors AS a
INNER JOIN Contacts AS c ON a.ContactID = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name] ASC

-- 10. Fictions in Denver
SELECT
a.[Name] AS [Author],
b.[Title],
l.[Name] AS [Library],
c.PostAddress AS [Library Address]
FROM Books AS b
JOIN Authors AS a ON b.AuthorId = a.Id
JOIN Genres AS g ON b.GenreId = g.Id
JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE
g.[Name]= 'Fiction'
AND c.PostAddress LIKE '%Denver%'
ORDER BY
b.Title ASC

-- 11. Authors with Books
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
   DECLARE @TotalBooks INT

   SELECT @TotalBooks = COUNT(b.Id)
   FROM Authors AS a
   JOIN Books AS b ON a.Id = b.AuthorId
   JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
   WHERE a.[Name] = @name

   RETURN @TotalBooks
END

-- 12. Search for Books from a Specific Genre
CREATE PROC usp_SearchByGenre(@genreName NVARCHAR(200))
AS
BEGIN
   SELECT
   b.Title,
   b.YearPublished AS [Year],
   b.ISBN,
   a.[Name] AS [Author],
   g.[Name] AS [Genre]
   FROM Books AS b
   JOIN Authors AS a ON b.AuthorId = a.Id
   JOIN Genres AS g ON b.GenreId = g.Id
   WHERE g.[Name] = @genreName
   ORDER BY b.Title ASC
END