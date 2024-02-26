using EtiSysAdmin.Server.Repositorios;
using EtiSysAdmin.Shared;
using Microsoft.EntityFrameworkCore;

namespace EtiSysAdmin.Server.Servicios
{
    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly IGenericoRepositorio<Departamento> _departamentoRepositorio;
        private readonly IMapper _mapper;
        public DepartamentoServicio(IGenericoRepositorio<Departamento> departamentoRepositorio, IMapper mapper)
        {
            _departamentoRepositorio = departamentoRepositorio;
            _mapper = mapper;

        }
        public async Task<ResponseDTO<List<DepartamentoDTO>>> Lista(string Valor)
        {
            ResponseDTO<List<DepartamentoDTO>> response = new ResponseDTO<List<DepartamentoDTO>>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _departamentoRepositorio.Consultar(c =>
                    c.Nombre!.ToLower().Contains(Valor.ToLower())
                );

                List<DepartamentoDTO> lista = _mapper.Map<List<DepartamentoDTO>>(await consulta.ToListAsync());
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
        public async Task<ResponseDTO<DepartamentoDTO>> Crear(DepartamentoDTO modelo)
        {
            ResponseDTO<DepartamentoDTO> response = new ResponseDTO<DepartamentoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var dbModelo = _mapper.Map<Departamento>(modelo);
                var rspModelo = await _departamentoRepositorio.Crear(dbModelo);

                if (rspModelo.IdDepartamento != 0)
                    response.Resultado = _mapper.Map<DepartamentoDTO>(rspModelo);
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
        public async Task<ResponseDTO<DepartamentoDTO>> Obtener(int id)
        {
            ResponseDTO<DepartamentoDTO> response = new ResponseDTO<DepartamentoDTO>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _departamentoRepositorio.Consultar(p => p.IdDepartamento == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    response.Resultado = _mapper.Map<DepartamentoDTO>(fromDbModelo);
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

        public async Task<ResponseDTO<bool>> Editar(DepartamentoDTO modelo)
        {

            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                Mensaje = "Ok",
                EsCorrecto = true
            };

            try
            {
                var consulta = _departamentoRepositorio.Consultar(p => p.IdDepartamento == modelo.IdDepartamento);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Estatus = modelo.Estatus;

                    var respuesta = await _departamentoRepositorio.Editar(fromDbModelo);

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
                var consulta = _departamentoRepositorio.Consultar(p => p.IdDepartamento == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _departamentoRepositorio.Eliminar(fromDbModelo);

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
