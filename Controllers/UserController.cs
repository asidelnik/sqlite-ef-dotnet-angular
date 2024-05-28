using Microsoft.AspNetCore.Mvc;
using sqlink.Data;
using sqlink.Dtos;
using sqlink.Models;
using sqlink.Services.IRepositories;
using sqlink.Services.Repositories;

namespace sqlink.Controllers;

[ApiController]
[Route("[users]")]
public class UserController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  private readonly IInsurancePolicyRepository _insurancePolicyRepository;

  public UserController()
  {
    _userRepository = new UserRepository(new InsuranceDbContext());
    _insurancePolicyRepository = new InsurancePolicyRepository(new InsuranceDbContext());
  }

  public UserController(IUserRepository userRepository, IInsurancePolicyRepository insurancePolicyRepository)
  {
    _userRepository = userRepository;
    _insurancePolicyRepository = insurancePolicyRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetUsers()
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
  public async Task<IActionResult> Add(UserDto user)
  {
    await _userRepository.AddAsync(user);
    _userRepository.Save();
    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, User user)
  {
    if (id != user.Id)
    {
      return BadRequest();
    }
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