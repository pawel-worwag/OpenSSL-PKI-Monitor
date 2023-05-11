using Core.Abstractions;

namespace Core.Dto;

public class CaIndexItem
{
    public string Status { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime? RevocationDate { get; set; }
    public string? RevocationReason { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
    public ValidState State { get; set; } = ValidState.Invalid;
}

public static class IndexItemExtensions
{
    public static CaIndexItem Map(this Domain.CaIndexItem source)
    {
        ValidState state = ValidState.Valid;
        var current = DateTime.UtcNow;
        if (source.ExpirationDate.AddDays(-7) <= current)
        {
            state = ValidState.Alert;
        }
        if (source.ExpirationDate <= current)
        {
            state = ValidState.Invalid;
        }

        return new CaIndexItem
        {
            Status = source.Status,
            ExpirationDate = source.ExpirationDate,
            RevocationDate = source.RevocationDate,
            RevocationReason = source.RevocationReason,
            SerialNumber = source.SerialNumber,
            DistinguishedName = source.DistinguishedName,
            State = state
        };
    }
}