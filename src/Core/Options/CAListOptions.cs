namespace Core.Options;

public class CAListOptions
{
    public ICollection<CertificationAuthorityOptions> CertificationAuthorities { get; set; } =
        new List<CertificationAuthorityOptions>();
}