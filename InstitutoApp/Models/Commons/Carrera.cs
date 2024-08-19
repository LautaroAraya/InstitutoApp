using System.ComponentModel.DataAnnotations;

namespace InstitutoApp.Models.Commons
{
    public class Carrera 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre debe cargarse obligatoriamente")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "La sigla debe cargarse obligatoriamente")]
        public string Sigla { get; set; } = string.Empty;


        public override string ToString()
        {
            return $"id:{Id} nombre:{Nombre}";
        }
    }
}
