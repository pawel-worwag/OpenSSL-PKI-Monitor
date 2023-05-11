namespace Core.Dto;

public record CertificationAuthority
{
    public string Name { get; set; } = String.Empty;
    public ICollection<CaCertificate> CaCertificates { get; set; } = new List<CaCertificate>();
    public ICollection<Crl> Crls { get; set; } = new List<Crl>();
    public ICollection<IndexItem> Cerfiticates { get; set; } = new List<IndexItem>();
}

public static class CertificationAuthorityExtension
{
    public static CertificationAuthority Map(this Domain.CertificationAuthority source)
    {
        var r = new CertificationAuthority()
        {
            Name = source.Name
        };
        foreach (var cert in source.CaCertificates)
        {
            r.CaCertificates.Add(cert.Map());
        }

        foreach (var crl in source.Crls)
        {
            r.Crls.Add(crl.Map());
        }

        foreach (var c in source.Certificates)
        {
            r.Cerfiticates.Add(c.Map());
        }
        return r;
    }
}