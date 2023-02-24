namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static void ToLz4(this Stream rawStream, Stream outputStream) =>
        Lz4Helper.Compress(rawStream, outputStream);

    public static void UnLz4(this Stream compressedStream, Stream outputStream) =>
        Lz4Helper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToLz4(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        rawStream.ToLz4(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnLz4(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnLz4(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}