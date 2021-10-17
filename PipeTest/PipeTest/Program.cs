using System;
using System.IO;
using System.IO.Pipes;

namespace PipeTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------CLIENT--------------");
            var client = new NamedPipeClientStream("PipesOfPices");
            Console.WriteLine("Client waiting connect.....");
            client.Connect();
            Console.WriteLine("Client connected to server.....!");
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);
            while (true)
            {
                Console.WriteLine("Client want: ");
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }
                writer.WriteLine(input);
                writer.Flush();
                Console.WriteLine("Server: " + reader.ReadLine());
            }
        }
    }
}
