using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace CTA
{
    class Domain
    {
        private string domainName;

        public Domain (string _name)
        {
            domainName = _name;
        }
        public string DomainName { get { return domainName; } }
    }
    class Workstation
    {
        private string worstationName;
        private Domain domain;

        public Workstation(string _name, Domain _domain)
        {
            worstationName = _name;
            domain = _domain;
        }
        public string WorkstationName { get { return worstationName; } }
        public Domain DomainName { get { return domain; } }
    }
    class User
    {
        private string userName;
        private Domain domain;

        public User(string _name, Domain _domain)
        {
            userName = _name;
            domain = _domain;
        }
        public string UserName { get { return userName; } }
        public Domain DomainName { get { return domain; } }
    }
    class ADAccount
    {
        string domain;
        string name;
        string password;
        PrincipalContext context;

        public ADAccount (string _name, string _password, string _domain)
        {
            domain = _domain;
            name = _name;
            password = _password;
            context = new PrincipalContext(ContextType.Domain, domain, name, password);
        }
        public string Domain { get { return domain; } }
        public string Name { get { return name; } }
        public PrincipalContext Context { get { return context; } }
    }
}
