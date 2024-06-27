using System.Text;

namespace ResumeGeneratorX
{
    internal class Template3Gen : HtmlGenBase
    {
        public Template3Gen(ResumeInfo rio) : base(rio)
        {
            template = 3;
        }

        protected override void GenResumeContent(StringBuilder sb)
        {
            throw new NotImplementedException();
        }
    }
}
