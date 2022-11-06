

namespace DO;
/// <summary>
/// structure for prodact
/// </summary>
public struct Prodact
{
    /// <summary>
    /// Unique Id for
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique Name for
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Unique Price for
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Unique Category for
    /// </summary>
    public Enums Category { get; set; }

    /// <summary>
    /// Unique inStock for
    /// </summary>
    public int inStock { get; set; }    
}
