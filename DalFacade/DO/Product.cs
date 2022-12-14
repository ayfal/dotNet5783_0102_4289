namespace DO;
/// <summary>
/// structure for Product
/// </summary>
public struct Product
{
    /// <summary>
    /// Unique Id for
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Unique Name for
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Unique Price for
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Unique Category for
    /// </summary>
    public Enums.Category? Category { get; set; }

    /// <summary>
    /// Unique InStock for
    /// </summary>
    public int InStock { get; set; }
    public override string ToString() => this.AutoToString();
}
