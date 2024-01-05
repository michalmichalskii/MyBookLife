using MyBookLife.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Interfaces
{
    public interface IDiaryService
    {
        List<DiaryForListVm> GetUserDiariesList(string userId);
    }
}
