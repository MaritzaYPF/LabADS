using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
    public interface ICarreraRepository
    {
        List<CarreraViewModel> obtenerCarreras();

        int agregarCarrera(CarreraViewModel carreraViewModel);

        int actualizarCarrera(int idcarrera, CarreraViewModel carreraViewModel);

        bool eliminarCarrera(int idcarrera);

        CarreraViewModel obtenerCarreraPorID(int idcarrera);
    }
}
