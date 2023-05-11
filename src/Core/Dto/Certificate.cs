using System.Security.Cryptography.X509Certificates;
using Core.Abstractions;

namespace Core.Dto;

public record Certificate
{
    public string Subject { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public DateTime NotBefore { get; set; }
    public DateTime NotAfter { get; set; }
    public ValidState State { get; set; } = ValidState.Invalid;
}

public static class CaCertificateExtensions
{
    public static Certificate Map(this X509Certificate2 source)
    {
        ValidState state = ValidState.Valid;
        var current = DateTime.UtcNow;
        if (source.NotAfter.AddDays(-7) <= current)
        {
            state = ValidState.Alert;
        }
        if (source.NotAfter <= current)
        {
            state = ValidState.Invalid;
        }
        return new Certificate
        {
            Subject = source.Subject,
            SerialNumber = source.SerialNumber,
            Issuer = source.Issuer,
            NotBefore = source.NotBefore,
            NotAfter = source.NotAfter,
            State = state
        };
    }
}