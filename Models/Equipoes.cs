using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerClase.Models
{
    public class Equipoes
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Ciudad { get; set; }

        public int Titulos { get; set; }

        public bool AceptaExtranjeros { get; set; }

        public Estadios? Estadio { get; set; }

        [ForeignKey(nameof(Estadio))]
        public int IdEstadio { get; set; }
    }
}