using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceUsuarioReference;
using UsuariosFron.Models;

namespace UsuariosFron.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
            ServiceUsuarioReference.UsuariosClient UsuarioService = new UsuariosClient();
            var usr = await UsuarioService.GetUsuariosAsync();

            List<Usuario> result = new List<Usuario>();
            foreach (var item in usr)
            {
                result.Add(new Usuario()
                {
                    NombreUsuario = item.Nombre,
                    FechaNacimiento = item.FechaNacimiento,
                    Sexo = item.Sexo,
                    Id = item.Id
                });
            }

            return View(result);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsuariosFron.Models.Usuario collection)
        {
            try
            {
                ServiceUsuarioReference.UsuariosClient UsuarioService = new UsuariosClient();
                await UsuarioService.SetUsuarioAsync(collection.NombreUsuario.Trim(),Convert.ToDateTime(collection.FechaNacimiento), collection.Sexo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ServiceUsuarioReference.UsuariosClient UsuarioService = new UsuariosClient();
                var item = await UsuarioService.GetUsuarioAsync(id);

                Usuario result = new Usuario()
                {
                    NombreUsuario = item.Nombre,
                    FechaNacimiento = item.FechaNacimiento,
                    Sexo = item.Sexo,
                    Id = item.Id
                };
                return View(result);
            }
            catch
            {
                return View();
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UsuariosFron.Models.Usuario collection)
        {
            try
            {
                ServiceUsuarioReference.UsuariosClient UsuarioService = new UsuariosClient();
                await UsuarioService.UpdateUsuarioAsync(id,collection.NombreUsuario.Trim(), Convert.ToDateTime(collection.FechaNacimiento), collection.Sexo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                ServiceUsuarioReference.UsuariosClient UsuarioService = new UsuariosClient();
                await UsuarioService.RemoveUsuarioAsync(id);
            }
            catch
            {
                return View();
            }

            return Content("1");
        }

    }
}
