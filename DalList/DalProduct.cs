using DO;
using static Dal.DataSource;
using DalApi;

namespace Dal;

public class DalProduct : IProduct
{
    public int Add(Product product) 
    {
        if (products.Exists(p => p.ID == product.ID)) throw new ObjectAlreadyExistsException();
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
        var index = products.FindIndex(x=>x.ID==product.ID);
        if (index == -1) throw new ObjectNotFoundException();
        products[index] = product;
    }

    public Product Get(int ID)
    {
        try { return products.First(o => o.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public IEnumerable<Product> Get()
    {
        return products.Where(i => i.ID != 0);
    }
}

