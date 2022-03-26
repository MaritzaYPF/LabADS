using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {

        private readonly List<ProfesorViewModel> lstProfesor;


        public ProfesorRepository()
        {
            lstProfesor = new List<ProfesorViewModel>
            {
                new ProfesorViewModel{ idProfesor = 1, nombresProfesor= "Juan", apellidosProfesor = "Perez", correoProfesor = "Juan@usonsonate.edu.sv"}
            };
        }



        public int agregarProfesor(ProfesorViewModel profesorViewModel)
        {
            try
            {
                if (lstProfesor.Count > 0)
                {
                    profesorViewModel.idProfesor = lstProfesor.Last().idProfesor + 1;
                }
                else
                {
                    profesorViewModel.idProfesor = 1;
                }
                lstProfesor.Add(profesorViewModel);
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
                lstProfesor[lstProfesor.FindIndex(x => x.idProfesor == idProfesor)] = profesorViewModel;
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
                lstProfesor.RemoveAt(lstProfesor.FindIndex(x => x.idProfesor == idProfesor));
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
                return lstProfesor;
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
                var item = lstProfesor.Find(x => x.idProfesor == idProfesor);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
