using System.ComponentModel.DataAnnotations;

namespace UserService.Database.Models;

public class User
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set;} = null!;

  [Required]
  public string Email { get; set; } = null!;

  [Required]
  public string Password { get; set; } = null!;

  [Required]
  public int RoleId { get; set; }
  public Role Role { get; set; } = null!;

  public int ProfileId { get; set; }
  public Profile Profile { get; set; } = null!;

  public DateTime RefreshTokenTime { get; set; }
}
