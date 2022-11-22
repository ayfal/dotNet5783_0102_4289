    namespace DO;
/// <summary>
/// structure for orderItem
/// </summary>
public struct OrderItem
{
    /// <summary>
    /// Unique ID for order item
    /// </summary>
    public int ID { get; set; }
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
        ID : {ID}
        Product ID : {ProductID}
        OrderID : {OrderID}
    	Price: {Price}
    	Amount of pruduct: {Amount}
";
}