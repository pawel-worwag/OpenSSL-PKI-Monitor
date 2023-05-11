using Core.Abstractions;
using Org.BouncyCastle.X509;

namespace Core.Dto;

public record Crl
{
    public int Version { get; init; }
    public DateTime ThisUpdate { get; init; }
    public DateTime NextUpdate { get; init; }
    public string Issuer { get; init; } = string.Empty;
    public ValidState State { get; set; } = ValidState.Invalid;
}

public static class CrlExtensions
{
    public static Crl Map(this X509Crl source)
    {
        ValidState state = ValidState.Valid;
        var current = DateTime.UtcNow;
        if (source.NextUpdate.Value.AddDays(-7) <= current)
        {
            state = ValidState.Alert;
        }
        if (source.NextUpdate.Value <= current)
        {
            state = ValidState.Invalid;
        }
        return new Crl
        {
            Version = source.Version,
            ThisUpdate = source.ThisUpdate,
            NextUpdate = source.NextUpdate.Value,
            Issuer = source.IssuerDN.ToString(),
            State = state
        };
    }
}