using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TeamDTO, Team>();
            CreateMap<Team, TeamDTO>();

            CreateMap<UserPolicyDTO, UserPolicy>();
            //CreateMap<RoleDTO, Role>();
            //CreateMap<Role, RoleDTO>();
            CreateMap<PolicyDTO, Policy>();
            CreateMap<Policy, PolicyDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<FileCM, FileDTO>();
            CreateMap<FileDTO, FileCM>();
            CreateMap<RolePermission, RolePermissionDTO>();
            CreateMap<RolePermissionDTO, RolePermission>();


            CreateMap<Role, RoleDTO>()
     .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
     .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
     .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
     .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions));

            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions));
        }
    }
}
