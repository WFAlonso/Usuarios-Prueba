using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Datos;

namespace WcfUsuario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuarios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Usuarios.svc o Usuarios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuarios : IUsuarios
    {


        public Datos.Usuarios GetUsuario(int id)
        {
            Datos.Datos da = new Datos.Datos();
            var data = da.ObtenerUsuario(id);

            Datos.Usuarios u = new Datos.Usuarios();

            u.Id = Convert.ToInt32(data.Rows[0].ItemArray[0]);
            u.Nombre = data.Rows[0].ItemArray[1].ToString();             
             if (!string.IsNullOrEmpty(data.Rows[0].ItemArray[2].ToString()))
                u.FechaNacimiento = Convert.ToDateTime(data.Rows[0].ItemArray[2].ToString());
            u.Sexo = data.Rows[0].ItemArray[3].ToString();
            
            return u;
        }

        public List<Datos.Usuarios> GetUsuarios()
        {
            Datos.Datos da = new Datos.Datos();
            var data = da.ObtenerUsuarios();

            List<Datos.Usuarios> urs = new List<Datos.Usuarios>();

            foreach (DataRow item in data.Rows)
            {
                Datos.Usuarios us = new Datos.Usuarios();

                us.Id = Convert.ToInt32(item.ItemArray[0]);
                us.Nombre = item.ItemArray[1].ToString();
                if(!string.IsNullOrEmpty(item.ItemArray[2].ToString()))
                    us. FechaNacimiento = Convert.ToDateTime(item.ItemArray[2].ToString());
                us.Sexo = item.ItemArray[3].ToString();

                urs.Add(us);
            }
            
            return urs;
        }

        public bool RemoveUsuario(int id)
        {
            Datos.Datos da = new Datos.Datos();
            da.RemoverUsuarios(id);
            return true;
        }

        public bool SetUsuario(string Nombre, DateTime Nacimiento, string Sexo)
        {
            Datos.Datos da = new Datos.Datos();
            da.AgregarUsuario(Nombre, Nacimiento, Sexo);
            return true;
        }

        public bool UpdateUsuario(int id, string Nombre, DateTime Nacimiento, string Sexo)
        {
            Datos.Datos da = new Datos.Datos();
            da.EditarUsuarios(id, Nombre, Nacimiento, Sexo);
            return true;
        }
    }
}
