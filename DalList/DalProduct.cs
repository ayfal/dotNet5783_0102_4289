using DO;
using static Dal.DataSource;

namespace Dal;

public class DalProduct
{
    public int Add(Product product)
    {
        try
        {
            Get(product.ID);
            throw new Exception("product ID already exists!");
        }
        catch (KeyNotFoundException)
        {
            products[Config.products] = product;
            Config.products++;
            return product.ID;
        }
    }

    public void Delete(int ID)
    {
        Get(ID);
        products = products.Where(i => i.ID != ID).ToArray();
        Config.products--;
    }

    public void Update(Product pro)
    {
        Get(pro.ID);
        for (int i = 0; i < Config.products; i++)
        {
            if (products[i].ID == pro.ID) products[i] = pro;
        }
    }

        public Product Get(int ID) // TODO חריגות
    {
        for (int i = 0; i < Config.products; i++)
        {
            if (orderItems[i].ID == ID) return products[i];
        }
        throw new Exception("key not found");
    }
    public Product[] Get()
    {
        return products.ToArray();
    }
}

