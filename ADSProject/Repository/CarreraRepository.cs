using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class CarreraRepository : ICarreraRepository
    {
        //private readonly List<CarreraViewModel> lstCarrera;

        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstCarrera = new List<CarreraViewModel>
            {
                new CarreraViewModel{ idCarrera = 1, codigoCarrera = "04", NombresCarrera= "Ingenieria en Sistema"}
            };*/
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarCarrera(CarreraViewModel carreraViewModel)
        {
            try
            {
                /*  if (lstCarrera.Count > 0)
                  {
                      carreraViewModel.idCarrera = lstCarrera.Last().idCarrera + 1;
                  }
                  else
                  {
                      carreraViewModel.idCarrera = 1;
                  }
                  lstCarrera.Add(carreraViewModel);
                  return carreraViewModel.idCarrera;*/

                applicationDbContext.Carreras.Add(carreraViewModel);
                applicationDbContext.SaveChanges();

                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarCarrera(int idCarrera, CarreraViewModel carreraViewModel)
        {
            try
            {
                // lstCarrera[lstCarrera.FindIndex(x => x.idCarrera == idCarrera)] = carreraViewModel;
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == idCarrera);

                applicationDbContext.Entry(item).CurrentValues.SetValues(carreraViewModel);

                applicationDbContext.SaveChanges();

                return carreraViewModel.idCarrera;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarCarrera(int idCarrera)
        {
            try
            {
                //lstCarrera.RemoveAt(lstCarrera.FindIndex(x => x.idCarrera == idCarrera));
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == idCarrera);


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

        public CarreraViewModel obtenerCarreraPorID(int idCarrera)
        {
            try
            {
                //var item = lstCarrera.Find(x => x.idCarrera == idCarrera);
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == idCarrera);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CarreraViewModel> obtenerCarreras()
        {
            try
            {
                //obtener todo los estudiantes  con filtros(estado = 1)*/
                return applicationDbContext.Carreras.Where(x => x.estado == true).ToList();
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
