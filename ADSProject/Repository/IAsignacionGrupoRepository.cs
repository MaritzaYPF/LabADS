using System.Collections.Generic;
using ADSProject.Models;

namespace ADSProject.Repository
{
   public interface IAsignacionGrupoRepository
    {
        public int agregarAsignacionGrupo(GrupoViewModel grupoViewModel);

        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel);

        public int actualizarAsignacionGrupo(int idAgrupo, AsignacionGrupoViewModel asignacionGrupoViewModel);

        public bool eliminarAsignacionGrupo(int idAgrupo);

        public List<AsignacionGrupoViewModel> obtenerAsignacionGrupo();

        public AsignacionGrupoViewModel obtenerAsignacionPorId(int idAgrupo);
    }
}
