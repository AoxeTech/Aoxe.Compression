namespace Aoxe.Snappy;

public static partial class SnappyHelper
{
    public static MemoryStream Compress(Stream inputStream)
    {
        var rawBytes = inputStream.ReadToEnd();
        var compressedBytes = IronSnappy.Snappy.Encode(rawBytes);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return new MemoryStream(compressedBytes);
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var compressedBytes = inputStream.ReadToEnd();
        var rawBytes = IronSnappy.Snappy.Decode(compressedBytes);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return new MemoryStream(rawBytes);
    }

    public static void Compress(Stream inputStream, Stream outputStream)
    {
        var rawBytes = inputStream.ReadToEnd();
        var compressedBytes = IronSnappy.Snappy.Encode(rawBytes);
        outputStream.Write(compressedBytes, 0, compressedBytes.Length);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        var compressedBytes = inputStream.ReadToEnd();
        var rawBytes = IronSnappy.Snappy.Decode(compressedBytes);
        outputStream.Write(rawBytes, 0, rawBytes.Length);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
