﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using Lab2.Data;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TravelAgencyContext();


            var customers = 
                from c in db.Customers
                select new
                {
                    c,
                    ToursCount = (from tr in db.Trips where tr.CustomerID == c.ID select tr).Count()
                };

            using (var file = File.CreateText("D:\\uni\\7th term\\.NET\\Lab2\\customers.csv"))
            {
                file.WriteLine("ID, Прізвище, Ім'я, По-батькові, Номер телефону, Адреса, К-сть замовлених турів");
                foreach (var customer in customers)
                {
                    file.WriteLine($"{customer.c}, {customer.ToursCount}");
                }
            }


            var tours = db.Tours;

            using (var file = File.CreateText("D:\\uni\\7th term\\.NET\\Lab2\\tours.csv"))
            {
                file.WriteLine("ID, Назва, Тривалість (днів), Ціна (грн.), Опис");
                foreach (var tour in tours)
                {
                    file.WriteLine(tour);
                }
            }


            var trips =
                from c in db.Customers
                join tr in db.Trips on c.ID equals tr.CustomerID
                join t in db.Tours on tr.TourID equals t.ID
                select new
                {
                    tr.ID,
                    Customer = $"{c.LastName} {c.FirstName} {c.Surname}",
                    Tour = t.Name,
                    Date = tr.TripDate,
                    t.Duration,
                    tr.Discount
                };

            using (var file = File.CreateText("D:\\uni\\7th term\\.NET\\Lab2\\trips.csv"))
            {
                file.WriteLine("ID, Клієнт, Назва туру, Дата, Тривалість (днів), Знижка (%)");
                foreach (var trip in trips)
                {
                    file.WriteLine($"{trip.ID}, {trip.Customer}, {trip.Tour}, {trip.Date}, {trip.Duration}, {trip.Discount}");
                }
            }

        }
    }
}