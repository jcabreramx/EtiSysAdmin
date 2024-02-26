using EtiSysAdmin.Shared;

namespace EtiSysAdmin.Client.Servicios
{
    public interface ICarritoServicio
    {
        event Action ActualizarVista;
        int CantidadProductos();
        Task AgregarCarrito(CarritoDTO modelo);
        Task EliminarCarrito(int idProducto);
        Task<List<CarritoDTO>> DevolverCarrito();
        Task LimpiarCarrito();
    }
}
