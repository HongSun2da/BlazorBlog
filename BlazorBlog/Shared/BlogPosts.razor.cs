using BlazorBlog.Models;
using BlazorBlog.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBlog.Shared
{
    public partial class BlogPosts
    {
        [Inject]
        private IBlogService BlogService { get; set; }

        private List<BlogPost> Posts = new List<BlogPost>();

        string placeholderImage = "https://via.placeholder.com/1060x180";

        protected override async Task OnInitializedAsync()
        {
            Posts = await BlogService.GetBlogPosts();
        }
    }
}
