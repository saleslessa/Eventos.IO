using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(p =>
            {
                p.AddProfile(new DomainToViewModeMappingProfile());
                p.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
