using AutoMapper;
using Bee.Data.Abstractions.Extensions;
using Bee.Data.Service.Models;
using Bee.Desktop.Wpf.PoC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Mapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<User, UserModel>()
                //.ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                //.ForMember(d => d.EmailAddress, o => o.MapFrom(s => s.EmailAddress))
                //.ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsSelected, o => o.MapFrom(s => false));
        }
    }
}
