using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class GroupController : Controller
{


   ApplicationContext context = new ApplicationContext();


   public IActionResult Index ()
   {
    var groups = context.Groups.ToList();

     return View(groups);
   }
    public IActionResult Add_group_view( )
    {
        
       return View();
    }

    public IActionResult addgroup(Group group){
         if(group == null){
            return BadRequest("object is empty");
        }
       
        if(group.Name!=null ){
      
        context.Groups.Add(group);
        context.SaveChanges();
        }


        return RedirectToAction("Index");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
