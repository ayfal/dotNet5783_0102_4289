using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        private DalApi.IDal? dal = DalApi.Factory.Get();
        private BO.Enums.OrderStatus GetStatus(DO.Order order)
        {
            return order.ShipDate == null ? BO.Enums.OrderStatus.Approved : order.DeliveryDate == null ? BO.Enums.OrderStatus.Shipped : BO.Enums.OrderStatus.Delivered;
        }

        private List<BO.OrderItem> GetLogicItems(IEnumerable<DO.OrderItem?> listD)
        {
            List<BO.OrderItem> listB = new List<BO.OrderItem>();
            foreach (DO.OrderItem item in listD)
            {
                BO.OrderItem orderItem = new BO.OrderItem()
                {
                    //ID = item.ID,
                    //ProductID = item.ProductID,
                    Name = dal?.product.Get(item.ProductID)?.Name,
                    //Price = item.Price,
                    //Amount = item.Amount,
                    TotalPrice = item.Amount * item.Price
                };
                orderItem.CopyProperties(item);
                listB.Add(orderItem);
            }
            return listB;
        }
        public IEnumerable<BO.OrderForList> Get()
        {
            var orders = dal?.order.Get() ?? throw new NullReferenceException();
            var ordersList = new List<BO.OrderForList>();
            foreach (var order in orders)
            {
                BO.OrderForList orderForList = new BO.OrderForList()
                {
                    //ID = order?.ID ?? throw new NullReferenceException(),
                    //CustomerName = order?.CustomerName,
                    Status = GetStatus((DO.Order)order!),
                    AmountOfItems = dal?.orderItem.GetOrderItems((int)(order?.ID!)).Count() ?? throw new NullReferenceException(),
                    TotalPrice = (double)dal?.orderItem.GetOrderItems((int)(order?.ID!)).Sum(x => x?.Price)!
                };
                orderForList.CopyProperties(order);
                ordersList.Add(orderForList);
            }
            return ordersList;
        }
        public BO.Order GetOrderDetails(int ID)
        {
            try
            {
                if (ID > 0)
                {
                    var orderD = dal?.order.Get(ID);
                    var v = GetLogicItems((dal ?? throw new NullReferenceException()).orderItem.GetOrderItems((int)(orderD?.ID!)))!;
                    var orderB = new BO.Order()
                    {
                        ID = ID,
                        CustomerName = orderD?.CustomerName,
                        CustomerEmail = orderD?.CustomerEmail,
                        CustomerAddress = orderD?.CustomerAddress,
                        Status = GetStatus((DO.Order)orderD!),
                        //OrderDate = orderD?.OrderDate,
                        //ShipDate = orderD?.ShipDate,
                        //DeliveryDate = orderD?.DeliveryDate,
                        Items = GetLogicItems((IEnumerable<DO.OrderItem?>)(dal ?? throw new NullReferenceException()).orderItem.GetOrderItems((int)(orderD?.ID!)))!,
                        TotalPrice = (double)dal?.orderItem.GetOrderItems((int)orderD?.ID!)?.Sum(x => x?.Price)!
                    };
                    orderB.CopyProperties(orderD);
                    return orderB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Order UpdateShipping(int ID)
        {
            try
            {
                var orderD = dal?.order.Get(ID) ?? throw new NullReferenceException();
                if (orderD.ShipDate == null)
                {
                    orderD.ShipDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.ShipDate = orderD.ShipDate;
                    dal?.order.Update(orderD);
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Order UpdateDelivery(int ID)
        {
            try
            {
                var orderD = dal?.order.Get(ID) ?? throw new NullReferenceException();
                if (orderD.ShipDate == null) throw new BO.Exceptions.NotShippedYetException();
                if (orderD.DeliveryDate == null)
                {
                    orderD.DeliveryDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.DeliveryDate = orderD.DeliveryDate;
                    dal?.order.Update(orderD);
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.OrderTracking Track(int ID)
        {
            try
            {
                var order = dal?.order.Get(ID) ?? throw new NullReferenceException();
                BO.OrderTracking orderTracking = new BO.OrderTracking()
                {
                    ID = order.ID,
                    Status = GetStatus(order),
                    OrderDiary = new Dictionary<DateTime, BO.Enums.OrderStatus>()
                };
                orderTracking.OrderDiary.Add(order.OrderDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Approved);//TODO if this outputs a number, then use toStirng, and change orderDiary def to string
                if (order.ShipDate != null)
                {
                    orderTracking.OrderDiary.Add(order.ShipDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Shipped);//todo: there has to be better way than checking twice it isn't null, find it
                    if (order.DeliveryDate != null) orderTracking.OrderDiary.Add(order.DeliveryDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Delivered);//todo as above
                }
                return orderTracking;
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.OrderItem Update(int orderID, int productID, int newAmount)
        {
            try
            {
                var orderItem = dal?.orderItem.Get(productID, orderID) ?? throw new NullReferenceException();
                var product = dal?.product.Get(productID) ?? throw new NullReferenceException();
                if (product.InStock >= newAmount - orderItem.Amount)
                {
                    orderItem.Amount = newAmount;
                    dal?.orderItem.Update((DO.OrderItem)orderItem!);
                    product.InStock -= newAmount - orderItem.Amount;
                    dal?.product.Update(product);
                    orderItem = dal?.orderItem.Get(productID, orderID) ?? throw new NullReferenceException();
                    product = dal?.product.Get(productID) ?? throw new NullReferenceException();
                    return new BO.OrderItem()
                    {
                        ID = orderItem.ID,
                        ProductID = orderItem.ProductID,
                        Name = product.Name,
                        Price = orderItem.Price,
                        Amount = orderItem.Amount,
                        TotalPrice = orderItem.Price * orderItem.Amount
                    };
                }
                else throw new BO.Exceptions.InsufficientStockException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
    }
}
