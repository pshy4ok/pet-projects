using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface ITransferService
{
    Task TransferAsync(HttpContext httpContext, TransferModel transferModel);
}