namespace Zaabee.Compressor.UnitTest;

public class LeaveOpenTest
{
     [Theory]
     [InlineData(true)]
     [InlineData(false)]
     public void BrotliIsKeepOpenTest(bool leaveOpen) =>
          IsKeepOpenTest(new BrotliCompressor(), leaveOpen);

     [Theory]
     [InlineData(true)]
     [InlineData(false)]
     public void Lz4IsKeepOpenTest(bool leaveOpen) =>
          IsKeepOpenTest(new Lz4Compressor(), leaveOpen);

     [Theory]
     [InlineData(true)]
     [InlineData(false)]
     public void Bzip2IsKeepOpenTest(bool leaveOpen) =>
          IsKeepOpenTest(new Bzip2Compressor(), leaveOpen);

     [Theory]
     [InlineData(true)]
     [InlineData(false)]
     public void GzipIsKeepOpenTest(bool leaveOpen) =>
          IsKeepOpenTest(new GzipCompressor(), leaveOpen);

     private void IsKeepOpenTest(ICompressor compressor, bool leaveOpen)
     {
          var compressedStream = new MemoryStream();
          compressor.Compress(new MemoryStream(Consts.Data), compressedStream, leaveOpen);
          Assert.Equal(leaveOpen, compressedStream.CanWrite);
          var decompressedStream = new MemoryStream();
          var reCompressedStream = new MemoryStream(compressedStream.ToArray());
          compressor.Decompress(reCompressedStream, decompressedStream, leaveOpen);
          Assert.Equal(leaveOpen, reCompressedStream.CanWrite);
          var decompressedBytes = decompressedStream.ToArray();
          Assert.Equal(Consts.Data, decompressedBytes);
     }
}