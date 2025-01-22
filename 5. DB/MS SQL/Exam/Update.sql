UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(n.Name, ' ', '')) + '.com'
FROM Contacts AS e
INNER JOIN Authors AS n
ON e.Id = n.ContactID
WHERE e.Website IS NULL OR e.Website = ''