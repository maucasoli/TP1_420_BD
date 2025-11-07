using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TP1_420_BD.Interfaces;

namespace TP1_420_BD.Data
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        public abstract DataTable? GetAll();
        public abstract bool Create(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);
        public abstract DataTable? Search(String searchString);



    }
}
