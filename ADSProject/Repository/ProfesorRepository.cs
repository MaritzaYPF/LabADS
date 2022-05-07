using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {

        // private readonly List<ProfesorViewModel> lstProfesor;
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstProfesor = new List<ProfesorViewModel>
            {
                new ProfesorViewModel{ idProfesor = 1, nombresProfesor= "Juan", apellidosProfesor = "Perez", correoProfesor = "Juan@usonsonate.edu.sv"}
            };*/
            this.applicationDbContext = applicationDbContext;
        }



        public int agregarProfesor(ProfesorViewModel profesorViewModel)
        {
            try
            {
                /*if (lstProfesor.Count > 0)
                {
                    profesorViewModel.idProfesor = lstProfesor.Last().idProfesor + 1;
                }
                else
                {
                    profesorViewModel.idProfesor = 1;
                }
                lstProfesor.Add(profesorViewModel);
                return profesorViewModel.idProfesor;*/

                applicationDbContext.Profesores.Add(profesorViewModel);
                applicationDbContext.SaveChanges();

                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarProfesor(int idProfesor, ProfesorViewModel profesorViewModel)
        {
            try
            {
                //lstProfesor[lstProfesor.FindIndex(x => x.idProfesor == idProfesor)] = profesorViewModel;

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesorViewModel);

                applicationDbContext.SaveChanges();

                return profesorViewModel.idProfesor;

             
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarProfesor(int idProfesor)
        {
            try
            {
                //lstProfesor.RemoveAt(lstProfesor.FindIndex(x => x.idProfesor == idProfesor));

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                
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

        public List<ProfesorViewModel> obtenerProfesor()
        {
            try
            {
                //  return lstProfesor;
                //obtener todo los estudiantes  con filtros(estado = 1)*/
                return applicationDbContext.Profesores.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ProfesorViewModel obtenerProfesorPorID(int idProfesor)
        {
            try
            {
                //var item = lstProfesor.Find(x => x.idProfesor == idProfesor);

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);
          
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
