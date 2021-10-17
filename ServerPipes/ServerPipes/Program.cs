using System;
using System.IO.Pipes;
using System.IO;

namespace ServerPipes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------SERVER----------------");
            var server = new NamedPipeServerStream("PipesOfPices");
            Console.WriteLine("Server waiting connect....");
            server.WaitForConnection();
            Console.WriteLine("Server connected to client!");

            //Đọc hoặc nhận thông điệp từ server
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
                //Nhận thông điệp từ client
                Console.WriteLine("Client:" + reader.ReadLine());
                Console.Write("Server want: ");
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }
                writer.WriteLine(input);
                writer.Flush();
            }
        }
    }
}
