using System.ComponentModel.DataAnnotations;

namespace Pizzapan.PresentationLayer.Models
{
    //Kaydolmak için model nesnesi.
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Girdiğiniz şifre ile onay şifresi uyuşmuyor. Lütfen düzeltiniz.")]
        public string ConfirmPassword { get; set; }
    }
}