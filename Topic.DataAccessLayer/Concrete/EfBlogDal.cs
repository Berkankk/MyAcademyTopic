using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public EfBlogDal(TopicContext topicContext) : base(topicContext)
        {
        }

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context.Blogs.Where(x => x.CategoryID == id).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.Category).ToList(); //dahil ettik categoriyle ıd sini

        }

        public Blog GetBlogWithCategoryByID(int id)
        {
            return _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.BlogID == id);
        }
    }
}
