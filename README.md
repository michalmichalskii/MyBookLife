# MyBookLife
Instrukcja do uruchomienia projektu

Pobieranie Projektu z GitHuba:
1. Otwórz przeglądarkę internetową i przejdź do strony projektu na GitHubie: MyBookLife GitHub Repository.

2. Skorzystaj z przycisku "Code" i wybierz opcję "Download ZIP" lub skopiuj link do repozytorium i użyj go w terminalu/git bash do sklonowania repozytorium na swoim komputerze.

Pobieranie ASP.NET w wersji 6.0:
1. Przejdź na oficjalną stronę ASP.NET: ASP.NET.

2. Znajdź i pobierz najnowszą wersję ASP.NET 6.0, zgodną z systemem operacyjnym Twojego komputera.

3. Postępuj zgodnie z instrukcjami instalacyjnymi dostępnymi na stronie, aby zainstalować ASP.NET w wersji 6.0.

XAMPP:
1.	Pobierz aplikację XAMPP na swój komputer i włącz moduł Apache

Włączanie Projektu za pomocą Visual Studio 2022:
1. Otwórz Visual Studio 2022 na swoim komputerze.

2. Wybierz opcję "Open a project or solution" z ekranu startowego Visual Studio.

3. Przejdź do katalogu, w którym został pobrany projekt z GitHuba, i otwórz plik projektu .sln.

Dostosowanie połączenia z bazą danych do Swojego Komputera:
1. Zainstaluj aplikację SqlSerwer ze strony https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads

2. Zainstaluj aplikację SQL Server Management Studio ze strony https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

3. Utwórz baze danych pod nazwą "BookLifeDb"

4. W projekcie MyBookLife otwórz plik appsettings.json znajdujący się w projekcie MyBookLife.Web.

5. Znajdź sekcję dotyczącą połączenia do bazy danych (DefaultConnection).

6. Dostosuj ustawienia połączenia: "DefaultConnection": "Server=SERVER_NAME(tutaj_zmien);Database=BookLifeDb;Trusted_Connection=True;"

7. Upewnij się, że baza danych o nazwie podanej w konfiguracji istnieje na Twoim serwerze bazy danych.

8. Wykonaj migrację danych

Dostosowywanie triggera:
1. W bazie danych (SQL Server Managment Studio) utwórz tabelę za pomocą nowego query z kodem:
<pre><code>USE [BookLifeDb]
GO

/****** Object:  Table [dbo].[ReadingHistory]    Script Date: 19/12/2024 10:23:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReadingHistory](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [EntryId] [int] NOT NULL,
    [DiaryId] [int] NOT NULL,
    [BookId] [int] NOT NULL,
    [PagesRead] [int] NOT NULL,
    [CreateDateTime] [datetime2](7) NOT NULL,
    [Action] [varchar](10) NOT NULL,
    [UserId] [nvarchar](450) NULL,
PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
</code></pre>

2. W nowym query utwórz trigger za pomocą poniższego kodu:
<pre><code>USE [BookLifeDb]
GO

/****** Object:  Trigger [dbo].[UpdateReadingHistory]    Script Date: 19/12/2024 10:24:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[UpdateReadingHistory]
ON [dbo].[Entries]
AFTER INSERT, UPDATE
AS
BEGIN
	--wyłącza wysyłanie komunikatów o liczbie zmodyfikowanych wierszy
    SET NOCOUNT ON; 

    INSERT INTO ReadingHistory (EntryId, DiaryId, BookId, UserId, PagesRead, CreateDateTime, Action)
	--Te linie wybierają dane do wstawienia. i odnosi się do tabeli inserted, która zawiera nowe lub zaktualizowane wiersze.
    SELECT 
        i.Id,
        i.DiaryId,
        i.BookId,
        u.Id,
        i.PagesRead,
        i.CreateDateTime,
		--CASE określa, czy operacja to INSERT (gdy d.Id jest NULL) czy UPDATE.
        CASE
            WHEN d.Id IS NULL THEN 'INSERT'
            ELSE 'UPDATE'
        END
	--Te linie łączą tabelę inserted z tabelą deleted. Dla operacji INSERT, deleted będzie pusta.
    FROM 
        inserted i
    LEFT JOIN 
        deleted d ON i.Id = d.Id
	--To złączenie pobiera Id użytkownika z tabeli AspNetUsers, łącząc pole Owner z Entries z UserName z AspNetUsers.
    INNER JOIN
        [dbo].[AspNetUsers] u ON i.Owner = u.UserName;
END;
GO

ALTER TABLE [dbo].[Entries] ENABLE TRIGGER [UpdateReadingHistory]
GO


</code></pre>

Logowanie przez Google:
1. Wejdź na stronę https://console.cloud.google.com/projectcreate i utwórz nowy projekt o dowolnej nazwie

2. Po utworzeniu wejdź w zakładkę "Ekran zgody OAuth"

3. Wybierz "Z zewnątrz" i naciśnij przycisk utwórz

4. Wypełnij formularz podając najlepiej nazwę aplikacji "MyBookLife", podając swój adres email w sekcji: "Informacje o aplikacji" oraz "Dane kontaktowe dewelopera". Następnie naciśnij "Zapisz i Kontynuuj"

5. W zakładce "Zakresy" nic nie zmienaj, naciśnij "Zapisz i Kontynuuj"

6. W zakładce "Użytkownicy testowi" nic nie zmienaj, naciśnij "Zapisz i Kontynuuj"

7. W sekcji "Podsumowanie" sprawdź dane i przejdź do panelu wybierając przycisk "Powrót do panelu"

8. W bocznym menu wybierz "Dane logowania", następnie utwórz dane logowania za pomocą przycisku "Utwórz dane logowania"->"Identyflkator klienta OAuth"

9. Wybierz typ aplikacji: "Aplikacja inetrnetowa", podaj dowolną nazwę i naciśnij przycisk "Utwórz"

10. W Visual Studio włącz aplikację i skopiuj adres strony

11. Do pola "Autoryzowane identyfikatory URI przekierowania"->"Dodaj URI" wklej adres strony + "/signin-google" (Na przykład będzie to "https://localhost:7101/signin-google")

12. Naciśnij przycisk "Utwórz"

13. Skopiuj "Identyfikator klienta"

14. W Visual Studio otówrz terminal, przejdź do folderu "MyBookLife.Web" i wpisz "dotnet user-secrets set "Authentication:Google:ClientId" "twój skopiowany klucz"", naciśnij enter

15. z przeglądarki skopiuj "Tajny klucz klienta"

16. W Visual Studio otówrz terminal, przejdź do folderu "MyBookLife.Web" i wpisz "dotnet user-secrets set "Authentication:Google:ClientSecret" "twój skopiowany tajny klucz"", naciśnij enter

17. Odkomentuj poniższy fragment kodu z pliku "Program.cs":
<pre><code class="language-csharp">//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
//});</code></pre>

Uruchamianie Projektu:
1. Wybierz projekt MyBookLife.Web jako główny projekt w Visual Studio.

2. Naciśnij przycisk "Start" lub skorzystaj z klawisza F5, aby uruchomić aplikację.

3. Otwórz przeglądarkę internetową i przejdź do adresu https://localhost:PORT, gdzie PORT to numer portu, na którym została uruchomiona aplikacja

Projekt został wykonany przez: Michał Michalski (130615), Bartosz Sikorski (131593), Marek Marcinkowski (130604)
