USE LibraryDb

DELETE FROM Authors
WHERE Id = (
    SELECT AuthorId
    FROM Books
    WHERE Id IN (
        SELECT BookId
        FROM LibrariesBooks
        WHERE BookId IN (
            SELECT Id
            FROM Books
            WHERE AuthorId = (
                SELECT Id
                FROM Authors
                WHERE Name = 'Alex Michaelides'
            )
        )
    )
);