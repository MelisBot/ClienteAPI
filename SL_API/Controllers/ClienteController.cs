using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SL_API.Controllers
{
    public class ClienteController : ApiController
    {
        //1. GET /api/clientes
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Cliente.GetAllEF();
            if (result.Correct)
                return Ok(result.Objects.Cast<ML.Cliente>());
            else
                return NotFound();
        }

        //2. GET /api/clientes/{id}
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            ML.Result result = BL.Cliente.GetByIdEF(id);
            if (result.Correct)
                return Ok((ML.Cliente)result.Object);
            else
                return NotFound();
        }


        //3. POST /api/clientes
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.Cliente cliente)
        {
            ML.Result result = BL.Cliente.AddEF(cliente);
            if (result.Correct)
                return Ok("Cliente agregado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }

        //4. PUT /api/clientes/{id}
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ML.Cliente cliente)
        {
            cliente.IdCliente = id;
            ML.Result result = BL.Cliente.UpdateEF(cliente);
            if (result.Correct)
                return Ok("Cliente actualizado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }


        //5. DELETE /api/clientes/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ML.Result result = BL.Cliente.DeleteEF(id);
            if (result.Correct)
                return Ok("Cliente eliminado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }

    }
}
