using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudFinal.WEB.Models.DAL;
using CrudFinal.WEB.Models.Entities;
using CrudFinal.WEB.Clases;
using CrudFinal.WEB.Models.Abstract;

namespace CrudFinal.WEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IRolBusiness _rolBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness, IRolBusiness rolBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
            _rolBusiness = rolBusiness;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _usuarioBusiness.ObtenerUsuariosTodos());

        }

        public async Task<IActionResult> Crear()
        {
            ViewData["ListaRoles"] = new SelectList(await _rolBusiness.ObtenerListaRolesTodos(), "IdRol", "Rol");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdUsuario,Nombre,Documento,Rol,Telefono")] UsuarioGuardarDto usuarioGuardarDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioBusiness.GuardarUsuario(usuarioGuardarDto);
                    var respuesta = await _usuarioBusiness.GuardarCambios();
                    if (respuesta)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(usuarioGuardarDto);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id != null)
            {
                try
                {
                    var usuarioDto = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
                    ViewData["ListaRoles"] = new SelectList(await _rolBusiness.ObtenerListaRolesTodos(), "IdRol", "Rol");
                    if (usuarioDto == null)
                        return View("Index");
                    return View(usuarioDto);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, UsuarioGuardarDto usuarioGuardarDto)
        {
            if (id != usuarioGuardarDto.IdUsuario)
            {
                return View(usuarioGuardarDto);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioBusiness.EditarUsuario(usuarioGuardarDto);
                    var guardarUsuario = await _usuarioBusiness.GuardarCambios();
                    if (guardarUsuario)

                        return RedirectToAction("Index");

                    else
                        return View(usuarioGuardarDto);
                }
                catch (Exception)
                {

                    return View(usuarioGuardarDto);
                }
            }
            return View(usuarioGuardarDto);
        }

        [HttpPost]

        public async Task<IActionResult> Eliminar(int? id)
        {

            try
            {
                var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
                if (usuario == null)
                    return RedirectToAction("Index");
                _usuarioBusiness.EliminarUsuario(usuario);
                var eliminarUsuario = await _usuarioBusiness.GuardarCambios();
                if (eliminarUsuario)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id != null)
            {
                try
                {
                    var usuario = await _usuarioBusiness.ObtenerUsuarioDtoPorId(id.Value);
                    if (usuario == null)
                        return RedirectToAction("Index");
                    return View(usuario);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
    }
}
