using core_crud_mvc.Model;
using core_crud_mvc.Data;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_crud_mvc.Repository
{
    public class MockRepo : IRepository
    {
        private readonly TransactionDbContext _context;
        public TransactionController(TransactionDbContext context){
            _context = context;
        }

       public async Task<ListTransactionModel>> GetAll(){
             return await db.Transactions.ToListAsync();            
        }

        public async Task<TransactionModel> GetById(int id){
          return await db.Transactions.FirstOrDefaultAsync(x => x.ID == Id);
         }

        public async Task Add(TransactionModel x){            
            await db.Transactions.AddAsync(x);              
        }     

        public async Task Update(TransactionModel x){            
           db.Transactions.Update(x);           
        }

       public async Task DeleteEmployee(int? Id){    
            var x = await db.Transactions.FirstOrDefaultAsync(x => x.ID == Id);
            if (x != null)                      
                db.Transactions.Remove(x);
        }       
    }
}