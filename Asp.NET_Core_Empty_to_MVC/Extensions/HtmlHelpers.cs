using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NET_Core_Empty_to_MVC.Extensions
{
    static public class HtmlHelpers
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value = null, string placeHolder = null)
        => htmlHelper.TextBox(name, value, new
        {
            style = "background-color:green;color:white;font-size:11px",
            @class = "form-input",
            placeholder = placeHolder
        });
    }
}
