using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MeetEric.Storage
{
    public static class IO
    {
        public static async Task<IBuffer> ToBuffer(this IRandomAccessStream stream)
        {
            stream.Seek(0);
            var buffer = new Windows.Storage.Streams.Buffer((uint)stream.Size);
            await stream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.None);
            return buffer;
        }

        public static async Task CopyToOutputStream(this IRandomAccessStream stream, IOutputStream output)
        {
            var buffer = await stream.ToBuffer();
            await output.WriteAsync(buffer);
        }

        public static async Task CopyToStorageFile(this IRandomAccessStream stream, IStorageFile file)
        {
            var buffer = await stream.ToBuffer();
            await FileIO.WriteBufferAsync(file, buffer);
        }
    }
}