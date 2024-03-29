# Currency Web API

Bu API uygulamas� [www.kur.doviz.com](https://kur.doviz.com/) web sitesinden d�viz kurlar�n�n al�n�p veritaban�na kaydedilmesi i�in yaz�lm��t�r.

## Teknolojiler ve paketler

- .Net 8.0
- EntitiyFramework
- HtmlAgilityPack
- Quartz
- SignalR
- Autofac
- Automapper

## Ba�larken

Uygulamay� klonlad�ktan sonra �al��t�rmak i�in CurrencyWebAPI katman�nda bulunan appsettings.json dosyas� i�indeki sql connection c�mleci�ini de�i�tirmeniz gerekmektedir.

![appsettings](/Documantation/appsettingsjson.png "appsettings")
![Connection String](/Documantation/appsettingsjsonconnectionstring.png "Connection String")

Sonras�nda Package Manager Console�da update-database komutunu �al��t�rmal�s�n�z.

## Endpoints

D�viz (Currency) ve D�viz de�eri (CurrencyDetail) i�in ayr� endpointler olu�turulmu�tur. Sisteminize kaydetti�iniz d�vizleri g�r�nt�leyebilir (GetAllCurrencies, GetCurrencyById), yeni d�viz ekleyebilir (AddCurrency), d�viz bilgilerini g�ncelleyebilir (UpdateCurrency) ve d�viz bilgilerini silebilirsiniz (DeleteCurrency). Saatlik (GetHourlyValue) ve g�nl�k (GetDailyValue) verileride istenen parametreleri g�ndererek alabiliriz.

![Endpointler](/Documantation/endpoints.png "Endpointler")
Yeni d�viz eklemek i�in, enpoint'de bulunan name alan�na kendi belirledi�iniz ismi koymal�, attribute name alan�n� doldurabilmek i�in ise [www.kur.doviz.com](https://kur.doviz.com/) sitesine gitmeli ve d�vizin k�sa kodunu b�y�k harfler ile yazmal�s�n�z. 

![Kanada Dolar�](/Documantation/kanadadolari.png "Kanada Dolar�")
![Kanada Dolar� Ekleme](/Documantation/addkanadadolari.png "Kanada Dolar� Ekleme")

D�viz de�eri i�inse veritaban�ndan sadece en g�ncel veriyi �ekebilirsiniz. Web sitesinden veri �ekilebilmesi i�in HtmlAgilityPack kullan�lm��t�r (WebScraping). Geriye kalan i�lemler Quartz.net ile belirlenen zamanlarda tetiklenmekte ve veritaban�na kaydedilmektedir (JOB).

## JOBS

Sistemin otomatikle�tirilmesi i�in [Jobs](/CurrencyWebAPI.Service/Jobs) dosyas� i�irisine, Quartz.net kullan�larak 3 adet job yaz�ld�. GetCurrencyValueJob Job'� istenen d�viz kurlar�n�n g�ncel de�erlerini almak i�in yaz�lm��t�r. CreateCurrencyHourlyValuesJob Job'� veritabab�na kaydedilen verilerin her saat i�in maksimum, minimum ve ortalama de�erini almak i�in yaz�lm��t�r.  Veritaban�n�n ekonomik kullan�labilmesi i�in saatlik de�erler hesapland�ktan sonra kullan�lan verileri silmektedir. CreateCurrencyDailyValuesJob Job'� ise saatlik job ile benzer �al��makta fakat bu i�lemi her g�n sonunda yapmaktad�r ve bu i�lemde herhangi bir veri silinmemektedir. Bu joblar�n tetiklenmesi i�in gereken kodlar� g�rmek i�in [buraya](/IoC/QuartzDependencyInjection.cs) t�klayabilirsiniz. GetCurrencyValueJob 5 saniyede bir, CreateCurrencyHourlyValuesJob her saat ba�� ve CreateCurrencyDailyValuesJob her g�n sonunda tetiklenmektedir.

## SignalR

SignalR veritaban�nda veri de�i�ti�i zaman, endpoint ile bunu haber veren bir yap�ya sahiptir. Uygulama bir �ny�z ile birlikte kullan�ld��� zaman g�ncel verileri almak i�in kullan�labilir. Bu uygulama i�erisinde https://localhost:44383/currencyhub endpoint'i ile istenen d�viz kurlar�n�n anl�k de�i�imlerini takip edebiliriz. Uygulamas�n� g�rmek i�in [CurrencyMVC](https://github.com/tunahankilic48/CurrencyMVC) projesini inceleyebilirsiniz.

# Currency Web API
