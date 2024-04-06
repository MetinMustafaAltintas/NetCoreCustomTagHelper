using Microsoft.AspNetCore.Razor.TagHelpers;
using NetCoreCustomTagHelper.Models.ContextClasses;
using NetCoreCustomTagHelper.Models.Entities;

namespace NetCoreCustomTagHelper.CustomTagHelpers
{
    //Bir class'ın TagHelper olabilmesi icin TagHelper class'ından miras alması gereklidir...
    [HtmlTargetElement("myOwn")] //Bu ifade yarattıgımız  element hangi isimle kullanılacak bunu belirtir
    public class MyTagHelper : TagHelper
    {
        NorthwindContext _db;

        public MyTagHelper(NorthwindContext db)
        {
            _db = db;
        }
        public string Deneme { get; set; }
        public string TestVerisi { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Product> products = _db.Products.ToList();
            string result = null;
            foreach (Product item in products)
            {
                result += $"<tr> <td>{item.ProductName} </td> </tr> ";
            }

            //output.Content.SetHtmlContent($"<h1> Hello World {Deneme} </h1>");
            output.Content.SetHtmlContent(result);
        }
    }
}