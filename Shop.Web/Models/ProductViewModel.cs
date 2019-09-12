namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;
    public class ProductViewModel:Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
