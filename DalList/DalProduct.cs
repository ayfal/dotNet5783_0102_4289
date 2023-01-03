using DO;
using static Dal.DataSource;
using DalApi;
using System.IO.Pipes;

namespace Dal;

public class DalProduct : IProduct
{
    public int Add(Product product)
    {
        if (products.Exists(p => p?.ID == product.ID)) throw new ObjectAlreadyExistsException();
        if (product.ID < 100000 || product.ID > 999999) throw new ObjectNotFoundException();
        products.Add(product);
        return product.ID;
    }

    public void Delete(int ID)
    {
        products.Remove(Get(ID));
    }

    public void Update(Product product)
    {
        var index = products.FindIndex(x => x?.ID == product.ID);
        if (index == -1) throw new ObjectNotFoundException();
        products[index] = product;
    }

    public Product? Get(int ID)
    {
        try { return products.First(o => o?.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public IEnumerable<Product?> Get(Func<Product?, bool>? f = null)
    {
        //if (f==null) return products.Where(i => i?.ID != 0);
        if (f == null) return from p in products
                              where p?.ID != 0
                              orderby p?.ID
                              select p;
        //return products.Where(i => f(i));
        return from p in products
               where f(p)
               select p;
    }
    public Product? GetSingle(Func<Product?, bool>? f)
    {
        try { return products.First(o => f!(o)); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
}

