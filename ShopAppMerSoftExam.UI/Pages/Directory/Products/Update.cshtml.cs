using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Products
{
    public class UpdateModel : PageModel
    {

        private readonly IProductRepasitory _productRepasitory;
        private readonly IGrupeRepasitory _grupeRepasitory;
        public UpdateModel(IProductRepasitory productRepasitory,
                           IGrupeRepasitory grupeRepasitory)
        {
            _productRepasitory = productRepasitory;
            _grupeRepasitory = grupeRepasitory;
            Update = new UpdateProductModel();
            Grupes = new List<SelectListItem>();
        }


        public class UpdateProductModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Կոդը պարտադիր է")]
            public string Code { get; set; }

            [Required(ErrorMessage = "Անվանումը պարտադիր է")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Դաշտը պարտադիր է")]
            public int GrupId { get; set; }
        }

        [BindProperty]
        public UpdateProductModel Update { get; set; }

        public List<SelectListItem> Grupes { get; set; }

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

                Update.Id = result.Id;
                Update.Code = result.Code;
                Update.Name = result.Name;
                Update.GrupId = result.GrupId;
            }

            var grupLis = _grupeRepasitory.GetAll();

            foreach (var grup in grupLis)
            {
                var item = new SelectListItem()
                {
                    Text = grup.Name,
                    Value = grup.Id.ToString()
                };
                Grupes.Add(item);
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
                    var product = _productRepasitory.GetByID(Update.Id);

                    product.Code = Update.Code;
                    product.Name = Update.Name;
                    product.GrupId = Update.GrupId;


                    _productRepasitory.Update(product);

                    return RedirectToPage("/Directory/Products/Index");
                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Update.Id);
                }
            }
            else
            {
                PrepareData(Update.Id);
            }

            return Page();
        }
    }
}
