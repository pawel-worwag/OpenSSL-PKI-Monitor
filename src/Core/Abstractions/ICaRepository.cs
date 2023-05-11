using Core.Domain;

namespace Core.Abstractions;

public interface ICaRepository
{
    List<CertificationAuthority> GetCertificateAuthorities();
}