using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;
using System.Data;

namespace EduHubMVC.Repository;
public class FeedBackRepository : IFeedBackService
{
    private readonly AppDbContext _context;
    public FeedBackRepository(AppDbContext context)
    {
        _context=context;
    }

    public List<FeedBack> getAllFeedBacks()
    {
       var data=_context.feedBacks.ToList();
       return data;
    }

    public object getAllFeedBacksByCourseId(int Cid)
    {
       var data=_context.feedBacks.Where(x=> x.CourceId==Cid).ToList();
       return data;
    }
}

