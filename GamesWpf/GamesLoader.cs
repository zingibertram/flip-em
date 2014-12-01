using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Games.Core;

namespace GamesWpf
{
    public class GamesLoader
    {
        private static readonly string _appDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games");
        private static readonly Type _gameInfoType = typeof (IGameInfo);

        public static ObservableCollection<IGameInfo> Load()
        {
            var games = new ObservableCollection<IGameInfo>();

            var gamesLibs = Directory.GetFiles(_appDir, "*.dll");
            foreach (var glibFile in gamesLibs)
            {
                var info = LoadGame(glibFile);
                if (info != null)
                {
                    games.Add(info);
                }
            }

            return games;
        }

        public static IGameInfo LoadGame(string path)
        {
            var glib = Assembly.LoadFile(path);

            foreach (var type in glib.GetExportedTypes())
            {
                if (type.BaseType == _gameInfoType)
                {
                    return Activator.CreateInstance(type) as IGameInfo;
                }
            }

            return null;
        }
    }
}
