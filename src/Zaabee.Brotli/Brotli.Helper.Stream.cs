namespace Zaabee.Brotli;

public static partial class BrotliHelper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        uint quality = Quality,
        uint window = Window)
    {
        using (var brotliStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
        {
            brotliStream.SetQuality(quality);
            brotliStream.SetWindow(window);
            inputStream.CopyTo(brotliStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream)
    {
        using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, true))
            brotliStream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}