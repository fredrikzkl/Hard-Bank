--HARDBANK PROJECT--

Ny medlem

Vi lagde en egen view hvor du kan lage en ny bruker direkte fra siden. Her f�r vi ogs� vist
at vi mestrer Regular Expressions

Konto

F�r � gj�re det enklere � debugge, blir en konto autmatisk opprettet ved 
opprettelse av nytt medlem. Kontoene vil bli vist frem p� "MinSide". Dette
blir hentet ved hjelp av AJAX.    

BankId

Vi bestemte oss for � bare ha den tom, siden det ikke skulle p�virke innlogging.
Den er i "formen", men trenger ikke � bli fyllt inn, ettersom JS scriptet til 
den viewn fyller den ut automatisk. 

Session

Headern til siden vil endre seg dersom en kunde er innlogget. Input boksen og "logg inn" knappen
vil bytte seg til navnet til kunden som er innlogget og en "logg ut knapp". "Bli medlem" linken
vil bli byttet ut til "MinSide".

MinSide

Alle funksjoner tilgjenglig for kunden skjer p� samme viewet, og ved hjelp av modaler kan kunden
endre og slette betalinger uten � bevege seg vekk fra "MinSide". For � redusere scrolling s�
la vi de to funksjonee p� to forskjellige "tabber". 

Om oss

Et imformasjons view hvor vi viser hvem som har v�rt med p� � utvilke denne nettbanken. 

-Side Note-

Alle henting og innleggelse i databasen ble skrevet f�r vi l�rte oss ajax, derfor skrev vi om
henting av kontoer slik at vi viser at vi mestrer denne metoden.