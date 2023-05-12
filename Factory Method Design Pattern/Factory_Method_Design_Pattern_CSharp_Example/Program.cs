using System.Threading.Channels;

BankCreator bankCreator = new();
GarantiBank? garanti = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkbank= bankCreator.Create(BankType.HalkBank) as HalkBank;
Vakifbank? vakifbank=bankCreator.Create(BankType.VakifBank) as Vakifbank;

#region Abstract Product
interface IBank
{

}
#endregion
#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;

    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
        _password = password;
    }
    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected");
    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent");
}
class HalkBank : IBank
{
    string _userVode, _password;

    public HalkBank(string userVode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");

        _userVode = userVode;
    }

    public string Password { set => _password = value; }
    public void Send(int amount, string accountNumber)
        => Console.WriteLine($"{amount} money sent");
}
class CredentialVakifbank
{

}
class Vakifbank : IBank
{
    string _userCode, _email, _password;
    public bool isAuthentcation { get; set; }

    public Vakifbank(string userCode, string email, string password)
    {
        Console.WriteLine($"{nameof(Vakifbank)} nesnesi oluşturuldu.");

        _userCode = userCode;
        _email = email;
        _password = password;
    }

    public void ValidateCredential()
    {
        if (true) //validating
            isAuthentcation = true;
    }

    public void SendMoneyToAccounNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}
#endregion
#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion
#region Concrete Factories

class GarantiFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        GarantiBank garanti = new("asd", "123");
        garanti.ConnectGaranti();
        return garanti;
    }
}

class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("asd");
        halkBank.Password = "123";
        return halkBank;
    }
}

class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        throw new NotImplementedException();
    }
}
#endregion
#region Creator
enum BankType
{
    Garanti, HalkBank, VakifBank
}
class BankCreator
{
    public IBank Create(BankType bankType)
    {
        IBankFactory _bankFactory = bankType switch
        {
            BankType.VakifBank => new VakifBankFactory(),
            BankType.HalkBank => new HalkBankFactory(),
            BankType.Garanti => new GarantiFactory()
        };
        return _bankFactory.CreateInstance();
    }
}
#endregion