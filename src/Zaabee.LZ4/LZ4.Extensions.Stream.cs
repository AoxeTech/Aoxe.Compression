﻿namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static void ToLz4(
        this Stream rawStream,
        Stream outputStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory,
        bool leaveOpen = Lz4Helper.LeaveOpen) =>
        Lz4Helper.Compress(rawStream, outputStream, level, extraMemory, leaveOpen);

    public static void UnLz4(
        this Stream compressedStream,
        Stream outputStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool leaveOpen = Lz4Helper.LeaveOpen,
        bool interactive = Lz4Helper.Interactive) =>
        Lz4Helper.Decompress(compressedStream, outputStream, settings, leaveOpen, interactive);

    public static MemoryStream ToLz4(
        this Stream rawStream,
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory)
    {
        var outputStream = new MemoryStream();
        rawStream.ToLz4(outputStream, level, extraMemory, true);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnLz4(
        this Stream compressedStream,
        LZ4DecoderSettings? settings = Lz4Helper.Settings,
        bool interactive = Lz4Helper.Interactive)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnLz4(outputStream, settings, true, interactive);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}