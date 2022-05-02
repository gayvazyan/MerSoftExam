using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Grupe
{
    public class CreateModel : PageModel
    {
        private readonly IGrupeRepasitory _grupeRepasitory;
        public CreateModel(IGrupeRepasitory grupeRepasitory)
        {
            _grupeRepasitory = grupeRepasitory;
            Create = new CreateNewsModel();
        }

        public class CreateNewsModel
        {
            public int Code { get; set; }

            [Required(ErrorMessage = "Անվանումը պարտադիր է")]
            public string Name { get; set; }

        }

        [BindProperty]
        public CreateNewsModel Create { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var grup = new Grup
                    {
                        Name = Create.Name
                        
                    };

                    var result = _grupeRepasitory.Insert(grup);

                    if (result != null)
                        return RedirectToPage("/Directory/Grupe/Index");

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
