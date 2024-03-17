using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Parser.Test;

public class DataParsingTests
{
    private const string ExpectedName = "Р.С-10. Стол офисный";
    private const string ExpectedNumber = "КЛ220"; 
    
    private string _exampleJsonPath;
    private string _exampleXmlPath;
    private string _jsonFolderPath;
    private string _xmlFolderPath;
    private string _jsonFilePath;
    private string _xmlFilePath;

    private Service.Service _orderParser;

    [SetUp]
    public void Setup()
    {
        _jsonFolderPath = "/Users/zgmnnv/Dev/Parser/Parser.Test/TestData/Json";
        _exampleJsonPath = "/Users/zgmnnv/Dev/Parser/Parser.Test/TestData/Json/example.json";
        _xmlFolderPath = "/Users/zgmnnv/Dev/Parser/Parser.Test/TestData/Xml";
        _exampleXmlPath = "/Users/zgmnnv/Dev/Parser/Parser.Test/TestData/Xml/example.xml";
        _orderParser = new Service.Service();
    }

    [TearDown]
    public void TearDown()
    {
        var xmlFiles = Directory.GetFiles(_xmlFolderPath);

        if (xmlFiles.Contains(_xmlFilePath))
        {
            File.Delete(_xmlFilePath);
        }
        
        var jsonFiles = Directory.GetFiles(_jsonFolderPath);

        if (jsonFiles.Contains(_jsonFilePath))
        {
            File.Delete(_jsonFilePath);
        }
    }

    [Test]
    public void Deserialize_XmlToDto()
    {
        var orderDto = _orderParser.DeserializeXml(_exampleXmlPath);
        Assert.That(orderDto.Name, Is.EqualTo(ExpectedName));
    }

    [Test]
    public void Serialize_DtoToXml()
    {
        var fileName = "/" + Randomizer.CreateRandomizer().GetString(10) + ".xml";
        _xmlFilePath = _xmlFolderPath + fileName;

        var orderDto = _orderParser.DeserializeXml(_exampleXmlPath);
        _orderParser.SerializeDtoToXml(orderDto, _xmlFilePath);
        var newOrderDto = _orderParser.DeserializeXml(_xmlFilePath);

        Assert.That(newOrderDto.Name, Is.EqualTo(orderDto.Name));
    }

    [Test]
    public async Task Deserialize_JsonToDto()
    {
        var orderDto = await _orderParser.DeserializeJsonAsync(_exampleJsonPath);
        Assert.That(orderDto.Order.Name, Is.EqualTo(ExpectedName));
    }

    [Test]
    public async Task Serialize_DtoToJson()
    {
        var fileName = "/" + Randomizer.CreateRandomizer().GetString(10) + ".json";
        _jsonFilePath = _jsonFolderPath + fileName;

        var orderDto = await _orderParser.DeserializeJsonAsync(_exampleJsonPath);
        await _orderParser.SerializeDtoToJsonAsync(orderDto, _jsonFilePath);
        var newOrderDto = await _orderParser.DeserializeJsonAsync(_jsonFilePath);
        
        Assert.Multiple(() =>
        {
            Assert.That(newOrderDto.Order.Name, Is.EqualTo(orderDto.Order.Name));
            Assert.That(newOrderDto.Order.Number, Is.EqualTo(orderDto.Order.Number));
        });
    }

    [Test]
    public async Task Serialize_JsonToXml()
    {
        var fileName = "/" + Randomizer.CreateRandomizer().GetString(10) + ".xml";
        _xmlFilePath = _xmlFolderPath + fileName;
        
        await _orderParser.ConvertJsonToXmlAsync(_exampleJsonPath, _xmlFilePath);
        var xmlFiles = Directory.GetFiles(_xmlFolderPath);
        
        Assert.That(xmlFiles, Does.Contain(_xmlFilePath));

        var xmlDto = _orderParser.DeserializeXml(_xmlFilePath);
        
        Assert.Multiple(() =>
        {
            Assert.That(xmlDto.Name, Is.EqualTo(ExpectedName));
            Assert.That(xmlDto.Number, Is.EqualTo(ExpectedNumber));
            Assert.That(xmlDto.Specification.Item.Count, Is.EqualTo(3));

        });
    }

    [Test]
    public async Task Serialize_XmlToJson()
    {
        var jsonFileName = "/" + Randomizer.CreateRandomizer().GetString(10) + ".json";
        _jsonFilePath = _jsonFolderPath + jsonFileName;

        await _orderParser.ConvertXmlToJsonAsync(_exampleXmlPath, _jsonFilePath);
        var jsonFiles = Directory.GetFiles(_jsonFolderPath);
        
        Assert.That(jsonFiles, Does.Contain(_jsonFilePath));

        var jsonDto = await _orderParser.DeserializeJsonAsync(_jsonFilePath);
        
        Assert.Multiple(() =>
        {
            Assert.That(jsonDto.Order.Name, Is.EqualTo(ExpectedName));
            Assert.That(jsonDto.Order.Number, Is.EqualTo(ExpectedNumber));
            Assert.That(jsonDto.Order.Specification.Item.Count, Is.EqualTo(3));
        });
    }
}