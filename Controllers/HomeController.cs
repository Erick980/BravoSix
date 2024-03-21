using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


using BravoSix.Models;

namespace BravoSix.Controllers;

public class HomeController : Controller
{

    private List<Operador> GetOperadores()
    {
        List<Operador> operadores = [];

        using(StreamReader leitor = new("Data/operadores.json"))
        {
            string dados = leitor.ReadToEnd();
            operadores = JsonSerializer.Deserialize<List<Operador>>(dados);
        }
        
        return operadores;
    }

    private List<Funcao> GetFuncoes()
    {
        List<Funcao> funcoes = [];

        using (StreamReader leitor = new("Data/tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            funcoes = JsonSerializer.Deserialize<List<Funcao>>(dados);
        }

        return funcoes;
    }
    private readonly ILogger<HomeController> _logger;
    
    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Operador> operadores = GetOperadores();
        
        List<Funcao> funcoes = GetFuncoes();

        ViewData["Funcoes"] = funcoes;

        return View(operadores);
    }

    public IActionResult Details(int id)
    {
        List<Operador> operadores = GetOperadores();
        
        List<Funcao> funcoes = GetFuncoes();

        ViewData["Funcoes"] = funcoes;

        DetailsVM details = new() {
            Anterior = operadores.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Atual = operadores.FirstOrDefault(p => p.Numero == id),
            Proximo = operadores.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
            Funcoes = funcoes
        };
        
        return View(details);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
