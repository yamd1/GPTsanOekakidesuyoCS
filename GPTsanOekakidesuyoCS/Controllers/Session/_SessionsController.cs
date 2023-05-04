﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GPTsanOekakidesuyoCS.Data;
//using GPTsanOekakidesuyoCS.Models;

//namespace GPTsanOekakidesuyoCS.Controllers.Session
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SessionsController : ControllerBase
//    {
//        private readonly GPTsanOekakidesuyoCSContext _context;

//        public SessionsController(GPTsanOekakidesuyoCSContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Sessions
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Session>>> GetSession()
//        {
//          if (_context.Session == null)
//          {
//              return NotFound();
//          }
//            return await _context.Session.ToListAsync();
//        }

//        // GET: api/Sessions/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Session>> GetSession(int id)
//        {
//          if (_context.Session == null)
//          {
//              return NotFound();
//          }
//            var session = await _context.Session.FindAsync(id);

//            if (session == null)
//            {
//                return NotFound();
//            }

//            return session;
//        }

//        // PUT: api/Sessions/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSession(int id, Session session)
//        {
//            if (id != session.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(session).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SessionExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Sessions
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Session>> PostSession(Session session)
//        {
//          if (_context.Session == null)
//          {
//              return Problem("Entity set 'GPTsanOekakidesuyoCSContext.Session'  is null.");
//          }
//            _context.Session.Add(session);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSession", new { id = session.Id }, session);
//        }

//        // DELETE: api/Sessions/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSession(int id)
//        {
//            if (_context.Session == null)
//            {
//                return NotFound();
//            }
//            var session = await _context.Session.FindAsync(id);
//            if (session == null)
//            {
//                return NotFound();
//            }

//            _context.Session.Remove(session);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool SessionExists(int id)
//        {
//            return (_context.Session?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
