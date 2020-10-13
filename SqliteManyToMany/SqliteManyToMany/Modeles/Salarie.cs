using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteManyToMany.Modeles
{
   // [Table("Salarie")]
    public class Salarie
    {
        
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        
        [ManyToMany(typeof(SalariePoste))]
        public List<Poste> LesPostes { get; set; }

    }
}
