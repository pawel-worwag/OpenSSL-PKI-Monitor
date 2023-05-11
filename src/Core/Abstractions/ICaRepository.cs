namespace Core.Abstractions;

public interface ICaRepository
{
    List<Domain.CertificationAuthority> GetCertificateAuthorities();
}