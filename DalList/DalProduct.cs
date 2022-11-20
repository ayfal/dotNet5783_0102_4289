using DO;
using static Dal.DataSource;

namespace Dal;

public class DalProduct
{
    
    public void Add(Product product)
    {
        if (products.Exists(p => p.ID == product.ID)) throw new Exception("product ID already exists!");
        if (product.ID < 100000 || product.ID > 999999) throw new Exception("product ID is out of range!");
        products.Add(product);
    }

    public void Delete(int ID)
    {
        products.Remove(Get(ID));
    }

    public void Update(Product product)
    {
        var obj = Get(product.ID);
        obj = product;//TODO check if this updates the object inside the list
        //for (int i = 0; i < Config.products; i++)
        //{
        //    if (products[i].ID == pro.ID) products[i] = pro;
        //}
    }

    public Product Get(int ID)
    {
        try { return products.First(o => o.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public Product[] Get()
    {
        return products.Where(i => i.ID != 0).ToArray();
    }
}

