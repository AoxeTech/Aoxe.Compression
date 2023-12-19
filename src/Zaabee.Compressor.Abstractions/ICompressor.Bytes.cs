namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    byte[] Compress(byte[] rawBytes);
    byte[] Decompress(byte[] compressedBytes);
}
