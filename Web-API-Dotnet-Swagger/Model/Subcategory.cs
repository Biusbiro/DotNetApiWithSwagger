using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Dotnet_Swagger.Model
{
    public class Subcategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo não pode ter mais do que 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve ser preenchido")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        public Category Category { get; set; }
    }
}
