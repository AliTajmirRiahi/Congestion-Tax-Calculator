using Anshan.Framework.Domain;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Domain.Consumer
{
    public class Consumer : AggregateRoot<int>
    {
        public Consumer()
        {
            Title = "";
            Description = "";
            SubDomain = "";
            Domain = "";
            HaveDomain = false;
            ExpireDomain = DateTime.Now;
            RegisterDomain = DateTime.Now;
            ExpireDate = DateTime.Now;
            RegisterSource = "";
            Enable = true;
            ThemeName = "";
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDomain { get; set; }
        public bool HaveDomain { get; set; }
        public string Domain { get; set; }
        public DateTime ExpireDomain { get; set; }
        public DateTime RegisterDomain { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RegisterSource { get; set; }
        public bool Enable { get; set; }
        public string ThemeName { get; set; }
        public Language Language { get; set; }


        public IReadOnlyCollection<User> Users => _users;
        private readonly List<User> _users = new List<User>();

        //TODO
        //Plan
        //
    }
}
public enum Language
{
    fa = 0,
    en = 1,
    ar = 2,
}