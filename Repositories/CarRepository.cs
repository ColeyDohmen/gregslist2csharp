using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist2.Models.cs;

namespace gregslist2.Repositories
{
    public class CarRepository
    {
        public readonly IDbConnection _db;

        public CarRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);
        }

        internal Car Get(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, year, color)
            VALUES
            (@Make, @Model, @Year, @Color);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}