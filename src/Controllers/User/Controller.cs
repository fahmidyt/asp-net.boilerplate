using User.Models;
using User.Service;
using Microsoft.AspNetCore.Mvc;

namespace User.Controller;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
  public UserController() { }

  // GET all action
  [HttpGet]
  public ActionResult<List<UserModel>> GetAll() => UserService.GetAll();

  // GET by Id action
  [HttpGet("{id}")]
  public ActionResult<UserModel> Get(int id)
  {
    var user = UserService.Get(id);
    if (user is null) return NotFound();

    return user;
  }

  // POST action
  [HttpPost]
  public IActionResult Create(UserModel user)
  {
    UserService.Add(user);
    return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
  }

  // PUT action
  [HttpPut("{id}")]
  public IActionResult Update(int id, UserModel user)
  {
    var existingUser = UserService.Get(id);
    if (existingUser is null)
      return NotFound();

    UserService.Update(id, user);

    return NoContent();
  }

  // DELETE action
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var user = UserService.Get(id);

    if (user is null)
      return NotFound();

    UserService.Delete(id);
    return NoContent();
  }
}