-- WAITFOR
DROP TABLE IF EXISTS Numbers;
CREATE TABLE Numbers(Number INT);
declare @x int
select @x=2
insert into Numbers values( @x );
print 'Wstawiono...'
waitfor delay '00:00:05'
insert into Numbers values( @x+2 );
print 'Wstawiono...'
GO

-- IF..ELSE
if EXISTS( select * from SalesLT.SalesOrderHeader) print('S� zam�wienia')
else print('Nie ma �adnych zam�wie�')
GO

-- WHILE
declare @y int
select @y=0
while ( @y<10 )
begin
  print @y
  if ( @y=5 ) break
  set @y=@y+1
end

-- CASE
select Tytul as Tytu�, Cena, [Cena jest]=CASE
	when Cena<40.00 then 'Niska'
	when Cena between 40.00 and 80.00 then 'Przyst�pna'
	when Cena>80 then 'Wysoka'
	else 'Nieznana'
	end
from Ksiazka

select p.Name, Kategoria=CASE c.Name
	when 'Bikes' then 'Rowery'
	when 'Brakes' then 'Hamulce'
	when 'Chains' then '�a�cuchy'
	when 'Gloves' then 'R�kawice'
	else 'Inne'
	end
FROM SalesLT.Product p JOIN SalesLT.ProductCategory c ON p.ProductCategoryID=c.ProductCategoryID
-- Jak powy�sze nale�y w�a�ciwie zrobi�?

-- NULLIF
-- przydatne, kiedy chcemy pomin�� jak�� warto�� w funkcjach agreguj�cych
select
avg( nullif( Weight, 0 ) ) as [�rednia waga],
min( nullif( Weight, 0 ) ) as [Minimalna waga]
from SalesLT.Product

-- ISNULL
-- pozwala na nadawanie warto�ci domy�lnych tam, gdzie jest NULL
SELECT Name, ISNULL(ThumbnailPhotoFileName, 'http://jakasdomyslnafocia.pl/') FROM SalesLT.Product
-- mo�na te� umieszcza� podzapytania, np.: isnull( price, ( select MIN(price) from ceny ) )
