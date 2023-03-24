namespace Zaabee.Zstd;

public static partial class ZstdHelper
{
    public static async Task<MemoryStream> CompressAsync(
        Stream inputStream,
        int level = Level,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, level, cancellationToken);
        return outputStream;
    }

    public static async Task<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        int level = Level,
        CancellationToken cancellationToken = default)
    {
        var inputBytes = await inputStream.ReadToEndAsync(cancellationToken: cancellationToken);
        var outputBytes = Compress(inputBytes, level);
#if NETSTANDARD2_0
        await outputStream.WriteAsync(outputBytes, 0, outputBytes.Length, cancellationToken);
#else
        await outputStream.WriteAsync(outputBytes, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
        var inputBytes = await inputStream.ReadToEndAsync(cancellationToken: cancellationToken);
        var outputBytes = Decompress(inputBytes);
#if NETSTANDARD2_0
        await outputStream.WriteAsync(outputBytes, 0, outputBytes.Length, cancellationToken);
#else
        await outputStream.WriteAsync(outputBytes, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}