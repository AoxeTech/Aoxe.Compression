#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibExtensions
{
    public static void ToZLib(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => ZLibHelper.Compress(rawStream, outputStream, compressionLevel);

    public static void UnZLib(this Stream compressedStream, Stream outputStream) =>
        ZLibHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToZLib(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => ZLibHelper.Compress(rawStream, compressionLevel);

    public static MemoryStream UnZLib(this Stream compressedStream) =>
        ZLibHelper.Decompress(compressedStream);
}
#endif
