using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models
{
    public interface IFileRepository<T> : IEnumerable<T>
    {
        int Count { get; }

        IEnumerable<T> GetAllItemsRepository();

        T GetItemById(int itemId);

        void AddFileRepository(T item);
        void EditFileRepository(T item);
        void DeleteFileRepository(int itemId);
        void ClearRepository();
    }
}
