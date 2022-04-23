using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
      public interface IGrupoRepository
    {
        List<GrupoViewModel> obtenerGrupo();

        int agregarGrupo(GrupoViewModel grupoViewModel);

        int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel);

        bool eliminarGrupo(int idGrupo);

        GrupoViewModel obtenerGrupoPorID(int idGrupo);
    }
}
