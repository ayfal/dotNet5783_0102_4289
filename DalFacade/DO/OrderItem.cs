
using System.Xml.Linq;

namespace DO;
/// <summary>
/// structure for orderItem
/// </summary>
public struct OrderItem
{
    /// <summary>
    /// Unique ProductID for
    /// </summary>
    public int ProductID { get; set; }
    /// <summary>
    /// Unique OrderID for
    /// </summary>
    public int OrderID { get; set; }
    /// <summary>
    /// Unique Price for
    /// </summary>
    public double Price { get; set; }
    /// <summary>
    /// Unique Amount for
    /// </summary>
    public int Amount { get; set; }

    /// </summary>
    ///
    /// </summary>
    public override string ToString() => $@"
        Product ID={ProductID}, 
        OrderID : {OrderID}
    	Price: {Price}
    	Amount of pruduct: {Amount}
";
}