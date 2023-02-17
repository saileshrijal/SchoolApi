using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interface
{
    public interface IGradeService
    {
        Task<List<Grade>> GetAll(); 
        Task<Grade> Get(int id);
        Task<int> Delete(int id);
        Task<int> Edit(Grade grade);
        Task<int> Create(Grade grade);
    }
}
