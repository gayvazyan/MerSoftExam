using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Grupe
{
    public class UpdateModel : PageModel
    {
        private readonly IGrupeRepasitory _grupeRepasitory;
        public UpdateModel(IGrupeRepasitory grupeRepasitory)

        {
            _grupeRepasitory = grupeRepasitory;
            Update = new UpdateGrupeModel();
        }


        public class UpdateGrupeModel
        {
            public int Code { get; set; }

            [Required(ErrorMessage = "Անվանումը պարտադիր է")]
            public string Name { get; set; }
        }

        [BindProperty]
        public UpdateGrupeModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
            var result = _grupeRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Code = result.Code;
                Update.Name = result.Name;
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
                    var grup = _grupeRepasitory.GetByID(Update.Code);

                    grup.Code = Update.Code;
                    grup.Name = Update.Name;


                    _grupeRepasitory.Update(grup);

                    return RedirectToPage("/Directory/Grupe/Index");
                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Update.Code);
                }
            }
            else
            {
                PrepareData(Update.Code);
            }

            return Page();
        }
    }
}
