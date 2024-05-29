
using Microsoft.AspNetCore.Mvc;
using sqlink.Dtos;
using sqlink.Models;
using sqlink.Services.IRepositories;

namespace sqlink.Controllers;

[Route("api/insurance-policy")]
[ApiController]
public class InsurancePolicyController : ControllerBase
{
  private readonly IInsurancePolicyRepository _insurancePolicyRepository;
  private readonly IUserRepository _userRepository;

  public InsurancePolicyController(IInsurancePolicyRepository insurancePolicyRepository, IUserRepository userRepository)
  {
    _insurancePolicyRepository = insurancePolicyRepository;
    _userRepository = userRepository;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var insurancePolicies = await _insurancePolicyRepository.GetAsync();
    return Ok(insurancePolicies);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var insurancePolicy = await _insurancePolicyRepository.GetByIdAsync(id);
    if (insurancePolicy == null)
    {
      return NotFound();
    }
    return Ok(insurancePolicy);
  }

  [HttpPost]
  public async Task<IActionResult> Add(InsurancePolicyDto newItem)
  {
    User user = await _userRepository.GetByIdAsync(newItem.UserId);
    InsurancePolicy insurance = new()
    {
      PolicyNumber = newItem.PolicyNumber,
      InsuranceAmount = newItem.InsuranceAmount,
      StartDate = newItem.StartDate,
      EndDate = newItem.EndDate,
      UserId = newItem.UserId,
      User = user
    };

    await _insurancePolicyRepository.AddAsync(insurance);
    _insurancePolicyRepository.Save();
    return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, InsurancePolicy insurancePolicy)
  {
    if (id != insurancePolicy.Id)
    {
      return BadRequest();
    }

    await _insurancePolicyRepository.UpdateAsync(insurancePolicy);
    _insurancePolicyRepository.Save();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _insurancePolicyRepository.DeleteAsync(id);
    _insurancePolicyRepository.Save();
    return NoContent();
  }
}