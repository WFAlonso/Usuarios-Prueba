using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfUsuario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        List<Datos.Usuarios> GetUsuarios();

        [OperationContract]
        Datos.Usuarios GetUsuario(int id);

        [OperationContract]
        bool SetUsuario(string Nombre, DateTime Nacimiento, string Sexo);

        [OperationContract]
        bool UpdateUsuario(int id, string Nombre, DateTime Nacimiento, string Sexo);

        [OperationContract]
        bool RemoveUsuario(int id);
    }
}
