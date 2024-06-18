using System.Text;

namespace ResumeGeneratorX
{
    internal class Template2Gen : HtmlGenBase
    {
        public Template2Gen(ResumeInfo rio) : base(rio)
        {
        }

        protected override void GenResumeContent(StringBuilder sb)
        {
            //base.GenResumeContent(sb);
            sb.Append("<div class=\"template2-resume resume-content\">");
            GenBasicInfo(sb);
            sb.Append("</div>");
        }

        private void GenBasicInfo(StringBuilder sb)
        {
            sb.Append("<div class=\"basic-info\">");
            GenProfile(sb);
            sb.Append("</div>");
        }

        private void GenProfile(StringBuilder sb)
        {
            sb.Append("<div class=\"profile\">");
            GenProfileInfo(sb);
            sb.Append("</div>");
        }

        private void GenProfileInfo(StringBuilder sb)
        {
            sb.Append("<div class=\"profile-info\">");
            GenName(sb);
            sb.Append("</div>");
        }

        private void GenName(StringBuilder sb)
        {
            sb.Append("<div class=\"name\">");
            sb.Append(rio.Profile.Name);
            sb.Append("</div>");
        }
    }
}
