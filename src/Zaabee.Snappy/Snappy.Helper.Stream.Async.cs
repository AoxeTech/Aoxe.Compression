namespace Zaabee.Snappy;

public static partial class SnappyHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var rawBytes = await inputStream.ReadToEndAsync(cancellationToken);
        var compressedBytes = IronSnappy.Snappy.Encode(rawBytes);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return new MemoryStream(compressedBytes);
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadToEndAsync(cancellationToken);
        var rawBytes = IronSnappy.Snappy.Decode(compressedBytes);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return new MemoryStream(rawBytes);
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
        var rawBytes = await inputStream.ReadToEndAsync(cancellationToken);
        var compressedBytes = IronSnappy.Snappy.Encode(rawBytes);
#if NETSTANDARD2_0
        await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken);
#else
        await outputStream.WriteAsync(compressedBytes, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadToEndAsync(cancellationToken);
        var rawBytes = IronSnappy.Snappy.Decode(compressedBytes);
#if NETSTANDARD2_0
        await outputStream.WriteAsync(rawBytes, 0, rawBytes.Length, cancellationToken);
#else
        await outputStream.WriteAsync(rawBytes, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}