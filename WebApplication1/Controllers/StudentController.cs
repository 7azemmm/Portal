using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class StudentController : Controller
{


   ApplicationContext context = new ApplicationContext();


   public IActionResult addStudent ()
   {
    var groups = context.Groups.ToList();
        ViewBag.groups = groups;
     return View();
   }
    public IActionResult AddStud( Student student)
    {
        
        if(student == null){
            return BadRequest("object is empty");
        }
       
        if(student.Name!=null && student.Stud_Phone_number!=null && student.Stud_Parent_Phone_number!=null){
        student.groupId=1;
         context.Students.Add(student);
        context.SaveChanges();
        }


        return RedirectToAction("Get_All_Students");
    }

    public IActionResult Get_All_Students()
    {
        var students = context.Students.ToList();
        var groups = context.Groups.ToList();
        ViewBag.groups = groups;
        return View(students);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
