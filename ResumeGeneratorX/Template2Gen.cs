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
            GenSectionEducation(sb);
            GenSectionWork(sb);
            GenSectionAboutMe(sb);
            sb.Append("</div>");
        }

        private void GenSectionAboutMe(StringBuilder sb)
        {
            if (rio.AboutMe == null) return;
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\"><span class=\"title\">");
            sb.Append(rio.TitleNameMap.AboutMe);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
            sb.Append("<div class=\"section-body\">");
            sb.Append($"<div>{rio.AboutMe.AboutMeDesc}</div>");
            sb.Append("<div></div></div></div>");
        }

        private void GenSectionWork(StringBuilder sb)
        {
            sb.Append("<div class=\"section section section-work\">");
            GenSectionWorkTitle(sb);
            GenSectionWorkBody(sb);
            sb.Append("</div>");
        }

        private void GenSectionWorkBody(StringBuilder sb)
        {
            sb.Append("<div class=\"section-body\">");
            if (rio.WorkList is not null)
                foreach (var item in rio.WorkList)
                    GenSectionWorkItem(sb, item);
            sb.Append("</div>");
        }

        private void GenSectionWorkItem(StringBuilder sb, Work item)
        {
            sb.Append("<div>");
            sb.Append("<div>");
            sb.Append("<span role=\"img\" aria-label=\"crown\" class=\"anticon anticon-crown\" style=\"color: rgb(255, 193, 7); margin-right: 8px;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"crown\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\crown.txt"));
            sb.Append("</svg>");
            sb.Append("</span>");
            sb.Append($"<b class=\"info-name\">{item.WorkName}</b>");
            sb.Append($"<a class=\"sub-info\" href=\"{item.VisitLink}\">{item.VisitLink}</a>");
            sb.Append("</div>");
            sb.Append($"<div>{item.WorkDesc}</div>");
            sb.Append("</div>");
        }

        private void GenSectionWorkTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\"><span class=\"title\">");
            sb.Append(rio.TitleNameMap.WorkList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
        }

        private void GenSectionEducation(StringBuilder sb)
        {
            sb.Append("<div class=\"section section section-education\">");
            GenSectionEducationTitle(sb);
            GenSectionEducationBody(sb);
            sb.Append("</div>");
        }

        private void GenSectionEducationBody(StringBuilder sb)
        {
            sb.Append("<div class=\"section-body\">");
            if (rio.EducationList is not null)
                foreach(var item in rio.EducationList)
                    GenSectionEducationItem(sb, item);
            sb.Append("</div>");
        }

        private void GenSectionEducationItem(StringBuilder sb, Education education)
        {
            sb.Append("<div class=\"education-item\"><div><span><div><span>");
            sb.Append($"<b>{education.School}</b>");
            sb.Append("<span style=\"margin-left: 8px;\">");
            sb.Append($"<span>{education.Major}</span>");
            sb.Append($"<span class=\"sub-info\" style=\"margin-left: 4px;\">({education.AcademicDegree})</span>");
            sb.Append("</span></span>");
            sb.Append($"<span class=\"sub-info\" style=\"float: right;\">{education.BeginTime}~{education.EndTime??"至今"}</span>");
            sb.Append("</div></div>");
        }

        private void GenSectionEducationTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\"><span class=\"title\">");
            sb.Append(rio.TitleNameMap.EducationList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
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
