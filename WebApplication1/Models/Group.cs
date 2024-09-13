using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Group
{
    [Key]
    public int? Id { get; set; }

    public string? Name {get; set;}

   public virtual ICollection<Student>? Students {get; set;}





}
