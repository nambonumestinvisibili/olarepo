SET STATISTICS TIME ON
-- 1

SELECT DISTINCT c.PESEL, c.Nazwisko FROM Egzemplarz e
JOIN Ksiazka k		ON e.Ksiazka_ID    = k.Ksiazka_ID
JOIN Wypozyczenie w ON e.Egzemplarz_ID = w.Egzemplarz_ID
JOIN Czytelnik c	ON c.Czytelnik_ID  = w.Czytelnik_ID


-- Client processing time:		44.70
-- Total execution time:		45.11 -- MIDDLE
-- Wait time on server replies:	0.444


SET STATISTICS TIME Off
