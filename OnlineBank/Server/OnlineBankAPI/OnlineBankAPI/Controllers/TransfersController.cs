using Microsoft.AspNetCore.Mvc;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Controllers;

[ApiController]
[Route("api/transfers")]
public class TransfersController : ControllerBase
{
    private readonly ITransferService _transferService;

    public TransfersController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> TransferAsync([FromBody] TransferModel transferModel)
    {
            await _transferService.TransferAsync(HttpContext, transferModel);
            return Ok("Transfer completed successfully");
    }
}