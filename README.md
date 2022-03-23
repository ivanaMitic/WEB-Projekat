"# WEB-Projekat" 
PLesni Klubovi

	Kreirana web aplikacija namenjana je instruktorima plesa različitih plesnih klubova i omogućava im:
 	-upis novih članova kluba,
 	-ispis članova kluba,
 	-promenu kategorije člana kluba,
 	-unos podataka o plaćanju članarine,
 	-pregled plaćenih članarina za jednu godinu,
 	-pregled svih članarina koje je jedan član kluba platio.
  
Početni ekran

	Na početnom ekranu dostupna je opadajuća lista koja sadrži listu plesnih klubova kao i linija za unos jedinstvene lozinke kluba koja bi bila dostupna samo instruktorima kluba.
	Ukoliko nije uneta ispravna lozinka ili lozinka uopšte, javlja se obaveštenje sa porukom. Isto tako se prikazuje obaveštenje o uspešnom logovanju sa unetu ispravnu lozinku kluba.
 
 
Glavni ekran

	Glavna forma aplikacije podeljena je na dva dela – prvi koji je namenjen upisu, ispisu članova kluba i promeni informacija o kategoriji članova kao i prikazu informacija o članovima koji su upisani ili su njihove informacije izmenjene, i drugi deo koji služi za upis novih plaćanja i prikaz informacija o prethodno plaćenim članarinama.

 
Član kluba

	U delu “Član Kluba”, kao što je navedeno, dostupne su funkcije za manipulaciju informacijama o članovima kluba. Ukoliko prilokom unosa informacija dođe do unosa nevalidnih podataka, javljaju se odgovarajuća obaveštenja o problemu koji je nastao prilikom unosa.
	Nakon ispravnog unosa informacija javlja se i obaveštenje o uspešnom upisu dok se na formi ispisuju podaci o članu kome je dodeljen jedinsteveni broj (JB), na osnovu koga se dalje pristupa njegovim informacijama u bazi.

	Što se tiče izmene kategorije člana kluba, potrebno je uneti JB koji postoji u bazi i izabrati novu kategoriju iz opadajuće liste. Ukoliko je izmena neuspešna zbog neispravnosti unetih podataka, javljaju se obaveštenja o neuspeloj izmeni. 

    Nasuprot tome, kada je promena izvršena uspešno – ispisuje se obaveštenje o uspešnoj promeni i tabela popunjena podacima o članu kome je kategorija promenjena.
 
	Kao i za izmenu kategorije, za ispis člana kluba potreban je samo njegov JB. Nakon istih validacija kao i u prethodnim slučajevima, izabrani član kluba će biti obrisan pri čemu se prethodni sadržaj tabele briše.

 
Članarina

	U delu “Članarina“, instruktori plesa imaju mogućnost da unose podatke o novim plaćanjima i mogućnost da pregledaju listu članarina koje je platio neki od članova kluba.
	Kako bi pristupio podacima o plaćenim članarinama, instruktor mora da popuni polje JB i godinu za koju želi da pregleda plaćene članarine. U zavisnosti od ispravnosti unetih podataka, javljaju se obaveštenja o neuspešnoj ili uspešnoj pretrazi.

    Za evidentiranje novog plaćanja članarine, potrebno je izabrati mesec ze koji je članarina plaćena, upisati godinu i JB člana koji je izvršio uplatu. Moguće je upisati članarinu za mesec i godinu koji se ne nalaze u bazi podataka što omogućava instruktorima da ažuriraju listu članarina. Ponovo, uneti podaci nisu u bazi, javi će se odgovarajuće obaveštenje. U suprotnom slučaju se dešava isto uz dodatak ispisivanja svih članarina koje je platio član za koga je evidentirana nova uplata.
