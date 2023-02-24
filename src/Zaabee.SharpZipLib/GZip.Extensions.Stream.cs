namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static void ToGZip(this Stream rawStream, Stream outputStream)
    {
        GzipHelper.Compress(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void UnGZip(this Stream compressedStream, Stream outputStream)
    {
        GzipHelper.Decompress(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static TStream ToGZip<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        GzipHelper.Compress(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static TStream UnGZip<TStream>(this Stream compressedStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        GzipHelper.Decompress(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}