﻿#if !NETSTANDARD2_0
namespace Aoxe.SystemIoCompression;

public static partial class BrotliHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, compressionLevel, cancellationToken);
        return outputStream;
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal,
        CancellationToken cancellationToken = default
    )
    {
        await using (
            var brotliOutputStream = new BrotliStream(outputStream, compressionLevel, true)
        )
            await inputStream.CopyToAsync(brotliOutputStream, cancellationToken);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    )
    {
        await using (
            var brotliInputStream = new BrotliStream(inputStream, CompressionMode.Decompress, true)
        )
            await brotliInputStream.CopyToAsync(outputStream, cancellationToken);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
#endif
