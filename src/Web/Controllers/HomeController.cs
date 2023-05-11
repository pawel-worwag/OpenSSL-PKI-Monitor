using System.Diagnostics;
using Core.Abstractions;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

[Route("/")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICaRepository _repo;

    public HomeController(ILogger<HomeController> logger, ICaRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var cas = _repo.GetCertificateAuthorities();
        var data = new List<Core.Dto.CertificationAuthority>();
        foreach (var ca in cas)
        {
            data.Add(ca.Map());
        }
        return View(data);
    }
    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}