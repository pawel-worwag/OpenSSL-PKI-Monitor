using Core.Abstractions;

namespace Core.Dto;

public record CertificationAuthority
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Certificate> CaCertificates { get; set; } = new List<Certificate>();
    public ICollection<Crl> Crls { get; set; } = new List<Crl>();
    public ICollection<CaIndexItem> Cerfiticates { get; set; } = new List<CaIndexItem>();
}

public static class CertificationAuthorityExtension
{
    public static CertificationAuthority Map(this Domain.CertificationAuthority source)
    {
        var r = new CertificationAuthority
        {
            Name = source.Name
        };
        foreach (var cert in source.CaCertificates) r.CaCertificates.Add(cert.Map());

        foreach (var crl in source.Crls) r.Crls.Add(crl.Map());

        foreach (var c in source.Certificates) r.Cerfiticates.Add(c.Map());
        return r;
    }
}