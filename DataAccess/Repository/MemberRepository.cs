using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();
        public void UpdateMember() => MemberDAO.Instance.UpdateMember();
    }
}
