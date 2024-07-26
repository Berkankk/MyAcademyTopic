using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _question;

        public QuestionManager(IQuestionDal question)
        {
            _question = question;
        }

        public void TCreate(Questions entity)
        {
            _question.Create(entity);
        }

        public void TDelete(int id)
        {
            _question.Delete(id);
        }

        public Questions TGetByFilter(Expression<Func<Questions, bool>> filter)
        {
            return _question.GetByFilter(filter);
        }

        public Questions TGetById(int id)
        {
            return _question.GetById(id);
        }

        public List<Questions> TGetFilteredList(Expression<Func<Questions, bool>> filter)
        {
            return _question.GetFilteredList(filter);
        }

        public List<Questions> TGetList()
        {
            return _question.GetList();
        }

        public void TUpdate(Questions entity)
        {
            _question.Update(entity);
        }
    }
}
