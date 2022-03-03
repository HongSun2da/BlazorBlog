﻿using BlazorBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> GimmeAllTheBlogPosts()
        {
            return Ok(_context.BlogPosts.OrderByDescending(post => post.DateCreated));
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> GimmeThatSingleBlogPost(string url)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("This post does not exist.");
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost request)
        {
            _context.BlogPosts.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
