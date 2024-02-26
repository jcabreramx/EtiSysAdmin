using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Server.Servicios
{
    public interface IDepartamentoServicio
    {
        Task<ResponseDTO<List<DepartamentoDTO>>> Lista(string Valor);
        Task<ResponseDTO<DepartamentoDTO>> Obtener(int id);
        Task<ResponseDTO<DepartamentoDTO>> Crear(DepartamentoDTO modelo);
        Task<ResponseDTO<bool>> Editar(DepartamentoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
