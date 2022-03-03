using BlazorBlog.Models;
using BlazorBlog.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBlog.Pages
{
    public partial class Create
    {
        [Inject]
        private IBlogService BlogService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private BlogPost newBlogPost = new BlogPost();

        async Task CreateNewBlogPost()
        {
            var result = await BlogService.CreateNewBlogPost(newBlogPost);
            NavigationManager.NavigateTo($"posts/{result.Url}");
        }

        async Task OnFileChange(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var resizedImage = await e.File.RequestImageFileAsync(format, 1060, 1060);
            var buffer = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(buffer);
            var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
            newBlogPost.Image = imageData;

            //Console.WriteLine(newBlogPost.Image);
        }
    }
}
