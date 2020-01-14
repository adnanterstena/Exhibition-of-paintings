using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Models
{
    [Table("Ekspozitat")]
    public class Ekspozitat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Ekspozites { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Ju lutem plotesoni Titullin e Ekspozites")]
        public string Titulli { get; set; }

        [StringLength(256)]
        public string uzerEmail { get; set; }

        public int? Ekspozita { get; set; }


        [MaxLength]
        public string Pershkrimi { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string FotojaURL { get; set; }
    }
}
