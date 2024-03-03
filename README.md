# Currency Web API

Bu API uygulaması [www.kur.doviz.com](https://kur.doviz.com/) web sitesinden döviz kurlarının alınıp veritabanına kaydedilmesi için yazılmıştır.

## Teknolojiler ve paketler

- .Net 8.0
- EntitiyFramework
- HtmlAgilityPack
- Quartz
- SignalR
- Autofac
- Automapper

## Başlarken

Uygulamayı klonladıktan sonra çalıştırmak için CurrencyWebAPI katmanında bulunan appsettings.json dosyası içindeki sql connection cümleciğini değiştirmeniz gerekmektedir.

![appsettings](/Documantation/appsettingsjson.png "appsettings")
![Connection String](/Documantation/appsettingsjsonconnectionstring.png "Connection String")

Sonrasında Package Manager Console’da update-database komutunu çalıştırmalısınız.

## Endpoints

Döviz (Currency) ve Döviz değeri (CurrencyDetail) için ayrı endpointler oluşturulmuştur. Sisteminize kaydettiğiniz dövizleri görüntüleyebilir (GetAllCurrencies, GetCurrencyById), yeni döviz ekleyebilir (AddCurrency), döviz bilgilerini güncelleyebilir (UpdateCurrency) ve döviz bilgilerini silebilirsiniz (DeleteCurrency). 

![Endpointler](/Documantation/endpoints.png "Endpointler")

Yeni döviz eklemek için, enpoint'de bulunan name alanına kendi belirlediğiniz ismi koymalı, attribute name alanını doldurabilmek için ise [www.kur.doviz.com](https://kur.doviz.com/) sitesine gitmeli ve dövizin kısa kodunu büyük harfler ile yazmalısınız. 

![Kanada Doları](/Documantation/kanadadolari.png "Kanada Doları")
![Kanada Doları Ekleme](/Documantation/addkanadadolari.png "Kanada Doları Ekleme")

Döviz değeri içinse veritabanından sadece en güncel veriyi çekebilirsiniz. Web sitesinden veri çekilebilmesi için HtmlAgilityPack kullanılmıştır. Geriye kalan işlemler Quartz.net ile belirlenen zamanlarda tetiklenmekte ve veritabanına kaydedilmektedir (JOB).

## JOBS

Sistemin otomatikleştirilmesi için [Jobs](/CurrencyWebAPI.Service/Jobs) dosyası içirisine, Quartz.net kullanılarak 3 adet job yazıldı. GetCurrencyValueJob Job'ı istenen döviz kurlarının güncel değerlerini almak için yazılmıştır. CreateCurrencyHourlyValuesJob Job'ı veritababına kaydedilen verilerin her saat için maksimum, minimum ve ortalama değerini almak için yazılmıştır.  Veritabanının ekonomik kullanılabilmesi için saatlik değerler hesaplandıktan sonra kullanılan verileri silmektedir. CreateCurrencyDailyValuesJob Job'ı ise saatlik job ile benzer çalışmakta fakat bu işlemi her gün sonunda yapmaktadır ve bu işlemde herhangi bir veri silinmemektedir. Bu jobların tetiklenmesi için gereken kodları görmek için [buraya](/IoC/QuartzDependencyInjection.cs) tıklayabilirsiniz. GetCurrencyValueJob 5 saniyede bir, CreateCurrencyHourlyValuesJob her saat başı ve CreateCurrencyDailyValuesJob her gün sonunda tetiklenmektedir.

## SignalR

SignalR veritabanında veri değiştiği zaman, endpoint ile bunu haber veren bir yapıya sahiptir. Uygulama bir önyüz ile birlikte kullanıldığı zaman güncel verileri almak için kullanılabilir. Uygulamasını görmek için [CurrencyMVC](https://github.com/tunahankilic48/CurrencyMVC) projesini inceleyebilirsiniz.

# Currency Web API
