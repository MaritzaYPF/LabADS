using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;


        public GrupoController(IGrupoRepository grupoRepository)
        {
            this.grupoRepository = grupoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = grupoRepository.obtenerGrupo();

                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Form(int? idGrupo, Operaciones operaciones)
        {
            try
            {
                var grupo = new GrupoViewModel();

                if (idGrupo.HasValue)
                {
                    grupo = grupoRepository.obtenerGrupoPorID(idGrupo.Value);
                }
                
                ViewData["Operaciones"] = operaciones;

                return View(grupo);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(GrupoViewModel grupoViewModel)
        {
            try
            {
                if (grupoViewModel.idGrupo == 0) 
                {
                   grupoRepository.agregarGrupo(grupoViewModel);
                }
                else 
                {
                   grupoRepository.actualizarGrupo
                        (grupoViewModel.idGrupo, grupoViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idGrupo)
        {
            try
            {
                grupoRepository.eliminarGrupo(idGrupo);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }






    }
}
