namespace Zaabee.Zstd;

public static partial class ZstdExtensions
{
    public static void ToZstd(
        this Stream rawStream,
        Stream outputStream,
        int level = ZstdHelper.Level
    ) => ZstdHelper.Compress(rawStream, outputStream, level);

    public static void UnZstd(this Stream compressedStream, Stream outputStream) =>
        ZstdHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToZstd(this Stream rawStream, int level = ZstdHelper.Level) =>
        ZstdHelper.Compress(rawStream, level);

    public static MemoryStream UnZstd(this Stream compressedStream) =>
        ZstdHelper.Decompress(compressedStream);
}
