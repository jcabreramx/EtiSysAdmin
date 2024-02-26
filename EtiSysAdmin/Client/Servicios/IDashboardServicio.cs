using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Client.Servicios
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
