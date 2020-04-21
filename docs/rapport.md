# Rapport SFF

*Av: Lucas Wiseby*


Jag tycker att projektet gick riktigt bra trots at slutprodukten inte blev riktigt som jag hade tänkt mig. Den blev heller inte riktigt vad uppgiften beskrev, men jag gjorde vad jag kunde med tiden jag fick. 

En väldigt lärorik uppgift där dom flesta pusselbitarna användes. 
Jag lade stor del i hur koden var strukturerad och ville ha så låg koppling som möjligt. Detta fick jag sätta lite åt sidan då min tid började sina. Det var viktigt att jag fick något som fungerade i slutändan.

Jag använde mig utav postman för att testa och har inkluderat en collection man kan importera föra att beskriva lite hur mina endpoints fungerar. Denna ligger i docs/postman. Finns även en del dokumenterat i docs mappen i form av .md dokument om du är intresserad med lite tankar och funderingar under projektets gång.

Mina största fallgropar var EF då mina migrationer inte blev alltid som jag velat. Är mer den som gärna gör min databas innan applikationskoden. På det sättet kan man planera mer i detalj i ett tidigt stadie. Tanken med detta tillvägagångssätt var väl ända att komma igång med koden fort?! Jag hade svårt att få ihop hur EF skulle sätta ihop tabelerna utifrån mina domän modeller. Desse ändrades mycket för att få dom att fungera. Dom såg helt annorlunda ut nu mot slutet vilket gjorde mig lite besviken då jag tyckte att jag hade jätte fin grund från början. Gjorde väl misstaget att köra utan en InMemory databas i utvecklingsfasen. Hade jag bara lagt ner lite tid på att få ihop lite data seed funktioner som skullle kunna ha initierat databasen ifrån början hade man haft mer data att jobba med och sluppit göra så många misslyckade migrationer och liknande. Här fick jag också problem då jag plockade bort referenserna av produkter, ordrar för studios då jag trodde att man bara behövde id för att koppla ihop dessa. Blev riktigt illa då du skulle ha fram en order som inte höll en enda referens av produkter och studio och skulle plocka ihop en etikett (där av den lustiga xml etiketten ;) ). Lesson Learned! Jag vet vad jag gjorde fel!

Även attributerna som styr hur man användes sig utav querystrings och annat för att leda clienten in på rätt del av API:et var mycket dåligt dokumenterat på nätet. Får återkomma till detta så att man får reda på dom bästa sätten att få med parametrar och liknande till sin API.
Min applikation är rätt buggig och saknar korrekt felhantering. Tex detta med att returnera annat än Ok status. Detta hade man kunnat slipa mer på. Tror dock att jag fått kläm på async tänket och att hantera tasks.  

Detta projekt ledde också till en hel del linq och övning på att söka innehålll från databasen. Mycket kul. Inte säkert att jag har testat det helt så att man hittar rätt. Kan bli lite snurrit när man ska ha ihop flera tabeller.