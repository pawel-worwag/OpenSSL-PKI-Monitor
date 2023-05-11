namespace Core.Options;

public class CertificationAuthorityOptions
{
    public string Name { get; set; } = string.Empty;
    public string IndexPath { get; set; } = string.Empty;
    public ICollection<string> Certificates { get; set; } = new List<string>();
    public ICollection<string> Crls { get; set; } = new List<string>();
}