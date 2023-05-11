using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.X509;

namespace Core.Domain;

public class CertificationAuthority
{
    public string Name { get; set; } = String.Empty;
    public List<X509Certificate2> CaCertificates { get; set; } = new List<X509Certificate2>();
    public List<X509Crl> Crls { get; set; } = new List<X509Crl>();
    public List<IndexItem> Certificates { get; set; } = new List<IndexItem>();
}