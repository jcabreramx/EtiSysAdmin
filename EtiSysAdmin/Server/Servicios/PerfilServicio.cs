using EtiSysAdmin.Server.Repositorios;
using EtiSysAdmin.Shared;
using Microsoft.EntityFrameworkCore;

namespace EtiSysAdmin.Server.Servicios
{
    public class PerfilServicio : IPerfilServicio
    {
        private readonly IGenericoRepositorio<Perfil> _perfilRepositorio;
        private readonly IMapper _mapper;
        public PerfilServicio(IGenericoRepositorio<Perfil> perfilRepositorio, IMapper mapper)
        {
            _perfilRepositorio = perfilRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<List<PerfilDTO>>> Lista(string Valor)
        {
            ResponseDTO<List<PerfilDTO>> response = new ResponseDTO<List<PerfilDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _perfilRepositorio.Consultar(c =>
                    c.Nombre!.ToLower().Contains(Valor.ToLower())
                );

                List<PerfilDTO> lista = _mapper.Map<List<PerfilDTO>>(await consulta.ToListAsync());
                response.Resultado = lista;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
            return response;
        }
        public async Task<ResponseDTO<PerfilDTO>> Crear(PerfilDTO modelo)
        {
            ResponseDTO<PerfilDTO> response = new ResponseDTO<PerfilDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Perfil>(modelo);
                var rspModelo = await _perfilRepositorio.Crear(dbModelo);

                if (rspModelo.IdPerfil != 0)
                    response.Resultado = _mapper.Map<PerfilDTO>(rspModelo);
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se pudo crear";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }

            return response;
        }
        public async Task<ResponseDTO<PerfilDTO>> Obtener(int id)
        {
            ResponseDTO<PerfilDTO> response = new ResponseDTO<PerfilDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _perfilRepositorio.Consultar(p => p.IdPerfil == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<PerfilDTO>(fromDbModelo);
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron coincidencias";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = null;
            }
            return response;
        }

        public async Task<ResponseDTO<bool>> Editar(PerfilDTO modelo)
        {

            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _perfilRepositorio.Consultar(p => p.IdPerfil == modelo.IdPerfil);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Estatus = modelo.Estatus;

                    var respuesta = await _perfilRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                    {
                        response.EsCorrecto = false;
                        response.Mensaje = "No se pudo editar";
                    }
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron resultados";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = false;
            }

            return response;

        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _perfilRepositorio.Consultar(p => p.IdPerfil == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _perfilRepositorio.Eliminar(fromDbModelo);

                    if (!respuesta)
                    {
                        response.EsCorrecto = false;
                        response.Mensaje = "No se pudo eliminar";
                    }
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontraron resultados";
                }

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
                response.Resultado = false;
            }

            return response;
        }




    }
}
