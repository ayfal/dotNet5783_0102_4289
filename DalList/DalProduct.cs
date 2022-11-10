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
        try
        {
            Get(ID);
            products = products.Where(i => i.ID != ID).ToArray();

        }
        catch (KeyNotFoundException)
        {


        }
    }

    public void Update()
    {

    }
        
    public Product Get(int ID) // TODO חריגות
    {
        for (int i = 0; i < DataSource.Config.products; i++)
        {
            if (DataSource.products[i].ID == ID)
                return DataSource.products[i];
        }
        throw new KeyNotFoundException();   
    }
}

