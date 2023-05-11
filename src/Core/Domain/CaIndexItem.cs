namespace Core.Domain;

public class CaIndexItem
{
    public string Status { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime? RevocationDate { get; set; }
    public string? RevocationReason { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
}