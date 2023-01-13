using System.ComponentModel.DataAnnotations;

namespace BakeryAuth.Models 
{
  public class Treat {
    [Key]
    public int treat_id {get; set;}
    public int user_id {get; set;}
    public string name {get; set;}
  }
}