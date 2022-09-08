using System;
using System.Net; // Para poder trabajar con peticiones HTTP
using Newtonsoft.Json; // Para poder traducir los objetos JSON a C#

namespace getrequest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string API_URL = "https://jsonplaceholder.typicode.com/posts?_limit=5"; // Servidor donde voy a pedir datos
            var client = new WebClient(); // Cliente que hace la misma petición del navegador - Permite obtener un Objeto
            var json = client.DownloadString(API_URL); // Me trae los datos en formato JSON
            Console.WriteLine(json);

            Console.WriteLine("***** Iterando por cada objeto *****\n");

            dynamic posts = JsonConvert.DeserializeObject(json); //  Devuelve un objeto personalizado a partir de datos JSON.

            foreach (var post in posts)
            {
                Console.WriteLine(post.id + ": " + post.title);
            }
        }
    }
}