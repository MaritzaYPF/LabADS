using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class MateriaController : Controller
    {
        private readonly IMateriaRepository materiaRepository;
        private readonly ICarreraRepository carreraRepository;


        public MateriaController(IMateriaRepository materiaRepository, ICarreraRepository carreraRepository)
        {
            this.materiaRepository = materiaRepository;
            this.carreraRepository = carreraRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                // var item = materiaRepository.obtenerMaterias();
                var item = materiaRepository.obtenerMaterias (new string[] { "Carreras" });


                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Form(int? idMateria, Operaciones operaciones)
        {
            try
            {
                var materia = new MateriaViewModel();

                if (idMateria.HasValue)
                {
                    materia = materiaRepository.obtenerMateriaPorID(idMateria.Value);
                }
               
                ViewData["Operaciones"] = operaciones;

                ViewBag.Carreras = carreraRepository.obtenerCarreras();

                return View(materia);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(MateriaViewModel materiaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    if (materiaViewModel.idMateria == 0)
                    {
                        id = materiaRepository.agregarMateria(materiaViewModel);
                    }
                    else
                    {
                       id = materiaRepository.actualizarMateria
                             (materiaViewModel.idMateria, materiaViewModel);
                    }
                    if (id > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }

                    else
                    {
                        return StatusCode(StatusCodes.Status202Accepted);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idMateria)
        {
            try
            {
                materiaRepository.eliminarMateria(idMateria);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}

