using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

using WebApplication1.context;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers;

[Authorize]
public class AttendanceController : Controller
{
   
    ApplicationContext context;
     public AttendanceController(ApplicationContext context, ILogger<AttendanceController> logger)
    {
        this.context = context;
        // Use the logger as needed
    }

  public IActionResult TakeAttendance(List<Student_Attendance> stud)
{
    
 foreach (var student in stud)
    {
        var studentAttendance = new Student_Attendance
        {
            
            Name = student.Name,
            Attendance_State = student.Attendance_State,
            studentId = student.studentId,
            Quiz_Grade = student.Quiz_Grade ,
            date = student.date
        };

        context.Student_Attendance.Add(studentAttendance);
    }

    context.SaveChanges();

    Console.WriteLine(stud);
    Console.WriteLine(stud.Count);
    return RedirectToAction("index" , "Home");
}

public IActionResult Get_Student_Attendance(int ID)
{
    var studAttendance = context.Student_Attendance
    .Where(x => x.studentId == ID).ToList();

    var student = context.Students.Find(ID);
    
    ViewBag.student = student ; 

    var groups = context.Groups.Find(ViewBag.student.groupId);

    ViewBag.group = groups;
    
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
