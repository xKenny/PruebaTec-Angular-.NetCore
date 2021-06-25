using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BELibreria.Modelos
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Anio { get; set; }
        [Required]
        public string Genero { get; set; }
        public string Paginas { get; set; }
        [Required]
        public string Editorial { get; set; }
        [Required]
        public string Autor { get; set; }
    }
}
