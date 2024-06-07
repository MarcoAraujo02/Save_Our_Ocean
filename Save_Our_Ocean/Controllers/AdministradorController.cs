using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Save_Our_Ocean.Data;
using Save_Our_Ocean.DTOs;

namespace Save_Our_Ocean.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly ILogger<AdministradorController> _logger;



        private readonly DataContext _dataContext;


        public AdministradorController(ILogger<AdministradorController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LoginPage()
        {
            return View();
        }


        public IActionResult Logar(LoginAdmDTO request)
        {
            var find = _dataContext.Administrador.FirstOrDefault(x => x.Nome == request.Nome);

            if (find == null)
            {
                return BadRequest("Nome Invalido");
            }

            if (find.Senha != request.Senha)
            {
                return BadRequest("Senha inválida");
            }


            HttpContext.Session.SetInt32("_Id", find.Id);

            return RedirectToAction("Home");
        }



        public IActionResult Home()
        {
            return View();
        }


        public IActionResult LimparArea(int Areaid)
        {
            var area = _dataContext.Area.FirstOrDefault(e => e.Id == Areaid);

            if (area != null)
            {
                area.Status = "Limpa";
                _dataContext.SaveChanges();
            }

            return View("~/Views/Administrador/Home.cshtml");
        }

        public async Task<IActionResult> ListaDeAreaLimpar()
        {
            // Recupere os dados das tabelas de área e eventos
            var areas = await _dataContext.Area.ToListAsync();



            return View(areas);
        }


        public async Task<IActionResult> ListaVoluntario()
        {
            // Recupere os dados das tabelas de área e eventos
            var voluntarios= await _dataContext.Voluntario.ToListAsync();



            return View(voluntarios);
        }


        public async Task<IActionResult> EditarPage(int id)
        {

            var Area = await _dataContext.Voluntario.FindAsync(id);
            return View(Area);
        }


        public IActionResult EditarVoluntario(int id, CadastrarVoluntarioDTO request)
        {
            var vol = _dataContext.Voluntario.Find(id);

            vol.Nome = request.Nome;
            vol.Email= request.Email;
            vol.Senha = request.Senha;
            vol.sexo = request.Sexo;

            _dataContext.Update(vol);
            _dataContext.SaveChanges();

            return RedirectToAction("ListaVoluntario", "Administrador");
        }



        public IActionResult DeletarVoluntario(int id)
        {
            var vol = _dataContext.Voluntario.Find(id);

            _dataContext.Remove(vol);
            _dataContext.SaveChanges();
            return RedirectToAction("ListaVoluntario");
        }


    }
}
