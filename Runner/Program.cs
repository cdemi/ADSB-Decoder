using SBS_Decoder;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Runner
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (TcpClient adsbhubClient = new TcpClient("data.adsbhub.org", 5002))
            using (NetworkStream adsbNetworkStream = adsbhubClient.GetStream())
            using (StreamReader adsbStreamReader = new StreamReader(adsbNetworkStream))
            {
                processMessage(await adsbStreamReader.ReadLineAsync());
                while (!adsbStreamReader.EndOfStream)
                {
                    processMessage(await adsbStreamReader.ReadLineAsync());
                }
            }
        }

        private static void processMessage(string message)
        {
            var msg = Message.GetMessage(message);
            Console.WriteLine(msg.FlightID);
        }
    }
}
