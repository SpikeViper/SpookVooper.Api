using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api.Oauth2
{
    public class AuthorizeModel
    {
        public string ReponseType { get; set; }
        public string ClientID { get; set; }
        public string UserID { get; set; }
        public string Redirect { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
        public string Code { get; set; }

        public string GetDesc(string scope)
        {
            if (scope == "view")
            {
                return "View your account";
            }
            else if (scope == "eco")
            {
                return "Control credit payments";
            }
            else
            {
                return $"Use {scope} management";
            }
        }
        public List<string> GetScopeDesc()
        {
            List<string> scopes = new List<string>();

            foreach (string s in Scope.Split('|'))
            {
                if (s != "")
                {
                    scopes.Add($"- {GetDesc(s)}");
                }
            }

            return scopes;
        }
    }
}
