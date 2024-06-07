using System;
using System.Collections.Generic;
using Vehicles;

namespace VehicleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractVehicle> vehicles = new List<AbstractVehicle>();

            var car = new Car(4, EngineType.Petrol, 150);
            var motorcycle = new Motorcycle(80);
            var motorboat = new Motorboat(5000, 200);
            var airplane = new Airplane(EngineType.Petrol, 1000, 3); // Adding wheel count for airplane
            var amphibiousVehicle = new AmphibiousVehicle(4, 3000, EngineType.Diesel, 250);
            var bicycle = new Bicycle();

            vehicles.Add(car);
            vehicles.Add(motorcycle);
            vehicles.Add(motorboat);
            vehicles.Add(airplane);
            vehicles.Add(amphibiousVehicle);
            vehicles.Add(bicycle);
            bicycle.SetSpeed(30);
            car.SetSpeed(130);
            motorcycle.SetSpeed(220);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }

            
            airplane.SetSpeed(150); 
            airplane.TakeOff();
            Console.WriteLine("Airplane after takeoff:");
            Console.WriteLine(airplane.ToString());

            airplane.SetSpeed(20); 
            airplane.Land();
            Console.WriteLine("Airplane after landing:");
            Console.WriteLine(airplane.ToString());
            Console.WriteLine("\n All Land vehicles:");
            foreach (var vehicle in vehicles)
            {
                if(vehicle is ILand landvehicle)
                {
                    Console.WriteLine(landvehicle.ToString());
                }
            }

            var sortedVehicles = vehicles.OrderBy(vehicle =>
               -AbstractVehicle.ConvertSpeed(vehicle.Speed, vehicle.SpeedUnits, SpeedUnits.Ms)).ToList();
            Console.WriteLine("\n All vehicles sorted by speed: ");
            foreach (var vehicle in sortedVehicles)
            {
                    Console.WriteLine(vehicle.ToString());
            }
            var landVehicles = vehicles
    .Where(vehicle => vehicle is ILand && vehicle.Speed > 0) 
    .OrderByDescending(vehicle =>
        AbstractVehicle.ConvertSpeed(vehicle.Speed, vehicle.SpeedUnits, SpeedUnits.Ms))
    .ToList();

            Console.WriteLine("Land vehicles sorted by speed, from fastest to slowest:");
            foreach (var vehicle in landVehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
