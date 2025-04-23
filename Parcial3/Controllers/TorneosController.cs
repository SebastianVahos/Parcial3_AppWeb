using Parcial3.Clases;
using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial3.Controllers
{
    [RoutePrefix("api/Torneo")]
    public class TorneosController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public string Ingresar([FromBody] Torneo torneo)
        {
            clsTorneos Torneo = new clsTorneos();
            Torneo.torneos = torneo;
            return Torneo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            clsTorneos Torneo = new clsTorneos();
            Torneo.torneos = torneo;
            return Torneo.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXid")]
        public string EliminarXid(int id)
        {
            clsTorneos Torneo = new clsTorneos();
            return Torneo.Eliminar(id);
        }

        [HttpGet]
        [Route("ConsultarXtipo")]
        public Torneo ConsultarXtipo(string tipoTorneo)
        {
            clsTorneos Torneo = new clsTorneos();
            return Torneo.ConsultarPorTipo(tipoTorneo);
        }

        [HttpGet]
        [Route("ConsultarXnombre")]
        public Torneo ConsultarXnombre(string nombreTorneo)
        {
            clsTorneos Torneo = new clsTorneos();
            return Torneo.ConsultarPorNombre(nombreTorneo);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public Torneo ConsultarXFecha(DateTime fecha)
        {
            clsTorneos Torneo = new clsTorneos();
            return Torneo.ConsultarPorFecha(fecha);
        }
    }
}