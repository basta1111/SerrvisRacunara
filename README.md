# ServisRacunara

Seminarski rad iz predmeta Arhitektura informacionih sistema.

## Opis projekta

Aplikacija za upravljanje servisom računara razvijena korišćenjem ASP.NET Core MVC i n-tier arhitekture.

Sistem omogućava:

* Evidenciju klijenata
* Evidenciju uređaja
* Evidenciju servisera
* Evidenciju servisnih naloga
* Dodavanje, izmenu i brisanje podataka
* Pregled statistike na početnoj stranici

## Tehnologije

* ASP.NET Core MVC (.NET 9)
* Entity Framework Core
* SQL Server
* Bootstrap

## Arhitektura

Projekt je organizovan kroz tri sloja:

### DAL (Data Access Layer)

Sadrži:

* Entitete
* DbContext
* Migracije

### BLL (Business Logic Layer)

Sadrži:

* Poslovnu logiku
* Validacije podataka

### Web (Presentation Layer)

Sadrži:

* MVC kontrolere
* View modele
* Razor View stranice

## Autor

Sebastijan Miloš
