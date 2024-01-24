using Microsoft.Extensions.DependencyInjection;
using CodeTest.Vehicles;

 var serviceProvider = new ServiceCollection()
            .AddTransient<Car>()        
            .AddTransient<Motorbike>()
            .AddTransient<TollCalculator>()
            .BuildServiceProvider();

        var _ = serviceProvider.GetRequiredService<TollCalculator>();

        var car = serviceProvider.GetRequiredService<Car>();
        var motorbike = serviceProvider.GetRequiredService<Motorbike>();

        DateTime[] dates = new DateTime[]
        {
            new(2024, 1, 24, 6, 15, 0),
            new(2024, 1, 24, 8, 45, 0),
            new(2024, 1, 24, 15, 30, 0)
        };

        int carTotalTollFee = TollCalculator.GetTollFee(car, dates);
        int motorbikeTotalTollFee = TollCalculator.GetTollFee(motorbike, dates);

        Console.WriteLine($"Type of vehicle: {car.GetVehicleType()}, Total Toll Fee: {carTotalTollFee} SEK");
        Console.WriteLine($"Type of vehicle: {motorbike.GetVehicleType()}, Total Toll Fee: {motorbikeTotalTollFee} SEK");
