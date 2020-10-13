using SqliteManyToMany.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SqliteManyToMany.VuesModeles
{
    public class ManyVueModele : INotifyPropertyChanged
    {
        #region Attributs
        private List<Salarie> _maListe;
        #endregion
        #region constructeurs
        public ManyVueModele()
        {
             ActionAjoutMethode();
        }
        #endregion
        #region Getters Setters
        public List<Salarie> MaListe
        {
            get
            {

                return _maListe;
            }

            set
            {
                _maListe = value;
                OnPropertyChanged(nameof(MaListe));
            }

        }

        #endregion
        #region methodes
        public async void ActionAjoutMethode()
        {
            Salarie LeSalarie = new Salarie();
            Poste LePoste = new Poste();

            LeSalarie.LesPostes = new List<Poste>();
            LePoste.LesSalaries = new List<Salarie>();

            LeSalarie.Nom = "nom";

            LePoste.Libelle = "fghjg";
            

            LeSalarie.LesPostes.Add(LePoste);
            LePoste.LesSalaries.Add(LeSalarie);

            await App.Database.SaveItemAsync(LeSalarie);
            await App.Database.SaveItemAsyncEvent(LePoste);

            await App.Database.MiseAJourRelationSalariePoste(LeSalarie);
            await App.Database.MiseAJourRelationPosteSalarie(LePoste);


            var SalarieStored = App.Database.GetRelationSalariePoste(LeSalarie);
            var PosteStored = App.Database.GetRelationPosteSalarie(LePoste);

            string x = SalarieStored.Result.Nom;

            MaListe = await App.Database.GetItemsAsync();
            //TodoItem eventStored2 = await App.Database.TOTO2(MaListe[3]);

        }
        #endregion
        #region notifications
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
