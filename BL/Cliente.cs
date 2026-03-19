using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        //Add
        public static ML.Result AddEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ClienteAPIEntities context = new DL.ClienteAPIEntities())
                {
                    int filasAfectadas = context.ClienteAdd(
                        cliente.Nombre,
                        cliente.Email,
                        cliente.Telefono,
                        cliente.Ciudad
                        );
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar al cliente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //Update
        public static ML.Result UpdateEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ClienteAPIEntities context = new DL.ClienteAPIEntities())
                {
                    int filasAfectadas = context.ClienteUpdate(
                        cliente.IdCliente,
                        cliente.Nombre,
                        cliente.Email,
                        cliente.Telefono,
                        cliente.Ciudad
                        );
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar al cliente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //DELETE
        public static ML.Result DeleteEF(int IdCliente) //solo ID
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ClienteAPIEntities context = new DL.ClienteAPIEntities())
                {
                    int filasAfectadas = context.ClienteDelete(IdCliente);

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar al cliente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //GetAll

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try 
            {
                using (DL.ClienteAPIEntities context = new DL.ClienteAPIEntities())
                {
                    var query = context.ClienteGetAll().ToList();
                    result.Objects = new List<object>(); //lista

                    
                    if (query.Count > 0 )
                    {
                        foreach (var fila in query)
                        {
                            ML.Cliente cliente = new ML.Cliente();
                            cliente.IdCliente = fila.IdCliente;
                            cliente.Nombre = fila.Nombre;
                            cliente.Email = fila.Email;
                            cliente.Telefono = fila.Telefono;
                            cliente.Ciudad = fila.Ciudad;

                            result.Objects.Add(cliente); //Agregamos a la lista
                        }

                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron datos";
                    }

                }
            }
            catch(Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //GetById
        public static ML.Result GetByIdEF(int IdCliente) 
        {
            ML.Result result = new ML.Result();
            try 
            {
                using (DL.ClienteAPIEntities context = new DL.ClienteAPIEntities()) 
                {
                    var query = context.ClienteGetById((int)IdCliente).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.IdCliente = query.IdCliente;
                        cliente.Nombre = query.Nombre;
                        cliente.Email = query.Email;
                        cliente.Telefono = query.Telefono;
                        cliente.Ciudad = query.Ciudad;

                        //Asignar el objeto
                        result.Object = cliente;
                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al cliente con el ID indicado";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.Ex= ex;
                result.ErrorMessage = ex.Message;   
            }
            return result;
        }
    }
}
