
using Desafio_Api_Dio.Context;
using Desafio_Api_Dio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Api_Dio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF

            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            // caso contrário retornar OK com a tarefa encontrada
            var tarefaId = _context.Tarefas.Find(id);

            if (tarefaId == null)
                return NotFound();

            return Ok(tarefaId);
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF

            return Ok(_context.Tarefas.ToList());
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tarefaTitulo = _context.Tarefas.Where(t => t.Titulo == titulo.Trim());
            return Ok(tarefaTitulo);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(Tarefas novaTarefa)
        {
            if (novaTarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(novaTarefa);
            _context.SaveChanges();
            return Ok(novaTarefa);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefas tarefa)
        {
            var tarefaAtualizada = _context.Tarefas.Find(id);

            if (tarefaAtualizada == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)

            if (tarefaAtualizada != null)
            {
                tarefaAtualizada.Descricao = tarefa.Descricao;
                tarefaAtualizada.Titulo = tarefa.Titulo;
                tarefaAtualizada.Status = tarefa.Status;
                tarefaAtualizada.Data = tarefa.Data;

                _context.Tarefas.Update(tarefaAtualizada);
                _context.SaveChanges();
            }
            return Ok(tarefaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}