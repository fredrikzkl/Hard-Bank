--HARDBANK PROJECT--

Ny medlem

Vi lagde en egen view hvor du kan lage en ny bruker direkte fra siden. Her får vi også vist
at vi mestrer Regular Expressions

Konto

Får å gjøre det enklere å debugge, blir en konto autmatisk opprettet ved 
opprettelse av nytt medlem. Kontoene vil bli vist frem på "MinSide". Dette
blir hentet ved hjelp av AJAX.    

BankId

Vi bestemte oss for å bare ha den tom, siden det ikke skulle påvirke innlogging.
Den er i "formen", men trenger ikke å bli fyllt inn, ettersom JS scriptet til 
den viewn fyller den ut automatisk. 

Session

Headern til siden vil endre seg dersom en kunde er innlogget. Input boksen og "logg inn" knappen
vil bytte seg til navnet til kunden som er innlogget og en "logg ut knapp". "Bli medlem" linken
vil bli byttet ut til "MinSide".

MinSide

Alle funksjoner tilgjenglig for kunden skjer på samme viewet, og ved hjelp av modaler kan kunden
endre og slette betalinger uten å bevege seg vekk fra "MinSide". For å redusere scrolling så
la vi de to funksjonee på to forskjellige "tabber". 

Om oss

Et imformasjons view hvor vi viser hvem som har vært med på å utvilke denne nettbanken. 

-Side Note-

Alle henting og innleggelse i databasen ble skrevet før vi lærte oss ajax, derfor skrev vi om
henting av kontoer slik at vi viser at vi mestrer denne metoden.