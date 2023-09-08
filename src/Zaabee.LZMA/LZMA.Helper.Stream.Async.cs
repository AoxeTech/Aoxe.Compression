using Decoder = SevenZip.Compression.LZMA.Decoder;
using Encoder = SevenZip.Compression.LZMA.Encoder;

namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static async ValueTask<MemoryStream> CompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await CompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask<MemoryStream> DecompressAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        var outputStream = new MemoryStream();
        await DecompressAsync(inputStream, outputStream, cancellationToken);
        return outputStream;
    }

    public static async ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
        var encoder = new Encoder();
        // Write the encoder properties
        encoder.WriteCoderProperties(outputStream);

        // Write the decompressed file size.
        await outputStream.WriteAsync(BitConverter.GetBytes(inputStream.Length), 0, 8, cancellationToken);

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        await outputStream.FlushAsync(cancellationToken);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default)
    {
        var decoder = new Decoder();
        // Read the decoder properties
        var properties = new byte[5];
#if NETSTANDARD2_0
        await inputStream.ReadAsync(properties, 0, 5, cancellationToken);
#else
        await inputStream.ReadAsync(properties.AsMemory(0, 5), cancellationToken);
#endif
        decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
        var fileLengthBytes = new byte[8];
#if NETSTANDARD2_0
        await inputStream.ReadAsync(fileLengthBytes, 0, 8, cancellationToken);
#else
        await inputStream.ReadAsync(fileLengthBytes.AsMemory(0, 8), cancellationToken);
#endif
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        await outputStream.FlushAsync(cancellationToken);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}