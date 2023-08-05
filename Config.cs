using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace FullServerForwarding
{
    public sealed class Config : IConfig
    {
        [Description("Enable")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Get random one. If false then will be used the first game port")]
        public bool RandomPort { get; set; } = false;

        [Description("Game ports with the same ip")]
        public ushort[] GamePorts { get; set; } = new ushort[]
        {
            7777,
            7778
        };
    }
}
