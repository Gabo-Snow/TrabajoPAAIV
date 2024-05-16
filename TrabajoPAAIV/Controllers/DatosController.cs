using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace TrabajoPAAIV.Controllers
{
    public class DatosController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        [Route("api/Datos/GetIndicadores/{tipoIndicador}")]
        public IHttpActionResult GetIndicadores(string tipoIndicador)
        {
            string apiUrl = "https://mindicador.cl/api";

            string fecha = System.DateTime.Now.ToString("dd-MM-yyy");

            if (tipoIndicador.ToLower().Equals("uf"))
            {
                apiUrl = $"https://mindicador.cl/api/{tipoIndicador.ToLower()}/{fecha}";
            }

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var indicadores = JsonConvert.DeserializeObject<Models.Indicadores>(webClient.DownloadString(apiUrl));

            return Ok(indicadores);
        }

        [Route("api/Datos/GetIndicadores/uf/{fecha}")]
        public IHttpActionResult GetValorUf ()
        {
            string fecha = System.DateTime.Now.ToString("dd-MM-yyy");

            string apiUrl = $"https://mindicador.cl/api/uf/{fecha}"; 

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            var valorUf = JsonConvert.DeserializeObject<Models.Indicadores>(webClient.DownloadString(apiUrl));
                       

            return Ok(valorUf);
        }


    }
}