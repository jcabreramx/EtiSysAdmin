using EtiSysAdmin.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace EtiSysAdmin.Client.Servicios
{
    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly HttpClient _httpClient;
        public DepartamentoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<DepartamentoDTO>> Crear(DepartamentoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Departamento/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<DepartamentoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(DepartamentoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Departamento/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Departamento/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<DepartamentoDTO>>> Lista(string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<DepartamentoDTO>>>($"/api/Departamento/Lista/{Valor}");
        }

        public async Task<ResponseDTO<DepartamentoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DepartamentoDTO>>($"/api/Departamento/Obtener/{Id}");
        }
    }
}
