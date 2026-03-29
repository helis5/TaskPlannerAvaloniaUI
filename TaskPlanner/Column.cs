using System;
using System.Collections.ObjectModel;

namespace TaskPlanner;

public class Column : BaseEntity
{
    private readonly string _title = "Название столбца";
    public string Name { get; set; }
    //Здесь будем хранить коллекцию карточек для этого столбца
    public ObservableCollection<TaskCard> Cards { get; set; } = new();
    //Конструкторы по умолчанию и с заданным именем
    public Column() => Name = _title;
    public Column(string columnName) => Name = columnName;

}