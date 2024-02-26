using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Server.Servicios
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
