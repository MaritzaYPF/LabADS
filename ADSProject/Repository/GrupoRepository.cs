﻿using ADSProject.Data;
using ADSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ADSProject.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        // private readonly List<GrupoViewModel> lstGrupo;

        private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            /* lstGrupo = new List<GrupoViewModel>
              {
                  new GrupoViewModel{ idGrupo = 1, idCarrera = 1, idMateria = 1,
                     idProfesor = 1, Ciclo = "01", Anio="2022"}
           };*/
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {
                /* if (lstGrupo.Count > 0)
                 {
                     grupoViewModel.idGrupo = lstGrupo.Last().idGrupo + 1;
                 }
                 else
                 {
                     grupoViewModel.idGrupo = 1;
                 }
                 lstGrupo.Add(grupoViewModel);
                 return grupoViewModel.idGrupo;*/

                applicationDbContext.Grupos.Add(grupoViewModel);
                applicationDbContext.SaveChanges();

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
                // lstGrupo[lstGrupo.FindIndex(x => x.idGrupo == idGrupo)] = grupoViewModel;
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupoViewModel);

                applicationDbContext.SaveChanges();

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
                //lstGrupo.RemoveAt(lstGrupo.FindIndex(x => x.idGrupo == idGrupo));

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);


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

        public List<GrupoViewModel> obtenerGrupos()
        {

            try
            {
                return applicationDbContext.Grupos.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<GrupoViewModel> obtenerGrupos(string[] includes)
        {
            try
            {
                var lst = applicationDbContext.Grupos.Where(x => x.estado == true).AsQueryable();

                foreach (var item in includes)
                {
                    lst = lst.Include(item);
                }
                return lst.ToList();
            }
            catch
            {
                throw;
            }

        }


        //obtener grupo filtrados
        public GrupoViewModel obtenerGrupoPorID(int idGrupo, string[] includes)
        {
            try
            {
                var lst = applicationDbContext.Grupos.Where(x => x.estado == true).AsQueryable();
                if(includes != null && includes.Count() > 0)
                {
                    foreach(var item in includes)
                    {
                        lst = lst.Include(item);
                    }
                }
                return lst.SingleOrDefault(x => x.idGrupo == idGrupo);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public GrupoViewModel obtenerGrupoPorId(int idGrupo)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
