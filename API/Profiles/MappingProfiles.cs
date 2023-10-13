using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auditoria,AuditoriaDto>().ReverseMap();
            CreateMap<Blockchain,BlockchainDto>().ReverseMap();
            CreateMap<EstadoNotificacion,EstadoNotificacionDto>().ReverseMap();
            CreateMap<Formato,FormatoDto>().ReverseMap();
            CreateMap<GenericosVsSubmoduloDto,GenericosVsSubmoduloDto>().ReverseMap();
            CreateMap<HiloRespuestaNotificacion,HiloRespuestaNotificacionDto>().ReverseMap();
            CreateMap<MaestrosVsSubmodulo,MaestrosVsSubmoduloDto>().ReverseMap();
            CreateMap<ModuloNotificacion,ModuloNotificacionDto>().ReverseMap();
            CreateMap<ModulosMaestro,ModulosMaestroDto>().ReverseMap();
            CreateMap<PermisoGenerico,PermisoGenericoDto>().ReverseMap();
            CreateMap<Radicado,RadicadoDto>().ReverseMap();
            CreateMap<Rol,RolDto>().ReverseMap();
            CreateMap<RolVsMaestro,RolVsMaestroDto>().ReverseMap();
            CreateMap<Submodulo,SubmoduloDto>().ReverseMap();
            CreateMap<TipoNotificacion,TipoNotificacionDto>().ReverseMap();
            CreateMap<TipoRequerimiento,TipoRequerimientoDto>().ReverseMap();
            
        }
    }
}