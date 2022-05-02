using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepasitory _productRepasitory;
        private readonly IGrupeRepasitory _grupeRepasitory;
        public IndexModel(IProductRepasitory productRepasitory,
                          IGrupeRepasitory grupeRepasitory)

        {
            _productRepasitory = productRepasitory;
            _grupeRepasitory = grupeRepasitory; 
            InputList = new List<InputModel>();
        }


        public List<InputModel> InputList = new List<InputModel>();
        public List<Product> GrupList { get; set; }
        public class InputModel : Product
        { 
            public string GrupeName { get; set; } 
        }

       

        protected void PrepareData()
        {
            var productList = _productRepasitory.GetAll().ToList();

            InputList = productList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id, 
                    Code = p.Code,
                    Name = p.Name,
                    GrupeName = GetGrupeName(p.GrupId)
                };
            }).ToList();
        }
        public void OnGet()
        {
            PrepareData();
        }

        public ActionResult OnPost()
        {
            PrepareData();
            return Page();
        }

        public string GetGrupeName(int id)
        {
            return _grupeRepasitory.GetByID(id).Name;
        }
    }
}
