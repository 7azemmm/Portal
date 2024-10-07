using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Student_Attendance
{
    [Key]
    public int? Id { get; set; }

    public string? Name {get; set;}

    public string? Attendance_State {get ;set;}

    
      public int studentId{get; set;}

       [ForeignKey("studentId")]
    public virtual Student? student {get ; set ;}

    public string? Quiz_Grade {get; set;}

    public string? date{get; set;}  

}