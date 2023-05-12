
while (true)
{
    for (int i = 0; i < 100; i++)
    {
        try
        {
            A? a = ProductCreator.GetInstance(ProductType.A) as A;
            a.Run();

            B? b = ProductCreator.GetInstance(ProductType.B) as B;
            b.Run();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

#region Abstract Product
interface IIProduct
{
    void Run();
}

#endregion
#region Concrete Products
class A : IIProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IIProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IIProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion
#region Creator
enum ProductType
{
    A, B, C
}

class ProductCreator
{
    static public IIProduct GetInstance(ProductType productType)
    {
        IIProduct _product = null;

        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                //....
                break;
            case ProductType.B:
                _product = new B();
                //....
                break;
            case ProductType.C:
                _product = new C();
                //....
                break;
            default:
                break;
        }

        return _product;
    }

}

#endregion