using AutoMapper;
using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Server.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Persona
            CreateMap<Persona, PersonaDTO>();
            CreateMap<Persona, SesionDTO>();
            CreateMap<PersonaDTO, Persona>();
            #endregion Persona

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();
            #endregion Categoria

            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();
            #endregion Departamento

            #region Puesto
            CreateMap<Puesto, PuestoDTO>();
            CreateMap<PuestoDTO, Puesto>();
            #endregion Puesto

            #region Perfil
            CreateMap<Perfil, PerfilDTO>();
            CreateMap<PerfilDTO, Perfil>();
            #endregion Perfil

            #region Categoria
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>().ForMember(destino =>
                    destino.IdCategoriaNavigation,
                    opt => opt.Ignore()
                ); ;
            #endregion Categoria

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>();
            CreateMap<DetalleVentaDTO, DetalleVenta>();
            #endregion DetalleVenta

            #region Venta
            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();
            #endregion Venta
        }
    }
}
