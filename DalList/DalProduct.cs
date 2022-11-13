using DO;
using static Dal.DataSource;

namespace Dal;

public class DalProduct
{
    public void Add(Product product)
    {
        if (product.ID < 100000 || product.ID > 999999) throw new Exception("product ID is out of range!");
        if (Array.Exists(products, p => p.ID == product.ID)) throw new Exception("product ID already exists!");
        products[Config.products] = product;
        Config.products++;//TODO check if this line can be combined in the prev. relevant to all entities
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

        public Product Get(int ID)
    {
        for (int i = 0; i < Config.products; i++)
        {
            if (products[i].ID == ID) return products[i];
        }
        throw new Exception("key not found");
    }
    public Product[] Get()
    {
        return products.Where(i => i.ID != 0).ToArray();
    }
}

