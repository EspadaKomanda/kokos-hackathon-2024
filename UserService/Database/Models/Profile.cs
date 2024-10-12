using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Database.Models;

public class Profile
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("UserId")]
  public int UserId { get; set; }
  public User User { get; set; } = null!;

  public string? Bio { get; set; }

  public string? AvatarLink { get; set; }

  public string? TelegramLink { get; set; }

  public string? VKLink { get; set; }
}
