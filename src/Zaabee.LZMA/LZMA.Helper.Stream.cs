namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static void Compress(Stream inputStream, Stream outputStream)
    {
        using MemoryStream inputMemory = new MemoryStream();
        inputStream.CopyTo(inputMemory);
        inputStream.Flush();
        inputMemory.Flush();
        inputMemory.Position = 0;

        var encoder = new Encoder();

        // Write the encoder properties
        encoder.WriteCoderProperties(outputStream);

        // Write the decompressed file size.
        outputStream.Write(BitConverter.GetBytes(inputMemory.Length), 0, 8);

        // Encode
        encoder.Code(inputMemory, outputStream, inputMemory.Length, -1, null);
        outputStream.Flush();
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        using MemoryStream inputMemory = new MemoryStream();
        inputStream.CopyTo(inputMemory);
        inputStream.Flush();
        inputMemory.Flush();
        inputMemory.Position = 0;

        var decoder = new Decoder();

        // Read the decoder properties
        var properties = new byte[5];
        inputMemory.Read(properties, 0, 5);
        decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
        var fileLengthBytes = new byte[8];
        inputMemory.Read(fileLengthBytes, 0, 8);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

        // Decode
        decoder.Code(inputMemory, outputStream, inputMemory.Length, fileLength, null);
        outputStream.Flush();
    }
}