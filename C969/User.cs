using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }

        public User(string userName, string password, string userId, 
            string active, string createDate, string createdBy,
            string lastUpdate, string lastUpdateBy)
        {
            this.userId = Int32.Parse(userId);
            this.userName = userName;
            this.password = password;
            this.active = Int32.Parse(active);
            this.createDate = DateTime.Parse(createDate);
            this.createdBy = createdBy;
            this.lastUpdate = DateTime.Parse(lastUpdate);
            this.lastUpdateBy = lastUpdateBy;
        }

        public User(string[] query)
        {
            this.userId = Int32.Parse(query[0]);
            this.userName = query[1];
            this.password = query[2];
            this.active = Int32.Parse(query[3]);
            this.createDate = DateTime.Parse(query[4]);
            this.createdBy = query[5];
            this.lastUpdate = DateTime.Parse(query[6]);
            this.lastUpdateBy = query[7];
        }
    }
}
