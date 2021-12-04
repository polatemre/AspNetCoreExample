using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Asp.NET_Core_Empty_to_MVC.TagHelpers
{
    //[HtmlTargetElement("mail")] // Eğer sınıfın ismi olan Email dışında bir tag ismi vermek istiyorsak burayı kullanabiliriz.
    public class EmailTagHelper : TagHelper
    {
        // Property'ler otomatik olarak helper'ın attribute'u olarak oluşacaktır.
        public string Mail { get; set; }
        public string Display { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{Mail}");
            output.Content.Append(Display);
        }
    }
}
