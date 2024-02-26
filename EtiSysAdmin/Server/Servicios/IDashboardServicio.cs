using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Server.Servicios
{
    public interface IDashboardServicio
    {
        ResponseDTO<DashBoardDTO> Resumen();
    }
}
