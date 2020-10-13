using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteManyToMany.Modeles
{
    public class Poste
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Libelle { get; set; }

        [ManyToMany(typeof(SalariePoste))]
        public List<Salarie> LesSalaries { get; set; }
    }
}
