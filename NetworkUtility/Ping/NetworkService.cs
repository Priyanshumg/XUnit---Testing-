﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            // Search DNS()
            // Build Packets()
            return "Success: Ping Sent!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            // Method Returns Object
            return new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            };
        }

        public IEnumerable<PingOptions> MostRecentPing()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,
                },

                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,
                }
            };
            return pingOptions;
        }
    }
}