# Programowanie desktopowych aplikacji biznesowych

Semestr 5 - mgr Artur Kornatka
[Link do przedmiotu](https://wsb-nlu.clouda.edu.pl/Kursy/ListaKursow?idPrzedmiotEdycja=58592)

### INFO

1. Pierwszy komit zawiera oryginalne pliki otrzymane na zajęciach, dodałem tylko .gitignore, README.md oraz LICENSE
2. Kod tworzony jest na ćwiczeniach
3. Folder z bazą danych nazywa się SQL i znajduje się w głównym folderze projektu
   1. Plik z rozszerzeniem .sql zawiera skrypt do utworzenia bazy danych
   2. Plik z rozszerzeniem .bak zawiera pełną bazę razem z danymi

### URUCHOMIENIE PROJEKTU

1. Sklonuj projekt na swój dysk twardy `git clone https://github.com/kzrepo/studia-aplikacje-desktopowe-projekt.git`
2. Utwórz bazę danych w SSMS ze skryptu lub odtwórz z backupu
3. Uruchom VS i w pliku App.Config podmień w linii 8 fragment `data source=Y700\SQLEXPRESS;` na `data source=NazwaTwojegoSerweraSQL;`
4. Od tego momentu aplikacja powinna mieć połączenie z lokalną bazą danych

### NOTATKI Z ZAJĘĆ + MATERIAŁY DODAKTOWE

Są trzy różne sposoby łączenia się z bazą danych, które możemy zastosować w Entity Framework:
https://docs.microsoft.com/en-us/ef/
1. **Code-First**
   1. https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx
   2. Najpierw tworzymy klasy, które reprezentują tabele bazy danych oraz klasę, która reprezentuje całą bazę danych, a baza danych tworzy się automatycznie z tych klas. Tak będziemy robić na internetowych aplikacjach.
2. **Database-Fist**
   1. https://www.entityframeworktutorial.net/entityframework6/introduction.aspx
   2. Najpierw tworzymy bazę danych na serwerze bazy danych, a następnie Entity Framework tworzy automatycznie klasy dostępowe do bazy danych. Dla każdej tabeli tworzy klasę ją reprezentującą. A dla całej bazy tworzy klasę ją reprezentującą. Tym sposobem będziemy robić w aplikacjach desktopowych.
3. **Model-First** (Diagram-First -> Kornatka)
   1. https://www.entityframeworktutorial.net/model-first-with-entity-framework.aspx
   2. ...

Entity Framework to narzędzie Microsoft do mapowania danych na obiekty w C#

### BAZY DANYCH

1. Typy danych pól weryfikujemy sprawdzając we wzorcach
   1. Enova, Optima - po zainstalowaniu można podejrzeć bazę danych
   2. Przykładowe bazy danych od Microsoftu https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks
1. Tabele słownikowe
   1. Dwa paradygamty tworzenia tabel słownikowych, wszystkie słowniki w jednej, lub każdy słownik w oddzielnej tabalie
   2. Tabele słownikowe stosujemy by dane, które się powtarzają były ujednolicone
   3. http://www.glowacki.p9.pl/nowa_strona/strony/niedatowane/kurs_mysql/k_2_3_0.php
3. Nie powinno się używać DELETE w bazach biznesowych, dlatego stosujemy pole statusu CzyAktywny i po tym filtrujemy rekordy
   1. Rekordy możemy skasować z bazy danych jeśli wcześniej zrobimy ich archiwizację do innych zasobów

### PROCEDURA GENEROWANIA MODELU Z DOSTĘPEM DO BAZY DANYCH 

1. Otwórz aplikację do kórej chcesz podłączyć bazę danych
2. PPM na Model i Add > New Folder > Entities
    1. Aplikację budujemy za pomocą wzorca projektowego MVVM (Model-View-ViewModel) gdzie:
    2. **Model** zawiera klasy logiki biznesowej (bliczeniowe) i klasy dostępu do bazy danych.
    3. **View** zawiera widoki
    4. **ViewModel** zawiera klasy pośredniczące między widokiem a modelem
3. PPM na Entities i Add > New Item.. > Data > ADO.NET Entity Data Model, który nazywamy ModelFaktury
4. Entity Data Model Wizard > EF Designer form database > New Connection...
5. New Connection... > Server name > Nazwa serwera w naszym systemie (np. Y750\SQLEXPRESS)
6. NEW Connection... > Select or enter a database name > Wybieramy naszą bazę danych
7. NEW Connection... > Test Conncetion > Sprawdzamy połączenie z bazą > Next
8. Wybieramy elementy bazy, które chcemy podłączyć do aplikacji > Finish
9. Dostęp do bazy danych powienien być docelowo wydzielony do oddzielnego projektu w solucji