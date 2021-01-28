using Microsoft.AspNetCore.Mvc;
using sistemaEscolarNotas.Application.Model;
using sistemaEscolarNotas.Application.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using sistemaEscolarNotas.Application.Common;

namespace sistemaEscolarNotas.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AlunoRequestModel alunoRequest)
        {
            try
            {
                int id = await _alunoService.Create(alunoRequest);
                return CreatedAtRoute(alunoRequest, id);
            }
            catch (AlunoException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            try
            {
                return Ok(await _alunoService.GetById(id));
            }
            catch (AlunoException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AlunoRequestModel model)
        {
            try
            {
                await _alunoService.Update(id, model);
                return Ok("Aluno atualizado com sucesso.");
            }
            catch (AlunoException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _alunoService.Delete(id);
                return Ok("Aluno deletado com sucesso.");
            }
            catch (AlunoException gex)
            {
                return BadRequest(gex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
