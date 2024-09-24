using Test.Presentation;

public static class Program
{
    private static List<Factory> _factories = [];
        
    private static void Terminal()
    {
        while (true)
        {
            Console.WriteLine("\nFactories system: ");
            Console.WriteLine("1. Add factory");
            Console.WriteLine("2. Get factories information");
            Console.WriteLine("3. Get factory information by identifier");
            Console.WriteLine("4. Delete factory from list");
            Console.WriteLine("5. Exit");
            
            Console.Write("Your choice: ");
            var userChoice = Console.ReadLine();

            if (!int.TryParse(userChoice, out var userChoiceInFormat))
            {
                Console.WriteLine("\nEnter correct data!");
            }

            switch (userChoiceInFormat)
            {
                case 1:
                    CreateFactory();
                    break;
                case 2:
                    GetFactories();
                    break;
                case 3:
                    GetFactoryById();
                    break;
                case 4:
                    DeleteFactory();
                    break;
                case 5:
                    Console.WriteLine("\nGood bye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please, try again!");
                    break;
            }
        }
    }

    private static void DeleteFactory()
    {
        Console.Write("\nEnter factory identifier: ");
        var factoryIdentifier = Convert.ToInt32(Console.ReadLine());

        var factory = _factories.FirstOrDefault(f => f.Id == factoryIdentifier);

        if (factory is null)
        {
            Console.WriteLine("\nFactory not found! Please, try again!");
            return;
        }

        _factories.Remove(factory);
        
        Console.WriteLine("\nFactory has been successfully deleted from the factories list!");
    }

    private static void GetFactoryInfo(Factory factory)
    {
        Console.Write($"\n\t-ID: {factory.Id}\n\t\t-Electricity per plan (P): {factory.P}" +
                      $"\n\t\t-Electricity in fact (F): {factory.F}" +
                      $"\n\t\t-Deviation from the plan (O1): {Math.Round(factory.O1, 2)} kWt" +
                      $"\n\t\t-Deviation in fact (O2): {Math.Round(factory.O2,2)} %");
    }
    
    private static void GetFactoryById()
    {
        Console.Write("\nEnter factory identifier: ");
        var factoryIdentifier = Convert.ToInt32(Console.ReadLine());

        var factory = _factories.FirstOrDefault(f => f.Id == factoryIdentifier);

        if (factory is null)
        {
            Console.WriteLine("\nFactory not found! Please, try again!");
            return;
        }

        GetFactoryInfo(factory);
    }

    private static void GetFactories()
    {
        if (_factories.Count == 0)
        {
            Console.WriteLine("\nThere aren't factories yet. Please, add one!");
            return;
        }
        
        Console.WriteLine("\nFactories list:");
        foreach (var factory in _factories)
        {
            GetFactoryInfo(factory);
        }
    }

    private static void CreateFactory()
    {
        Console.Write("\n1. Enter electricity capability use per plan: ");
        var planElectricity = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("2. Enter electricity capability use in fact: ");
        var inFactElectricity = Convert.ToDouble(Console.ReadLine());

        var newFactory = new Factory(_factories.Count + 1, planElectricity, inFactElectricity);
        
        _factories.Add(newFactory);
        
        Console.WriteLine("\nFactory has been successfully added!");
    }

    public static void Main()
    {
        Terminal();
    }
}