using BlogApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface IYorumService: IService<Yorum>
    {
        List<Yorum> GetAllByBLogId(int blogId);
        List<Yorum> GetAllByYazarId(int yazarId);
    }
}
