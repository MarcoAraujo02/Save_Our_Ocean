using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Save_Our_Ocean.Data;
using Save_Our_Ocean.DTOs;
using Save_Our_Ocean.Models;

namespace Save_Our_Ocean.Controllers
{
    public class AreaController : Controller
    {


        private readonly ILogger<AreaController> _logger;



        private readonly DataContext _dataContext;


        public AreaController(ILogger<AreaController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarArea()
        {

            var id = HttpContext.Session.GetInt32("_Id");
            var idVoluntario = _dataContext.Voluntario.Find(id);
            ViewBag.IdVoluntario = idVoluntario.Id;

            return View();
        }

        public IActionResult CadastroArea(CadastroAreaDTO request, int idVoluntario)
        {
            var vef = _dataContext.Area.FirstOrDefault(x => x.Cep == request.Cep);

            if (vef != null)
            {
                return BadRequest("Area ja Cadastrada");
            }

            Area area = new Area
            {
                Cep = request.Cep,
                TipoPoluicao = request.TipoPoluicao,
                Descricao = request.Descricao,
                VoluntarioId = idVoluntario,
            };


            _dataContext.Add(area);
            _dataContext.SaveChanges();

            return View("~/Views/Voluntario/Home.cshtml");
        }

        public async Task<IActionResult> ListaDeAreaLimpas()
        {
            // Recupere os dados das tabelas de área e eventos
            var areas = await _dataContext.Area.ToListAsync();



            return View(areas);
        }


    }
}
