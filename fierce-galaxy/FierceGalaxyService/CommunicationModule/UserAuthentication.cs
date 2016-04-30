using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace FierceGalaxyServer.CommunicationModule
{
    public class UserAuthentication : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            try
            {
                GameFacade.GetInstance().PlayerManager.Login(userName, password);
            }
            catch (ArgumentException)
            {
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}