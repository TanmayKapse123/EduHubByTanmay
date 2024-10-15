using System;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using EduHubMVC.Models;
namespace EduHubMVC.Services;

    public interface IFeedBackService
    {
    public List<FeedBack>   getAllFeedBacks();
       
       public object getAllFeedBacksByCourseId(int Cid);
    }
