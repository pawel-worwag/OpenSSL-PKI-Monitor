namespace Core.Dto;

public class CaIndexItem
{
    public string Status { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime? RevocationDate { get; set; }
    public string? RevocationReason { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
}

public static class IndexItemExtensions
{
    public static CaIndexItem Map(this Domain.CaIndexItem source)
    {
        return new CaIndexItem
        {
            Status = source.Status,
            ExpirationDate = source.ExpirationDate,
            RevocationDate = source.RevocationDate,
            RevocationReason = source.RevocationReason,
            SerialNumber = source.SerialNumber,
            DistinguishedName = source.DistinguishedName
        };
    }
}