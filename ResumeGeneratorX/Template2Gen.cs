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
            GenAvatar(sb);
            sb.Append("</div>");
        }

        private void GenAvatar(StringBuilder sb)
        {
            sb.Append("<div class=\"avatar \"><span class=\"ant-avatar ant-avatar-square ant-avatar-image avatar\">");
            sb.Append($"<img src=\"{rio.Avatar.Src}\">");
            sb.Append("</span></div>");
        }

        private void GenProfileInfo(StringBuilder sb)
        {
            sb.Append("<div class=\"profile-info\">");
            GenName(sb);
            GenProfileList(sb);
            sb.Append("</div>");
        }

        private void GenName(StringBuilder sb)
        {
            sb.Append("<div class=\"name\">");
            sb.Append(rio.Profile.Name);
            sb.Append("</div>");
        }

        private void GenProfileList(StringBuilder sb)
        {
            sb.Append("<div class=\"profile-list\">");
            GenMobile(sb);
            GenEmail(sb);
            GenGithub(sb);
            GenZhihu(sb);
            GenWorkPlace(sb);
            GenExpectJob(sb);
            sb.Append("</div>");
        }

        private void GenExpectJob(StringBuilder sb)
        {
            sb.Append("<div class=\"expect-job\"><span role=\"img\" aria-label=\"heart\" class=\"anticon anticon-heart\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"heart\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\heart.txt"));
            sb.Append($"</svg></span><span>{rio.Profile.PositionTitle}</span></div>");
        }

        private void GenWorkPlace(StringBuilder sb)
        {
            sb.Append("<div class=\"work-place\"><span role=\"img\" aria-label=\"environment\" class=\"anticon anticon-environment\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"environment\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\environment.txt"));
            sb.Append($"</svg></span><span>{rio.Profile.WorkPlace}</span></div>");
        }

        private void GenZhihu(StringBuilder sb)
        {
            sb.Append("<div class=\"zhihu\"><span role=\"img\" aria-label=\"zhihu-circle\" class=\"anticon anticon-zhihu-circle\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"zhihu-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\zhihu-circle.txt"));
            sb.Append($"</svg></span><span style=\"cursor: pointer;\">{rio.Profile.Zhihu}</span></div>");
        }

        private void GenGithub(StringBuilder sb)
        {
            sb.Append("<div class=\"github\"><span role=\"img\" aria-label=\"github\" class=\"anticon anticon-github\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"github\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\github.txt"));
            sb.Append($"</svg></span><span style=\"cursor: pointer;\">{rio.Profile.Github}</span></div>");
        }

        private void GenEmail(StringBuilder sb)
        {
            sb.Append("<div class=\"email\"><span role=\"img\" aria-label=\"mail\" class=\"anticon anticon-mail\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"mail\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\mail.txt"));
            sb.Append($"</svg></span>{rio.Profile.Email}</div>");
        }

        private void GenMobile(StringBuilder sb)
        {
            sb.Append("<div class=\"mobile\"><span role=\"img\" aria-label=\"phone\" class=\"anticon anticon-phone\"" +
                "style=\"color: rgb(47, 87, 133); opacity: 0.85;\"><svg viewBox=\"64 64 896 896\" focusable=\"false\"" +
                "data-icon=\"phone\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\mobile.txt"));
            sb.Append($"</svg></span>{rio.Profile.Mobile}</div>");
        }
    }
}
