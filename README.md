# MyBookLife
Instrukcja do uruchomienia projektu
1. Pobieranie Projektu z GitHuba:
• Otwórz przeglądarkę internetową i przejdź do strony projektu na GitHubie: 
MyBookLife GitHub Repository.
• Skorzystaj z przycisku "Code" i wybierz opcję "Download ZIP" lub skopiuj link do 
repozytorium i użyj go w terminalu/git bash do sklonowania repozytorium na swoim 
komputerze.
2. Pobieranie ASP.NET w wersji 6.0:
• Przejdź na oficjalną stronę ASP.NET: ASP.NET.
• Znajdź i pobierz najnowszą wersję ASP.NET 6.0, zgodną z systemem operacyjnym 
Twojego komputera.
• Postępuj zgodnie z instrukcjami instalacyjnymi dostępnymi na stronie, aby 
zainstalować ASP.NET w wersji 6.0.
3. Włączanie Projektu za pomocą Visual Studio 2022:
• Otwórz Visual Studio 2022 na swoim komputerze.
• Wybierz opcję "Open a project or solution" z ekranu startowego Visual Studio.
• Przejdź do katalogu, w którym został pobrany projekt z GitHuba, i otwórz plik 
projektu .sln.
4. Dostosowanie połączenia z bazą danych do Swojego Komputera:
• Zainstaluj aplikację SqlSerwer ze strony https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads
• Zainstaluj aplikację SQL Server Management Studio ze strony https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
• Utwórz baze danych pod nazwą "BookLifeDb"
• W projekcie MyBookLife otwórz plik appsettings.json znajdujący się w projekcie 
MyBookLife.Web.
• Znajdź sekcję dotyczącą połączenia do bazy danych (DefaultConnection).
• Dostosuj ustawienia połączenia: "DefaultConnection": 
"Server=SERVER_NAME(tutaj_zmien);Database=BookLifeDb;Trusted_Connection=True;"
• Upewnij się, że baza danych o nazwie podanej w konfiguracji istnieje na Twoim 
serwerze bazy danych.
• Wykonaj migrację danych
6. Logowanie przez Google:
• Wejdź na stronę https://console.cloud.google.com/projectcreate i utwórz nowy projekt o dowolnej nazwie
• Po utworzeniu wejdź w zakładkę "Ekran zgody OAuth"
• Wybierz "Z zewnątrz" i naciśnij przycisk utwórz
• Wypełnij formularz podając najlepiej nazwę aplikacji "MyBookLife", podając swój adres email w sekcji: "Informacje o aplikacji" oraz "Dane kontaktowe dewelopera". Następnie naciśnij "Zapisz i Kontynuuj"
• W zakładce "Zakresy" nic nie zmienaj, naciśnij "Zapisz i Kontynuuj"
• W zakładce "Użytkownicy testowi" nic nie zmienaj, naciśnij "Zapisz i Kontynuuj"
• W sekcji "Podsumowanie" sprawdź dane i przejdź do panelu wybierając przycisk "Powrót do panelu"
• W bocznym menu wybierz "Dane logowania", następnie utwórz dane logowania za pomocą przycisku "Utwórz dane logowania"->"Identyflkator klienta OAuth"
• Wybierz typ aplikacji: "Aplikacja inetrnetowa", podaj dowolną nazwę i naciśnij przycisk "Utwórz"
• W Visual Studio włącz aplikację i skopiuj adres strony
• Do pola "Autoryzowane identyfikatory URI przekierowania"->"Dodaj URI" wklej adres strony + "/signin-google" (Na przykład będzie to "https://localhost:7101/signin-google")
• Naciśnij przycisk "Utwórz"
• Skopiuj "Identyfikator klienta"
• W Visual Studio otówrz terminal, przejdź do folderu "MyBookLife.Web" i wpisz "dotnet user-secrets set "Authentication:Google:ClientId" "_twój skopiowany klucz_", naciśnij enter
• z przeglądarki skopiuj "Tajny klucz klienta"
• W Visual Studio otówrz terminal, przejdź do folderu "MyBookLife.Web" i wpisz "dotnet user-secrets set "Authentication:Google:ClientSecret" "_twój skopiowany tajny klucz_", naciśnij enter
• Odkomentuj poniższy fragment kodu z pliku "Program.cs": 
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
//});
7. Uruchamianie Projektu:
• Wybierz projekt MyBookLife.Web jako główny projekt w Visual Studio.
• Naciśnij przycisk "Start" lub skorzystaj z klawisza F5, aby uruchomić aplikację.
• Otwórz przeglądarkę internetową i przejdź do adresu https://localhost:PORT, gdzie 
PORT to numer portu, na którym została uruchomiona aplikacja

Projekt został wykonany przez: Michał Michalski (130615), Bartosz Sikorski (131593), Marek Marcinkowski (130604)
