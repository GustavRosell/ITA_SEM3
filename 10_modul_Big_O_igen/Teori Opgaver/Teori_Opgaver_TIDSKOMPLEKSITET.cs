/*

TAGS: big_o, tidskompleksitet, opgaver, teori, øvelser, tid, kompleksitet, BIG O

Teori opgaver
Opgaver - Modul 10 - Teoriopgaver

Opgave 1
Brug store O-notationen til at beskrive udførselstiden for følgende handlinger med udgangspunkt i worst case:

1. Du ankommer til undervisningen og vælger at give hånd til alle de andre fremmødte. Der er n fremmødte.
- O(n)
2. Alle fremmødte beslutter sig for at give hånd til hinanden.
- O(n²)
3. Du går ned af alle trapperne til kantinen for at købe kaffe. Der er n trin.
- O(n)
4. Du går ind i en elevator, trykker på en knap, for at køre op fra kantinen igen.
- O(1)
5. Du læser en spændende programmeringsbog to gange. Bogen indeholder n sider.
- O(n)

Opgave 2
Opfind en fjollet algoritme for at gå op af alle trappetrinene fra kantinen og op til dit lokale, som kører med en worst case udførselstid udtrykt ved O(n²).
- Ved hvert trin, skal du gå hele vejen op af trappen og tage elevatoren ned igen

Opgave 3
Herunder er en operation i form af en JavaScript-funktion. Hvad er dens udførseltid udtryk ved “store O”?

function IsTextHello(s) {
  if (s === "Hello") return true;
  return false;
}

- O(1)
- Fordi, at udførselstiden er konstant, uanset længden af inputtet

Opgave 4
Herunder er en operation i form af en JavaScript-funktion. Hvad er dens udførseltid udtryk ved “store O”?

function checkText(text, c) {
  for (let i = 0; i < text.length; i++) {
    if (text.charAt(i) == c) {
      return true;
    }
  }
  return false;
}

- O(n)

Opgave 5
Herunder er en algoritme som er kodet i JavaScript. Noget af koden er udeladt. 
Du skal kun forholde dig til den del du kan se. 
Hvad er dens udførseltid udtrykt ved “store O”?

for (let pass = 1; pass <= n; pass++) {
  for (let index = 0; index <= n; index++) {
    for (let count = 1; count < 10; count++) {
      . . .
    } 
  } 
}

- O(n²)

Opgave 6
Kig på opgave 5 igen, men erstat count < 10 med count < n. Hvad er udførselstiden nu?

- O(n³)

Opgave 7
Du har fire programmer, der hedder A, B, C og D, som alle har følgende udførselstider:

A: O(log n)
B: O(n) 
C: O(n²)
D: O(2ⁿ)
Hvert program er 10 sekunder om at køre færdigt når input har størrelse 1000. Hvor lang tid tager hvert program når input har størrelse 2000?

A: O(log n) = 10 sekunder
- Fordi log₂(2000) ≈ 11
B: O(n) = 40 sekunder
- Fordi 2000 / 1000 = 2
C: O(n²) = 160 sekunder
- Fordi 2000 / 1000 = 2² = 4
D: O(2ⁿ) = 10240 sekunder
- Fordi 2^2000 / 2^1000 = 2^1000 = 1024

Opgave 8
Hvad er størrelsesordenen af udførselstiden for funktionen F1 udtrykt ved store O?

function F1(array, int n) {
  for (let index = 0; index < n - 1; index++) {
    let mark = F1_helper(array, index, n - 1);
    let temp = array[index];
    array[index] = array[mark];
    array[mark] = temp;
  }
}

function F1_helper(array, first, last) {
  let min = array[first];
  let indexOfMin = first;
  
  for (let index = first + 1; index <= last; index++) {
    if (array[index] < min) {
      min = array[index];
      indexOfMin = index;
    }
  }

  return indexOfMin;
}

- O(n²)
- Fordi der er to for-løkker, hvor den ene er indlejret i den anden

*/