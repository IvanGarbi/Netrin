using AutoMapper;
using Netrin.App.Models;
using Netrin.Domain.Models;

namespace Netrin.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
            CreateMap<PessoaViewModel, Pessoa>().ForMember(x => x.Endereco, z => z.MapFrom(a => a.EnderecoViewModel))
                                                               .ReverseMap();
            CreateMap<GetPessoaViewModel, Pessoa>().ForMember(x => x.Endereco, z => z.MapFrom(a => a.EnderecoViewModel))
                                                               .ReverseMap();
            CreateMap<EnderecoViewModel, Endereco>().ForMember(x => x.Pessoa, z => z.MapFrom(a => a.PessoaViewModel))
                                                               .ReverseMap();
        }
    }
}
