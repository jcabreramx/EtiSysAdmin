using EtiSysAdmin.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace EtiSysAdmin.Client.Servicios
{
    public class PuestoServicio : IPuestoServicio
    {
        private readonly HttpClient _httpClient;
        public PuestoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<PuestoDTO>> Crear(PuestoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Puesto/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PuestoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PuestoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Puesto/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Puesto/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<PuestoDTO>>> Lista(string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PuestoDTO>>>($"/api/Puesto/Lista/{Valor}");
        }

        public async Task<ResponseDTO<PuestoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PuestoDTO>>($"/api/Puesto/Obtener/{Id}");
        }
    }
}
