using ADSProject.Models;
using System.Collections.Generic;

namespace ADSProject.Repository
{
      public interface IGrupoRepository
    {

        int agregarGrupo(GrupoViewModel grupoViewModel);

        int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel);

        bool eliminarGrupo(int idGrupo);

        List<GrupoViewModel> obtenerGrupos();

        List<GrupoViewModel> obtenerGrupos(string[] includes);

        GrupoViewModel obtenerGrupoPorID(int idGrupo, string[] includes);
       
        GrupoViewModel obtenerGrupoPorId(int idGrupo);
    }
}
