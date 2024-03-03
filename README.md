# Currency Web API

Bu API uygulaması [www.kur.doviz.com](https://kur.doviz.com/) websitesinden döviz kurlarının alınıp veritabanına kaydedilmesi için yazılmıştır.

## Technologies and Packages

- .Net 8.0
- EntitiyFramework
- HtmlAgilityPack
- Quartz
- SignalR
- Autofac
- Automapper

## Getting Started

Uygulamayı klonladıktan sonra çalıştırmak için CurrencyWebAPI katmanında bulunan appsettings.json dosyası içindeki sql connection cümleciğini değiştirmeniz gerekmektedir.
![appsettings.json](/Documentation/Images/appsettingsjson.png)

### Requirements

- Java 17
- Maven
- PostgreSQL

### Installation

1. Clone the project:

   ```bash
   git clone https://github.com/erenuygur/flight-search-api.git
   ```
2. Navigate to the project directory:

   ```bash
   cd flight-search-api
   ```
3. Build the project:
   ```bash
   mvn clean install
   ```

4. Run the application:
   ```bash
   mvn java -jar target/flight-search-api-1.0.0.jar
   ```
### Security Considerations
For security reasons, certain configuration details such as API keys, passwords, and sensitive information are not included in this public repository. Follow the steps below to configure these details:
   ```
      username: admin
      password: admin
   ```
Database Configuration: Configure the database connection details in the application.properties file.
   ```
      spring.datasource.url=jdbc:postgresql://localhost:5432/flight_search
      spring.datasource.username=postgres
      spring.datasource.password=1234
   ```

Once the application is running, you can access the API documentation at http://localhost:8080/swagger-ui.html.

![Swagger](/content/SwaggerDoc.PNG "End Points").



# Flight-Search-API
