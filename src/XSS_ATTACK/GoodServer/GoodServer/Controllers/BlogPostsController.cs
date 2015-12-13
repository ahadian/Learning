using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GoodServer.DbContexts;
using GoodServer.Models;

namespace GoodServer.Controllers
{
    public class BlogPostsController : ApiController
    {
        private BlogContext db = new BlogContext();
        [HttpGet]
        // GET: api/BlogPosts
        public IQueryable<BlogPost> GetAllPost()
        {
            return db.Posts;
        }

        // GET: api/BlogPosts/5
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult GetBlogPost(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlogPost(int id, BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.Id)
            {
                return BadRequest();
            }

            db.Entry(blogPost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BlogPosts
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult PostBlogPost(BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(blogPost);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blogPost.Id }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult DeleteBlogPost(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            db.Posts.Remove(blogPost);
            db.SaveChanges();

            return Ok(blogPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogPostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}