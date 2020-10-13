using SqliteManyToMany.Services;
using SqliteManyToMany.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteManyToMany
{
    public partial class App : Application
    {
        static GestionDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new ManyVue();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static GestionDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GestionDatabase();
                }
                return database;
            }
        }
    }
}
