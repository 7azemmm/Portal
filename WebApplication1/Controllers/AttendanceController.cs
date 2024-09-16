using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

using WebApplication1.context;

namespace WebApplication1.Controllers;

public class AttendanceController : Controller
{
   
    ApplicationContext context = new ApplicationContext();

  public IActionResult TakeAttendance(Student_Attendance stud)
{
    context.Student_Attendance.Add(stud);
    context.SaveChanges();
    return RedirectToAction("Index", "Home");
}

public IActionResult Get_Student_Attendance(int ID)
{
    var studAttendance = context.Student_Attendance.Where(x => x.studentId == ID).ToList();
    
    if (!studAttendance.Any())
    {
        return NotFound();
    }

    return View(studAttendance);
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
