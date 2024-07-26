namespace Topic.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryBlogWith
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int BlogCount { get; set; }
    }
}
