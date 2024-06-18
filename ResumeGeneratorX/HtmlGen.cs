﻿using System.Text;
using System.Text.RegularExpressions;

namespace ResumeGeneratorX
{
    internal partial class HtmlGenBase
    {
        protected const string assetsBasePath = @".\Assets";
        protected readonly ResumeInfo rio;

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
        protected void GenHead(StringBuilder sb)
        {
            sb.Append(File.ReadAllText($"{assetsBasePath}\\head1.txt"));
            // 查看头像比例（宽x高）
            var sizeStrings = rio.Avatar.Size.Split('x');
            double w = double.Parse(sizeStrings[0]);
            double h = double.Parse(sizeStrings[1]);
            // 修改头像高宽比例
            string s = File.ReadAllText($"{assetsBasePath}\\head2.txt");
            var s2 = FindHeight().Replace(s, (m) => (
                $"height: {double.Parse(m.Groups[1].Value) * h / w}px"));
            //Console.WriteLine(s2);
            sb.Append(s2);
            sb.Append(File.ReadAllText($"{assetsBasePath}\\head3.txt"));
        }
        protected void GenBody(StringBuilder sb)
        {
            sb.Append("<body lang=\"zh-CN\" class=\"\" style=\"\">" +
                "<div id=\"___gatsby\">" +
                "<div style=\"outline:none\" tabindex=\"-1\" id=\"gatsby-focus-wrapper\">" +
                "<div class=\"ant-spin-nested-loading\">" +
                "<div class=\"ant-spin-container\">" +
                "<div class=\"page\">");
            GenResumeContent(sb);
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
        protected virtual void GenResumeContent(StringBuilder sb)
        {

        }
        /*
        [GeneratedRegex("width: \\d+px;")]
        private static partial Regex FindWidth();
        */
        [GeneratedRegex("height: (\\d+)px")]
        private static partial Regex FindHeight();
    }
}
