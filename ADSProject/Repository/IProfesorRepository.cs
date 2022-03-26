using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
    public interface  IProfesorRepository
    {
        List<ProfesorViewModel> obtenerProfesor();

        int agregarProfesor(ProfesorViewModel profesorViewModel);

        int actualizarProfesor(int idProfesor, ProfesorViewModel profesorViewModel);

        bool eliminarProfesor(int idProfesor);

        ProfesorViewModel obtenerProfesorPorID(int idProfesor);


    }
}
