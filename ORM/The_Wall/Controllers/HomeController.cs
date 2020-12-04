using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using The_Wall.Models;

namespace The_Wall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("wall")]
        public IActionResult TheWall()
        {
            int? UserId = HttpContext.Session.GetInt32("User");

            if (UserId == null)
            {
                return RedirectToAction("Registration", "LogReg");
            }
            else
            {
                ViewBag.UserInSession = _context.Users
                    .FirstOrDefault(u => u.UserId == UserId);
                ViewBag.allMessages = _context.Messages
                    .Include(m => m.User)
                    .Include(m => m.Comments)
                    .ThenInclude(c => c.User).OrderByDescending(c => c.UpdatedAt)
                    .Include(m => m.MessageLiked)
                    .ThenInclude(ml => ml.User)
                    .Include(c => c.Comments)
                    .ThenInclude(cl => cl.CommentLiked);
                return View("MessageBoard");
            }
        }

        [HttpPost("wall/message")]
        public IActionResult AddMessage(Message messageForm)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            if (ModelState.IsValid)
            {
                messageForm.UserId = UserId;
                _context.Add(messageForm);
                _context.SaveChanges();
                return RedirectToAction("TheWall");
            }
            else
            {
                return View("MessageBoard");
            }
        }

        [HttpPost("wall/{MessageId}/comment")]
        public IActionResult AddComment(int MessageId, Comment commentForm)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            if (ModelState.IsValid)
            {
                commentForm.UserId = UserId;
                commentForm.MessageId = MessageId;
                _context.Add(commentForm);
                _context.SaveChanges();
                return RedirectToAction("TheWall");
            }
            else
            {
                return View("MessageBoard");
            }
        }

        [HttpGet("like/message/{MessageId}")]
        public IActionResult LikedMessage(int MessageId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            if (_context.MessagesLiked.Any(m => m.MessageId == MessageId && m.UserId == UserId))
            {
                return View("MessageBoard");
            }
            else
            {
                MessageLiked messageLiked = new MessageLiked();
                messageLiked.UserId = UserId;
                messageLiked.MessageId = MessageId;
                _context.Add(messageLiked);
                _context.SaveChanges();
                return RedirectToAction("TheWall");
            }
        }

        [HttpGet("unlike/message/{MessageId}")]
        public IActionResult UnlikedMessage(int MessageId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            MessageLiked messageToUnlike = _context.MessagesLiked.FirstOrDefault(ml => ml.UserId == UserId && ml.MessageId == MessageId);

            _context.Remove(messageToUnlike);
            _context.SaveChanges();
            return RedirectToAction("TheWall");
        }

        [HttpGet("like/comment/{CommentId}")]
        public IActionResult LikedComment(int CommentId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            if (_context.CommentsLiked.Any(c => c.CommentId == CommentId && c.UserId == UserId))
            {
                return View("MessageBoard");
            }
            else
            {
                CommentLiked commentLiked = new CommentLiked();
                commentLiked.CommentId = CommentId;
                commentLiked.UserId = UserId;
                _context.Add(commentLiked);
                _context.SaveChanges();
                return RedirectToAction("TheWall");
            }
        }

        [HttpGet("unlike/comment/{CommentId}")]
        public IActionResult UnlikeComment(int CommentId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");

            CommentLiked commentToUnlike = _context.CommentsLiked.FirstOrDefault(cl => cl.UserId == UserId && cl.CommentId == CommentId);

            _context.Remove(commentToUnlike);
            _context.SaveChanges();
            return RedirectToAction("TheWall");
        }

        [HttpGet("message/delete/{MessageId}/{UserId}")]
        public IActionResult DeleteMessage(int MessageId, int UserId)
        {

            Message messageToDelete = _context.Messages
                .FirstOrDefault(m => m.MessageId == MessageId && m.UserId == UserId);

            _context.Remove(messageToDelete);
            _context.SaveChanges();
            return RedirectToAction("TheWall");
        }


        [HttpGet("comment/delete/{CommentId}/{UserId}")]
        public IActionResult DeleteComment(int CommentId, int UserId)
        {
            Comment commentToDelete = _context.Comments
                .FirstOrDefault(m => m.CommentId == CommentId && m.UserId == UserId);

            _context.Remove(commentToDelete);
            _context.SaveChanges();
            return RedirectToAction("TheWall");
        }

    }
}