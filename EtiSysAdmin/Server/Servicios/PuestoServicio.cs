using EtiSysAdmin.Server.Repositorios;
using EtiSysAdmin.Shared;
using Microsoft.EntityFrameworkCore;

namespace EtiSysAdmin.Server.Servicios
{
    public class PuestoServicio : IPuestoServicio
    {
        private readonly IGenericoRepositorio<Puesto> _puestoRepositorio;
        private readonly IMapper _mapper;
        public PuestoServicio(IGenericoRepositorio<Puesto> puestoRepositorio, IMapper mapper)
        {
            _puestoRepositorio = puestoRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<List<PuestoDTO>>> Lista(string Valor)
        {
            ResponseDTO<List<PuestoDTO>> response = new ResponseDTO<List<PuestoDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _puestoRepositorio.Consultar(c =>
                    c.Nombre!.ToLower().Contains(Valor.ToLower())
                );

                List<PuestoDTO> lista = _mapper.Map<List<PuestoDTO>>(await consulta.ToListAsync());
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
        public async Task<ResponseDTO<PuestoDTO>> Crear(PuestoDTO modelo)
        {
            ResponseDTO<PuestoDTO> response = new ResponseDTO<PuestoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Puesto>(modelo);
                var rspModelo = await _puestoRepositorio.Crear(dbModelo);

                if (rspModelo.IdPuesto != 0)
                    response.Resultado = _mapper.Map<PuestoDTO>(rspModelo);
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
        public async Task<ResponseDTO<PuestoDTO>> Obtener(int id)
        {
            ResponseDTO<PuestoDTO> response = new ResponseDTO<PuestoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _puestoRepositorio.Consultar(p => p.IdPuesto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<PuestoDTO>(fromDbModelo);
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

        public async Task<ResponseDTO<bool>> Editar(PuestoDTO modelo)
        {

            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _puestoRepositorio.Consultar(p => p.IdPuesto == modelo.IdPuesto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Estatus = modelo.Estatus;

                    var respuesta = await _puestoRepositorio.Editar(fromDbModelo);

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
                var consulta = _puestoRepositorio.Consultar(p => p.IdPuesto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _puestoRepositorio.Eliminar(fromDbModelo);

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
