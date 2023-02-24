namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        using var inputStream = new MemoryStream(rawBytes);
        using var outputStream = new MemoryStream();
        var encoder = new Encoder();

        // Write the encoder properties
        encoder.WriteCoderProperties(outputStream);

        // Write the decompressed file size.
        outputStream.Write(BitConverter.GetBytes(inputStream.Length), 0, 8);

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        outputStream.Flush();

        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var outputStream = new MemoryStream();
        var decoder = new Decoder();

        // Read the decoder properties
        var properties = new byte[5];
        inputStream.Read(properties, 0, 5);
        decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
        var fileLengthBytes = new byte[8];
        inputStream.Read(fileLengthBytes, 0, 8);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        outputStream.Flush();

        return outputStream.ToArray();
    }
    
    
}