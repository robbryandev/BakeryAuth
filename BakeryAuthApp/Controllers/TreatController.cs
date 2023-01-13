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
    
    [HttpGet("/treat")]
    public async Task<ActionResult> Index() {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser user = await _userManager.FindByIdAsync(userId);
      List<Treat> treats = _db.treats
        .Where(tr => tr.user_id.ToString() == user.Id)
        .ToList();
      ViewBag.treats = treats;
      return View(user);
    }
  }
}