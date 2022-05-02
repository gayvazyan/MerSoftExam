using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepasitory _productRepasitory;
        public DeleteModel(IProductRepasitory productRepasitory)
        {
            _productRepasitory = productRepasitory;
            Delete = new DeleteProductModel();
        }

        public class DeleteProductModel : Product { }

        [BindProperty]
        public DeleteProductModel Delete { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        protected void PrepareData(int id)
        {
            var result = _productRepasitory.GetByID(id);

            if (result != null)
            {
                Delete.Id = result.Id;
                Delete.Code = result.Code;
                Delete.Name = result.Name;
                Delete.GrupId = result.GrupId;
            }
        }

        public void OnGet(int id)
        {
            PrepareData(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var grup = _productRepasitory.GetByID(Delete.Id);

                    _productRepasitory.Delete(grup);

                    return RedirectToPage("/Directory/Products/Index");

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Delete.Id);
                }
            }

            return Page();
        }
    }
}
