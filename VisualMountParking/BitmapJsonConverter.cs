using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Drawing.Imaging;

namespace ChekMountPosition
{
	public class BitmapJsonConverter : JsonConverter<Bitmap>
	{
		public override Bitmap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var txt = reader.GetString();
			var bytes = Convert.FromBase64String(txt);
			var ms = new MemoryStream();
			ms.Write(bytes, 0, bytes.Length);
			ms.Position = 0;
			return (Bitmap)Image.FromStream(ms);
		}

		public override void Write(Utf8JsonWriter writer, Bitmap value, JsonSerializerOptions options)
		{
			var ms = new MemoryStream();
			value.Save(ms, ImageFormat.Png);
			var txt = Convert.ToBase64String(ms.ToArray());
			writer.WriteStringValue(txt);
		}
	}
}
