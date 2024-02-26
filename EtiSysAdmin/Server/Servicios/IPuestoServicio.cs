using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Server.Servicios
{
    public interface IPuestoServicio
    {
        Task<ResponseDTO<List<PuestoDTO>>> Lista(string Valor);
        Task<ResponseDTO<PuestoDTO>> Obtener(int id);
        Task<ResponseDTO<PuestoDTO>> Crear(PuestoDTO modelo);
        Task<ResponseDTO<bool>> Editar(PuestoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
