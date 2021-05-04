using System;
using System.Reflection;

namespace _5951071008_TranQuangDuy_Nhom3.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}