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
                var glib = Assembly.LoadFile(glibFile);

                foreach (var type in glib.GetExportedTypes())
                {
                    if (type.BaseType == _gameInfoType)
                    {
                        var info = Activator.CreateInstance(type) as IGameInfo;
                        if (info != null)
                        {
                            games.Add(info);
                        }
                    }
                }

            }

            return games;
        }

        public static IGameInfo LoadGame()
        {
            return null;
        }
    }
}
