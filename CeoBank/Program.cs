public class Bank
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal Profit { get; set; }
    public List<Worker> Workers { get; set; }
    public List<Manager> Managers { get; set; }
    public List<Client> Clients { get; set; }

    public Bank(string name)
    {
        Name = name;
        Workers = new List<Worker>();
        Managers = new List<Manager>();
        Clients = new List<Client>();
    }

    public void CalculateProfit()
    {
        Profit = Budget * 0.1m;  
        Console.WriteLine($"Profit calculated: {Profit}");
    }

    public void ShowClientCredit(string fullName)
    {
        Console.WriteLine($"Showing credit for {fullName}");
    }


    public void PayCredit(Client client, decimal money)
    {
        Console.WriteLine($"Paying {money} to {client.Name} {client.Surname}");
    }

    public void ShowAllCredit()
    {
        Console.WriteLine("Showing all credits");
    }
}

public class Worker
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Worker(string name, string surname, string position, decimal salary)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Position = position;
        Salary = salary;
    }
    public void Organize()
    {
        Console.WriteLine($"{Name} is organizing tasks");
    }
    public void MakeMeeting()
    {
        Console.WriteLine($"{Name} made Meeting");
    }
    public void DecreasePercentage(decimal percent)
    {
        Salary -= Salary * (percent / 100);
        Console.WriteLine($"Salary decreased by {percent}%,  New salary: {Salary}");
    }
}

public class Manager
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public Manager(string name, string surname, string position, decimal salary)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Position = position;
        Salary = salary;
    }
    public void Organize()
    {
        Console.WriteLine($"{Name} is organizing tasks");
    }

    public void MakeMeeting()
    {
        Console.WriteLine($"{Name} made Meeting");
    }

    public void CalculateSalaries(List<Worker> workers)
    {
        foreach (var worker in workers)
        {
            Console.WriteLine($"Calculating salary for {worker.Name},  Current salary: {worker.Salary}");
        }
    }
}

public class Operation
{
    public Guid Id { get; set; }
    public string ProcessName { get; set; }
    public DateTime DateTime { get; set; }

    public Operation(string processName)
    {
        Id = Guid.NewGuid();
        ProcessName = processName;
        DateTime = DateTime.Now;
    }

    public void AddOperation()
    {
        Console.WriteLine($"Operation {ProcessName} added at {DateTime}");
    }
}

public class Credit
{
    public Guid Id { get; set; }
    public Client Client { get; set; }
    public decimal Amount { get; set; }
    public decimal Percent { get; set; }
    public int Months { get; set; }

    public Credit(Client client, decimal amount, decimal percent, int months)
    {
        Id = Guid.NewGuid();
        Client = client;
        Amount = amount;
        Percent = percent;
        Months = months;
    }

    public void CalculatePercent()
    {
        decimal interest = Amount * Percent / 100;
        Console.WriteLine($"Interest for credit: {interest},  Total amount with interest: {Amount + interest}");
    }

    public void MakePayment(decimal payment)
    {
        Amount -= payment;
        Console.WriteLine($"Payment of {payment} made,  Remaining amount: {Amount}");
    }
}

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string LiveAddress { get; set; }
    public string WorkAddress { get; set; }
    public decimal Salary { get; set; }

    public Client(string name, string surname, decimal salary)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Salary = salary;
    }
}

public class Program
{
    public static void Main()
    {
        Bank bank = new Bank("National Bank");
        bank.Budget = 1000000;

        Worker worker1 = new Worker("John", "Doe", "Clerk", 3000);
        Worker worker2 = new Worker("Jane", "Smith", "Assistant", 3500);
        bank.Workers.Add(worker1);
        bank.Workers.Add(worker2);

        Manager manager1 = new Manager("Alice", "Johnson", "Manager", 5000);
        bank.Managers.Add(manager1);

        Client client1 = new Client("Michael", "Brown", 4000);
        bank.Clients.Add(client1);

        Credit credit1 = new Credit(client1, 20000, 5, 24);
        credit1.CalculatePercent();

        worker1.MakeMeeting();
        manager1.CalculateSalaries(bank.Workers);
        bank.PayCredit(client1, 5000);
        worker1.Organize();
        manager1.Organize();
        worker2.DecreasePercentage(1);
        Operation operation1 = new Operation("take a break");
        operation1.AddOperation();
    }
}