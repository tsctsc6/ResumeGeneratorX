using System.Text;

namespace ResumeGeneratorX
{
    internal class Template1Gen : HtmlGenBase
    {
        public Template1Gen(ResumeInfo rio) : base(rio)
        {
            template = 1;
        }

        protected override void GenResumeContent(StringBuilder sb)
        {
            throw new NotImplementedException();
        }
    }
}
