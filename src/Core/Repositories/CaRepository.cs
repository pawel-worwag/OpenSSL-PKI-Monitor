using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using Core.Abstractions;
using Core.Domain;
using Core.Options;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.X509;

namespace Core.Repositories;

public class CaRepository : ICaRepository
{
    private readonly Options.CAListOptions _caOptions;
    private readonly IIndexParser _parser;

    public CaRepository(IOptions<CAListOptions> caOptions, IIndexParser parser)
    {
        _parser = parser;
        _caOptions = caOptions.Value;
    }

    public List<CertificationAuthority> GetCertificateAuthorities()
    {
        var ret = new List<CertificationAuthority>();
        foreach (var caOpt in _caOptions.CertificationAuthorities)
        {
           var ca  =  new CertificationAuthority()
            {
                Name = caOpt.Name
            };
           foreach (var file in caOpt.Certificates)
           {
               var cert = new X509Certificate2(file);
               ca.CaCertificates.Add(cert);
           }

           foreach (var file in caOpt.Crls)
           {
               System.Numerics.BigInteger nr = new();
               X509CrlParser xx = new X509CrlParser();
               var crl = xx.ReadCrl(File.ReadAllBytes(file));
               ca.Crls.Add(crl);
           }

           ca.Certificates.AddRange(_parser.ParseFile(caOpt.IndexPath));
           ret.Add(ca);

        }
        return ret;
    }
}