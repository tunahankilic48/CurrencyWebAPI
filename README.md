# Currency Web API

This API application was written to get currencies  from the website [www.kur.doviz.com](https://kur.doviz.com/) and save them to the database.

## Technologies and Packages

- .Net 8.0
- EntitiyFramework
- HtmlAgilityPack
- Quartz
- SignalR
- Autofac
- Automapper

## Getting Started

To run the application after cloning it, you need to change the sql connection string in the appsettings.json file in the CurrencyWebAPI layer.
![appsettings](/Documantation/appsettingsjson.png "appsettings")
![Connection String](/Documantation/appsettingsjsonconnectionstring.png "Connection String")

Afterwards, you must run the update-database command in the Package Manager Console.

## Endpoints

Different endpoints have been created for Currency (Currency)  and Currency Detail (CurrencyDetail). You can get the currencies you have saved in your database (GetAllCurrencies, GetCurrencyById), add new currency (AddCurrency), update currency values (UpdateCurrency) and delete currency (DeleteCurrency).
![Endpoints](/Documantation/endpoints.png "Endpoints")

To add a new currency, you must enter your own name in the name field in Enpoint. To fill in the Attribute name field, you must go to [www.kur.doviz.com](https://kur.doviz.com/) and write the short code of the currency in capital letters.
![Kanada Doları](/Documantation/kanadadolari.png "Kanada Doları")
![Adding Canada Dolar](/Documantation/addkanadadolari.png "Adding Canada Dolar")

For the currency value, you can only get the most current data from the database. HtmlAgilityPack was used to get data from the website (WebScraping). The remaining transactions are triggered at specified times with Quartz.net and saved in the database (JOB).
## JOBS

To automate the system, 3 jobs were written in the [Jobs](/CurrencyWebAPI.Service/Jobs) file using Quartz.net. The GetCurrencyValueJob was written to get the current values of the desired currency. CreateCurrencyHourlyValuesJob Job was written to get the maximum, minimum and average value of the data saved in the database for each hour. In order to use the database economically, the used data is deleted after the hourly values are calculated. The CreateCurrencyDailyValuesJob works similar to the hourly job, but it performs this operation at the end of each day and no data is deleted in this process. You can click [here](/IoC/QuartzDependencyInjection.cs) to see the codes required to trigger these jobs. GetCurrencyValueJob is triggered every 5 seconds, CreateCurrencyHourlyValuesJob is triggered every hour, and CreateCurrencyDailyValuesJob is triggered at the end of each day.

## SignalR

SignalR has a structure that notifies you with an endpoint when data changes in the database. When used with a frontend, the application can be used to get up-to-date data. You can review the [CurrencyMVC](https://github.com/tunahankilic48/CurrencyMVC) project to see its implementation.
# Currency Web API
