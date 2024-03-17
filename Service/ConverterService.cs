using System.Xml.Serialization;
using Newtonsoft.Json;
using Service.DTO.Json;
using Service.DTO.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using Item = Service.DTO.Json.Item;
using Specification = Service.DTO.Xml.Specification;

namespace Service;

public class ConverterService
{
    public OrderXml DeserializeXml(string xmlFilePath)
    {
        var serializer = new XmlSerializer(typeof(OrderXml));
        var order = (OrderXml)serializer.Deserialize(new FileStream(xmlFilePath, FileMode.Open))!;

        return order;
    }

    public void SerializeDtoToXml(OrderXml orderXml, string filePath)
    {
        var serializer = new XmlSerializer(typeof(OrderXml));
        using var textWriter = new StreamWriter(filePath);
        serializer.Serialize(textWriter, orderXml);
    }

    public async Task<OrderJson> DeserializeJsonAsync(string jsonFilePath)
    {
        var jsonData = await File.ReadAllTextAsync(jsonFilePath);
        var order = JsonConvert.DeserializeObject<OrderJson>(jsonData);

        return order;
    }

    public async Task SerializeDtoToJsonAsync(OrderJson orderJson, string filePath)
    {
        var jsonContent = JsonConvert.SerializeObject(orderJson, Formatting.Indented);
        await File.WriteAllTextAsync(filePath, jsonContent);
    }

    public async Task ConvertJsonToXmlAsync(string jsonFilePath, string xmlFilePath)
    {
        var jsonDto = await DeserializeJsonAsync(jsonFilePath);
        var xmlItemList = new List<DTO.Xml.Item>();

        foreach (var item in jsonDto.Order.Specification.Item)
        {
            var xmlItem = new DTO.Xml.Item
            {
                Name = item.Name,
                Position = Convert.ToInt32(item.Position),
                Material = item.Material,
                Quantity = Convert.ToInt32(item.Quantity),
                Thickness = Convert.ToInt32(item.Thickness),
                Length = Convert.ToInt32(item.Length),
                Width = Convert.ToInt32(item.Width),
            };
            
            xmlItemList.Add(xmlItem);
        }

        var xmlDto = new OrderXml()
        {
            Number = jsonDto.Order.Number,
            Article = jsonDto.Order.Article,
            Name = jsonDto.Order.Name,
            Specification = new Specification
            {
                Item = xmlItemList
            }
        };
        
        SerializeDtoToXml(xmlDto, xmlFilePath);
    }

    public async Task ConvertXmlToJsonAsync(string xmlFilePath, string jsonFilePath)
    {
        var xmlDto = DeserializeXml(xmlFilePath);
        var jsonItemList = new List<Item>();

        foreach (var item in xmlDto.Specification.Item)
        {
            var jsonItem = new Item
            {
                Name = item.Name,
                Position = item.Position.ToString(),
                Material = item.Material,
                Quantity = item.Quantity.ToString(),
                Thickness = item.Thickness.ToString(),
                Length = item.Length.ToString(),
                Width = item.Width.ToString()
            };
            
            jsonItemList.Add(jsonItem);
        }
        
        var jsonDto = new OrderJson()
        {
            Order = new Order()
            {
                Article = xmlDto.Article,
                Name = xmlDto.Name,
                Number = xmlDto.Number,
                Specification = new DTO.Json.Specification()
                {
                    Item = jsonItemList
                }
            }
        };

        await SerializeDtoToJsonAsync(jsonDto, jsonFilePath);
    }
}