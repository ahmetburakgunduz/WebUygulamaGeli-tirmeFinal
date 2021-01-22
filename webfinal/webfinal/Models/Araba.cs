using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace webfinal.Models
{
    [Serializable]
    public class Araba
    {
        public virtual int Id { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Model { get; set; }
        public virtual string Yil { get; set; }
        public virtual string MotorGucu { get; set; }
        public virtual ICollection<Alici> Aliciler { get; set; } = new List<Alici>();
    }

    /*
    [Id] [int] NOT NULL,
	[Ad] [nvarchar](20) NOT NULL,
	[Sube] [nvarchar](30) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Sehir] [nvarchar](30) NULL,
    */

    public class ArabaMap : ClassMapping<Araba>
    {
        public ArabaMap()
        {
            Table("Araba");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Marka, c => c.Length(20));
            Property(x => x.Model, c => c.Length(20));
            Property(x => x.Yil);
            Property(x => x.MotorGucu);

            Set(e => e.Aliciler,
                mapper =>
                {
                    mapper.Key(k => k.Column("Araba"));
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All);
                },
               relation => relation.OneToMany(mapping => mapping.Class(typeof(Alici))));
        }
    }
}