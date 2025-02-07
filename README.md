# CatalogManagement

## Scopo del progetto
CatalogManagement è una **Single Page Application (SPA)** creata per un progetto universitario per l'esame di **Applicazioni Web e Mobile**. Il progetto è stato sviluppato con il backend in **.NET** e il frontend in **Angular**.
Lo scopo di questo progetto è quello di permettere la visualizzazione online del catalogo di un negozio. Gli utenti possono navigare nel catalogo senza essere autenticati, ma hanno anche la possibilità di registrarsi, accedere e modificare le proprie credenziali di accesso.

## Tecnologie Utilizzate
### Lato Backend
- **.NET Framework**: Utilizzato per sviluppare l'intera applicazione backend.
- **Swagger UI**: Utilizzato per testare gli endpoint dell'API.
- **JWT Authentication**: Utilizzato per proteggere gli endpoint e gestire l'autenticazione degli utenti.
- **SSMS (SQL Server Management Studio)**: Utilizzato per la gestione persistente dei dati.
- **Entity Framework Core**: Utilizzato per l'accesso ai dati e la gestione del database.
- **Microsoft.Extensions.Configuration**: Utilizzato per la gestione della configurazione dell'applicazione.

### Lato Frontend
- **Angular**: Framework di sviluppo web front-end basato su TypeScript, utilizzato per creare applicazioni web dinamiche e single-page applications (SPA).
- **TypeScript**: Superset di JavaScript che aggiunge tipizzazione statica e altre funzionalità avanzate.
- **HTML**: Utilizzato per definire la struttura del contenuto delle pagine.
- **CSS/SCSS**: Linguaggi di stile utilizzati per descrivere la presentazione di un documento scritto in HTML.
- **Angular HTTP Client**: Modulo di Angular che fornisce un'API per effettuare richieste HTTP verso server remoti.
- **JWT (JSON Web Token)**: Utilizzato per l'autenticazione e l'autorizzazione. I token JWT vengono utilizzati per verificare l'identità degli utenti.

## Struttura del Backend
### 1. Application Layer
Questo livello contiene tutti i **servizi**, i **DTOs (Data Transfer Objects)**, le **richieste** e le **risposte** del progetto. È responsabile dell'implementazione della logica di business e dell'orchestrazione delle operazioni.
**Componenti**:
- **Servizi**: Gestiscono le operazioni di business, come `UserService` per la gestione degli utenti.
- **DTOs**: Oggetti utilizzati per trasferire dati tra il client e il server, come `UserDTO`.
- **Requests e Responses**: Definiscono le strutture delle richieste e delle risposte per gli endpoint API.

### 2. Web Layer
Questo livello contiene i **controller API**, il file `Program.cs` e il file di configurazione `appsettings.json`. È responsabile della gestione delle richieste HTTP e dell'inizializzazione dell'applicazione.
**Componenti**:
- **Controllers**: Espongono gli endpoint API per l'interazione con il frontend, come `UserController`.
- **Program.cs**: Punto di ingresso dell'applicazione, dove viene configurato il web host.
- **appsettings.json**: File di configurazione che contiene impostazioni come stringhe di connessione al database e chiavi di configurazione.

### 3. Module Layer
Questo livello contiene tutte le **configurazioni**, i **repository**, il **contesto del database** e le **entità**. Definisce le strutture dati e le regole di business fondamentali.
**Componenti**:
- **Configurazioni**: Configurazioni per Entity Framework e altre impostazioni.
- **Repositories**: Classi che gestiscono l'accesso ai dati, come `UserRepository`.
- **DB Context**: Classe che rappresenta il contesto del database, come `MyDbContext`.
- **Entità**: Modelli di dati che rappresentano le tabelle del database, come `User`, `Apparel`, `Category`.

## Struttura del Frontend
Il frontend è composto da una pagina principale che cambia il proprio contenuto in modo dinamico in base alla route. Ogni route richiama un componente diverso, permettendo una navigazione fluida e una gestione modulare delle diverse sezioni dell'applicazione.
**Componenti**:
Ogni componente è composto da tre file principali:
- **TypeScript (.ts)**: Contiene la logica del componente, inclusi i metodi, le proprietà e le interazioni con i servizi.
- **HTML (.html)**: Definisce la struttura del componente, utilizzando il markup HTML per organizzare il contenuto.
- **CSS/SCSS (.css o .scss)**: Contiene lo stile del componente, definendo l'aspetto visivo e la presentazione del contenuto.

**Servizi**:
I servizi sono raggruppati nella cartella `services` e fungono da nodo di comunicazione con il backend. Gestiscono le operazioni di business e le comunicazioni HTTP.

**Interceptor**:
Gli interceptor vengono utilizzati per intercettare le richieste HTTP prima che vengano inviate al server, aggiungendo nell'header il **JWT**.

**Environment**:
Il file di configurazione `environment` viene utilizzato per salvare globalmente l'URL dell'API.

## Funzionamento
Le entità principali sono **Apparel**, **Category** e **User**. Ogni **Apparel** deve avere una sola **Category**. La struttura delle entità è la seguente:

- **User** è composto da `id`, `username`, `email`, `password` e `role`.
- **Category** è composta da `id` e `name`.
- **Apparel** è composta da `id`, `categoryId` e molti altri elementi che servono per rappresentarlo (nome, descrizione, prezzo, materiale, ecc.).

Per ogni entità nel sistema esistono diversi componenti, ciascuno con uno scopo ben preciso:
- **Configurazione**: Ogni entità ha una configurazione che rappresenta la sua tabella nel database. Questa configurazione definisce la struttura dei dati e le relazioni con altre entità.
- **Repository**: Ogni entità ha una repository che estende una repository generale. La repository generale implementa operazioni di base come il salvataggio, l'aggiornamento e la cancellazione dei dati, mentre la repository dell'entità gestisce operazioni più avanzate e personalizzate.
- **DTO (Data Transfer Object)**: Ogni entità ha un DTO che serve a preimpostare e strutturare le informazioni in un formato visualizzabile nel frontend.
- **Servizio**: Ogni entità ha un servizio che interagisce con la repository per eseguire operazioni sul database e arricchisce le operazioni con logica di business.
- **Controller**: Ogni entità ha un controller che gestisce le API, eseguendo chiamate ai servizi per recuperare o modificare i dati.

**Request Model**:
Ogni API utilizza un Request Model che rappresenta la struttura dei dati inviati dal frontend al backend. Il Request Model è usato per validare e strutturare correttamente le informazioni ricevute prima che vengano elaborate dal servizio.

## Servizi che Interagiscono con le API
- **usersService** utilizza le API `AddUser`, `Login`, `UpdateUser`
- **categoriesService** utilizza l'API `GetCategories`
- **apparelsService** utilizza le API `GetApparels`, `GetApparelById`, `GetApparelsByCategoryName`, `GetApparelsByName`
- **tokenService** compie tutte le operazioni necessarie sul token che viene inviato dal backend al frontend in fase di login, lo decodifica, ne controlla la scadenza e ne fornisce i metodi per essere richiamato.

# Sicurezza
## CORS - Cross-Origin Resource Sharing
Il **CORS** è stato implementato per garantire la sicurezza delle rotte nel backend, permettendo solo a domini autorizzati di accedere alle risorse del server. Questo è stato fatto configurando le politiche CORS nel middleware dell'applicazione e autorizzando specificamente i domini del frontend e del backend.


## Protezione da SQL Injection
**Entity Framework Core** è un ORM (Object-Relational Mapper) che mappa le entità del dominio a tabelle del database e consente di interagire con il database utilizzando oggetti C#. Una delle caratteristiche principali di **Entity Framework Core** è la protezione automatica contro **SQL Injection**.
**Entity Framework Core** utilizza query SQL parametrizzate per prevenire **SQL Injection**. Quando si eseguono query utilizzando **Entity Framework Core**, i parametri delle query vengono automaticamente convertiti in parametri SQL, impedendo l'inserimento di codice SQL malevolo.

### Esempio di Query Parametrizzata
Consideriamo un esempio in cui si cerca un utente per email:

```csharp
public User GetUserByEmail(string email)
{
    return _context.Users.SingleOrDefault(user => user.Email == email);
}
```

In questo esempio, `email` è un parametro passato alla query. **Entity Framework Core** genera una query SQL parametrizzata, che assicura che il valore di `email` venga trattato come un parametro e non come parte del codice SQL.

### Query Generata da Entity Framework Core
La query generata da **Entity Framework Core** potrebbe apparire simile a questa:

```bash
SELECT * FROM Users WHERE Email = @p0
```

Dove `@p0` è un parametro che contiene il valore di `email`. Questo approccio impedisce che un attaccante possa inserire codice SQL malevolo nel parametro `email`.

## Sicurezza delle Password
Ho gestito la sicurezza della password utilizzando l'algoritmo **BCrypt** (che fornisce un *salt* in autonomia), combinato con un *pepper*.
In fase di registrazione, l'utente inserisce la password che desidera. Questa password, tramite l'utilizzo di un *pepper* e di un *salt*, viene *hashata* 12 volte (workfactor = 12).

### Funzione per Hashare la Password

```csharp
public string HashPassword(string password)
{
    int workfactor = 12;
    string pepperedPassword = password + _pepper;
    return BCrypt.Net.BCrypt.HashPassword(pepperedPassword, workfactor);
}
```

Una volta *hashata*, la password viene salvata nel database evitando quindi di salvare le password in chiaro.
In fase di login, l'utente inserisce la propria password e viene richiamato il metodo `Verify` di **BCrypt**. **BCrypt** estrae il *salt* dalla password *hashata*, combina il *salt*, il *pepper* e la password fornita, e verifica se corrisponde alla stringa *hashata*.

### Funzione per Verificare la Password

```csharp
public bool VerifyPassword(string password, string hashedPassword)
{
    string pepperedPassword = password + _pepper;
    return BCrypt.Net.BCrypt.Verify(pepperedPassword, hashedPassword);
}
```

## Autenticazione tramite JWT - JSON Web Token
Il **JWT** è la quarta e ultima entità presente nel backend, è composta dalla `key`, dall'`Issuer`, da un `Audience` e da `ExpiryMinutes` che indica la durata del token.

Quando l'utente effettua il login, dal frontend viene inviata una richiesta `POST` al backend. Il backend verifica le credenziali e, se corrette, viene richiamato il metodo `CreateToken` del **JwtService** che crea il token. Questo token viene incluso in un oggetto `LoginResponseModel` che viene restituito come risposta **JSON** al frontend.

Il payload del token contiene l'`id`, l'`username` e l'`email` dell'utente che ha effettuato il login.

Nel frontend, il **JWT** viene impostato come **Item** nel `LocalStorage` e l'interceptor intercetta ogni richiesta **Http** aggiungendo nell'header il token, permettendo così l'autenticazione automatica dell'utente fino al logout o alla scadenza del token.

Se l'utente non è autenticato, non potrà effettuare tutte quelle operazioni che nel backend richiedono l'autorizzazione, come, nel caso di questo progetto, l'`UpdateUser`.

Nel frontend, le rotte protette dal **Guard** necessitano dell'autenticazione, altrimenti non sono raggiungibili.
