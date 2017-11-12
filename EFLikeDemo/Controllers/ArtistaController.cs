using System.Linq;
using EFLikeDemo.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

namespace EFLikeDemo.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly EFDemoContexto _contexto;
        public ArtistaController(EFDemoContexto contexto)
        {
            _contexto = contexto;
        }
        // GET: Artista
        public ActionResult UsoContains()
        {
            var sobrenome = "va";

            var artistas = _contexto.Artistas.Where(c => c.Sobrenome.Contains(sobrenome));

            return View(artistas);
        }
        public ActionResult UsoStartsWith()
        {
            var sobrenome = "S";

            var artistas = _contexto.Artistas.Where(c => c.Sobrenome.StartsWith(sobrenome));

            return View(artistas);
        }

       

        public ActionResult UsoEFLike()
        {
            var sobrenome = "va";

            var artistas = _contexto.Artistas.Where(c => EF.Functions.Like(c.Sobrenome,$"%{sobrenome}%"));

            return View(artistas);
        }

        public ActionResult UsoEFLikeStartsWith()
        {
            var sobrenome = "S";

            var artistas = _contexto.Artistas.Where(c => EF.Functions.Like(c.Sobrenome, $"{sobrenome}%"));

            return View(artistas);
        }

       


    }
}