# Project C# Mobile 2023-2024
Naam en email: **Ferah Talha + Talha.ferah@student.pxl.be**

Titel applicatie: **My Bmw App**

*Deze C# Mobile-applicatie voor autohandel biedt een gebruiksvriendelijk platform waar gebruikers moeiteloos auto's kunnen kopen, verkopen en favorieten kunnen markeren. De app heeft een uitgebreide database met gedetailleerde specificaties en prijsinformatie van verschillende voertuigen. Gebruikers kunnen hun auto's gedetailleerd presenteren met nauwkeurige informatie, waardoor potentiële kopers weloverwogen beslissingen kunnen nemen. Het platform ondersteunt soepele interacties tussen kopers en verkopers, en biedt een intuïtieve gebruikerservaring om gemakkelijk door beschikbare aanbiedingen te bladeren en transacties uit te voeren.*

Opsomming belangrijkste kenmerken en onderdelen/features van de applicatie: 
* Auto Kopen en Verkopen: Gebruikers kunnen moeiteloos auto's zowel kopen als verkopen via het platform.
* Filteropties: Het platform biedt diverse filters op basis van prijsklasse & bouwjaar waardoor gebruikers gericht kunnen zoeken naar auto's die aan hun voorkeuren voldoen.
* Favorietenlijst: Gebruikers kunnen favoriete auto's toevoegen aan een persoonlijke lijst voor gemakkelijke toegang en vergelijking van hun favoriete voertuigen.
* Gedetailleerde Voertuiginformatie: De app toont uitgebreide informatie over auto's, inclusief specificaties zoals merk, model, bouwjaar, kilometerstand en prijs.

# Logboek

Eerste zit
* *06/12/2023: Ontwerp voor inloggen, aanmelden en de homepagina is gemaakt*
* *07/12/2023: Gestart met het coderen van inlog logica*
* *09/12/2023: Inlog en registreren logica's zijn af*
* *14/12/2023: Gestart met het aanmaken van de sql database voor auto informatie en de logica voor homecontroller*
* *16/12/2023: HomeController is afgemaakt de auto gegevens komen tevoorschijn in de home pagina*
* *20/12/2023: Verkoop pagina is gemaakt*
* *21/12/2023: gebruikers kunnnen foto uploaden om een auto te verkopen*
* *22/12/2023: Picker toegevoegd, gebruikers kunnen nu de autos filteren*
* *25/12/2023: Add car controller is af gebruikers kunnen nu hun autos verkopen*
* *29/12/2023: Design aanpassingen gedaan op de verschillende paginas en een custom splash screen toegevoegd*
* *04/01/2023: DeleteCar methode toegevoegd nu worden de verkochte auto's verwijderd uit da database*
* *07/01/2023: De functies voor het toevoegen van een auto naar de favorieten pagina zijn af*
* *09/01/2023: *Design aanpassingen op de details en favorieten pagina's*
* *11/01/2023: *Laatste Design aanpassingen overal*

Tweedezit uitwerking
* **22/07/2024:** Creëren en configureren van een Azure Storage Account.
* **23/07/2024:** Methodes om door gebruikers geüploade foto's op te slaan in de Azure Cloud.
* **24/07/2024:** Methode in VerkoopPage.xaml voor het ophalen van door de gebruiker geüploade foto’s uit de cloud en het opslaan van deze foto’s in mijn database
* **25/07/2024:** Wijzigingen in SSMS Tabellen en Toevoeging van Nieuwe UserFavorites Tabel.
* **26/07/2024:** Wijzigingen aan het FavorietenViewModel voor Opslag van Favoriete Auto's in de Database.
* **27/07/2024:** EmailValidationBehavior toegevoegd.
* **04/08/2024:** Interface en repository toegevoegd.
* **05/08/2024:** Veranderingen in de favorietenviewmodel en de favoriet pagina.
* **10/08/2024:** RegisterViewModel en LoginViewModel Toegevoegd.
* **14/08/2024:** api/SettingsController en settingspagina is toegevoegd.






  

# Optioneel: Screenshots
Splashscreen
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 152400.png" width="300"></p>

Aanmelden pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 152454.png" width="300"></p>

Registratie pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230706.png" width="300"></p>

Registratie pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230746.png" width="300"></p>

Home Pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230822.png" width="300"></p>

Filters
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230838.png" width="300"></p>

Auto Details Pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230857.png" width="300"></p>

Navigation
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230915.png" width="300"></p>

Verkoop pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230932.png" width="300"></p>

Favorieten Auto's Pagina
<p align="center"><img src="Screenshots/Schermafbeelding 2024-08-17 230953.png" width="300"></p>

Settings Pagina
<p align="center"><img src="Screenshots/Untitled design (13).png" width="300"></p>



# Videolink
https://www.youtube.com/watch?v=RJm0XDQth7A&ab_channel=T

# Bronnen

*Voor het aanmaken van een custom splash screen:*
* *https://learn.microsoft.com/en-us/dotnet/maui/user-interface/images/splashscreen?view=net-maui-8.0&tabs=android*

*Gebruik van File Picker om foto's toe te voegen*
* *https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker?view=net-maui-8.0&tabs=android*

*Gebruik van Azure functies en blob opslag*
* *https://learn.microsoft.com/en-us/azure/storage/blobs/blob-upload-function-trigger?tabs=azure-portal*

*Gebruik van Picker om filter waardes weer te geven*
* *https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0*

*Het maken van een connectie tussen android emulator en local web Api*
* *https://www.youtube.com/watch?v=kvNhLKuAySA&ab_channel=AbhayPrince*

*Voor het aanmaken van een converter*
* *https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/converters?view=net-maui-8.0*

*Gebruik van behavoir<entry>*
*  *https://learn.microsoft.com/en-us/previous-versions/xamarin/xamarin-forms/app-fundamentals/behaviors/creating*

*Viewmodel architectuur in mauiapp*
*  *https://blackboard.pxl.be/ultra/courses/_49036_1/outline/file/_1705232_1*

*Singleton design pattern voor de viewmodel*
*  *https://www.tutorialsteacher.com/csharp/singleton*

  

# Future work
* Als er meer tijd beschikbaar was, zou ik de mogelijkheid om meerdere afbeeldingen toe te voegen aan autoaanbiedingen verbeteren. Dit zou ik aanpakken door de gegevensstructuur aan te passen om meerdere afbeeldingen per auto toe te staan, de gebruikersinterface bij te werken voor het uploaden en bekijken van meerdere afbeeldingen, en de opslag en laadtijd van deze afbeeldingen te optimaliseren binnen de app. Dit zou de gebruikerservaring verbeteren door potentiële kopers een uitgebreider beeld van het voertuig te geven.

* Als er extra tijd was, zou ik avatar- en profielinstellingen toevoegen aan de app. Dit zou ik aanpakken door een sectie te creëren waar gebruikers hun profiel kunnen aanpassen, inclusief het uploaden van een profielfoto (avatar), het wijzigen van gebruikersgegevens en het instellen van voorkeuren. Ook zou ik de backend updaten om profielinformatie en avatars op te slaan en de gebruikersinterface bijwerken zodat gebruikers gemakkelijk hun profielinformatie kunnen bewerken en hun avatar kunnen tonen.

* Als ik de mogelijkheid had om meer tijd te besteden aan de app, zou ik een uitgebreidere backend-implementatie toevoegen voor permanente gegevensopslag. Dit zou inhouden dat alle gebruikersgegevens, inclusief profielinstellingen, favoriete auto's en aanbiedingen, continu worden opgeslagen in de backend, zelfs wanneer de gebruiker de applicatie afsluit of de sessie beëindigt. Hierdoor zou de app een meer consistente en persistente gebruikerservaring bieden, waarbij gebruikers hun voorkeuren en gegevens behouden, ongeacht wanneer ze de app openen of sluiten. 
