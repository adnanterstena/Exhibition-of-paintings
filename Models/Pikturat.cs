using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Models
{
    [Table("Pikturat")]
    public class Pikturat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPiktura { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string UrlPath { get; set; }

        [Required(ErrorMessage = "Ju lutem plotesoni Titullin e Piktures")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Titulli i Piktures")]
        public string TitulliPiktures { get; set; }

        [Required] 
        [Column(TypeName = "nvarchar(450)")]
        public string ID_Useri { get; set; }

        public string Pershkrimi { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Karakteristikat { get; set; }

        [DisplayName("Data e Postimit")]
        [DataType(DataType.DateTime)]
        public DateTime DataPostimit { get; set; }

        [DisplayName("Ekspozita")]
        public int? Ekspozitat { get; set; }

        [DisplayName("Lloji i Piktures")]
        public string LLojiPiktures { get; set; }

        [DisplayName("Çmimi i Piktures")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Çmimi duhet te jete brenda kufizave, 0 deri ne 18 shifrore")]
        public decimal CmimiPiktures { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Disponueshmeria { get; set; }

        
        public int? Shporta { get; set; }
    }
}
