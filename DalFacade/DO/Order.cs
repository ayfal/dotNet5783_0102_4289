namespace DO;
/// <summary>
/// structure for order
/// </summary>
public struct Order
{
    /// <summary>
    /// Uniqe ID of order
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Customer's name
    /// </summary>
    public string CustomerName { get; set; }
    /// <summary>
    /// Customer's Email
    /// </summary>
    public string CustomerEmail { get; set; }
    /// <summary>
    /// Customer's address
    /// </summary>
    public string CustomerAddress { get; set; }
    /// <summary>
    /// Order's date
    /// </summary>
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// Shipping's date
    /// </summary>
    public DateTime ShipDate { get; set; }
    /// <summary>
    /// Delivery's date
    /// </summary>
    public DateTime DeliveryDate { get; set; }
    public override string ToString() => $@"
        Order ID: {ID}
        Customer name: {CustomerName}
    	Email: {CustomerEmail}
        Address: {CustomerAddress}
        Order Date: {OrderDate}
        Ship Date: {ShipDate}
        Delivery Date: {DeliveryDate}    	
";
}
