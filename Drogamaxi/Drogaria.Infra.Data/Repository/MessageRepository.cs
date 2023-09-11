//using Drogaria.Domain.Entities.Message;
//using Drogaria.Domain.Interfaces;
//using DrPay.Infra.Data.Repository;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Drogaria.Infra.Data.Repository
//{
//    public class MessageRepository : Repository<Message>, IMessageRepository
//    {
//        private readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;

//        public MessageRepository(DrogariaDbContext context) : base(context)
//        {
//            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
//        }
//    }
//}
