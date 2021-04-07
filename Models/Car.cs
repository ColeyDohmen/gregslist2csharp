using System;

namespace gregslist2.Models.cs
{
    public class Car
    {
        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Id { get; private set; } = Guid.NewGuid().ToString();
    }
}