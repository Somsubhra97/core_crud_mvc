using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using core_crud_mvc.Models;
using core_crud_mvc.Repository;


namespace core_crud_mvc.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _context;
        public TransactionController(IUnitOfWork context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repo.GetAll());
        }

               
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new TransactionModel());
            else
            {
                var transactionModel = await _context.Repo.GetById(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }

        [HttpPost]        
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;
                    _context.Repo.Add(transactionModel);  
                    _context.Save();                 

                }
                //Update
                else
                {
                    _context.Repo.Update(transactionModel); 
                    _context.Save();  
                }
                return RedirectToAction(nameof(GetAllEmployees));
            }
            return RedirectToAction(nameof(Error))
        }
       
        public Task<IActionResult> Error(){

        	return View();
        } 
        
        public async Task<IActionResult> Details(int id){
        	var x=await _context.Repo.GetById(id);
        	return View(x);
        }      

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Repo.GetById(id);
            _context.Delete(transactionModel);  
            _context.Save();          
            return RedirectToAction(nameof(Index))
        }
        
    }
}
