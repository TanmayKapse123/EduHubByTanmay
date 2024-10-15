using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class FeedBackController : Controller{
     
        private readonly IFeedBackService _feedback;
        
        public  FeedBackController(IFeedBackService service)
        {
            _feedback=service;
           
        }
        public IActionResult AllFeedBacks()
        {
            var data=_feedback.getAllFeedBacks();
            return View(data);
        }
        [HttpGet]
        public IActionResult getFeedBackByCid(int id)
        {
            var data=_feedback.getAllFeedBacksByCourseId(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult writeFeedBack(int id,int uid)
        {
            var f=new FeedBack()
            {
                CourceId=id,
                UserId=uid
                
            };
            return View(f);
        }
    }