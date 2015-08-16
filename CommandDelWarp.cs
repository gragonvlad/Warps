﻿using Rocket.API;
using Rocket.Unturned.Chat;
using System.Collections.Generic;

namespace Warps
{
    public class CommandDelWarp : IRocketCommand
    {
        public static string syntax = "<\"warpname\">";
        public static string help = "Deletes a warp on the server.";

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public bool AllowFromConsole
        {
            get { return true; }
        }

        public string Help
        {
            get { return help; }
        }

        public string Name
        {
            get { return "delwarp"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "Warps.delwarp" }; }
        }

        public string Syntax
        {
            get { return syntax; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (Warps.Instance.Configuration.Instance.WarpsEnable)
            {
                if (command.Length == 0 || command.Length > 1)
                {
                    UnturnedChat.Say(caller, Warps.Instance.Translate("delwarp_help"));
                    return;
                }

                Warp warpData = Warps.warpsData.GetWarp(command[0]);
                if (warpData == null)
                {
                    UnturnedChat.Say(caller, Warps.Instance.Translate("delwarp_not_found"));
                    return;
                }
                else
                {
                    Warps.warpsData.RemoveWarp(command[0]);
                    UnturnedChat.Say(caller, Warps.Instance.Translate("delwarp_removed"));
                    return;
                }
            }
            else
            {
                UnturnedChat.Say(caller, Warps.Instance.Translate("warps_disabled"));
                return;
            }
        }
    }
}