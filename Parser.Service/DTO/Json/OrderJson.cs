namespace Parser.Service.DTO.Json;

public class OrderJson
{
    public Order Order { get; set; }
}

public class Order
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Article { get; set; }
    public Specification Specification { get; set; }
}

public class Item
{
    public string Position { get; set; }
    public string Thickness { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Width { get; set; }
    public string Material { get; set; }
    public string Quantity { get; set; }
}

public class Specification
{
    public List<Item> Item { get; set; }
}