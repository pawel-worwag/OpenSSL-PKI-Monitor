namespace Core.Options;

public class CaOptions
{
    public ICollection<CertificationAuthority> CertificationAuthorities { get; set; } =
        new List<CertificationAuthority>();
}