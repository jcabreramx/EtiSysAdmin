using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Client.Servicios
{
    public interface IDepartamentoServicio
    {
        Task<ResponseDTO<List<DepartamentoDTO>>> Lista(string Valor);
        Task<ResponseDTO<DepartamentoDTO>> Obtener(int Id);
        Task<ResponseDTO<DepartamentoDTO>> Crear(DepartamentoDTO modelo);
        Task<ResponseDTO<bool>> Editar(DepartamentoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);
    }
}
