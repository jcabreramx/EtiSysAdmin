using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Client.Servicios
{
    public interface IPerfilServicio
    {
        Task<ResponseDTO<List<PerfilDTO>>> Lista(string Valor);
        Task<ResponseDTO<PerfilDTO>> Obtener(int Id);
        Task<ResponseDTO<PerfilDTO>> Crear(PerfilDTO modelo);
        Task<ResponseDTO<bool>> Editar(PerfilDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);
    }
}
