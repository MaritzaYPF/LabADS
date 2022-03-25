using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
    public interface IMateriaRepository
    {
        List<MateriaViewModel> obtenerMaterias();

        int agregarMateria(MateriaViewModel materiaViewModel);

        int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel);

        bool eliminarMateria(int idMateria);

       MateriaViewModel obtenerMateriaPorID(int idMateria);
    }
}
