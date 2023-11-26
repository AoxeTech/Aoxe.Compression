namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static void ToXz(
        this Stream rawStream,
        Stream outputStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset
    ) => XzHelper.Compress(rawStream, outputStream, threads, preset);

    public static void UnXz(this Stream compressedStream, Stream outputStream) =>
        XzHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToXz(
        this Stream rawStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset
    ) => XzHelper.Compress(rawStream);

    public static MemoryStream UnXz(this Stream compressedStream) =>
        XzHelper.Decompress(compressedStream);
}
