//using Drogaria.Domain.Core.Models;
//using Drogaria.Domain.Entities.ApplicationUsers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Drogaria.Domain.Entities.Message
//{
//    [Table("TB_MESSAGE")]
//    public class Message : Notifies
//    {
//        public long Id { get; set; }
//        [MaxLength(255)]
//        public string Titulo { get; set; } = string.Empty;
//        public bool Ativo { get; set; }
//        public DateTimeOffset DataCadastro { get; set; }
//        public DateTimeOffset DataAlteracao { get; set; }

//        [ForeignKey("ApplicationUser")]
//        [Column(Order = 1)]
//        public Guid UsuarioId { get; set; }
//        public virtual ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
//    }
//}
