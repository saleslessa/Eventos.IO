using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Eventos;

namespace Eventos.IO.Application.AutoMapper
{
    internal class DomainToViewModeMappingProfile : Profile
    {
        public DomainToViewModeMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}