#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static void ToBrotli(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => BrotliHelper.Compress(rawStream, outputStream, compressionLevel);

    public static void UnBrotli(this Stream compressedStream, Stream outputStream) =>
        BrotliHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToBrotli(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => BrotliHelper.Compress(rawStream, compressionLevel);

    public static MemoryStream UnBrotli(this Stream compressedStream) =>
        BrotliHelper.Decompress(compressedStream);
}
#endif
