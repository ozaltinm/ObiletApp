using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ObiletApp.Converters;

public class PriceToStringConverter : JsonConverter<string>
{
    private static readonly CultureInfo TrCulture = new CultureInfo("tr-TR");

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // JSON'da sayı olarak gelen değeri oku
        var value = reader.GetDecimal();
        // "450,00 TL" formatında döndür
        return value.ToString("N2", TrCulture) + " TL";
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        // Eğer tekrar JSON'a string olarak yazmak istersen:
        writer.WriteStringValue(value);
    }
}