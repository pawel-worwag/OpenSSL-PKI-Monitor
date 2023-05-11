using Core.Abstractions;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ICaRepository _repo;

    public HomeController(ICaRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return RedirectToAction("Inspect");
    }
    
    [HttpGet("/inspect")]
    public IActionResult Inspect()
    {
        var cas = _repo.GetCertificateAuthorities();
        var data = new List<CertificationAuthority>();
        data.AddRange(cas.Select(x=>x.Map()));
        return View(data);
    }
}