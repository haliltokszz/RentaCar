namespace Entities.Filters
{
    public class CarFilter: IFilter
    {
        public string? Name { get; set; }
        public int? ModelYear { get; set; }
        public byte? RequiredDriveExperience { get; set; }
        public byte? LimitMinAge { get; set; }
        public int? KmLimitDaily { get; set; }
        public byte? SeatsNumber { get; set; }
        public decimal? DailyPrice { get; set; }
        public bool? Available { get; set; }

        public string? CompanyId { get; set; }
        public string? BrandId { get; set; }
        public string? ColorId { get; set; }
    }
}