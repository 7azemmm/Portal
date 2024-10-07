using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers;


[Authorize]

public class StudentController : Controller
{


   ApplicationContext context ;

    public StudentController(ApplicationContext context, ILogger<StudentController> logger)
    {
        this.context = context;
        // Use the logger as needed
    }


   public IActionResult addStudent ()
   {
    var groups = context.Groups.ToList();
    ViewBag.groups = groups;
     return View();
   }

   public IActionResult updateStudent ( int? Id)
   {
    var Student = context.Students.Find(Id);
     var groups = context.Groups.ToList();
     ViewBag.groups = groups;
     return View(Student);
   }

   public IActionResult deleteStudent ( int? Id)
   {
      var student = context.Students.Find(Id) ;
     context.Students.Remove(student);
     context.SaveChanges();
     return RedirectToAction("index" , "Home");
   }

   [HttpPost]
public IActionResult update_Stud(Student student)
{
    if (student == null)
    {
        // Handle null model (shouldn't happen in well-formed form submissions)
        return RedirectToAction("Index", "Home");
    }

    // Find the existing student by ID
    var stud = context.Students.Find(student.Id);

    if (stud == null)
    {
        // Handle the case where the student with the provided ID is not found
        return RedirectToAction("Index", "Home");
    }

    // Update the student's details
    stud.Name = student.Name;
    stud.Stud_Phone_number = student.Stud_Phone_number;
    stud.Stud_Parent_Phone_number = student.Stud_Parent_Phone_number;
    stud.groupId = student.groupId;

    // Save the changes to the database
    context.SaveChanges();

    // Redirect to the Index action of the Home controller
    return RedirectToAction("Index", "Home");
}



    public IActionResult AddStud( Student student)
    {
        
        if(student == null){
            return BadRequest("object is empty");
        }
       
        if(student.Name!=null && student.Stud_Phone_number!=null && student.Stud_Parent_Phone_number!=null){
       
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

   
   public async Task<IActionResult> GetStudents(int? groupId)
    {
        // Get all groups for the select input
        ViewBag.Groups = await context.Groups.ToListAsync();

        // If no groupId is provided, return all students
        var students = groupId == null 
            ? await context.Students.ToListAsync()
            : await context.Students.Where(s => s.groupId == groupId).ToListAsync();

        return View(students);
    }

    public IActionResult Search_For_Student(int id){
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
