using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IClassroomRepository: IBaseRepository<Classroom> {
        public Task<Classroom> FindByNameAsync(string name);
    }
}