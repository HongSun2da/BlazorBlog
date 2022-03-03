using BlazorBlog.Models;
using BlazorBlog.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBlog.Pages
{
    public partial class Post
    {
        [Inject]
        private IBlogService BlogService { get; set; }

        private BlogPost CurrentPost = new BlogPost();

        [Parameter]
        public string Url { get; set; }

        string placeholderImage = "https://via.placeholder.com/1060x300";

        protected override async Task OnInitializedAsync()
        {
            CurrentPost = await BlogService.GetBlogPostByUrl(Url);
        }
    }
}
