using SeatManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public interface IResourceManager<T>
    {
        public void Add(T entity);
        public void Allocate(T entity);
    }
}
