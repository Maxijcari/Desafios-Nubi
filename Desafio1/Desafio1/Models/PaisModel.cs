using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Desafio1.Models
{
    public class PaisModel
    {
        //Crear Lista Paises

        List<Paises> LPaises = new List<Paises>();
        Paises myPais = new Paises();
        public List<Paises>  GetPaises()
        {
            Paises p = new Paises { id = "AR", name = "Argentina", locale = "es_AR", currency_id = "ARS" };
            this.LPaises.Add(p);
            p = new Paises { id = "BO", name = "Bolivia", locale = "es_BO", currency_id = "BOB" };
            this.LPaises.Add(p);
            p = new Paises { id = "BR", name = "Brasil", locale = "pt_BR", currency_id = "BRL" };
            this.LPaises.Add(p);
            p = new Paises { id = "CL", name = "Chile", locale = "es_CL", currency_id = "CLP" };
            this.LPaises.Add(p);
            p = new Paises { id = "CN", name = "China", locale = "zh_CN", currency_id = "CNY" };
            this.LPaises.Add(p);
            p = new Paises { id = "CO", name = "Colombia", locale = "es_CO", currency_id = "COP" };
            this.LPaises.Add(p);
            p = new Paises { id = "CR", name = "Costa Rica", locale = "es_CR", currency_id = "CRC" };
            this.LPaises.Add(p);
            p = new Paises { id = "CBT", name = "Cross Border Trade", locale = "es_AR", currency_id = "ARS" };
            this.LPaises.Add(p);
            p = new Paises { id = "EC", name = "Ecuador", locale = "es_EC", currency_id = "USD" };
            this.LPaises.Add(p);
            p = new Paises { id = "SV", name = "El Salvador", locale = "es_SV", currency_id = "USD" };
            this.LPaises.Add(p);
            p = new Paises { id = "GT", name = "Guatemala", locale = "es_GT", currency_id = "GTO" };
            this.LPaises.Add(p);
            p = new Paises { id = "HN", name = "Honduras", locale = "es_HN", currency_id = "HNL" };
            this.LPaises.Add(p);
            p = new Paises { id = "MX", name = "Mexico", locale = "es_MX", currency_id = "MXN" };
            this.LPaises.Add(p);
            p = new Paises { id = "NI", name = "Nicaragua", locale = "es_NI", currency_id = "NIO" };
            this.LPaises.Add(p);
            p = new Paises { id = "PA", name = "Panamá", locale = "es_PA", currency_id = "USD" };
            this.LPaises.Add(p);
            p = new Paises { id = "PY", name = "Paraguay", locale = "es_PY", currency_id = "PYG" };
            this.LPaises.Add(p);
            p = new Paises { id = "PE", name = "Peru", locale = "es_PE", currency_id = "PEN" };
            this.LPaises.Add(p);
            p = new Paises { id = "PT", name = "Portugal", locale = "pt_PT", currency_id = "EUR" };
            this.LPaises.Add(p);
            p = new Paises { id = "PR", name = "Puerto Rico", locale = "es_PR", currency_id = "USD" };
            this.LPaises.Add(p);
            p = new Paises { id = "GB", name = "Reino Unido", locale = "en_GB", currency_id = "GBP" };
            this.LPaises.Add(p);
            p = new Paises { id = "DO", name = "Republica Dominicana", locale = "es_DO", currency_id = "DOP" };
            this.LPaises.Add(p);
            p = new Paises { id = "UY", name = "Uruguay", locale = "es_UY", currency_id = "UYU" };
            this.LPaises.Add(p);
            p = new Paises { id = "VE", name = "Venezuela", locale = "es_VE", currency_id = "VES" };
            this.LPaises.Add(p);
            p = new Paises { id = "COL", name = "newCOL", locale = "es_COL", currency_id = "COLS" };
            this.LPaises.Add(p);

            return LPaises;
        }

        public Paises BuscarPais(string id)
        {
            Pais p = new Pais();

            if (id.Equals("CO")|| id.Equals("BR"))
            {
                //Faltó responder con error 401
            }
           
            if (id.Equals("AR"))
            {
                string url = "https://api.mercadolibre.com/classified_locations/countries/"+id;
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                
                foreach (var i in m)
                {

                    switch (i.Name)
                    {
                        case "id":
                            p.id = i.First;
                            break;
                        case "name":
                            p.name = i.First;
                            break;
                        case "locale":
                            p.locale = i.First;
                            break;
                        case "currency_id":
                            p.currency_id = i.First;
                            break;
                        case "decimal_separator":
                            p.decimal_separator = i.First;
                            break;
                        case "thousands_separator":
                            p.thousands_separator = i.First;
                            break;
                        case "time_zone":
                            p.time_zone = i.First;
                            break;
                        case "geo_information":
                            Location location = new Location();
                            foreach (var j in i.First) {
                                switch (j.Name) 
                                {
                                    case "location":
                                        foreach (var k in j.First)
                                        {
                                            switch (k.Name) 
                                            {
                                                case "latitude":
                                                    location.latitude = k.First;
                                                    break;
                                                case "longitude":
                                                    location.longitude = k.First;
                                                    break;
                                            }
                                        }
                                        break;
                                }
                                p.geo_information = location;
                            }
                            break;
                        case "states":
                            List<States> states = new List<States>();
                            
                            var estados = i.First;
                            var listEstados = JsonConvert.DeserializeObject <List<States>>(estados.ToString());
                            
                            p.states= listEstados;
                            break;
                    }
                }

            }else
            {
                Paises MyPais = this.GetPaises().Find(myPais => myPais.id.Equals(id));
            }

            return p;
        }
    }
}
