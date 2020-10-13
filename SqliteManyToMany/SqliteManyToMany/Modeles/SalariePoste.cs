using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteManyToMany.Modeles
{
   public  class SalariePoste
    {
        [ForeignKey(typeof(Salarie))]
        public int salarieId { get; set; }
        [ForeignKey(typeof(Poste))]
        public int PosteId { get; set; }
    }
}
