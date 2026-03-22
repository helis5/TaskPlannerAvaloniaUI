using System;

namespace TaskPlanner;

public class Column : BaseEntity
{
    private readonly string _title = "Название столбца";
    public string Name { get; }
    //Конструкторы по умолчанию и с заданным именем
    public Column() => Name = _title;
    public Column(string columnName) => Name = columnName;

}