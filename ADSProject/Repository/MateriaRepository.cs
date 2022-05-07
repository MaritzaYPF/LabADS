using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository 
{
    public class MateriaRepository : IMateriaRepository
    {
        //private readonly List<MateriaViewModel> lstMateria;

        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstMateria = new List<MateriaViewModel>
            {
                new MateriaViewModel{ idMateria = 1, nombresMateria = "Sistema Digital"}
            };*/
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarMateria(MateriaViewModel materiaViewModel)
        {
            try
            {
                /*if (lstMateria.Count > 0)
                {
                    materiaViewModel.idMateria = lstMateria.Last().idMateria + 1;
                }
                else
                {
                    materiaViewModel.idMateria = 1;
                }
                lstMateria.Add(materiaViewModel);
                return materiaViewModel.idMateria;*/

                applicationDbContext.Materias.Add(materiaViewModel);
                applicationDbContext.SaveChanges();

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
                // lstMateria[lstMateria.FindIndex(x => x.idMateria == idMateria)] = materiaViewModel;

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materiaViewModel);

                applicationDbContext.SaveChanges();

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
                //lstMateria.RemoveAt(lstMateria.FindIndex(x => x.idMateria == idMateria));

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                item.estado = false;

                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();

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
                //var item = lstMateria.Find(x => x.idMateria == idMateria);
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
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
               // obtener todo los estudiantes  con filtros(estado = 1)*/
                return applicationDbContext.Materias.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
