# LABB 2 APIer

    I denna uppgift skall vi implementera databashantering och REST API för vår Westcoast Education-applikation.

## Steg 3

Kunden är väldigt nöjd med vad vi så här långt har byggt åt dem.

De har nu ett nytt krav. Det vill att vi utvecklar ett REST Api och de vill att vi gör det med Microsoft .NET 6.0 teknologier.

Tanken med det nya kravet är att de vill kunna återanvända api:et till flera applikationer som kommer att utvecklas framöver.

De har följande krav på lösningen:

## Grundläggande krav
* Det skall gå att skapa nya kurser som lagras i en databas(SQL-Server eller MongoDB)
* Det skall gå att ändra kurser i databasen
* Det skall gå att markera en kurs som pensionerad
* Det skall gå att hämta alla kurser
* Det skall gå att söka efter en kurs på kursens kursnummer
* Deltagare skall kunna registrera sig och uppgifterna skall lagras i databasen.
* Deltagare skall kunna uppdatera sina uppgifter
* Det skall gå att lista alla deltagare
* Det skall gå söka efter deltagare på e-post adress
* När en deltagare anmäler sig/köper en kurs måste vi kunna spåra vilken/vilka kurser som deltagaren har anmält sig till eller köpt
## Detaljkrav
### För en kurs skall följande uppgifter lagras i databasen

* Kursnummer
* Kurstitel
* Kursbeskrivning
* Kurslängd
* Nivå på kursen(nybörjare, medel, avancerad)
* Status(aktiv, pensionerad)

### För en deltagare skall följande information lagras

* Förnamn
* Efternamn
* E-post
* Mobilnummer
* Adressuppgifter
## Designkrav
REST Api-lösningen skall utvecklas enligt objektorienterade principer och använda följa Single Responsibility Principle.

## Användargränssnitt
Här lämnas det fritt, antingen kan vi använda JavaScript, React, Vue.js, Blazor eller ASP.NET MVC för att implementera en applikation för att kommunicera med REST Api-lösningen. Klient applikationen skall kunna presentera och hantera kurser, deltagare enligt kraven ovan.

## Bedömning
### Godkänt(G)
För att få godkänt skall alla delar för kurshanteringen vara implementerat. Kravet på att följa Single Responsibility Principle skall vara implementerat.

En klientapplikation skall vara kopplad till REST Api:et och uppfylla design kraven

### Väl godkänt(VG)
För väl godkänt skall alla krav på G nivån vara uppfyllt dessutom skall hantering av deltagare enligt kraven ovan vara uppfyllda. Förutom detta skall REST Api:et även implementera Unit of Work mönstret.

Klientapplikationen skall dessutom kunna hantera deltagare och presentation av vilka kurser som deltagaren har valt att anmäla sig till eller köpt.