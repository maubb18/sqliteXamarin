﻿using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlite2.Droid.Config))]
namespace Sqlite2.Droid
{
    public class Config : IConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    directorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return directorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }
    }
}