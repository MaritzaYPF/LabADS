using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository 
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly List<MateriaViewModel> lstMateria;

        public MateriaRepository()
        {
            lstMateria = new List<MateriaViewModel>
            {
                new MateriaViewModel{ idMateria = 1, nombresMateria = "Sistema Digital"}
            };
        }

        public int agregarMateria(MateriaViewModel materiaViewModel)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    materiaViewModel.idMateria = lstMateria.Last().idMateria + 1;
                }
                else
                {
                    materiaViewModel.idMateria = 1;
                }
                lstMateria.Add(materiaViewModel);
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel)
        {
            try
            {
                lstMateria[lstMateria.FindIndex(x => x.idMateria == idMateria)] = materiaViewModel;
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarMateria(int idMateria)
        {
            try
            {
                lstMateria.RemoveAt(lstMateria.FindIndex(x => x.idMateria == idMateria));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MateriaViewModel obtenerMateriaPorID(int idMateria)
        {
            try
            {
                var item = lstMateria.Find(x => x.idMateria == idMateria);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MateriaViewModel> obtenerMaterias()
        {
            try
            {
                return lstMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
