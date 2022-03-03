#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aspire.Data;
using Aspire.Models;

namespace Aspire.Controllers
{
    public class PostsController : Controller
    {
        private readonly AppDBContext _context;

        public PostsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Posts.Include(p => p.PostStatus).Include(p => p.PostType).OrderByDescending(p => p.Support);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.PostStatus)
                .Include(p => p.PostType)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["PostStatusId"] = new SelectList(_context.PostStatuses, "PostStatusId", "Name");
            ViewData["PostTypeId"] = new SelectList(_context.PostTypes, "PostTypeId", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Discription,Support,PostedOn,PostStatusId,PostTypeId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostStatusId"] = new SelectList(_context.PostStatuses, "PostStatusId", "Name", post.PostStatusId);
            ViewData["PostTypeId"] = new SelectList(_context.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["PostStatusId"] = new SelectList(_context.PostStatuses, "PostStatusId", "Name", post.PostStatusId);
            ViewData["PostTypeId"] = new SelectList(_context.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Discription,Support,PostedOn,PostStatusId,PostTypeId")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // avoid certain fields to get updated like postedOn and Support.
                    var original = _context.Posts.Find(post.PostId);
                    original.Title = post.Title;
                    original.Discription = post.Discription;
                    original.PostStatusId = post.PostStatusId;
                    original.PostTypeId = post.PostTypeId;

                    _context.Update(original);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostStatusId"] = new SelectList(_context.PostStatuses, "PostStatusId", "Name", post.PostStatusId);
            ViewData["PostTypeId"] = new SelectList(_context.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.PostStatus)
                .Include(p => p.PostType)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }

        // Add Suport to the post.
        public IActionResult Support(int? id)
        {
            var post = _context.Posts.Find(id);
            post.Support += 1;
            _context.Update(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new {id = id});
        }
    }
}
