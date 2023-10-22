using System.IO;
using NitroxModel.Platforms.OS.Shared;
using NitroxModel.Platforms.Store.Interfaces;

namespace NitroxModel.Platforms.Store
{
    public static class GamePlatforms
    {
        public static readonly IGamePlatform[] AllPlatforms = { Steam.Instance, EpicGames.Instance, Discord.Instance, MSStore.Instance, Pirated.Instance };

        public static IGamePlatform GetPlatformByGameDir(string gameDirectory)
        {
            if (!Directory.Exists(gameDirectory))
            {
                return null;
            }

            if(IsPirateByDirectory(gameDirectory))
            {
                return Pirated.Instance;
            }

            foreach (IGamePlatform platform in AllPlatforms)
            {
                if (platform.OwnsGame(gameDirectory))
                {
                    return platform;
                }
            }

            return null;
        }

        public static bool IsPirateByDirectory(string subnauticaRoot)
        {
            string subdirDll = Path.Combine(subnauticaRoot, "Subnautica_Data", "Plugins", "x86_64", "steam_api64.dll");
            if (File.Exists(subdirDll) && !FileSystem.Instance.IsTrustedFile(subdirDll))
            {
                return true;
            }
            // Dlls might be in root if cracked game (to override DLLs in sub directories).
            string rootDll = Path.Combine(subnauticaRoot, "steam_api64.dll");
            if (File.Exists(rootDll) && !FileSystem.Instance.IsTrustedFile(rootDll))
            {
                return true;
            }

            return false;
        }
    }

    
}
