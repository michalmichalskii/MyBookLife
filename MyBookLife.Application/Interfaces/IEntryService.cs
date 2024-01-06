using MyBookLife.Application.ViewModels.EntryVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Interfaces
{
    public interface IEntryService
    {
        int AddEntry(NewEntryVm newEntryVm);
        List<EntryForListVm> GetEntriesByDiaryId(int diaryId);
        NewEntryVm GetEntryForEdit(int entryId);
        void RemoveEntryById(int entryId);
        void UpdateEntry(NewEntryVm entryVm);
    }
}
