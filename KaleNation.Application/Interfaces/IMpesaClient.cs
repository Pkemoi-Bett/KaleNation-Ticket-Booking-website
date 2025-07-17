namespace KaleNation.Application.Interfaces;

public interface IMpesaClient
{
    /// <summary>
    /// Sends an STK Push request to MPesa for the given number and amount.
    /// </summary>
    Task<bool> InitiateStkPushAsync(string phoneNumber, decimal amount);
}
