using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
    public interface IEstudianteRepository
    {
        List<EstudianteViewModel> obtenerEstudiantes();

        int agregarEstudiante(EstudianteViewModel estudianteViewModel);

        int actualizarEstudiante(int idEstudiante, EstudianteViewModel estudianteViewModel);

        bool eliminarEstudiante(int idEstudiante);

        EstudianteViewModel obtenerEstudiantePorID(int idEstudiante);
    }
}
