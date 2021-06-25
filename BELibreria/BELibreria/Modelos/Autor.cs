using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BELibreria.Modelos
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
