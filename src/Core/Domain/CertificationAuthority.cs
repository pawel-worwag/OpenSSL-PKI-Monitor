using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.X509;

namespace Core.Domain;

public class CertificationAuthority
{
    public string Name { get; set; } = string.Empty;
    public List<X509Certificate2> CaCertificates { get; set; } = new();
    public List<X509Crl> Crls { get; set; } = new();
    public List<CaIndexItem> Certificates { get; set; } = new();
}