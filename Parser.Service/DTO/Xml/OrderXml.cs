using System.Xml.Serialization;

namespace Parser.Service.DTO.Xml;

[XmlRoot(ElementName = "Order")]
public class OrderXml
{
    [XmlElement(ElementName = "Number")] public string Number { get; set; }

    [XmlElement(ElementName = "Name")] public string Name { get; set; }

    [XmlElement(ElementName = "Article")] public string Article { get; set; }

    [XmlElement(ElementName = "Specification")]
    public Specification Specification { get; set; }
}

[XmlRoot(ElementName = "Item")]
public class Item
{
    [XmlElement(ElementName = "Position")] public int Position { get; set; }

    [XmlElement(ElementName = "Thickness")]
    public int Thickness { get; set; }

    [XmlElement(ElementName = "Name")] public string Name { get; set; }

    [XmlElement(ElementName = "Length")] public int Length { get; set; }

    [XmlElement(ElementName = "Width")] public int Width { get; set; }

    [XmlElement(ElementName = "Material")] public string Material { get; set; }

    [XmlElement(ElementName = "Quantity")] public int Quantity { get; set; }
}

[XmlRoot(ElementName = "Specification")]
public class Specification
{
    [XmlElement(ElementName = "Item")] public List<Item> Item { get; set; }
}