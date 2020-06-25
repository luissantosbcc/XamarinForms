using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App2.Services.Models;
using Newtonsoft.Json;

namespace App2.Services
{
    public class Search
    {
        private static string EnderecoURL = "http://www.omdbapi.com/?t={0}&apikey=2d4ef165";

        public static Movies BuscarEndereco(String movie)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, movie);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Movies end = JsonConvert.DeserializeObject<Movies>(Conteudo);

            if (end.Response == "False") return null;

            return end;
        }
    }
}
