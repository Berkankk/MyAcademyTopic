using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogDal _blog;

        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blog) : base(genericDal)
        {
            _blog = blog;
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
            return _blog.GetBlogsByCategoryId(id);
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return _blog.GetBlogsWithCategories();
        }

        public Blog TGetBlogWithCategoryByID(int id)
        {
            return _blog.GetBlogWithCategoryByID(id);
        }
    }
}
