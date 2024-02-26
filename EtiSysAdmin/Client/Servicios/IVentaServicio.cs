using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Client.Servicios
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
