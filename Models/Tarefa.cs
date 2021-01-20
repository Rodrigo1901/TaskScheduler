using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskScheduler.Models
{
    public class Tarefa
    {
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set;}
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string Hora_Inicial { get; set; }
        [Required]
        public string Hora_Final { get; set; }
        [Required]
        public string Prioridade { get; set; }
        [Required]
        public string Finalizada { get; set; }    
    }
}
