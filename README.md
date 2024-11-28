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
4. Dostosowanie DefaultConnection do Swojego Komputera:
• W projekcie MyBookLife otwórz plik appsettings.json znajdujący się w projekcie 
MyBookLife.Web.
• Znajdź sekcję dotyczącą połączenia do bazy danych (DefaultConnection).
• Dostosuj ustawienia połączenia: "DefaultConnection": 
"Server=SERVER_NAME(tutaj_zmien);Database=BookLifeDb;Trusted_Connection=Tru
e;"
• Upewnij się, że baza danych o nazwie podanej w konfiguracji istnieje na Twoim 
serwerze bazy danych.
5. Uruchamianie Projektu:
• Wybierz projekt MyBookLife.Web jako główny projekt w Visual Studio.
• Naciśnij przycisk "Start" lub skorzystaj z klawisza F5, aby uruchomić aplikację.
• Otwórz przeglądarkę internetową i przejdź do adresu https://localhost:PORT, gdzie 
PORT to numer portu, na którym została uruchomiona aplikacja

Projekt został wykonany przez: Michał Michalski (130615), Bartosz Sikorski (131593), Marek Marcinkowski (130604)
