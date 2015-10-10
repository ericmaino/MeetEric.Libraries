using System;
using System.Net;
using System.Threading.Tasks;

namespace MeetEric.Networking
{
    public interface INetworkClient<T> : IDisposable
    {
        int LocalPort { get; }
        Task Bind();
        Task SendMessage(IPAddress endpoint, T content);
    }
}