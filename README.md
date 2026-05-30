# Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi

## 1. Projenin Amacı

Bu proje, üniversite kampüsünde sınav, etkinlik, yemekhane ve kütüphane gibi farklı duyuruların oluşturulmasını ve ilgili kullanıcıların otomatik olarak bilgilendirilmesini sağlayan Windows Forms tabanlı bir uygulamadır.

Uygulamada gerçek SMS, e-posta veya mobil bildirim servisi kullanılmamıştır. Bildirim gönderim sonuçları Windows Forms ekranındaki RichTextBox log alanında gösterilir.

## 2. Kullanılan Teknolojiler

- C#
- Windows Forms
- .NET
- Katmanlı Mimari
- Nesne Yönelimli Programlama

## 3. Mimari Yapı

Proje katmanlı mimari yaklaşımıyla hazırlanmıştır. Her katman kendi sorumluluğuna odaklanır ve kodun daha düzenli, okunabilir ve geliştirilebilir olması hedeflenir.

- Presentation Layer

  Windows Forms arayüzünün bulunduğu katmandır. `MainForm`, form tasarımı ve kullanıcı etkileşimleri bu katmanda yer alır. Bu katman kullanıcıdan gelen işlemleri alır ancak duyuru oluşturma veya kullanıcı kaydetme gibi iş mantığını doğrudan yönetmez.

- Application Layer

  Uygulama servislerinin bulunduğu katmandır. `UserService` kullanıcı oluşturma ve abone etme işlemlerini, `AnnouncementService` ise duyuru oluşturma ve yayınlama işlemlerini yönetir. Presentation katmanı bu servisleri kullanarak iş akışını başlatır.

- Domain Layer

  Projenin temel model, interface ve abstract class yapılarının bulunduğu katmandır. Duyuru türleri, kullanıcı observer yapıları ve bildirim kanalları bu katmanda tanımlanır. Bu katman Presentation veya Infrastructure katmanlarına bağımlı değildir.

- Infrastructure Layer

  Factory sınıfları, Singleton bildirim merkezi ve bellek içi veri deposu bu katmanda yer alır. `NotificationCenter`, duyuruların kullanıcılara bildirilmesini yönetir. `InMemoryDataStore` ise gerçek veritabanı kullanmadan kullanıcı ve duyuru bilgilerini bellekte saklar.

## 4. Kullanılan Tasarım Desenleri

### Observer Pattern

Observer Pattern şu yapılarda kullanılmıştır:

- `NotificationCenter`
- `IUserObserver`
- `StudentObserver`
- `TeacherObserver`

Bu desen, yeni bir duyuru yayınlandığında sisteme kayıtlı kullanıcıların otomatik olarak bilgilendirilmesi için kullanılmıştır. Öğrenci ve öğretmen kullanıcıları observer olarak sisteme abone edilir. Duyuru yayınlandığında `NotificationCenter` tüm kayıtlı observer kullanıcıları bilgilendirir.

### Factory Pattern

Factory Pattern şu sınıflarda kullanılmıştır:

- `AnnouncementFactory`
- `NotificationFactory`

Bu desen, duyuru ve bildirim nesnelerinin merkezi ve yönetilebilir şekilde oluşturulması için kullanılmıştır. Böylece uygulamanın farklı yerlerinde dağınık şekilde `new` kullanımı azaltılmıştır.

### Singleton Pattern

Singleton Pattern şu sınıfta kullanılmıştır:

- `NotificationCenter`

Bu desen, sistemde tek bir bildirim merkezi olması gerektiği için kullanılmıştır. Uygulama boyunca duyuru yayınlama ve observer kullanıcıları bilgilendirme işlemleri `NotificationCenter.Instance` üzerinden yürütülür.

## 5. Uygulama Arayüzü

Uygulama bir Windows Forms pencere uygulamasıdır. Form üzerinde kullanıcı ekleme, duyuru oluşturma, kayıtlı kullanıcıları görüntüleme ve bildirim loglarını takip etme bölümleri bulunur.

- Kullanıcı Ekleme Bölümü

  Bu bölümde kullanıcının ad soyad bilgisi, kullanıcı tipi ve bildirim tercihi seçilir. Kullanıcı tipi olarak öğrenci veya öğretmen seçilebilir. Bildirim tercihi olarak email, sms veya push seçenekleri kullanılabilir.

- Kayıtlı Kullanıcılar Bölümü

  Sisteme eklenen kullanıcılar DataGridView üzerinde listelenir. Listede kullanıcının adı soyadı, kullanıcı tipi ve bildirim tercihi gösterilir.

- Duyuru Oluşturma Bölümü

  Bu bölümde duyuru tipi, başlık ve içerik bilgileri girilir. Duyuru tipi olarak exam, event, food ve library seçenekleri kullanılabilir. Duyuru yayınlandığında sistem kayıtlı kullanıcıları otomatik olarak bilgilendirir.

- Bildirim Logları Bölümü

  Bildirim sonuçları RichTextBox alanında gösterilir. Uygulamada gerçek SMS veya e-posta gönderimi yapılmadığı için, gönderim sonucu metinsel olarak log alanına yazdırılır.

- Demo Senaryosu Butonu

  Demo senaryosu butonu örnek kullanıcıları sisteme ekler ve örnek duyuruları yayınlar. Böylece uygulamanın Observer, Factory ve Singleton desenleriyle nasıl çalıştığı hızlıca görülebilir.

## 6. Çalışan Senaryo

1. Kullanıcı formdan öğrenci veya öğretmen ekler.
2. Kullanıcının bildirim tercihi belirlenir.
3. Kullanıcı observer olarak `NotificationCenter`'a abone edilir.
4. Yönetici formdan duyuru tipi, başlık ve içerik girer.
5. `AnnouncementFactory` uygun duyuru nesnesini üretir.
6. `AnnouncementService` duyuruyu yayınlar.
7. `NotificationCenter` observer kullanıcıları bilgilendirir.
8. `NotificationFactory` uygun bildirim kanalını üretir.
9. Bildirim sonucu formdaki RichTextBox log alanında gösterilir.

## 7. Sınıf Yapısı

- `ExamAnnouncement`: Sınav duyurularını temsil eder.
- `EventAnnouncement`: Etkinlik duyurularını temsil eder.
- `FoodMenuAnnouncement`: Yemekhane duyurularını temsil eder.
- `LibraryAnnouncement`: Kütüphane duyurularını temsil eder.
- `StudentObserver`: Öğrenci kullanıcı tipini observer olarak temsil eder.
- `TeacherObserver`: Öğretmen kullanıcı tipini observer olarak temsil eder.
- `EmailNotification`: Email bildirim sonucunu metin olarak üretir.
- `SmsNotification`: SMS bildirim sonucunu metin olarak üretir.
- `PushNotification`: Push bildirim sonucunu metin olarak üretir.
- `AnnouncementFactory`: Duyuru tipine göre uygun duyuru nesnesini oluşturur.
- `NotificationFactory`: Bildirim tercihine göre uygun bildirim nesnesini oluşturur.
- `NotificationCenter`: Singleton bildirim merkezidir ve observer kullanıcıları bilgilendirir.
- `InMemoryDataStore`: Kullanıcı ve duyuruları bellek içinde saklar.
- `UserService`: Kullanıcı oluşturma, kaydetme ve abone etme işlemlerini yönetir.
- `AnnouncementService`: Duyuru oluşturma, kaydetme ve yayınlama işlemlerini yönetir.
- `MainForm`: Windows Forms arayüzünü ve kullanıcı etkileşimlerini yönetir.

## 8. Projeyi Çalıştırma

Projeyi terminal üzerinden derlemek için:

```bash
dotnet build
```

Projeyi çalıştırmak için:

```bash
dotnet run
```

Bu proje bir Windows Forms uygulaması olduğu için Visual Studio üzerinden de çalıştırılabilir. Visual Studio'da proje açıldıktan sonra çalıştır butonu ile uygulama penceresi başlatılabilir.

## 9. Yapay Zeka Kullanımı

Bu projede yapay zeka / Codex aşağıdaki amaçlarla kullanılmıştır:

- Katmanlı mimari iskeletini oluşturma
- Domain sınıflarını oluşturma
- Factory, Observer ve Singleton desenlerini uygulama
- Windows Forms arayüzünü düzenleme
- Kod temizliği ve hata kontrolü
- README hazırlama

## 10. Sonuç

Bu proje, ödevde istenen temel şartları karşılayan çalışan bir Windows Forms pencere uygulamasıdır. Projede Observer Pattern, Factory Pattern ve Singleton Pattern uygulanmıştır. Ayrıca katmanlı mimari, interface ve abstract class kullanımı, basit bellek içi veri yönetimi ve form üzerinde çalışan bildirim log sistemi yer almaktadır.

Uygulama sayesinde kampüs duyuruları oluşturulabilir, kullanıcılar sisteme eklenebilir ve duyurular kullanıcıların tercih ettiği bildirim kanalı üzerinden simüle edilerek RichTextBox log alanında gösterilebilir.
