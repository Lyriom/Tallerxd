
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tallerxd.Models;

namespace TallerClase.Models
{
    public class Futbolistas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Posicion { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public int IdEquipo { get; set; }

        [ForeignKey(nameof(IdEquipo))]
        public virtual Equipoes? Equipo { get; set; }
    }
}