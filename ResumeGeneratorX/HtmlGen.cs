using System.Text;

namespace ResumeGeneratorX
{
    internal class HtmlGenBase
    {
        private const string assetsBasePath = @".\Assets\";
        private readonly ResumeInfo rio;

        public HtmlGenBase(ResumeInfo rio)
        {
            this.rio = rio;
        }

        public StringBuilder GenHtml()
        {
            var sb = new StringBuilder(1024 * 1024);
            sb.Append("<html>");
            GenHead(sb);
            GenBody(sb);
            sb.Append("</html>");
            return sb;
        }
        private void GenHead(StringBuilder sb)
        {
            sb.Append(File.ReadAllText($"{assetsBasePath}head.txt"));
        }
        private void GenBody(StringBuilder sb)
        {
            sb.Append("<body lang=\"zh-CN\" class=\"\" style=\"\">" +
                "<div id=\"___gatsby\">" +
                "<div style=\"outline:none\" tabindex=\"-1\" id=\"gatsby-focus-wrapper\">" +
                "<div class=\"ant-spin-nested-loading\">" +
                "<div class=\"ant-spin-container\">" +
                "<div class=\"page\">");

            sb.Append("<div class=\"box-size-info\" style=\"top: 4px; left: 0px;\">(0, 0)</div>" +
                "</div></div></div></div>" +
                "<div id=\"gatsby-announcer\"" +
                "style=\"position:absolute;top:0;width:1px;height:1px;padding:0;overflow:hidden;clip:rect(0, 0, 0, 0);white-space:nowrap;border:0\"" +
                "aria-live=\"assertive\" aria-atomic=\"true\"></div>" +
                "</div>" +
                "<deepl-input-controller></deepl-input-controller>" +
                "<div>" +
                "<div class=\"ant-message\">" +
                "<div></div>" +
                "</div>" +
                "</div>" +
                "<style rc-util-key=\"antd-wave\"></style>" +
                "</body>");
        }
    }
}
