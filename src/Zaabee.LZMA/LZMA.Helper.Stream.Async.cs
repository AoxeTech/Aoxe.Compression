namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static async Task CompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
        // Write the encoder properties
        Encoder.WriteCoderProperties(outputStream);

        // Write the decompressed file size.
#if NETSTANDARD2_0
        await outputStream.WriteAsync(BitConverter.GetBytes(inputStream.Length), 0, 8);
#else
        await outputStream.WriteAsync(BitConverter.GetBytes(inputStream.Length).AsMemory(0, 8));
#endif

        // Encode
        Encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        await outputStream.FlushAsync();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream)
    {
        // Read the decoder properties
        var properties = new byte[5];
#if NETSTANDARD2_0
        await inputStream.ReadAsync(properties, 0, 5);
#else
        await inputStream.ReadAsync(properties.AsMemory(0, 5));
#endif
            Decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
        var fileLengthBytes = new byte[8];
#if NETSTANDARD2_0
        await inputStream.ReadAsync(fileLengthBytes,0, 8);
#else
        await inputStream.ReadAsync(fileLengthBytes.AsMemory(0, 8));
#endif
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

        // Decode
        Decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        await outputStream.FlushAsync();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}