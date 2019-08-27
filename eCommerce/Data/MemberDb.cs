using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    public static class MemberDb
    {
        /// <summary>
        /// Adds a member to the database. returns the member
        /// with their MemberId populated.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static async Task<Member> AddAsync(GameContext context, Member m)
        {
            context.Members.Add(m);
            await context.SaveChangesAsync();
            return m;
        }

        //public async
    }
}
