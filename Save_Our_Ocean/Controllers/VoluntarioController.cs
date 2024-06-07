using Microsoft.AspNetCore.Mvc;
using Save_Our_Ocean.Data;
using Save_Our_Ocean.DTOs;
using Save_Our_Ocean.Models;

namespace Save_Our_Ocean.Controllers
{
    public class VoluntarioController : Controller
    {


        private readonly ILogger<VoluntarioController> _logger;


        private readonly DataContext _dataContext;


        public VoluntarioController(ILogger<VoluntarioController> logger, DataContext dataContext)
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

        public IActionResult Home()
        {
            return View();
        }


        public IActionResult LogarVoluntario(LoginVoluntarioDTO request)
        {

            var voluntario = _dataContext.Voluntario.FirstOrDefault(x => x.Email == request.Email);

            if (voluntario == null)
            {
                return BadRequest("Email invalido");
            }

            if (voluntario.Senha != request.Senha)
            {
                return BadRequest("Senha Invalida");
            }


            HttpContext.Session.SetInt32("_Id", voluntario.Id);

            return RedirectToAction("Home");
        }

        public IActionResult CadastroConta()
        {
            return View();
        }

        public IActionResult CadastrarConta(CadastrarVoluntarioDTO request)
        {
            var voluntario = _dataContext.Voluntario.FirstOrDefault(x => x.Email == request.Email);

            if (voluntario != null)
            {
                return BadRequest("Voluntario ja foi cadastrado com esse email se atente");
            }

            Voluntario newVoluntario = new Voluntario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                sexo = request.Sexo,
            };

            _dataContext.Add(newVoluntario);
            _dataContext.SaveChanges();

            return RedirectToAction("LoginPage");
        }


       
    }
}
