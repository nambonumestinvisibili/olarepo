declare @x int, @s varchar(10)

set @x=10
set @s='2'

print @x+@s
--print 'n'+@x
GO


declare @imie varchar(20), @nazwisko varchar(20)

-- poprawnie
select @imie=FirstName, @nazwisko=LastName from SalesLT.Customer where CustomerID=7
print @imie+' '+@nazwisko

-- tutaj zostan� przypisane dane z ostatniego wiersza (przyda�oby si� sortowanie, �eby nad tym panowa�)
select @imie=FirstName, @nazwisko=LastName from SalesLT.Customer
print @imie+' '+@nazwisko

-- trzeba r�wnie� przypilnowa�, �eby by�y przypisane jakie� warto�ci. je�li w wyniku zapytania nie b�dzie
-- zwr�cona �adna warto�� zmienna zachowa dotychczasow� warto��
set @imie='Teofil'
set @nazwisko='Szczerbaty'
select @imie=FirstName, @nazwisko=LastName from SalesLT.Customer where CustomerID=20
print @imie+' '+@nazwisko

-- analizujemy poni�sze dwa przyk�ady
select @nazwisko=LastName from SalesLT.Customer
print @nazwisko
select @nazwisko=(select MIN(LastName) from SalesLT.Customer)
print @nazwisko
GO