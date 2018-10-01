using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Tools
{
    public static class Compare
    {

        public static bool CheckEmail(this string email)
        {
            List<Archer> ArcherList = new List<Archer>();
            using (ArcheryDbContext Db = new ArcheryDbContext()) {
                foreach (Archer element in Db.Archers)
                {
                    Archer ar = element;
                    ArcherList.Add(ar);
                }
                if (ArcherList?.Exists(x => x.Email == email) == null)
                {
                    bool check = true;
                    return check;
                }
                else
                {
                    bool check = false;
                    return check;
                }
            }
        }

           
            
           
        
    }
}