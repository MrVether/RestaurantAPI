RestaurantAPI to projekt, który umożliwia tworzenie i zarządzanie bazą danych restauracji oraz przypisanych do nich dań. Dzięki niemu możesz dodawać, usuwać i edytować restauracje oraz ich menu.

W projekcie zaimplementowany został także system logowania użytkowników z podziałem na role: "Admin", "Menadżer" i "User". Każda z ról ma dostęp do odpowiednich funkcjonalności aplikacji, co pozwala na skuteczne zarządzanie bazą danych.

Aby ułatwić korzystanie z aplikacji, stworzone zostały strony internetowe w oparciu o technologie HTML, CSS i JS. Dzięki nim użytkownicy mogą w łatwy sposób dodawać, usuwać i edytować zarówno restauracje, jak i menu.

W skrócie, RestauranAPI to projekt, który umożliwia skuteczne zarządzanie bazą danych restauracji oraz przypisanych do nich dań. Dzięki prostemu w obsłudze systemowi logowania oraz intuicyjnym interfejsom użytkownicy mogą w łatwy sposób zarządzać swoją bazą danych, 

Aby móc skorzystać z projektu RestaurantAPI, potrzebujesz środowiska z zainstalowanym .NET i Microsoft SQL Server. W projekcie zostały użyte różne biblioteki, w tym EntityFrameworkCore, MoQ, NLog, Web, Xunit i AutoMapper.

Aby skompilować i uruchomić aplikację, należy najpierw pobrać i zainstalować wymagane biblioteki przy użyciu menedżera pakietów NuGet. Następnie należy skonfigurować połączenie z bazą danych w pliku konfiguracyjnym, aby umożliwić aplikacji dostęp do bazy.

Aby przetestować aplikację, należy użyć narzędzia do testowania, takiego jak np. xUnit, a także zainstalować odpowiednie narzędzia, takie jak Moq, które umożliwiają testowanie kodu.

Wymagania dla użytkowników końcowych obejmują przeglądarkę internetową, która obsługuje HTML, CSS i JavaScript, ponieważ strony internetowe są napisane w tych technologiach. Wymagane jest również konto użytkownika, aby korzystać z aplikacji, a role użytkowników są definiowane w bazie danych.

Ogólnie rzecz biorąc, aby skorzystać z projektu RestauranAPI, należy mieć podstawową wiedzę na temat .NET, Microsoft SQL Server oraz narzędzi i bibliotek, takich jak NuGet, xUnit, Moq, NLog i AutoMapper.

Projekt należy sklonować z Githuba: https://github.com/MrVether/RestaurantAPI

Aby skonfigurować projekt RestauranAPI, należy najpierw ustawić połączenie z bazą danych w pliku RestaurantDbContext. W celu połączenia z bazą danych Microsoft SQL Server, należy zmodyfikować w tym pliku pole "_connectionString" na podstawie swoich potrzeb. Przykładowa konfiguracja wygląda następująco:


Server=<nazwa serwera>;Database=<nazwa bazy danych>;Trusted_Connection=True;
Należy zastąpić <nazwa serwera> odpowiednim adresem serwera bazy danych, a <nazwa bazy danych> - nazwą bazy danych, którą chcemy utworzyć lub wykorzystać.

Aby uruchomić projekt, należy zainstalować menedżer pakietów NuGet i dodać migracje, które umożliwią utworzenie bazy danych. Można to zrobić za pomocą konsoli menedżera pakietów NuGet, wpisując następujące polecenia:

Add-Migration <nazwa migracji>
Update-Database
Po wykonaniu tych kroków, baza danych zostanie utworzona, a aplikacja będzie gotowa do użycia.

W projekcie RestauranAPI są trzy testowe konta użytkowników, które służą do testowania funkcjonalności systemu logowania. Poniżej przedstawione są informacje o tych użytkownikach:\
1.	Użytkownik (rola "User")
•	Email: user@example.com
•	Hasło: password
•	Data urodzenia: 1 stycznia 1990
•	Narodowość: polska
2.	Menadżer (rola "Manager")
•	Email: manager@example.com
•	Hasło: password
•	Data urodzenia: 1 stycznia 1985
•	Narodowość: amerykańska
3.	Administrator (rola "Admin")
•	Email: admin@example.com
•	Hasło: password
•	Data urodzenia: 1 stycznia 1980
•	Narodowość: brytyjska
  
Po uruchomieniu aplikacji, użytkownik jest przekierowywany na stronę logowania, na której musi podać swoje dane logowania. Po zalogowaniu się użytkownik zostaje przekierowany na stronę główną, gdzie może wybrać jedną z wielu akcji, które są dostępne w menu nawigacyjnym.

Na stronie głównej użytkownik ma do wyboru następujące akcje: Strona główna, logowanie, rejestracja, tworzenie dania, tworzenie restauracji, usuwanie dań, usuwanie restauracji, edytowanie restauracji, pobieranie informacji o restauracjach, pobieranie dań z restauracji oraz pobieranie dań i restauracji po id.

Każda akcja ma swój formularz, który użytkownik musi wypełnić, aby stworzyć, edytować lub usunąć restaurację, danie lub użytkownika. W przypadku tworzenia restauracji, użytkownik musi podać nazwę restauracji, adres, numer telefonu oraz opis. Podobnie, aby dodać nowe danie, użytkownik musi podać nazwę dania, opis oraz ceny.

Usunięcie restauracji lub dania wymaga jedynie potwierdzenia przez użytkownika. W przypadku edycji restauracji, użytkownik może zmienić nazwę, adres, numer telefonu oraz opis, a w przypadku edycji dania, użytkownik może zmienić nazwę, opis oraz ceny.

Poza tym, użytkownik ma możliwość pobierania informacji o restauracjach i daniach. Użytkownik może pobrać listę wszystkich restauracji, listę dań dla konkretnej restauracji lub informacje o konkretnej restauracji lub daniu za pomocą identyfikatora.

Wszystkie te funkcje zostały zaprojektowane w taki sposób, aby były proste i intuicyjne w użyciu, a formularze są łatwe do wypełnienia nawet dla początkujących użytkowników.
