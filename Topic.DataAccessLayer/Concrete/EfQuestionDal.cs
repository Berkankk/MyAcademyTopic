using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Concrete
{
    public class EfQuestionDal : GenericRepository<Questions>, IQuestionDal
    {
        public EfQuestionDal(TopicContext context) : base(context)
        {
        }
    }
}
