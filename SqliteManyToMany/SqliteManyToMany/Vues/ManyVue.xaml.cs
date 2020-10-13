using SqliteManyToMany.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteManyToMany.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManyVue : ContentPage
    {
        public ManyVue()
        {
            InitializeComponent();
            BindingContext = new ManyVueModele();
        }
    }
}