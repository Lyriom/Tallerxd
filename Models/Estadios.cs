using System.ComponentModel.DataAnnotations;

namespace TallerClase.Models
{
    public class Estadios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(150)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }

        public float Capacidad { get; set; }
    }
}