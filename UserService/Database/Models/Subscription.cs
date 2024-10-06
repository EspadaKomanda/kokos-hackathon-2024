using System.ComponentModel.DataAnnotations;

namespace UserService.Database.Models;

public class Subscription
{
  [Key]
  public int Id { get; set; }
  
  [Required]
  public int FanId { get; set; }
  [Required]
  public User Fan { get; set; } = null!;

  [Required]
  public int PlayerId { get; set; }
  [Required]
  public User Player { get; set; } = null!;

  // TODO: must make FanId and PlayerId unique together
}
