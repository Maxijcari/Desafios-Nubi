using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Desafio2.Models
{
    public class ResultModel
    {
        public List<Results> BuscarTermino(string term)
        {
            List<Results> myResultado = new List<Results>();
            string url = "https://api.mercadolibre.com/sites/MLA/search?q="+term;
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);

            foreach (var i in m)
            {

                switch (i.Name)
                {
                    case "results":
                        var resultado = i.First;
                        var listResultados = JsonConvert.DeserializeObject<List<Results>>(resultado.ToString());

                        myResultado = listResultados;
                        break;
                }
            }
            return myResultado;
        }
    }
}
