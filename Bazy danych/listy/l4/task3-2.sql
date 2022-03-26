SET STATISTICS TIME ON
-- 2

SELECT c.PESEL, c.Nazwisko
FROM Czytelnik c WHERE c.Czytelnik_ID IN
(SELECT w.Czytelnik_ID FROM Wypozyczenie w
JOIN Egzemplarz e ON e.Egzemplarz_ID = w.Egzemplarz_ID
JOIN Ksiazka k	  ON e.Ksiazka_ID    = k.Ksiazka_ID)


-- Client processing time:		42.9
-- Total execution time:		49.3 -- LONGEST
-- Wait time on server replies:	6.4



SET STATISTICS TIME Off
