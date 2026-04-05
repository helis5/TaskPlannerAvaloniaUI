using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskPlanner;
/// <summary>
/// Хранит коллекцию колонок, каждая из которых хранит свою коллекцию карточек
/// </summary>
public static class AppState 
{ 
    public static ObservableCollection<Column> Columns { get; } = new();
    
    // private const string FilePath = "columns.json";
    private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "columns.json");

    // Сохранение
    public static async Task SaveAsync()
    {
        string json = JsonSerializer.Serialize(Columns, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(FilePath, json);
    }

    // Загрузка
    public static async Task LoadAsync()
    {
        if (!File.Exists(FilePath)) return;

        string json = await File.ReadAllTextAsync(FilePath);
    
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // на случай если имена свойств не совпадают
        };
    
        var loaded = JsonSerializer.Deserialize<List<Column>>(json, options);

        Columns.Clear();
        foreach (var col in loaded ?? [])
        {
            foreach (var card in col.Cards)
                card.ParentColumn = col;

            Columns.Add(col);
        }
    }
}
