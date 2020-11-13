using core_mvc_crud.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_mvc_crud.Repository
{
    public interface IRepository
    {
        Task<List<TransactionModel>> GetAll();
        Task<TransactionModel> GetById(int id);
        Task Add(TransactionModel x);
        Task Update(TransactionModel x);
        Task Delete(int id);
    }
}