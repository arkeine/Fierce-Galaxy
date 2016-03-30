﻿using System;
using System.Net;

namespace FierceGalaxyInterface.Communication
{
    /// <summary>
    /// Event emit when the text server receive a message from the text client
    /// </summary>
    public interface ITextServerReceiveMessageEvent 
    {
        String Message
        {
            get;
        }

        IPAddress IPSource
        {
            get;
        }

        int Port
        {
            get;
        }
    }
}