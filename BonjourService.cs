﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace bonjour_broswer
{
    class BonjourService
    {

        public delegate void UpdateServiceListCallback(IReadOnlyList<IZeroconfHost> results);

        public async Task ListAll(UpdateServiceListCallback callback)
        {
            IReadOnlyList<IZeroconfHost> responses = new List<IZeroconfHost>();
            try
            {
                ILookup<string, string> domains = await ZeroconfResolver.BrowseDomainsAsync();
                responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key));
                foreach (var resp in responses)
                    Console.WriteLine(resp);
            }
            finally
            {
                callback(responses);
            }
        }
    }
}
