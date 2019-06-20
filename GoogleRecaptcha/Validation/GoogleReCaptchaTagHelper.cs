using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleRecaptcha.Validation
{
    public static class GoogleReCaptchaTagHelper 
    {
        public static IHtmlString GoogleReCaptcha(this HtmlHelper htmlHelper, String siteKey, String callback = null)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.Attributes.Add("class", "g-recaptcha");
            tagBuilder.Attributes.Add("data-sitekey", siteKey);

            if (callback != null && String.IsNullOrWhiteSpace(callback))
            {
                tagBuilder.Attributes.Add("data-callback", callback);
            }

            //using (var writer = new StringWriter())
            //{
            //    tagBuilder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            //    var htmlOutput = writer.ToString();
            //    return htmlHelper.Raw(htmlOutput);
            //}
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
}