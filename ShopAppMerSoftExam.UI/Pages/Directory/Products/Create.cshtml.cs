using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepasitory _productRepasitory;
        private readonly IGrupeRepasitory _grupeRepasitory;
        public CreateModel(IProductRepasitory productRepasitory,
                           IGrupeRepasitory grupeRepasitory)
        {
            _productRepasitory = productRepasitory;
            _grupeRepasitory = grupeRepasitory;
            Create = new CreateProductModel();
            Grupes = new List<SelectListItem>();
        }

        public class CreateProductModel
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
        public CreateProductModel Create { get; set; }

        public List<SelectListItem> Grupes { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet()
        {
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

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = new Product
                    {
                        Code = Create.Code,
                        Name = Create.Name,
                        GrupId = Create.GrupId
                    };

                    var result = _productRepasitory.Insert(product);

                    if (result != null)
                        return RedirectToPage("/Directory/Products/Index");

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                }
            }
            return Page();
        }
    }
}
