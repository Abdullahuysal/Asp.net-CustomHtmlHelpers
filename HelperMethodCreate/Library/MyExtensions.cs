using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethodCreate.Library
{
    public static class MyExtensions
    {
        //yöntem 1 Html helper içerisine custom button methodu oluşturma
        //this html helper=> html helper yazdığımız zaman içinde gözükmesi için
        public static MvcHtmlString Button(this HtmlHelper helper, string id, ButtonType typ,string text)
        {
            string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button>", id, typ.ToString(), text);

            // MvcHtmlString=> String to html form method.
            return MvcHtmlString.Create(html);          
        }

        // yöntem 2 tagBuilder ile helper methoda custom button ekleme
        //method overloading vardır.
        public static MvcHtmlString Button(this HtmlHelper helper, string id,string cssClass, ButtonType typ, string text)
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass(cssClass);
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string, string>("type",typ.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>("name", typ.ToString()));
            tag.SetInnerText(text);

            return MvcHtmlString.Create(tag.ToString());
           
        }

    }
    public enum ButtonType
    {
        button=0,
        submit=1,
        reset=2
    }
}