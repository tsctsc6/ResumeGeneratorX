namespace ResumeGeneratorX
{

    public class ResumeInfo
    {
        public TitleNameMap TitleNameMap { get; set; } = new();
        public Avatar Avatar { get; set; } = new();
        public Profile Profile { get; set; } = new();
        public Education[]? EducationList { get; set; }
        public Award[]? AwardList { get; set; }
        public WorkExp[]? WorkExpList { get; set; }
        public Skill[]? SkillList { get; set; }
        public ProjectList[]? ProjectList { get; set; }
        public Work[]? WorkList { get; set; }
        public AboutMe? AboutMe { get; set; }
        public Theme Theme { get; set; } = new();
    }

    public class TitleNameMap
    {
        public string EducationList { get; set; } = "教育背景";
        public string WorkExpList { get; set; } = "工作经历";
        public string ProjectList { get; set; } = "项目经历";
        public string SkillList { get; set; } = "个人技能";
        public string AwardList { get; set; } = "更多信息";
        public string WorkList { get; set; } = "个人作品";
        public string AboutMe { get; set; } = "自我介绍";
    }

    public class Avatar
    {
        public string Src { get; set; } = "./DefaultAvatar.png";
        public bool IsHidden { get; set; } = false;
        public string Shape { get; set; } = "square";
    }

    public class Profile
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Github { get; set; }
        public string? Zhihu { get; set; }
        public string? WorkExpYear { get; set; }
        public string? WorkPlace { get; set; }
        public string? PositionTitle { get; set; }
    }

    public class AboutMe
    {
        public string? AboutMe_Desc { get; set; }
    }

    public class Theme
    {
        public string Color { get; set; } = "#2f5785";
        public string TagColor { get; set; } = "#8bc34a";
    }

    public class Education
    {
        public string? BeginTime { get; set; }
        public string? EndTime { get; set; }
        public string? School { get; set; }
        public string? Major { get; set; }
        public string? AcademicDegree { get; set; }
    }

    public class Award
    {
        public string? AwardInfo { get; set; }
        public string? AwardTime { get; set; }
    }

    public class WorkExp
    {
        public string? CompanyName { get; set; }
        public string? DepartmentName { get; set; }
        public string? BeginTime { get; set; }
        public string? EndTime { get; set; }
        public string? WorkDesc { get; set; }
    }

    public class Skill
    {
        public string? skillName { get; set; }
        public string? SkillDesc { get; set; }
        public int SkillLevel { get; set; }
    }

    public class ProjectList
    {
        public string? ProjectName { get; set; }
        public string? ProjectRole { get; set; }
        public string? ProjectTime { get; set; }
        public string? ProjectDesc { get; set; }
        public string? ProjectContent { get; set; }
    }

    public class Work
    {
        public string? WorkName { get; set; }
        public string? WorkDesc { get; set; }
        public string? VisitLink { get; set; }
    }

}
