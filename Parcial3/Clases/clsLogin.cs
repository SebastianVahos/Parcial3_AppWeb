using Parcial3.Models;
using Servicios_Jue.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBExamenEntities dbExamen = new DBExamenEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try 
            {
                AdministradorITM admin = dbExamen.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                AdministradorITM admin = dbExamen.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (admin == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from A in dbExamen.Set<AdministradorITM>()
                       where A.Usuario == login.Usuario &&
                               A.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = A.NombreCompleto,
                           Autenticado = true,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }

    }
}