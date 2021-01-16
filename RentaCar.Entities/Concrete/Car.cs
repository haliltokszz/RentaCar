using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public byte RequiredDriveExperience { get; set; }
        public byte LimitMinAge { get; set; }
        public int KMLimitDaily { get; set; }
        public int KMCurrent { get; set; }
        public int TrunkCapacity { get; set; }
        public byte SeatsNumber { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
