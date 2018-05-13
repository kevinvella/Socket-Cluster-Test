using System;
using System.Diagnostics;
using ScClient;

namespace SocketClusterFormsApp.Services
{
	public class SocketClusterService
    {
        private Socket socket;
        public SocketClusterService()
        {
            try
            {
                socket = new Socket("ws://bbtest.eu-4.evennode.com/socketcluster/");

                socket.SetReconnectStrategy(new ReconnectStrategy().SetMaxAttempts(30));
                socket.SetSslCertVerification(false);
                //socket.SetAuthToken("12345678");

                socket.SetListerner(new SocketClusterListener());
                socket.Connect();
            }
            catch (Exception ex)
            {

            }

        }

        public Socket Socket
        {
            get => socket;
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }
    }

    public class SocketClusterListener : IBasicListener
    {
        private string TAG = "SocketCluster";
        public void OnConnected(Socket socket)
        {
            Debug.WriteLine($"{TAG} - connected got called");
        }

        public void OnDisconnected(Socket socket)
        {
            Debug.WriteLine($"{TAG} - disconnected got called");
        }

        public void OnAuthentication(Socket socket, bool status)
        {
            Debug.WriteLine(status ? $"{TAG} - Socket is authenticated" : $"{TAG} - Socket is not authenticated");
        }

        public void OnSetAuthToken(string token, Socket socket)
        {
            socket.SetAuthToken(token);
            Debug.WriteLine($"{TAG} - on set auth token got called");
        }

        public void OnConnectError(Socket socket, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Debug.WriteLine($"{TAG} - Error on Connection... {e.Exception}");
        }
    }
}
