using Microsoft.AspNetCore.Mvc;
using BakeryAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BakeryAuth.Controllers
{
  [Authorize]
  public class TreatController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly BakeryAuthContext _db;
    public TreatController(UserManager<ApplicationUser> userManager, BakeryAuthContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    
    [AllowAnonymous]
    [HttpGet("/treat")]
    public async Task<ActionResult> Index() {
      List<Treat> treats = _db.treats.ToList();
      ViewBag.treats = treats;
      string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if (userId != null)
      {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        List<Treat> my_treats = _db.treats
          .Where(tr => tr.user_id == user.Id)
          .ToList();
        ViewBag.my_treats = my_treats;        
        return View(user);
      } else {
        return View();
      }
    }

    [HttpGet("/treat/create")]
    public ActionResult Create() {
      return View();
    }

    [HttpPost("/treat/create")]
    public ActionResult CreateConfirm(Treat treat) {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      Treat newTreat = treat;
      newTreat.user_id = userId;
      _db.treats.Add(newTreat);
      _db.SaveChanges();
      return Redirect("/treat");
    }
  }
}