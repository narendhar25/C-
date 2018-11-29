using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
    public class CustomRoutes:IPageRouteModelConvention
    {
        public void Apply(PageRouteModel pageRouteModel)
        {
            foreach(var selector in pageRouteModel.Selectors)
            {
                var template = selector.AttributeRouteModel.Template;
                if (template.Contains("/"))
                {
                    var segments = template.Split(new[] { "/" }, StringSplitOptions.None);
                    if (segments.Count()>= 2)
                    {
                        selector.AttributeRouteModel.Template = $"{segments[0]}/{segments[1].Replace(segments[0], string.Empty).Replace("Index", string.Empty)}".TrimEnd('/');
                    }
                }
            }
        }
    }
}
