using System;

namespace TaskPlanner;

/// <summary>
/// Абстрактный базовый класс для всех сущностей.
/// Инкапсулирует общие поля: идентификатор и даты.
/// </summary>

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    /*public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime UpdatedAt { get; protected set; } = DateTime.Now;

    protected void MarkUpdated() => UpdatedAt = DateTime.Now;*/
}