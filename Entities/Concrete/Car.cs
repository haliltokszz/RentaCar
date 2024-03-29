﻿using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : AuditableEntity
    {
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public CarCategories Category { get; set; }
        public string Description { get; set; }
        public byte RequiredDriveExperience { get; set; }
        public byte LimitMinAge { get; set; }
        public int KmLimitDaily { get; set; }
        public int KmCurrent { get; set; }
        public int TrunkCapacity { get; set; }
        public byte SeatsNumber { get; set; }
        public decimal DailyPrice { get; set; }
        public bool Available { get; set; }

        public short? MinFindeksScore { get; set; }

        //References
        public string CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public string ColorId { get; set; }
        public virtual  Color Color { get; set; }

        public virtual  List<CarImage> Images { get; set; } = new EditableList<CarImage>();
    }
}