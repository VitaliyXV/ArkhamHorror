namespace ArkhamHorrorLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonstersAmount")]
    public partial class MonstersAmount
    {
        public int Id { get; set; }

        public int Monster { get; set; }

        public int GameExtention { get; set; }

        public int Amount { get; set; }

        public virtual GameExtention GameExtention1 { get; set; }

        public virtual Monster Monster1 { get; set; }
    }
}
