using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using HarmonyLib;

namespace FullServerForwarding
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        public Plugin() => Instance = this;
        public string PluginName => typeof(Plugin).Namespace;

        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 3, 0);
        public override string Author { get; } = "Akvityxs";
        
        private Harmony _harmony = new Harmony("akvityxs.fullserverforwarding");
        public override void OnEnabled()
        {
            _harmony.PatchAll();
            RegisterEvents(); 
        }
        public override void OnDisabled() => UnregisterEvents();
        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.Verified += PlayerOnVerified;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Verified -= PlayerOnVerified;
        }
        private void PlayerOnVerified(VerifiedEventArgs ev)
        {
            if (Player.List.Count() + 1 >= CustomNetworkManager.slots)
            {
                ushort port = Plugin.Instance.Config.RandomPort ? Plugin.Instance.Config.GamePorts[0] :
                    Plugin.Instance.Config.GamePorts[UnityEngine.Random.Range(0, Plugin.Instance.Config.GamePorts.Length -1)];
                ev.Player.Reconnect(port);
            }
        }
    }
}
