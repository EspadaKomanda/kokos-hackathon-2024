using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Database.Models;

public class Subscription
{
  [Key]
  public int Id { get; set; }
  
  [ForeignKey("FanId")]
  public int FanId { get; set; }
  public User Fan { get; set; } = null!;

  [ForeignKey("PlayerId")]
  public int PlayerId { get; set; }
  public User Player { get; set; } = null!;

  // TODO: must make FanId and PlayerId unique together
}
