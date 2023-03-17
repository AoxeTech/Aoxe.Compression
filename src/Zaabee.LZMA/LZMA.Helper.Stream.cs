namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream)
    {
        // Write the encoder properties
        Encoder.WriteCoderProperties(outputStream);

        // Write the decompressed file size.
        outputStream.Write(BitConverter.GetBytes(inputStream.Length), 0, 8);

        // Encode
        Encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        outputStream.Flush();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream)
    {
        // Read the decoder properties
        var properties = new byte[5];
        inputStream.Read(properties, 0, 5);
        Decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
        var fileLengthBytes = new byte[8];
        inputStream.Read(fileLengthBytes, 0, 8);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

        // Decode
        Decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        outputStream.Flush();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}