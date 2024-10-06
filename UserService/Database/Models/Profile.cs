using System.ComponentModel.DataAnnotations;

namespace UserService.Database.Models;

public class Profile
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int UserId { get; set; }
  [Required]
  public User User { get; set; } = null!;

  public string? Bio { get; set; }

  public string? AvatarLink { get; set; }

  public string? TelegramLink { get; set; }

  public string? VKLink { get; set; }
}
