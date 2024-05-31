using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DTO
{
    [XmlRoot("Проект")]
    public class ProjectDto
    {
        [XmlAttribute("Наименование")]
        public string Name { get; set; }

        [XmlAttribute("Номер")]
        public string Number { get; set; }

        [XmlAttribute("Версия")]
        public string Version { get; set; }

        [XmlElement("Изделие")]
        public Product Product { get; set; }
    }

    public class Product
    {
        [XmlElement("Наименование")]
        public string Name { get; set; }

        [XmlElement("ТипОбъекта")]
        public string ObjectType { get; set; }

        [XmlElement("Количество")]
        public int Quantity { get; set; }

        [XmlElement("Позиция")]
        public string Position { get; set; }

        [XmlElement("Цена")]
        public string Price { get; set; }

        [XmlArray("СписокЭлементов")]
        [XmlArrayItem("Объект")]
        public List<Element> Elements { get; set; }

        [XmlArray("СписокОпераций")]
        [XmlArrayItem("Операция")]
        public List<Operation> Operations { get; set; }

        [XmlElement("Артикул")]
        public string Article { get; set; }

        [XmlElement("Заказ")]
        public string Order { get; set; }

        [XmlElement("Разработчик")]
        public string Developer { get; set; }

        [XmlElement("ДобавленоВручную")]
        public ManualAddition ManualAddition { get; set; }
    }

    public class Element
    {
        [XmlElement("ТипОбъекта")]
        public string ObjectType { get; set; }

        [XmlElement("Наименование")]
        public string Name { get; set; }

        [XmlElement("Код")]
        public string Code { get; set; }

        [XmlElement("КодДетали")]
        public string DetailCode { get; set; }

        [XmlElement("Длина")]
        public decimal Length { get; set; }

        [XmlElement("Ширина")]
        public decimal Width { get; set; }

        [XmlElement("Длина_детали_без_облицовки")]
        public decimal LengthWithoutLining { get; set; }

        [XmlElement("Ширина_детали_без_облицовки")]
        public decimal WidthWithoutLining { get; set; }

        [XmlElement("Длина_готовой_детали")]
        public decimal FinishedLength { get; set; }

        [XmlElement("Ширина_готовой_детали")]
        public decimal FinishedWidth { get; set; }

        [XmlElement("ОбщаяТолщина")]
        public decimal TotalThickness { get; set; }

        [XmlElement("Количество")]
        public int Quantity { get; set; }

        [XmlElement("Позиция")]
        public int Position { get; set; }

        [XmlElement("Обозначение")]
        public string Designation { get; set; }

        [XmlElement("Прямоугольная")]
        public string Rectangular { get; set; }

        [XmlElement("ЛицеваяСторона")]
        public string FaceSide { get; set; }

        [XmlElement("Сторона")]
        public string Side { get; set; }

        [XmlElement("ОриентацияТекстуры")]
        public string TextureOrientation { get; set; }

        [XmlArray("СписокКромок1")]
        [XmlArrayItem("Кромка")]
        public List<Edge> Edges { get; set; }

        [XmlArray("СписокКромокСМЧертеж")]
        [XmlArrayItem("Кромка")]
        public List<Edge> DrawingEdges { get; set; }

        [XmlArray("Отверстия")]
        [XmlArrayItem("Отверстие")]
        public List<Hole> Holes { get; set; }

        [XmlElement("ТипПанели")]
        public string PanelType { get; set; }

        [XmlElement("ОсновнойМатериал")]
        public Material MainMaterial { get; set; }

        [XmlArray("СписокПазов")]
        [XmlArrayItem("Паз")]
        public List<Groove> Grooves { get; set; }

        [XmlElement("ОблицовкаПласти1")]
        public string TopLining { get; set; }

        [XmlElement("ОблицовкаПласти2")]
        public string BottomLining { get; set; }

        [XmlElement("ПорядокОблицовкиПласти")]
        public LiningOrder LiningOrder { get; set; }

        [XmlArray("СписокОпераций")]
        [XmlArrayItem("Операция")]
        public List<Operation> Operations { get; set; }

        [XmlArray("СопутствующиеМатериалы")]
        [XmlArrayItem("СопутствующийМатериал")]
        public List<AuxiliaryMaterial> AuxiliaryMaterials { get; set; }
    }

    public class Edge
    {
        [XmlElement("Наименование")]
        public string Name { get; set; }

        [XmlElement("Код")]
        public string Code { get; set; }

        [XmlElement("Длина")]
        public decimal Length { get; set; }

        [XmlElement("Ширина")]
        public decimal Width { get; set; }

        [XmlElement("Толщина")]
        public decimal Thickness { get; set; }

        [XmlElement("Обозначение")]
        public string Designation { get; set; }
    }

    public class Hole
    {
        [XmlElement("ПозицияX")]
        public decimal PositionX { get; set; }

        [XmlElement("ПозицияY")]
        public decimal PositionY { get; set; }

        [XmlElement("ПозицияZ")]
        public decimal PositionZ { get; set; }

        [XmlElement("Диаметр")]
        public decimal Diameter { get; set; }

        [XmlElement("Тип")]
        public string Type { get; set; }

        [XmlElement("Глубина")]
        public decimal Depth { get; set; }

        [XmlElement("НаправлениеX")]
        public decimal DirectionX { get; set; }

        [XmlElement("НаправлениеY")]
        public decimal DirectionY { get; set; }

        [XmlElement("НаправлениеZ")]
        public decimal DirectionZ { get; set; }
    }

    public class Material
    {
        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("Наименование")]
        public string Name { get; set; }

        [XmlElement("Код")]
        public string Code { get; set; }

        [XmlElement("Тип")]
        public string Type { get; set; }

        [XmlElement("Количество")]
        public decimal Quantity { get; set; }

        [XmlElement("КоличествоСМодели")]
        public decimal ModelQuantity { get; set; }

        [XmlElement("КоличествоПоСопут")]
        public decimal RelatedQuantity { get; set; }

        [XmlElement("КоличествоДоОкругления")]
        public decimal RoundedQuantity { get; set; }

        [XmlElement("ЕдИзм")]
        public string Unit { get; set; }

        [XmlElement("Цена")]
        public decimal Price { get; set; }

        [XmlElement("Стоимость")]
        public decimal Cost { get; set; }

        [XmlElement("Коэффициент")]
        public decimal Coefficient { get; set; }

        [XmlElement("Толщина")]
        public decimal Thickness { get; set; }

        [XmlElement("СпособОкругления")]
        public string RoundingMethod { get; set; }

        [XmlElement("ВеличинаОкругления")]
        public decimal RoundingValue { get; set; }

        [XmlElement("Класс")]
        public string Class { get; set; }

        [XmlElement("SyncID")]
        public string SyncID { get; set; }

        [XmlElement("Примечание")]
        public string Note { get; set; }
    }

    public class Groove
    {
        // Add properties for grooves if needed
    }

    public class LiningOrder
    {
        [XmlElement("Сверху")]
        public string Top { get; set; }

        [XmlElement("Снизу")]
        public string Bottom { get; set; }
    }

    public class Operation
    {
        // Add properties for operations if needed
    }

    public class AuxiliaryMaterial
    {
        [XmlElement("ID")]
        public int ID { get; set; }

        [XmlElement("Наименование")]
        public string Name { get; set; }

        [XmlElement("Код")]
        public string Code { get; set; }

        [XmlElement("Тип")]
        public string Type { get; set; }

        [XmlElement("Количество")]
        public decimal Quantity { get; set; }

        [XmlElement("КоличествоСМодели")]
        public decimal ModelQuantity { get; set; }

        [XmlElement("КоличествоПоСопут")]
        public decimal RelatedQuantity { get; set; }

        [XmlElement("КоличествоДоОкругления")]
        public decimal RoundedQuantity { get; set; }

        [XmlElement("ЕдИзм")]
        public string Unit { get; set; }

        [XmlElement("Цена")]
        public decimal Price { get; set; }

        [XmlElement("Стоимость")]
        public decimal Cost { get; set; }

        [XmlElement("Коэффициент")]
        public decimal Coefficient { get; set; }

        [XmlElement("СпособОкругления")]
        public string RoundingMethod { get; set; }

        [XmlElement("ВеличинаОкругления")]
        public decimal RoundingValue { get; set; }

        [XmlElement("Класс")]
        public string Class { get; set; }

        [XmlElement("SyncID")]
        public string SyncID { get; set; }

        [XmlElement("Примечание")]
        public string Note { get; set; }
    }

    public class ManualAddition
    {
        [XmlArray("Материалы")]
        [XmlArrayItem("Материал")]
        public List<Material> Materials { get; set; }

        [XmlArray("Операции")]
        [XmlArrayItem("Операция")]
        public List<Operation> Operations { get; set; }

        [XmlArray("СопутствующиеМатериалы")]
        [XmlArrayItem("СопутствующийМатериал")]
        public List<AuxiliaryMaterial> AuxiliaryMaterials { get; set; }
    }
}
