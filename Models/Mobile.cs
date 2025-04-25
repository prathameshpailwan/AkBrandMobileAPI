namespace AkBrandMobile.Models
{
    public class Mobile
    {
    }
    public class AccessoryModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Qty { get; set; }
        public float? Price { get; set; }
        public string Input { get; set; }


    }

    public class TypeCompanyColourModel
    {
        //public int? UserId { get; set; }
        public int? MobileTypeId { get; set; }
        public int? MobileCompanyId { get; set; }
        public int? MobileColourId { get; set; }
        public string? MobileType { get; set; }
        public string? CompanyName { get; set; }
        public string? MobileColour { get; set; }
        public int? Ram { get; set; }
        public int? RamId { get; set; }
        public int? Rom { get; set; }
        public int? RomId { get; set; }
        public string Input { get; set; }

    }
    public class ModelTransaction
    {
        //public int? UserId { get; set; }
        public int? ModelId { get; set; }
        public int? MobileTypeId { get; set; }
        public int? MobileCompanyId { get; set; }
        public int? MobileColourId { get; set; }
        public string? Model { get; set; }
        public string? DealerPrice { get; set; }
        public string? MOPPrice { get; set; }
        public string? BrandPrice { get; set; }
        public int? RamId { get; set; }
        public int? RomId { get; set; }
        public string Input { get; set; }


    }

    public class TypeCompanyColourSearchModel
    {
        public int? UserId { get; set; }
        public int? MobileTypeId { get; set; }
        public int? MobileCompanyId { get; set; }
        public int? MobileColourId { get; set; }
        public string Input { get; set; }


    }
}
