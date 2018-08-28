﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;

namespace ExemploClientServer.Hub.Client
{
    public class HubClient
    {
        protected HubConnection Connection { get; set; }
        protected string BaseUrl { get; set; } = "http://localhost:50096";

        public HubClient(string url)
        {
            Connection = new HubConnectionBuilder().WithUrl($"{BaseUrl}/{url}").Build();
            Connection.StartAsync();
        }
    }
}