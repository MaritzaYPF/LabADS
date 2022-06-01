using ADSProject.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{

    public class GrupoViewModel
    {

        [Display(Name = "IdGrupo")]
        [Key]
        public int idGrupo { get; set; }


        [Display(Name = "Carrera")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idCarrera { get; set; }
        [ForeignKey("idCarrera")]
        public CarreraViewModel Carreras { get; set; }



        [Display(Name = "Profesor")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idProfesor { get; set; }
        [ForeignKey("idProfesor")]
        public ProfesorViewModel Profesores { get; set; }


        
        [Display(Name = "Materias")]
        public int idMateria { get; set; }
        [ForeignKey("idMateria")]
        public MateriaViewModel Materias { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 2 caracteres.")]
        [Display(Name = "Ciclo")]
        public string Ciclo { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 4 caracteres.")]
        [Display(Name = "Anio")]
        public string Anio { get; set; }

        public bool estado { get; set; }

        public ICollection<AsignacionGrupoViewModel> AsignacionGrupos { get; set; }
    }
}
