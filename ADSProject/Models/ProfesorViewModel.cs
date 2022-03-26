using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;


namespace ADSProject.Models
{
    public class ProfesorViewModel
    {
        [Display(Name = "ID")]
        public int idProfesor { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 2 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombresProfesor { get; set; }

        [Display(Name = "Apellido")]
        public string apellidosProfesor { get; set; }
      
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(70, MinimumLength = 15, ErrorMessage = "La longitud del campo no debe ser mayor a 70 caracteres ni menor de 15 caracteres.")]
        [Display(Name = "Correo")]

        public string correoProfesor { get; set; }

    }
}
