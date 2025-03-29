[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=16526064)
# Quizify

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Andrej Pavešić | apavesic22@student.foi.hr | 0016158653 | apavesic22
Karlo Mišić | kmisic22@student.foi.hr | 0016158466 | kmisic22
Patrik Klarić | pklaric22@student.foi.hr | 0016158515 | pklaric22

## Opis domene
Quizify je aplikacija za ljubitelje kvizova, osmišljena da korisnicima pruži zabavno i izazovno iskustvo kroz raznovrsne trivije i testove znanja. Platforma pokriva širok spektar tema uključujući geografiju, književnost, povijest, glazbu, kulturu, jezike, znanost i brojne druge te omogućava korisnicima da testiraju svoje znanje, natječu se s prijateljima ili s globalnom zajednicom, i otkrivaju nove zanimljivosti. Quizify se ističe po tome što igrač može birati kategorije (osim ako želi "izmiješana" pitanja)  na koje će odgovarati i podešavati težinu pitanja. Quizify prati napredak svakog igrača tako da igrač skuplja poene sa svojim točnim odgovorima koji se zapisuju u njegov osobni igrački profil. Osim što služi za zabavu Quizify pruža mogućnost stjecanja novih znanja i kvizaških iskustava, a može služiti i kao vrsta pripreme za puno ozbiljnije kvizove koji se odigravaju u stvarnom svijetu u obliku kvizaških liga i kupova. Također omogućava više načina igranja odnosno njegovi se igrači mogu natjecati u brzini davanja točnih odgovora u načinu igre koji je ograničen zadanim timerom ili se mogu natjecati u klasičnom načinu igre gdje se odgovara na zadani broj pitanja bez vremenskog ograničenja a uspješnost igrača ovisi o količini točnih odgovora. 

## Specifikacija projekta
Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija i prijava | Quizify će korisnicima omogućiti registraciju sa svojim korisničkim podacima ako im je to prvi put da koriste aplikaciju odnosno moći će se prijaviti ako su već ranije koristili aplikaciju. | Andrej Pavešić
F02 | Mogućnost ručnog unosa pitanja u bazu | Korisnik će imati mogućnost dodavanja pitanja po vlastitom izboru za željenu kategoriju. | Karlo Mišić
F03 | Kreiranje kviza | Quizify će imati mogućnost kreiranja kviza tako da ga kreira prema kategorijama pitanja, načinu igre i težini. Moći će kreirati kviz prema nasumično odabranim kategorijama ili kategorijama koje korisnik odabere prema svojim željama i isto tako će ih moći kreirati prema težini (lako, srednje, teško). | Patrik Klarić
F04 | Praćenje uspjeha igrača | Aplikacija će imati implementiran sistem iskustvenih bodova. Funkcionalnost će omogućiti pregled: Ukupnog poretka igrač u odnosu na ostale, Ukupan broj ostvarenih iskustvenih bodova, Povijest odigranih kvizova s prikazom točnih i netočnih odgovora, Grafikone bodovnog rasta tijekom vremena. | Andrej Pavešić
F05 | Prikaz tablice uspješnosti | Unutar aplikacije postojat će mogućnost prikaza tablice s poretkom igrača gdje su igrači poredani prema svojem bodovnom postignuću. Pritom će postojati jedna tablica gdje će biti poredani top 10 igrača s najvećim brojem bodova. | Andrej Pavešić
F06 | Prikaz uspjeha po kategoriji | Korisnik će unutar aplikacije imati prikaz svojeg uspjeha po svakoj kategoriji u aplikaciji. Uz dodatne informacije o pitanju koje je najčešće odgovarano, prikaz će biti u grafičkom obliku. | Karlo Mišić
F07 | Sudjelovanje u kvizu | Korisnici sudjeluju u kvizu tako što se prijave pa pokrenu novu igru i odaberu način, kategoriju i težinu pitanja. | Patrik Klarić 
F08 | Nagrade za postignuća | Aplikacija će imati sistem nagrada za postignuća kroz dodjelu iskustvenih bodova (experience points). Igrači će dobivati bodove za različita postignuća, poput točnih odgovora na pitanja, s naglaskom na teža pitanja koja donose više bodova. Pravila dodjele uključuju i gubitak bodova za netočne odgovore, čime će igrači moći pratiti svoj ukupni napredak kroz osvajanje ili gubitak iskustvenih bodova.| Patrik Klarić
F09 | Kreiranje baze pitanja | Quizify će svoju bazu pitanja povlačiti iz API-ja s linka https://opentdb.com/api.php?amount=10 te će ih koristiti u kreiranju kviza i pitanja za kviz. | Karlo Mišić


## Tehnologije i oprema
Ovaj projekt bit će izrađen u razvojnom okruženju Visual studio koristeći razvojni okvir .NET framework. Vrsta projekta će biti WPF budući da je on dio .NET razvojnog okvira, a imamo iskustva s tim frameworkom s prošlih kolegija te je ova aplikacija između ostalog desktop aplikacija rezervirana za Windows operacijski sustav. Za verzioniranje programskog koda bit će korišteni git i GitHub. GitHub Wiki će biti korišten za pisanje tehničke i projektne dokumentacije. Za projektne zadatke koji će biti praćeni i planirani poslužit ćemo se alatom GitHub projects. Što se tiče baze podataka bit će korištena ona koju su kreirali nastavnici za potrebe ovog kolegija.
