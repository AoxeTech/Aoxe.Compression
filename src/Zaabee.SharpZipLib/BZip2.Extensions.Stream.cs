namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static void ToBZip2(this Stream rawStream, Stream outputStream)
    {
        Bzip2Helper.Compress(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void UnBZip2(this Stream compressedStream, Stream outputStream)
    {
        Bzip2Helper.Decompress(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static TStream ToBZip2<TStream>(this Stream rawStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        Bzip2Helper.Compress(rawStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static TStream UnBZip2<TStream>(this Stream compressedStream)
        where TStream : Stream, new()
    {
        var outputStream = new TStream();
        Bzip2Helper.Decompress(compressedStream, outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}