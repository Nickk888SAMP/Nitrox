using NitroxModel.Discovery;
using NitroxModel.Helper;
using NitroxModel.Platforms.OS.Shared;
using NitroxModel.Platforms.Store.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroxModel.Platforms.Store
{
    public sealed class Pirated : IGamePlatform
    {
        private static Pirated instance;
        public static Pirated Instance => instance ??= new Pirated();

        public string Name => nameof(Pirated);
        public Platform Platform => Platform.PIRATED;

        public string GetExeFile()
        {
            throw new NotImplementedException();
        }

        public bool OwnsGame(string gameDirectory)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessEx> StartGameAsync(string pathToGameExe, string launchArguments)
        {
            return await Task.FromResult(
                 ProcessEx.Start(
                     pathToGameExe,
                     new[] { (NitroxUser.LAUNCHER_PATH_ENV_KEY, NitroxUser.LauncherPath) },
                     Path.GetDirectoryName(pathToGameExe),
                     $"{launchArguments}")
                 );
        }

        public Task<ProcessEx> StartPlatformAsync()
        {
            throw new NotImplementedException();
        }
    }
}
