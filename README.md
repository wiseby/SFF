Uppdraget
===
I detta första uppdrag så ska ni jobba för Sveriges Förenade Filmstudios (SFF) och utveckla ett API som
filmstudion kan anropa för att beställa film.
SFF fungerar på så sätt att lokala filmintresserade bildar föreningar som ingår i SFF som är förbundet för hela
Sverige. SFF har rätt från filmbolagen att låna ut ett visst antal exemplar av olika filmer till dom lokala
föreningar som sedan visar dem på exempelvis kulturbiograferna i sina städer. Förut skedde detta via blanketter
och dyr transport av fysiska filmrullar - men idag sker detta såklart digitalt.
De filmer som inte hunnit digitaliseras ännu är dock reglerade för hur många filmer som får lånas ut samtidigt,
så SFF önskar nu att du tar fram ett API för att hålla koll på vilka filmer som finns tillgängliga för föreningarna
att låna digitalt!

----

API och gränssnitt
---
API:et och klientgränssnittet ska bara användas av administratörer som jobbar på SFFs
huvudkontor i Stockholm. De har kontakt med olika filmstudios genom många olika
kanaler och använder klientgränssnittet för att uppdatera den nuvarande statusen.

----

Din API-lösning ska vara byggt i ASP.NET Core 3.0 eller 3.1.
Alla endpoints ska returnera JSON-data

I API:et ska resursen filmer finnas:

+ Det ska gå att lägga till en ny film

+ Det ska gå att ändra hur många studios som kan låna filmen samtidigt

+ Det ska gå att markera att en film är utlånad till en filmstudio (man får 
inte låna ut den mer än filmen finns tillgänglig (max-antal samtidiga utlåningar)

+ Det ska gå att ändra så att filmen inte längre är utlånad till en viss filmstudio

En annan resurs som ska finnas är filmstudios:

+ Det ska gå att registrera en ny filmstudio
+ Det ska gå att ta bort en filmstudio
+ Det ska gå att byta namn, och ort på en filmstudio
+ Via API:et ska man kunna få fram vilka filmer som en viss studio har lånat
När filmstudiorna har visat filmerna rapporterar de in ett betyg och ibland även en triva på film
+ Det ska gå att skapa ett nytt trivia objekt som håller koll på en liten anekdot för en viss film (Kan
vara en string , kolla på IMDB för exempel)
+ Det ska gå att ta bort inskriven trivia

+ Det ska också gå att rapportera in ett betyg mellan 1 och 5, det är viktigt att komma ihåg vilken
studio som gav betyget för vilken film.
Tips
Notera att det behöver inte gå att ta bort filmer,

Tips
=

+ Notera att det behöver inte gå att ta bort filmer, eller ändra deras detaljer.

+ Det är ok att ni skapar extra resurser och klasser än de som finns här, men detta är nuvarande minimumkrav från SFF i detta projekt.

+ Innan allt är klart och specificerat är det smidigt att använda en
InMemory-databas.

+ Det finns inga krav på autentisering

+ Tänk på att kunden är en ovan beställare av datasystem. Kraven kan komma att
ändras.

----

Klientgränsnitt
---
SFF har ännu inte tagit beslut om hur ett eventuellt klientgränssnitt skall se ut, men
ber dig att göra klart API:et under tiden de tar beslut.
Detta betyder att du får sätta upp en testmiljö i Postman att använda under tiden.
Tips: Det går att automatisera API-anrop och köra flera anrop i rad i Postman.

---
Rapport
---
Du ska lämna in en sedvanlig teknisk rapport över din lösning. Huvudfokus är att
reflektera och motivera dina designval. Inlämning: Någon gång mellan 20-22 April.

Krav på innehåll:

+ En länk till gitrepot med implementationen av REST APIet.

+ En kort dokumentation över åtkomstpunkterna i API:et och vad dom returnerar för information.
+ En kort reflektion över utformningen av API:et för att uppfylla kraven
+ Ge exempel på hur du använt dig av LINQ för att accessa eller modifiera data i ditt projekt.
+ Identifierade du några alternativa möjliga lösningar när du skapade APIet?
+ Beskriv för och nackdelar med de alternativa lösningarna
+ Vad var motivet bakom de lösningar du valde?
+ Svara förslagsvis på om åtkomstpunkterna var väl valda för att lösa uppgiften. Tänk på att motivera dina
ställningstaganden.