/*
Herunder er tre offentlige API’er hvor I skal dykke ned i dokumentationen. Læs spørgsmålene, besvar dem sammen med din gruppe, og skriv svarene ned.

// Opgave 1.1: 

En ordbog
URI: https://dictionaryapi.dev/Links to an external site.

Spørgsmål:

1: Hvad kan man med denne API og hvad er det primære formål?
- API’en giver adgang til en ordbog
2: Kan API’en (mis)bruges til andre ting?
- Automatiseret indhentning af data til kommercielle formål uden tilladelse, hvilket kan krænke servicevilkårene.
- Overbelastning af servere med anmodninger, hvilket kan føre til denial-of-service (DoS) angreb, der forstyrrer tjenesten for andre brugere.
- Uautoriseret indlejring af API-data i egne produkter eller tjenester på en måde, der giver indtryk af, at indholdet er ens eget.
3: Hvor godt opfylder API’en følgende kriterier? Operational, expressive, simple og predictable.
- API’en er operational, expressive, simple og predictable, da den er let at bruge og forstå, og den er forudsigelig i sin adfærd.
4: Afprøv API’en hvis du ikke allerede har gjort det (browser, postman eller curl).
- Done

// Opgave 1.2: 

En filmdatabase
URI: https://ghibliapi.vercel.app/#Links to an external site.

Spørgsmål:

1: Hvad kan man med denne API og hvad er det primære formål?
- API’en giver adgang til en filmdatabase
2: Hvilke steps skal man udføre for at svare på følgende spørgsmål?
3: Hvilke film har “cat” som en “species” der indgår i filmen?
3.1: - brug endpoint for arter 'https://ghibliapi.vercel.app/species' - Dette vil give dig information om hver art, inklusive navnet og en URL til yderligere detaljer for hver art.
3.2: - Find 'cat' arten: Gennemgå listen over arter for at finde arten, der repræsenterer "cats". 
I detaljerne for hver art vil der være information om, hvilke film arten optræder i, oftest angivet som en liste af URLs, der peger på specifikke film.
3.3 - Hent film for 'cat' arten: Når du har identificeret URL'erne for de film, hvor 'cat' arten optræder, kan du bruge filmens endpoint (/films) med det specifikke ID for hver film for at hente detaljerne for de pågældende film.

4: Hvilke “species” findes der i filmen “Totoro”?
- Human, Cat, Totoro
5: Prøv dine steps af fra punkt 2.
6: Hvor godt opfylder API’en følgende kriterier? Operational, expressive, simple og predictable.
- API’en er operational, expressive, simple og predictable, da den er let at bruge og forstå, og den er forudsigelig i sin adfærd --> hvis man forstår API'ens struktur og endpoints.


// Opgave 1.3:

Reddit
URI: https://www.reddit.com/dev/api/Links to an external site.
Reddit API’en kræver en key, så den er ikke så nem at komme i gang med, som de andre. Men kig i dokumentationen for at svare på spørgsmålene.

Spørgsmål:

1: Hvordan sletter man et comment eller et link?'
- DELETE /api/comment
2: Hvordan henter man alle kommentarer fra en bestemt tråd?
- GET /r/{subreddit}/comments/{article}
3: Hvordan opdaterer man stylesheet på et subreddit?
- POST /api/subreddit_stylesheet
4: Hvordan ændrer man et “multi” subreddit’s markdown-beskrivelse?
- PUT /api/multi/{multipath}/r/{srname}/description
5: Hvor godt opfylder API’en følgende kriterier? Operational, expressive, simple og predictable.
- bro det koks 
*/