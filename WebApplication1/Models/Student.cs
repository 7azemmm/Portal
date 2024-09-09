using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Student
{
    [Key]
    public int? Id { get; set; }

    public string? Name {get; set;}

    public string? Stud_Phone_number {get; set;}

     public string? Stud_Parent_Phone_number {get; set;}

     public int groupId {get ; set;}

     [ForeignKey("groupId")]

     public virtual Group? group {get; set;}






}
