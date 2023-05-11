using System.Security.Cryptography.X509Certificates;

namespace Core.Dto;

public record CaCertificate
{
    public string Subject { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public DateTime NotBefore { get; set; }
    public DateTime NotAfter { get; set; }
}

public static class CaCertificateExtensions
{
    public static CaCertificate Map(this X509Certificate2 source)
    {
        
        return new CaCertificate()
        {
            Subject = source.Subject,
            SerialNumber = source.SerialNumber,
            Issuer = source.Issuer,
            NotBefore = source.NotBefore,
            NotAfter = source.NotAfter
        };
    }
}