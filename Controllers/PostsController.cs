using BlogApi.Data;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using BlogApi.DTOs;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbcontext _context;
        public PostsController(BlogDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()

        {
             var posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdatePost(
                int id,
                 UpdatePostDto request)
        {
            var existingPost = await _context.Posts.FindAsync(id);

            if (existingPost == null)
            {
                return NotFound();
                   
            }

            existingPost.Title= request.Title;
            existingPost.Content= request.Content;

            await _context.SaveChangesAsync();

            return NoContent();

           

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPost]

        public async Task<ActionResult<Post>> CreatePost(createPostDto request)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                CreatedDate = DateTime.UtcNow,
            };
            post.CreatedDate = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetPosts),
                new { id = post.Id },
            post
                );


            

      

                }

               
            }


        }
    

