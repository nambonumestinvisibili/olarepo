//po parsowaniu: mamy gotową drzewiastą strukturę
//Interpreter - Litlle Language

//Przy dodawaniu nowych funkcjonalności,
// /jestesmy bardzo narazani na zmiany w 
// kodzie
//dodaj pretty print do iterpretera
//dodaj inna funkcjonalnosc
//kazda z nich trzeba
//zaimpl nizej
//doszczegóławiać to w kolejnych typach
//wyrażeń

//szukamy
//uogólniony sposob opisu
//operacji
// ktorej szczegoly tyej operacji 
// mogly by byc na zewnatrz,
//w jakiejs strukturze reprezentujacej tę operację

//kod kliencki: nie wnikaj w to co ta operacja
//robi, szczególy są gdzieś indziej

//VISITOR

//zlozony: mamy strukture kompozytowa
//Element + Conrete
//Accept/=== Execute
//Element abstrahuje od szczegolow tej
//implementacji

//Visitor: tam trzymamy szczegoły
//mamy informacje: odwiedz element typu a
//odwiedz element typu c
//itd
//w zaleznosci od ilosci typow wezlow (czesto duzo)
//

//jeden wizytor: interpetuje

//inny wizytor: pretty print, inny: wizyta w bazach danych
//nie musimy rozszerzac klas kompozytowtcgh
//wystarczy dopisac visitora


//Accept w wezle: deleguje operacje do wizitora

























