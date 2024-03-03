# Currency Web API

Bu API uygulamasý [www.kur.doviz.com](https://kur.doviz.com/) web sitesinden döviz kurlarýnýn alýnýp veritabanýna kaydedilmesi için yazýlmýþtýr.

## Teknolojiler ve paketler

- .Net 8.0
- EntitiyFramework
- HtmlAgilityPack
- Quartz
- SignalR
- Autofac
- Automapper

## Baþlarken

Uygulamayý klonladýktan sonra çalýþtýrmak için CurrencyWebAPI katmanýnda bulunan appsettings.json dosyasý içindeki sql connection cümleciðini deðiþtirmeniz gerekmektedir.

![appsettings](/Documantation/appsettingsjson.png "appsettings")
![Connection String](/Documantation/appsettingsjsonconnectionstring.png "Connection String")

Sonrasýnda Package Manager Console’da update-database komutunu çalýþtýrmalýsýnýz.

## Endpoints

Döviz (Currency) ve Döviz deðeri (CurrencyDetail) için ayrý endpointler oluþturulmuþtur. Sisteminize kaydettiðiniz dövizleri görüntüleyebilir (GetAllCurrencies, GetCurrencyById), yeni döviz ekleyebilir (AddCurrency), döviz bilgilerini güncelleyebilir (UpdateCurrency) ve döviz bilgilerini silebilirsiniz (DeleteCurrency). 

![Endpointler](/Documantation/endpoints.png "Endpointler")
Yeni döviz eklemek için, enpoint'de bulunan name alanýna kendi belirlediðiniz ismi koymalý, attribute name alanýný doldurabilmek için ise [www.kur.doviz.com](https://kur.doviz.com/) sitesine gitmeli ve dövizin kýsa kodunu büyük harfler ile yazmalýsýnýz. 

![Kanada Dolarý](/Documantation/kanadadolari.png "Kanada Dolarý")
![Kanada Dolarý Ekleme](/Documantation/addkanadadolari.png "Kanada Dolarý Ekleme")

Döviz deðeri içinse veritabanýndan sadece en güncel veriyi çekebilirsiniz. Web sitesinden veri çekilebilmesi için HtmlAgilityPack kullanýlmýþtýr (WebScraping). Geriye kalan iþlemler Quartz.net ile belirlenen zamanlarda tetiklenmekte ve veritabanýna kaydedilmektedir (JOB).

## JOBS

Sistemin otomatikleþtirilmesi için [Jobs](/CurrencyWebAPI.Service/Jobs) dosyasý içirisine, Quartz.net kullanýlarak 3 adet job yazýldý. GetCurrencyValueJob Job'ý istenen döviz kurlarýnýn güncel deðerlerini almak için yazýlmýþtýr. CreateCurrencyHourlyValuesJob Job'ý veritababýna kaydedilen verilerin her saat için maksimum, minimum ve ortalama deðerini almak için yazýlmýþtýr.  Veritabanýnýn ekonomik kullanýlabilmesi için saatlik deðerler hesaplandýktan sonra kullanýlan verileri silmektedir. CreateCurrencyDailyValuesJob Job'ý ise saatlik job ile benzer çalýþmakta fakat bu iþlemi her gün sonunda yapmaktadýr ve bu iþlemde herhangi bir veri silinmemektedir. Bu joblarýn tetiklenmesi için gereken kodlarý görmek için [buraya](/IoC/QuartzDependencyInjection.cs) týklayabilirsiniz. GetCurrencyValueJob 5 saniyede bir, CreateCurrencyHourlyValuesJob her saat baþý ve CreateCurrencyDailyValuesJob her gün sonunda tetiklenmektedir.

## SignalR

SignalR veritabanýnda veri deðiþtiði zaman, endpoint ile bunu haber veren bir yapýya sahiptir. Uygulama bir önyüz ile birlikte kullanýldýðý zaman güncel verileri almak için kullanýlabilir. Uygulamasýný görmek için [CurrencyMVC](https://github.com/tunahankilic48/CurrencyMVC) projesini inceleyebilirsiniz.

# Currency Web API
