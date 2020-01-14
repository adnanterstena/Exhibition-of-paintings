using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Models
{
    [Table("Kritikat")]
    public class Kritikat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Kritika { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string Id_Useri { get; set; }

        [Required]
        public int Id_Piktura { get; set; }

        [Required]
        [MaxLength]
        [DisplayName("Kritika")]
        public string TekstiKritikes { get; set; }
    }
}
