using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_420_BD.Interfaces
{
    public interface IRepository<T>
    {
        DataTable? GetAll();
        bool Create(T item);
        void Update(T item);
        void Delete(int id);
        DataTable? Search(String searchString);

    }

}
