using ADSProject.Repository;
using ADSProject.Utils;
using System;
using Microsoft.AspNetCore.Mvc;
using ADSProject.Models;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly ICarreraRepository carreraRepository;
        private readonly IMateriaRepository materiaRepository;
        private readonly IProfesorRepository profesorRepository;


        public GrupoController(IGrupoRepository grupoRepository, ICarreraRepository carreraRepository,
                               IMateriaRepository materiaRepository, IProfesorRepository profesorRepository)
        {
            this.grupoRepository = grupoRepository;
            this.carreraRepository = carreraRepository;
            this.materiaRepository = materiaRepository;
            this.profesorRepository = profesorRepository;

        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                var item = grupoRepository.obtenerGrupos(new string[] { "Carreras", "Profesores", "Materias" });

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
                var grupos = new GrupoViewModel();

                if (idGrupo.HasValue)
                {
                    grupos = grupoRepository.obtenerGrupoPorId(idGrupo.Value);
                }

                ViewData["Operaciones"] = operaciones;

                // Listado de carreras
                ViewBag.Carreras = carreraRepository.obtenerCarreras();

                // Listado de materias
                ViewBag.Materias = materiaRepository.obtenerMaterias();

                // Listado de profesores
                ViewBag.Profesores = profesorRepository.obtenerProfesor();

                return View(grupos);
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
                if (ModelState.IsValid)
                {
                    if (grupoViewModel.idGrupo == 0) // Para el caso de agregar
                    {
                        grupoRepository.agregarGrupo(grupoViewModel);
                    }
                    else
                    {
                        grupoRepository.actualizarGrupo(grupoViewModel.idGrupo, grupoViewModel);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
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

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult cargarMaterias(int? idCarrera)
        {
            var listadoCarreras = idCarrera == null ? new List<MateriaViewModel>() :

            materiaRepository.obtenerMaterias().Where(x => x.idCarrera == idCarrera);

            return StatusCode(StatusCodes.Status200OK, listadoCarreras);
        }
    }
}