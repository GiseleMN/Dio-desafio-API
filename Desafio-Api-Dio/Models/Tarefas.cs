
using System.ComponentModel.DataAnnotations;


namespace Desafio_Api_Dio.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        
        public string Titulo { get; set; }

        public string Descricao { get; set; }

       public DateTime Data { get; set; }

       public EnumStatusTarefa Status { get; set; }
    }
}