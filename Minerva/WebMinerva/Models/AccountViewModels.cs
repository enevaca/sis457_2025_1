using System.ComponentModel.DataAnnotations;

namespace WebMinerva.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string clave { get; set; }
        [Display(Name = "Recordarme")]
        public bool recordarme { get; set; }
    }
}
