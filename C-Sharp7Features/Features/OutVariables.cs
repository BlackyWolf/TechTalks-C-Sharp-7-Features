using System;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Features
{
    public class OutVariables : IRun
    {
        public void Run()
        {
            Connections connection = Connections.Http,
                        otherConnection = Connections.Udp;

            string otherAddress;

            int otherPort;

            // 1. OutMethod using predefined variables
            OutMethod(otherConnection, out otherAddress, out otherPort);

            Console.WriteLine("{0} - {1}:{2}", otherConnection, otherAddress, otherPort);

            // 2. OutMethod using out variables
            OutMethod(connection, out string address, out var port);

            Console.WriteLine($"{connection} - {address}:{port}");

            Console.WriteLine($"{int.TryParse("1000", out var number)} - {number}");

            // 3. Out Variable scope
            if (int.TryParse("1e000", out int anotherNumber))
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine($"{anotherNumber}");

            // 4. Ignoring certain out variables
            OutMethod(Connections.Tcp, out string someAddress, out _);
            OutMethod(Connections.Smtp, out _, out int somePort);

            Console.WriteLine($"{someAddress}:{somePort}");
        }

        private void OutMethod(Connections connection, out string address, out int port)
        {
            switch (connection)
            {
                case Connections.Http:
                    address = "http://myadress.com";
                    port = 80;

                    break;
                case Connections.Tcp:
                    address = "tcp://10.0.0.1";
                    port = 5000;

                    break;
                case Connections.Udp:
                    address = "udp://10.0.0.1";
                    port = 5001;

                    break;
                case Connections.Sftp:
                    address = "sftp.mylocal.net";
                    port = 22;

                    break;
                case Connections.Smtp:
                    address = "smtp.mymail.org";
                    port = 465;

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(connection), connection, null);
            }
        }

        public enum Connections
        {
            Http,
            Tcp,
            Udp,
            Sftp,
            Smtp
        }
    }
}