using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ToDo.Data;
using ToDo.Services;

namespace ToDo.Core.AutoMapper
{
    public class AutoMapperBootstrap
    {
        public static void Initialize()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<ViewModelProfile>();
            });
        }
    }

    public class ViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModel"; }
        }

        protected override void Configure()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
