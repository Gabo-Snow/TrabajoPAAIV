using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioIndicadores
    {
        public Entidades.Indicadores GetListadoUF()
        {
            string apiUrl = "https://localhost:44375/api/Datos/GetIndicadores/uf";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var indicadores = JsonConvert.DeserializeObject<Entidades.Indicadores>(webClient.DownloadString(apiUrl));

            return indicadores;
        }

        public Entidades.Indicadores GetValorUf()
        {
            string fecha = System.DateTime.Now.ToString("dd-MM-yyyy");
            string apiUrl = $"https://localhost:44375/api/Datos/GetIndicadores/uf/{fecha}";

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var valorUf = JsonConvert.DeserializeObject<Entidades.Indicadores>(webClient.DownloadString(apiUrl));


            return valorUf;
        }
    }
}
