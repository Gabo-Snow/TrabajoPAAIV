using Entidades;
using MVCVentas.Models;
using Newtonsoft.Json;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCVentas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //string apiUrl = "https://localhost:44375/api/Datos/GetIndicadores/uf";

            //WebClient webClient = new WebClient();
            //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");

            //var indicadores = JsonConvert.DeserializeObject<Models.IndicadoresModel>(webClient.DownloadString(apiUrl));

            //return View(indicadores);
            return View();
        }

        public ActionResult GetIndicadores()
        {
            Servicios.ServicioIndicadores servicioIndicadores = new Servicios.ServicioIndicadores();
            var indicadores = servicioIndicadores.GetListadoUF();


            return View(indicadores.serie);
        }

        [HttpGet]
        public ActionResult NuevaVenta()
        {
            ViewBag.formularioVisible = true;
            ViewBag.resultadosVisibles = false;

            Servicios.ServicioIndicadores servicioIndicadores = new Servicios.ServicioIndicadores();
            var indicadores = servicioIndicadores.GetValorUf();

            DatosVentaModel datosVentasModel = new DatosVentaModel
            {
                Fecha = System.DateTime.Now,
                ValorUfdia = indicadores.serie[0].valor
                
            };

            return View(datosVentasModel);
        }



        [HttpPost]
        public ActionResult NuevaVenta(DatosVentaModel datosVentaModel)
        {
            ViewBag.formularioVisible = true;
            ViewBag.resultadosVisibles = false;

            if (!ModelState.IsValid)
            {
                ViewBag.Estado = false;
                ViewBag.MensajeError = "";
                return View(datosVentaModel);
            }

            if (ModelState.IsValid)
            {
                ViewBag.formularioVisible = false;
                ViewBag.resultadosVisibles = true;

                Entidades.DatosVenta datosVenta = new Entidades.DatosVenta
                {
                    CodigoProducto = datosVentaModel.CodigoProducto,
                    Fecha = System.DateTime.Now,
                    NombreProducto = datosVentaModel.NombreProducto,
                    PrecioUnitarioUf = datosVentaModel.PrecioUnitarioUf,
                    UnidadesVenta = datosVentaModel.UnidadesVenta
                };

                Calculos.Calculos calculos = new Calculos.Calculos
                {
                    ValorUfDia = datosVentaModel.ValorUfdia,
                    UnidadesVenta = datosVentaModel.UnidadesVenta,
                    PrecioUnitarioUf = datosVentaModel.PrecioUnitarioUf
                };


                var totalVentaNetoUf = calculos.TotalVentaNetoUf(calculos.PrecioUnitarioUf, calculos.UnidadesVenta);
                var totalVentaNetoPesos = calculos.TotalVentaNetoPesos(totalVentaNetoUf, calculos.ValorUfDia);
                var montoIva = calculos.MontoIva(totalVentaNetoPesos, (float)0.19);
                var totalVentaLiquido = calculos.TotalVentaLiquido(totalVentaNetoPesos, montoIva);

                if (totalVentaLiquido > 0)
                {
                    DatosVentaModel datosVentaModel1 = new DatosVentaModel
                    {
                        CodigoProducto = datosVenta.CodigoProducto,
                        Fecha = datosVenta.Fecha,
                        MontoIva = montoIva,
                        NombreProducto = datosVenta.NombreProducto,
                        PrecioUnitarioUf = datosVenta.PrecioUnitarioUf,
                        TotalVentaLiquido = totalVentaLiquido,
                        TotalVentaNetoPesos = totalVentaNetoPesos,
                        TotalVentaNetoUf = totalVentaNetoUf,
                        UnidadesVenta = datosVenta.UnidadesVenta,
                        ValorUfdia = calculos.ValorUfDia
                    };

                    return View(datosVentaModel1);

                }

            }

            return View(datosVentaModel);

        }
               

        public ActionResult ValorUf()
        {
            ServicioIndicadores servicioIndicadores = new ServicioIndicadores();
            var valorUf = servicioIndicadores.GetValorUf();

            return View(valorUf);
        }

    }
}