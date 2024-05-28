
using Microsoft.AspNetCore.Mvc;
using sqlink.Data;
using sqlink.Dtos;
using sqlink.Services.IRepositories;
using sqlink.Services.Repositories;

namespace sqlink.Controllers;

[ApiController]
[Route("[insurance-policy]")]
public class InsurancePolicyController : ControllerBase
{
  private readonly IInsurancePolicyRepository _insurancePolicyRepository;

  public InsurancePolicyController()
  {
    _insurancePolicyRepository = new InsurancePolicyRepository(new InsuranceDbContext());
  }

  public InsurancePolicyController(IInsurancePolicyRepository insurancePolicyRepository)
  {
    _insurancePolicyRepository = insurancePolicyRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetInsurancePolicies()
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
  public async Task<IActionResult> Add(InsurancePolicyDto insurancePolicy)
  {
    await _insurancePolicyRepository.AddAsync(insurancePolicy);
    _insurancePolicyRepository.Save();
    return CreatedAtAction(nameof(Get), new { id = insurancePolicy.Id }, insurancePolicy);
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