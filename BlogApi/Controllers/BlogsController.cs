using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using BlogApi.GenericRepository;

namespace BlogApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogApiContext _context;
        private IGenericRepository<Blogs> _repository = null;
        public BlogsController(BlogApiContext context, IGenericRepository<Blogs> repository)
        {
            _context = context;
            _repository = repository;
        }
         
        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blogs>>> GetBlogs()
        { 
            var blogs = await _repository.GetAllAsync();
            return blogs;
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Blogs>>> GetBlogs(int id)
        { 
            var blogs = await _repository.GetWithBlogsIdAsync(id);
            if (blogs == null)
            {
                return NotFound();
            } 
            return blogs;
        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogs(int id, Blogs blogs)
        {
            if (id != blogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();  
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
         
        [HttpPost]
        public async Task<ActionResult<Blogs>> PostBlogs(Blogs blogs)
        {
            _context.Blogs.Add(blogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogs", new { id = blogs.Id }, blogs);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBlogs(int id)
        { 
            var responseDelete = await _repository.Delete(id);
            return responseDelete;
        }

        private bool BlogsExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
