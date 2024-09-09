using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Student_Attendance
{
    [Key]
    public int? Id { get; set; }

    public string? Name {get; set;}

    public string? Attendance_State {get ;set;}

     

}