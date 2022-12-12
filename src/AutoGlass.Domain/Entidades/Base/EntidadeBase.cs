using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGlass.Domain.Entidades.Base
{
    public class EntidadeBase
    {        
        protected EntidadeBase()
        {
            Status = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public bool? Status { get; set; }
    }
}