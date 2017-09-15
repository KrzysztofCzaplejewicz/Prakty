using System;
using System.Collections.Generic;

namespace Indexers
{
    public class HttpCookie
    {
        private readonly Dictionary<string, string> _dictionary;

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Krisku";
            Console.WriteLine(cookie["name"]);
            Console.Read();

        }
    }
}
