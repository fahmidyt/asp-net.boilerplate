namespace User.Models;

public class UserModel {
  public int Id { get; set; }
  
  public string? Name { get; set; }

  public string? Password { get; set; }

  public bool Active { get; set; }
}