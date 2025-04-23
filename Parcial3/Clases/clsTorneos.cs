using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parcial3.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Parcial3.Clases
{
    public class clsTorneos
    {
        private DBExamenEntities dbexamen = new DBExamenEntities();
        public Torneo torneo { get; set; }

        public string Insertar()
        {
            try
            {
                dbexamen.Torneos.Add(torneo);
                dbSuper.SaveChanges();//guardar los cambios en la bd 
                return "Torneo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el torneo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Torneo torneo = ConsultarPorId(torneo.idTorneos);
                if (torneo == null)
                {
                    return "El torneo con el id ingresado no existe, no se puede actualizar";
                }
                //El empleado existe lo podemos actualizar
                dbexamen.Torneos.AddOrUpdate(torneo);
                dbexamen.SaveChanges();//guardar los cambios en la bd
                return "Se actualizó el torneo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el torneo: " + ex.Message;

            }
        }

        public List<Torneo> ConsultarTodos()
        {
            return dbexamen.Torneos
                .ToList();//tolist es una funcion que convierte una lista de datos en una lista de objetos
        }
        public Torneo ConsultarPorTipo(string TipoTorneo)
        {
            return dbexamen.Torneos.FirstOrDefault(e => e.TipoTorneo == TipoTorneo);
        }

        public Torneo ConsultarPorId(int idTorneos)
        {
            return dbexamen.Torneos.FirstOrDefault(e => e.idTorneos == idTorneos);
        }
        
        public Torneo ConsultarPorNombre(string NombreTorneo)
        {
            return dbexamen.Torneos.FirstOrDefault(e => e.NombreTorneo == NombreTorneo);
        }

        public Torneo ConsultarPorFecha(date FechaTorneo)
        {
            return dbexamen.Torneos.FirstOrDefault(e => e.FechaTorneo == FechaTorneo);
        }

        public string Eliminar(int idTorneos)
        {
            try
            {
                Torneo torneo = ConsultarPorId(idTorneos);
                if (torneo == null)
                {
                    return "El torneo con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                dbexamen.Torneos.Remove(torneo);
                dbSuper.SaveChanges();
                return "Se eliminó el torneo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el torneo: " + ex.Message;
            }
        }
    }
}