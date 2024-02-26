using EtiSysAdmin.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace EtiSysAdmin.Client.Servicios
{
    public class PerfilServicio : IPerfilServicio
    {
        private readonly HttpClient _httpClient;
        public PerfilServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<PerfilDTO>> Crear(PerfilDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Perfil/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PerfilDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PerfilDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Perfil/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"/api/Perfil/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<PerfilDTO>>> Lista(string Valor)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PerfilDTO>>>($"/api/Perfil/Lista/{Valor}");
        }

        public async Task<ResponseDTO<PerfilDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PerfilDTO>>($"/api/Perfil/Obtener/{Id}");
        }
    }
}
