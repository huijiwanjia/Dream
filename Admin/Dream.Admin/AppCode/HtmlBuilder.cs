using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Admin.AppCode
{
    public class HtmlBuilder
    {
        public static string GeneratePatentTypeHtml(string type)
        {
            string html = string.Empty;
            switch (type)
            {
                case "FMZL":
                    html = "<span style='color: orange'>[发明]</span>";
                    break;
                case "FMSQ":
                    html = "<span style='color: #000066'>[授权]</span>";
                    break;
                case "SYXX":
                    html = "<span style='color: green'>[实用新型]</span>";
                    break;
                case "MGZL":
                    html = "<span style='color: #ffcc00'>[美国专利]</span>";
                    break;
                case "MGSQ":
                    html = "<span style='color: #cc9900'>[美国授权]</span>";
                    break;
                case "EPZL":
                    html = "<span style='color: #9900ff'>[欧专局]</span>";
                    break;
                default:
                    html = "<span style='color: grey'>[未知]</span>";
                    break;
            }
            return html;
        }
    }
}
