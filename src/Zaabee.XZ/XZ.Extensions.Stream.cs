namespace Zaabee.XZ;

public static partial class XzExtensions
{
    public static void ToXz(
        this Stream rawStream,
        Stream outputStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        bool levelOpen = XzHelper.LevelOpen) =>
        XzHelper.Compress(rawStream, outputStream, threads, preset, levelOpen);

    public static void UnXz(
        this Stream compressedStream,
        Stream outputStream,
        bool levelOpen = XzHelper.LevelOpen) =>
        XzHelper.Decompress(compressedStream, outputStream, levelOpen);

    public static MemoryStream ToXz(
        this Stream rawStream,
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset,
        bool levelOpen = XzHelper.LevelOpen) =>
        XzHelper.Compress(rawStream);

    public static MemoryStream UnXz(
        this Stream compressedStream,
        bool levelOpen = XzHelper.LevelOpen) =>
        XzHelper.Decompress(compressedStream, levelOpen);
}