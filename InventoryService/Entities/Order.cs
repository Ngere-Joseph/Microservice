namespace InventoryService.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsComplete { get; set; }
        public int Qty { get; set; }

    }
}
