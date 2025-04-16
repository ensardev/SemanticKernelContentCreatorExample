# Semantic Kernel Blog Content Generator

Bu proje, Microsoft'un Semantic Kernel framework'ünü kullanarak otomatik blog içeriği üretmeyi sağlayan bir konsol uygulamasıdır. DeepSeek LLM API ile entegre çalışarak, belirtilen konuda başlık, içerik ve SEO anahtar kelimeleri oluşturur.

## Özellikler

- Özelleştirilebilir içerik konusu, tonu ve dili
- Ayarlanabilir minimum ve maksimum kelime sayısı
- SEO odaklı başlık üretimi
- Markdown formatında detaylı blog içeriği
- İlgili SEO anahtar kelimeleri listesi
- DeepSeek AI modeli ile entegrasyon

## Gereksinimler

- DeepSeek API anahtarı
- Semantic Kernel paketi

## Kurulum

1. Projeyi klonlayın
   ```
   git clone https://github.com/ensardev/SemanticKernelContentCreatorExample.git
   cd SemanticKernelContentCreatorExample
   cd SemanticKernelContentCreatorExample.APP
   ```

2. Gerekli paketleri yükleyin
   ```
   dotnet restore
   ```

3. Projeyi derleyin
   ```
   dotnet build
   ```

## Kullanım

1. Uygulamayı çalıştırın
   ```
   dotnet run
   ```

2. İstendiğinde aşağıdaki bilgileri girin:
   - DeepSeek API anahtarınız
   - İçerik konusu
   - İçerik tonu (profesyonel, samimi vb.)
   - İçerik dili (Türkçe, İngilizce vb.)
   - Minimum kelime sayısı
   - Maksimum kelime sayısı

3. Uygulama, belirtilen kriterlere göre blog başlığı, içeriği ve SEO anahtar kelimelerini üretecektir.

## Örnek Çıktı

```
Title:
Semantic Kernel: AI Entegrasyonunun Geleceği

Content:
# Semantic Kernel: AI Entegrasyonunun Geleceği

Günümüzde yapay zeka teknolojileri hızla gelişirken, bu teknolojileri...
[İçerik devam eder]

SEO Keywords:
semantic kernel, microsoft yapay zeka, ai entegrasyonu, llm entegrasyonu, yapay zeka geliştirme kiti, ai uygulama geliştirme, c# yapay zeka, python ai entegrasyonu
```

## Özelleştirme

Prompt şablonlarını kendi ihtiyaçlarınıza göre düzenleyebilirsiniz:

```csharp
string titlePrompt = $"""
    <message role="system">You are a professional content creator</message>
    <message role="user">For a blog post in {language}, in {tone}, on the topic '{topic}':
    - Catchy title
    - Maximum 10 words
    - SEO optimized
    - No emoji</message>
    """;
```
