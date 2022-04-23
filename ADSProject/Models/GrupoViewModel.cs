using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class GrupoViewModel
    {
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [Display(Name = "IdGrupo")]
        public int idGrupo { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [Display(Name = "IdCarrera")]
        public int idCarrera { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [Display(Name = "IdMateria")]
        public int idMateria { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [Display(Name = "IdProfesor")]
        public int idProfesor { get; set; }


        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 2 caracteres.")]
        [Display(Name = "Ciclo")]
        public string Ciclo { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 4 caracteres.")]
        [Display(Name = "Anio")]
        public string Anio { get; set; }

    }
}
