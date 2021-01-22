using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webfinal.Models
{
    public class Alici
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Soyad{ get; set; }

        public virtual Araba Araba { get; set; }
    }

    public class AliciMap : ClassMapping<Alici>
    {
        public AliciMap()
        {
            Table("Alici");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(10));
            Property(x => x.Soyad, c => c.Length(10));
            ManyToOne(x => x.Araba);
        }
    }
}