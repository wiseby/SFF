namespace Domain
{
    public interface IProduct
    {
        public int Id { get; set; }
         public string Name { get; set; }
         public int Quantity { get; set; }
         public int Licenses { get; set; }
         public float Price { get; set; }
    }
}