using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Id Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Números maior ou igual a 1")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [MinLength(5, ErrorMessage = "Tamanho mínim de 5 caracteres")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Preço Obrigatório")]
        //[Range(1, int.MaxValue, ErrorMessage = "Números maior ou igual a 1")]
        //public int Price { get; set; }
        public Category Category { get; set;}
    }
}