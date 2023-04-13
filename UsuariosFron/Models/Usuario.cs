using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosFron.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Fecha es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }

    }
}
