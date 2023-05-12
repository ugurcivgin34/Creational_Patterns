Example ex1 = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;
Example ex5 = Example.GetInstance;
Example ex6 = Example.GetInstance;
Example ex7 = Example.GetInstance;
Example ex8 = Example.GetInstance;
Example ex9 = Example.GetInstance;
class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
    }
    //1.Yöntem için
    static Example _example;

    //2.Yöntem için
    static Example()
    {
        _example = new Example();
    }
    public static Example GetInstance
    {
        get
        {
            #region 1.Yöntem
            //_example ??= new Example();
            //return _example;
            #endregion

            #region 2.Yöntem
            return _example;
            #endregion

        }
    }
}