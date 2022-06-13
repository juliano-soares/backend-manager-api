using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class ImageUploadViewModel
    {
        [Required(ErrorMessage = "O email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A imagem não pode ser vazia.")]
        public string Avatar { get; set; }
    }
}