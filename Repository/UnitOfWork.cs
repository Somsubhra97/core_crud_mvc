using System;
using core_crud_mvc.Models;
using core_crud_mvc.Interfaces;
using core_crud_mvc.Data;

namespace core_crud_mvc.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly TransactionDbContext _context;       
        public UnitOfWork(TransactionDbContext db,IRepository r){
            this._context = db;            
            this.r= r;            
        }
        
        public IRepository r { get; }  
        public int Complete()
        {
            return _context.SaveChanges();
        }       
    }
}
