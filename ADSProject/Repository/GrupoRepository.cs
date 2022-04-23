using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ADSProject.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly List<GrupoViewModel> lstGrupo;

        public GrupoRepository()
        {
            lstGrupo = new List<GrupoViewModel>
            {
                new GrupoViewModel{ idGrupo = 1, idCarrera = 1, idMateria = 1,
                    idProfesor = 1, Ciclo = "01", Anio="2022"}
         };
        }

        public int agregarGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {
                if (lstGrupo.Count > 0)
                {
                    grupoViewModel.idGrupo = lstGrupo.Last().idGrupo + 1;
                }
                else
                {
                    grupoViewModel.idGrupo = 1;
                }
                lstGrupo.Add(grupoViewModel);
                return grupoViewModel.idGrupo;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel)
        {
            try
            {
                lstGrupo[lstGrupo.FindIndex(x => x.idGrupo == idGrupo)] = grupoViewModel;
                return grupoViewModel.idGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarGrupo(int idGrupo)
        {
            try
            {
                lstGrupo.RemoveAt(lstGrupo.FindIndex(x => x.idGrupo == idGrupo));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GrupoViewModel> obtenerGrupo()
        {


            try
            {
                return lstGrupo;
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public GrupoViewModel obtenerGrupoPorID(int idGrupo)
        {
            try
            {
                var item = lstGrupo.Find(x => x.idGrupo == idGrupo);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
