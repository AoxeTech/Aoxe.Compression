using Decoder = SevenZip.Compression.LZMA.Decoder;
using Encoder = SevenZip.Compression.LZMA.Encoder;

namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static MemoryStream Compress(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream);
        return outputStream;
    }

    public static MemoryStream Decompress(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(
        Stream inputStream,
        Stream outputStream)
    {
        var encoder = new Encoder();
        encoder.WriteCoderProperties(outputStream);
        outputStream.Write(BitConverter.GetBytes(inputStream.Length), 0, 8);
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        outputStream.Flush();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream)
    {
        var decoder = new Decoder();
        var properties = new byte[5];
        inputStream.Read(properties, 0, 5);
        decoder.SetDecoderProperties(properties);
        long outSize = 0;
        for (var i = 0; i < 8; i++)
        {
            var b = inputStream.ReadByte();
            outSize |= (long)(byte)b << (8 * i);
        }
        decoder.Code(inputStream, outputStream, inputStream.Length, outSize, null);
        outputStream.Flush();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}