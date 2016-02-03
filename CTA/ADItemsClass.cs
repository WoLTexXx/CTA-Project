using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace CTA
{
    #region Статический Класс для работы с AD
    static class DomainManager
    {
        #region Классы

        public class Domain
        {
            private string domainName;

            public Domain(string _name)
            {
                domainName = _name;
            }
            public string DomainName { get { return domainName; } }
        }
        public class Workstation
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
        public class User
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
        class ConnectionADAccount
        {
            string domain;
            string name;
            string password;
            PrincipalContext context;

            public ConnectionADAccount(string _name, string _password, string _domain)
            {
                domain = _domain;
                name = _name;
                password = _password;
                try
                {
                    context = new PrincipalContext(ContextType.Domain, domain, name, password);
                }
                catch (Exception ex) { throw new Exception(); }
            }
            public string Domain { get { return domain; } }
            public string Name { get { return name; } }
            public PrincipalContext Context { get { return context; } }
        }
        #endregion
        #region Поля
        private static List<ConnectionADAccount> allADAccounts = new List<ConnectionADAccount>();
        private static List<string> allADProfiles = new List<string>();
        #endregion
        #region Методы

        public static List<string> GetAllADAccounts()
        {
            return allADProfiles;
        }
        public static void AddAccount(string name, string password, string domain)
        {
            try
            {
                allADAccounts.Add(new ConnectionADAccount(name, password, domain));
                allADProfiles.Add(String.Format(@"{0}\{1}", domain, name));
            }
            catch (Exception ex) { FSCWindow.ShowMessage(ex.Message); }
        }
        public static void DelAccount(string domain, string login)
        {
            var q = from n in allADAccounts
                    where n.Name == login
                    select n;
            
            foreach(var r in q)
            {
                allADAccounts.Remove(r);
            }

        }

        #endregion
    }
    #endregion
}
