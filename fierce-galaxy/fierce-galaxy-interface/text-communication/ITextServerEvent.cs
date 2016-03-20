using System.Net;

namespace fierce_galaxy_interface.text_communication
{
    public interface ITextServerEvent
    {
        IPAddress IPSource
        {
            get;
        }
    }
}
