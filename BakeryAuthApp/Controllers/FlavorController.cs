using Microsoft.AspNetCore.Mvc;
using BakeryAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BakeryAuth.Controllers
{
  [Authorize]
  public class FlavorController : Controller
  {
    private readonly BakeryAuthContext _db;
    public FlavorController(BakeryAuthContext db)
    {
      _db = db;
    }
    
    [HttpGet("/flavor")]
    public ActionResult Index() {
      return View();
    }
  }
}