using Org.BouncyCastle.X509;

namespace Core.Dto;

public record Crl
{
    public int Version { get; init; }
    public DateTime ThisUpdate { get; init; }
    public DateTime NextUpdate { get; init; }
    public string Issuer { get; init; } = string.Empty;
}

public static class CrlExtensions
{
    public static Crl Map(this X509Crl source)
    {
        return new Crl
        {
            Version = source.Version,
            ThisUpdate = source.ThisUpdate,
            NextUpdate = source.NextUpdate.Value,
            Issuer = source.IssuerDN.ToString()
        };
    }
}