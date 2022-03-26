SET STATISTICS TIME ON

SELECT DISTINCT c.PESEL, c.Nazwisko FROM Egzemplarz e
JOIN Ksiazka k		ON e.Ksiazka_ID    = k.Ksiazka_ID
JOIN Wypozyczenie w ON e.Egzemplarz_ID = w.Egzemplarz_ID
JOIN Czytelnik c	ON c.Czytelnik_ID  = w.Czytelnik_ID
-- Tworzymy tabelkê z niepowtarzalnych peseli i nazwisk, do³¹czamy do tego inne tabelki na podstawie powtarzaj¹cych siê kluczy.
-- Client processing time:		1.2
-- Total execution time:		1.6
-- Wait time on server replies:	0.4

SELECT c.PESEL, c.Nazwisko
FROM Czytelnik c WHERE c.Czytelnik_ID IN
(SELECT w.Czytelnik_ID FROM Wypozyczenie w
JOIN Egzemplarz e ON e.Egzemplarz_ID = w.Egzemplarz_ID
JOIN Ksiazka k	  ON e.Ksiazka_ID    = k.Ksiazka_ID)
-- Tworzymy tabelkê z peseli i nazwisk, gdzie ID czytelnika pokrywa siê z uzyskanymi w podzapytaniu ID czytelników wypo¿yczaj¹cych ksi¹¿ki.
-- Client processing time:		0.3
-- Total execution time:		1.0
-- Wait time on server replies:	0.7

-- inne zapytanie 
SELECT c.PESEL, c.Nazwisko
FROM Czytelnik c WHERE c.Czytelnik_ID IN
(SELECT w.Czytelnik_ID FROM Wypozyczenie w, Egzemplarz e, Ksiazka k WHERE e.Egzemplarz_ID = w.Egzemplarz_ID AND e.Ksiazka_ID = k.Ksiazka_ID)

-- Client processing time:		0.3
-- Total execution time:		0.4
-- Wait time on server replies:	0.1

SET STATISTICS TIME OFF

-- SET SHOWPLAN_ALL ON / OFF -- jakies dodatkowe info