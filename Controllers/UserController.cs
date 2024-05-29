using Microsoft.AspNetCore.Mvc;
using sqlink.Dtos;
using sqlink.Models;
using sqlink.Services.IRepositories;

namespace sqlink.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  private readonly IInsurancePolicyRepository _insurancePolicyRepository;

  public UserController(IUserRepository userRepository, IInsurancePolicyRepository insurancePolicyRepository)
  {
    _userRepository = userRepository;
    _insurancePolicyRepository = insurancePolicyRepository;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var users = await _userRepository.GetAsync();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var user = await _userRepository.GetByIdAsync(id);
    if (user == null)
    {
      return NotFound();
    }
    return Ok(user);
  }

  [HttpPost]
  public async Task<IActionResult> Add(UserDto newUser)
  {
    User user = new()
    {
      Name = newUser.Name,
      Email = newUser.Email,
    };

    await _userRepository.AddAsync(user);
    _userRepository.Save();
    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UserDto updateUser)
  {
    User user = await _userRepository.GetByIdAsync(id);
    if (user == null)
    {
      return NotFound();
    }
    user.Name = updateUser.Name;
    user.Email = updateUser.Email;
    await _userRepository.UpdateAsync(user);
    _userRepository.Save();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var user = await _userRepository.GetByIdAsync(id);
    if (user == null)
    {
      return NotFound();
    }
    await _userRepository.DeleteAsync(id);
    _userRepository.Save();
    return NoContent();
  }

  [HttpGet("{id}/insurance-policies")]
  public ActionResult<IEnumerable<InsurancePolicy>> GetInsurancePolicies(int id)
  {
    return Ok(_insurancePolicyRepository.GetAsync().Result.Where(x => x.UserId == id));
  }

  // protected override void Dispose(bool disposing)
  // {
  //   _userRepository.Dispose();
  //   base.Dispose(disposing);
  // }
}