# Programowanie desktopowych aplikacji biznesowych

Semestr 5 - mgr Artur Kornatka
[Link do przedmiotu](https://wsb-nlu.clouda.edu.pl/Kursy/ListaKursow?idPrzedmiotEdycja=58592)

### 01 INFO

1. Pierwszy komit zawiera oryginalne pliki otrzymane na zajęciach, dodałem tylko .gitignore, README.md oraz LICENSE
2. Folder z bazą danych nazywa się SQL i znajduje się w głównym folderze projektu
   - Plik z rozszerzeniem .sql zawiera skrypt do utworzenia bazy danych
   - Plik z rozszerzeniem .bak zawiera pełną bazę razem z danymi

### 02 URUCHOMIENIE PROJEKTU

1. Sklonuj projekt na swój dysk twardy `git clone https://github.com/kzrepo/studia-aplikacje-desktopowe-projekt.git`
2. Utwórz bazę danych w SSMS ze skryptu lub odtwórz z backupu
3. Uruchom VS i w pliku App.Config podmień w linii 8 fragment `data source=Y700\SQLEXPRESS;` na `data source=NazwaTwojegoSerweraSQL;`
4. Od tego momentu aplikacja powinna mieć połączenie z lokalną bazą danych

### 03 NOTATKI Z ZAJĘĆ + MATERIAŁY DODAKTOWE

Są trzy różne sposoby łączenia się z bazą danych, które możemy zastosować w Entity Framework:
https://docs.microsoft.com/en-us/ef/
1. **Code-First**
   - https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx
   - Najpierw tworzymy klasy, które reprezentują tabele bazy danych oraz klasę, która reprezentuje całą bazę danych, a baza danych tworzy się automatycznie z tych klas. Tak będziemy robić na internetowych aplikacjach.
2. **Database-Fist**
   - https://www.entityframeworktutorial.net/entityframework6/introduction.aspx
   - Najpierw tworzymy bazę danych na serwerze bazy danych, a następnie Entity Framework tworzy automatycznie klasy dostępowe do bazy danych. Dla każdej tabeli tworzy klasę ją reprezentującą. A dla całej bazy tworzy klasę ją reprezentującą. Tym sposobem będziemy robić w aplikacjach desktopowych.
3. **Model-First** (Diagram-First -> Kornatka)
   - https://www.entityframeworktutorial.net/model-first-with-entity-framework.aspx
   - ...

Entity Framework to narzędzie Microsoft do mapowania danych na obiekty w C#

### 04 BAZY DANYCH

1. Typy danych pól weryfikujemy sprawdzając we wzorcach
   - Enova, Optima - po zainstalowaniu można podejrzeć bazę danych
   - Przykładowe bazy danych od Microsoftu https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks
1. Tabele słownikowe
   - Dwa paradygamty tworzenia tabel słownikowych, wszystkie słowniki w jednej, lub każdy słownik w oddzielnej tabeli
   - Tabele słownikowe stosujemy by dane, które się powtarzają były ujednolicone
   - http://www.glowacki.p9.pl/nowa_strona/strony/niedatowane/kurs_mysql/k_2_3_0.php
3. Nie powinno się używać DELETE w bazach biznesowych, dlatego stosujemy pole statusu CzyAktywny i po tym filtrujemy rekordy
   - Rekordy możemy skasować z bazy danych tylko w jednym wypadku, jeśli wcześniej zrobimy ich archiwizację do innych zasobów

### 05 PROCEDURA GENEROWANIA MODELU Z DOSTĘPEM DO BAZY DANYCH 

1. Otwórz aplikację do kórej chcesz podłączyć bazę danych
2. PPM na Model i Add > New Folder > Entities
   - Aplikację budujemy za pomocą wzorca projektowego MVVM (Model-View-ViewModel) gdzie:
   - **Model** zawiera klasy logiki biznesowej (bliczeniowe) i klasy dostępu do bazy danych.
   - **View** zawiera widoki
   - **ViewModel** zawiera klasy pośredniczące między widokiem a modelem
3. PPM na Entities i Add > New Item.. > Data > ADO.NET Entity Data Model, który nazywamy ModelFaktury
4. Entity Data Model Wizard > EF Designer form database > New Connection...
5. New Connection... > Server name > Nazwa serwera w naszym systemie (np. Y750\SQLEXPRESS)
6. NEW Connection... > Select or enter a database name > Wybieramy naszą bazę danych
7. NEW Connection... > Test Conncetion > Sprawdzamy połączenie z bazą > Next
8. Wybieramy elementy bazy, które chcemy podłączyć do aplikacji > Finish
9. Dostęp do bazy danych powienien być docelowo wydzielony do oddzielnego projektu w solucji

### 06 PROCEDURA TWORZENIA WIDOKÓW DZIEDZICZONYCH

1. Solution Explorer > Views > Add > New item... > WPF > Custom Control (WPF)
   - https://wpf-tutorial.com/usercontrols-and-customcontrols/creating-using-a-usercontrol/
2. Do utworzonej klasy należy dodać dziedziczenie po UserControl
3. Przy tworzeniu Custom Control oprócz klasy w katalogu głównym projektu tworzony jest folder Themes, a w nim plik Generic.xaml, który steruje wyglądem tego Custom Control-a
4. Weryfikujemy `xmlns:local="clr-namespace: NameSpaces` czy wskazuje na NameSpace w którym znajduje się plik C# z odpowiednią klasą
5. Odpowiada za miejsce wklejenia widoku, który dziedziczy z tego Custom Control
6. Ustawienie dziedziczenia Custom Control we WszystkieTowaryView.xaml.cs
7. Elementy zdefiniowane w pliku .xaml zostaną umieszczone w ContentPresenter z pliku Generic.xaml