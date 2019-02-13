using System;

namespace AplicacionConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console program started. Press a key to call the web service");
            Console.ReadKey();
            Console.WriteLine("Calling to the service...");
            var programa = new ServiceClientAuthors();
            var listado = programa.GetAuthors();
            foreach (var elem in listado)
            {
                Console.WriteLine($"Name:{elem.Name}");
            }
            Console.WriteLine("\nEnd of Console program");
            Console.ReadKey();
        }
    }
}
