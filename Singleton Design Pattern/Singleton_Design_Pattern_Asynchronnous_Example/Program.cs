
var t1 = Task.Run(() =>
{
    Example.GetInstance();
});

var t2 = Task.Run(() =>
{
    Example.GetInstance();
});

await Task.WhenAll(t1, t2);

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
    }

    static Example()
    {
        _example = new Example();
    }

    static Example _example;

    //    static object _obj = new object();
    static public Example GetInstance()
    {
        //lock (_obj)
        //{
        //    if (_example == null)
        //        _example = new Example();
        //}
        return _example;
    }
}