using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork7.Services
{
    public static class EditorForModel
    {
        public static IHtmlContent OwnEditorForModel(this IHtmlHelper htmlHelper)
        {
            var model = htmlHelper.ViewData.ModelMetadata.ModelType;
            var properties = model.GetProperties();
            var result = properties.Select(x => x.MakeTitleAndInput(htmlHelper.ViewData.Model));
            return new HtmlString(string.Join(" ", result));
        }
        public static string MakeTitleAndInput(this PropertyInfo property, object model)
        {
            return property.MakeTitle(model) + property.MakeInput(model);
        }

        public static string MakeTitle(this PropertyInfo property, object model)
        {
            var label = new TagBuilder("label")
            {
            };
            var name = property.GetCustomAttribute<DisplayNameAttribute>() is null ?
                CamelCase(property.Name) : property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
            return label.InnerHtml.Append(name).GetString();
        }

        private static string CamelCase(string text) =>
            Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

        public static string MakeInput(this PropertyInfo property, object model)
        {
            var value = "";
            if (model != null)
            {
                value = property.GetValue(model)?.ToString();
            }

            var div = new TagBuilder("div")
            {
                Attributes =
                {
                    {"class", "editor-field"}
                }
            };

            var typeTextOrNumber = property.PropertyType == typeof(int) ? "number" : "text";
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "text-box single-line"},
                    {"data-val", "true"},
                    {"FirstName", property.Name},
                    {"LastName", property.Name},
                    {"type", typeTextOrNumber},
                    {"value", value}
                }
            };
            div.InnerHtml.AppendHtml(input);
            return div.GetString();
        }

        public static string GetString(this IHtmlContent content)
        {
            using var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
