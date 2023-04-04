namespace Zaabee.XZ;

public static partial class XzHelper
{
    public static async Task<MemoryStream> CompressAsync(
        Stream inputStream,
        int threads = Threads,
        uint preset = Preset,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, threads, preset, cancellationToken);
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
        int threads = Threads,
        uint preset = Preset,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var xzOutputStream = new XZOutputStream(outputStream, threads, preset, true))
            await inputStream.CopyToAsync(xzOutputStream);
#else
        await using (var xzOutputStream = new XZOutputStream(outputStream, threads, preset, true))
            await inputStream.CopyToAsync(xzOutputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using (var xzInputStream = new XZInputStream(inputStream, true))
            await xzInputStream.CopyToAsync(outputStream);
#else
        await using (var xzInputStream = new XZInputStream(inputStream, true))
            await xzInputStream.CopyToAsync(outputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}