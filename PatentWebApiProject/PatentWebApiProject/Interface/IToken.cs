using PatentWebApiProject.Models;

namespace PatentWebApiProject.Interface
{
    public interface IToken
    {
        string GenerateToken(Members mem);
    }
}
