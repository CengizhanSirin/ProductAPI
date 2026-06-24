# 🚀 Product API - Clean Architecture (.NET 10)

Bu proje, **.NET 10** kullanılarak geliştirilmiş, **Clean Architecture** prensiplerine uygun bir **Web API** uygulamasıdır.
Amaç; sürdürülebilir, test edilebilir ve katmanlı bir yapı kurarak modern backend geliştirme pratiği kazanmaktır.

---

## 📌 Kullanılan Teknolojiler

* ✅ .NET 10 Web API
* ✅ Entity Framework Core
* ✅ Generic Repository Pattern
* ✅ Unit of Work Pattern
* ✅ AutoMapper
* ✅ FluentValidation
* ✅ Custom Action Filter
* ✅ Global Exception Handling (IExceptionHandler)
* ✅ Swagger (OpenAPI)

---

## 🧱 Proje Mimarisi

Proje **Clean Architecture** yaklaşımıyla katmanlara ayrılmıştır:

### 🔹 Core / Domain

* Entity modelleri (Product vb.)

### 🔹 Application

* DTO’lar (Request / Response / DTO)
* Service Interface’leri
* FluentValidation kuralları
* AutoMapper profilleri
* ServiceResult yapısı

### 🔹 Infrastructure

* EF Core DbContext
* Repository implementasyonları
* UnitOfWork implementasyonu

### 🔹 API

* Controller’lar
* CustomBaseController
* FluentValidationFilter
* GlobalExceptionHandler
* Program.cs (DI ve middleware config)

---

## ⚙️ Özellikler

### ✅ Generic Repository & Unit of Work

* Veri erişimi soyutlandı
* Transaction yönetimi merkezi hale getirildi

### ✅ DTO Kullanımı

* Entity’ler dış dünyaya açılmadı

### ✅ AutoMapper

* Mapping işlemleri otomatik hale getirildi

### ✅ FluentValidation

* Request doğrulamaları merkezi yönetildi
* Default validation kapatıldı, custom filter kullanıldı

### ✅ ServiceResult Pattern

* Tüm servis dönüşleri standartlaştırıldı

### ✅ Global Exception Handler

* Uygulama genelinde hatalar yakalanır ve standart response dönülür

---

## 🔗 API Endpointleri

### 📍 Products

| Method | Endpoint                              | Açıklama               |
| ------ | ------------------------------------- | ---------------------  |
| GET    | /api/products                         | Tüm ürünleri getir     |
| GET    | /api/products/{id}                    | Id’ye göre ürün getir  |
| POST   | /api/products                         | Yeni ürün oluştur      |
| PUT    | /api/products/{id}                    | Ürün güncelle          |
| DELETE | /api/products/{id}                    | Ürün sil               |
| GET    | /api/products/{pageNumber}/{pageSize} | Sayfalı ürünleri getir |
---

## 🧪 Test

Swagger üzerinden test edilebilir:

👉 `/swagger`

---

## 📦 Örnek Response

### ✅ Başarılı

```json
{
  "data": {
    "id": 1,
    "name": "Kalem",
    "price": 10
  }
}
```

### ❌ Hatalı

```json
{
  "errorMessages": [
    "Product not found."
  ]
}
```

---

## 🧠 Geliştirme Notları

Bu proje öğrenme amaçlı geliştirilmiştir.
İlerleyen versiyonlarda eklenebilir:

* Pagination response modeli
* Logging (Serilog)
* JWT Authentication
* Caching (Redis)

---

## 👨‍💻 Geliştirici

Cengizhan Şirin
