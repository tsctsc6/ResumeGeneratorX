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
            GenMainInfo(sb);
            sb.Append("</div>");
        }

        private void GenMainInfo(StringBuilder sb)
        {
            sb.Append("<div class=\"main-info\">");
            GenSectionExperience(sb);
            GenSectionProject(sb);
            sb.Append("</div>");
        }

        private void GenSectionProject(StringBuilder sb)
        {
            if (rio.ProjectList is null) return;
            sb.Append("<div class=\"section project\">");
            GenSectionProjecTitle(sb);
            GenSectionProjectBody(sb);
            sb.Append("</div>");
        }

        private void GenSectionProjectBody(StringBuilder sb)
        {
            sb.Append("<div class=\"section-body\">");
            sb.Append("<div class=\"section section-project\">");
            if (rio.ProjectList is not null)
                foreach (var item in rio.ProjectList)
                    GenSectionProjectItem(sb, item);
            sb.Append("</div>");
            sb.Append("</div>");
        }

        private void GenSectionProjectItem(StringBuilder sb, Project item)
        {
            sb.Append("<div class=\"section-item\">");
            sb.Append("<div class=\"section-info\">");
            sb.Append("<b class=\"info-name\">");
            sb.Append(item.ProjectName);
            sb.Append("<span class=\"info-time\">");
            sb.Append($"{item.ProjectTime}");
            sb.Append("</span>");
            sb.Append("</b>");
            sb.Append("<span class=\"ant-tag ant-tag-has-color\" style=\"background-color: rgb(139, 195, 74);\">");
            sb.Append(item.ProjectRole);
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("<div class=\"section-detail\">");
            sb.Append("<span>");
            sb.Append("项目描述：");
            sb.Append("</span>");
            sb.Append("<span>");
            sb.Append(item.ProjectDesc);
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("<div class=\"section-detail\">");
            sb.Append("<span>");
            sb.Append("主要工作：");
            sb.Append("</span>");
            sb.Append("<span class=\"project-content\">");
            sb.Append(item.ProjectContent);
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("</div>");
        }

        private void GenSectionProjecTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\">");
            sb.Append("<span class=\"title\">");
            sb.Append(rio.TitleNameMap.ProjectList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
        }

        private void GenSectionExperience(StringBuilder sb)
        {
            if (rio.WorkExpList is null) return;
            sb.Append("<div class=\"section experience\">");
            GenSectionExperienceTitle(sb);
            GenSectionExperienceBody(sb);
            sb.Append("</div>");
        }

        private void GenSectionExperienceBody(StringBuilder sb)
        {
            sb.Append("<div class=\"section-body\">");
            sb.Append("<div class=\"section section-work-exp\">");
            if (rio.WorkExpList is not null)
                foreach (var item in rio.WorkExpList)
                    GeGenSectionExperienceItem(sb, item);
            sb.Append("</div></div>");
        }

        private void GeGenSectionExperienceItem(StringBuilder sb, WorkExp item)
        {
            sb.Append("<div class=\"section-item\">");
            sb.Append("<div class=\"section-info\">");
            sb.Append("<b class=\"info-name\">");
            sb.Append(item.CompanyName);
            sb.Append("<span class=\"sub-info\">");
            sb.Append(item.DepartmentName);
            sb.Append("</span>");
            sb.Append("</b>");
            sb.Append("<span class=\"info-time\">");
            if (item.EndTime is not null) sb.Append($"{item.BeginTime}~{item.EndTime}");
            else sb.Append($"{item.BeginTime} 至今");
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("<div class=\"work-description\">");
            sb.Append(item.WorkDesc?.Replace("\n", "<br>"));
            sb.Append("</div>");
            sb.Append("</div>");
        }

        private void GenSectionExperienceTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\"><span class=\"title\">");
            sb.Append(rio.TitleNameMap.WorkExpList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
        }

        private void GenBasicInfo(StringBuilder sb)
        {
            sb.Append("<div class=\"basic-info\">");
            GenProfile(sb);
            GenSectionEducation(sb);
            GenSectionWork(sb);
            GenSectionAboutMe(sb);
            GenSectionSkill(sb);
            sb.Append("</div>");
        }

        private void GenSectionSkill(StringBuilder sb)
        {
            if (rio.SkillList is null) return;
            sb.Append("<div class=\"section section section-skill\">");
            GenSectionSkillTitle(sb);
            GenSectionSkillBody(sb);  
            sb.Append("</div>");
        }

        private void GenSectionSkillBody(StringBuilder sb)
        {
            sb.Append("<div class=\"section-body\">");
            if (rio.SkillList is not null)
                foreach (var item in rio.SkillList)
                    GenSectionSkillItem(sb, item);
            sb.Append("</div>");
        }

        private void GenSectionSkillItem(StringBuilder sb, Skill item)
        {
            sb.Append("<div class=\"skill-item\">");
            sb.Append("<span>");
            sb.Append("<span role=\"img\" aria-label=\"check-circle\" class=\"anticon anticon-check-circle\" style=\"color: rgb(255, 193, 7); margin-right: 8px;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"check-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\check-circle.txt"));
            sb.Append("</svg>");
            sb.Append("</span>");
            if (string.IsNullOrEmpty(item.SkillDesc)) sb.Append($"{item.SkillName}");
            else sb.Append($"{item.SkillName}: {item.SkillDesc}");
            sb.Append("</span>");
            sb.Append("<ul class=\"ant-rate ant-rate-disabled skill-rate\" tabindex=\"-1\" role=\"radiogroup\">");
            byte[] statStates = new byte[5];
            int fullStarCount = item.SkillLevel / 20;
            for (int i = 0; i < fullStarCount; i++) statStates[i] = 2;
            if (item.SkillLevel % 20 / 10 == 1) statStates[fullStarCount] = 1;
            for (int i = 1; i <= 5; i++)
            {
                switch (statStates[i - 1])
                {
                    case 0: sb.Append("<li class=\"ant-rate-star ant-rate-star-zero\">"); break;
                    case 1: sb.Append("<li class=\"ant-rate-star ant-rate-star-half\">"); break;
                    case 2: sb.Append("<li class=\"ant-rate-star ant-rate-star-full\">"); break;
                    default: throw new ArgumentException();
                }
                sb.Append($"<div role=\"radio\" aria-checked=\"true\" aria-posinset=\"{i}\" aria-setsize=\"5\" tabindex=\"-1\">");
                sb.Append("<div class=\"ant-rate-star-first\">");
                sb.Append("<span role=\"img\" aria-label=\"star\" class=\"anticon anticon-star\">");
                sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"star\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
                sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\star.txt"));
                sb.Append("</svg></span></div>");
                sb.Append("<div class=\"ant-rate-star-second\">");
                sb.Append("<span role=\"img\" aria-label=\"star\" class=\"anticon anticon-star\">");
                sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"star\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
                sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\star.txt"));
                sb.Append("</svg></span></div>");
                sb.Append("</div></li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");
        }

        private void GenSectionSkillTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\">");
            sb.Append("<span class=\"title\">");
            sb.Append(rio.TitleNameMap.SkillList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
        }

        private void GenSectionAboutMe(StringBuilder sb)
        {
            if (rio.AboutMe == null) return;
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\">");
            sb.Append("<span class=\"title\">");
            sb.Append(rio.TitleNameMap.AboutMe);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
            sb.Append("<div class=\"section-body\">");
            sb.Append($"<div>{rio.AboutMe.AboutMeDesc}</div>");
            sb.Append("<div></div></div></div>");
        }

        private void GenSectionWork(StringBuilder sb)
        {
            if (rio.WorkList is null) return;
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
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\">");
            sb.Append("<span class=\"title\">");
            sb.Append(rio.TitleNameMap.WorkList);
            sb.Append("</span><span class=\"title-addon\"></span></div>");
        }

        private void GenSectionEducation(StringBuilder sb)
        {
            if (rio.EducationList is null) return;
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

        private void GenSectionEducationItem(StringBuilder sb, Education item)
        {
            sb.Append("<div class=\"education-item\"><div><span><div><span>");
            sb.Append($"<b>{item.School}</b>");
            sb.Append("<span style=\"margin-left: 8px;\">");
            sb.Append($"<span>{item.Major}</span>");
            sb.Append($"<span class=\"sub-info\" style=\"margin-left: 4px;\">({item.AcademicDegree})</span>");
            sb.Append("</span></span>");
            sb.Append($"<span class=\"sub-info\" style=\"float: right;\">");
            if (item.EndTime is not null) sb.Append($"{item.BeginTime}~{item.EndTime}");
            else sb.Append($"{item.BeginTime} 至今");
            sb.Append("</span></div></div>");
        }

        private void GenSectionEducationTitle(StringBuilder sb)
        {
            sb.Append("<div class=\"section-title\" style=\"color: rgb(47, 87, 133);\">");
            sb.Append("<span class=\"title\">");
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
            sb.Append("<div class=\"avatar \">");
            sb.Append("<span class=\"ant-avatar ant-avatar-square ant-avatar-image avatar\">");
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
            if (rio.Profile.PositionTitle == null) return;
            sb.Append("<div class=\"expect-job\">");
            sb.Append("<span role=\"img\" aria-label=\"heart\" class=\"anticon anticon-heart\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"heart\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\heart.txt"));
            sb.Append($"</svg></span><span>{rio.Profile.PositionTitle}</span></div>");
        }

        private void GenWorkPlace(StringBuilder sb)
        {
            if (rio.Profile.WorkPlace == null) return;
            sb.Append("<div class=\"work-place\">");
            sb.Append("<span role=\"img\" aria-label=\"environment\" class=\"anticon anticon-environment\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"environment\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\environment.txt"));
            sb.Append($"</svg></span><span>{rio.Profile.WorkPlace}</span></div>");
        }

        private void GenZhihu(StringBuilder sb)
        {
            if (rio.Profile.Zhihu == null) return;
            sb.Append("<div class=\"zhihu\">");
            sb.Append("<span role=\"img\" aria-label=\"zhihu-circle\" class=\"anticon anticon-zhihu-circle\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"zhihu-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\zhihu-circle.txt"));
            sb.Append($"</svg></span><span style=\"cursor: pointer;\">{rio.Profile.Zhihu}</span></div>");
        }

        private void GenGithub(StringBuilder sb)
        {
            if (rio.Profile.Github == null) return;
            sb.Append("<div class=\"github\">");
            sb.Append("<span role=\"img\" aria-label=\"github\" class=\"anticon anticon-github\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"github\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\github.txt"));
            sb.Append($"</svg></span><span style=\"cursor: pointer;\">{rio.Profile.Github}</span></div>");
        }

        private void GenEmail(StringBuilder sb)
        {
            if (rio.Profile.Email == null) return;
            sb.Append("<div class=\"email\">");
            sb.Append("<span role=\"img\" aria-label=\"mail\" class=\"anticon anticon-mail\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"mail\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\mail.txt"));
            sb.Append($"</svg></span>{rio.Profile.Email}</div>");
        }

        private void GenMobile(StringBuilder sb)
        {
            if (rio.Profile.Mobile == null) return;
            sb.Append("<div class=\"mobile\">");
            sb.Append("<span role=\"img\" aria-label=\"phone\" class=\"anticon anticon-phone\" style=\"color: rgb(47, 87, 133); opacity: 0.85;\">");
            sb.Append("<svg viewBox=\"64 64 896 896\" focusable=\"false\" data-icon=\"phone\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">");
            sb.Append(File.ReadAllText($"{assetsBasePath}\\svg.path\\mobile.txt"));
            sb.Append($"</svg></span>{rio.Profile.Mobile}</div>");
        }
    }
}
