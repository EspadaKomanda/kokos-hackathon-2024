using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Database.Models;

public class User
{
  [Key]
  public int Id { get; set; }

  public string Name { get; set;} = null!;

  public string Email { get; set; } = null!;

  public string Password { get; set; } = null!;

  [ForeignKey("RoleId")]
  public int RoleId { get; set; }
  public Role Role { get; set; } = null!;
  [ForeignKey("ProfileId")]
  public int ProfileId { get; set; }
  public Profile Profile { get; set; } = null!;

}
