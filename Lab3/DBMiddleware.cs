using System;
using System.Threading.Tasks;
using System.Linq;
using Lab3.Data;
using Microsoft.AspNetCore.Http;

namespace Lab3
{
    public class DBMiddleware
    {
        private readonly RequestDelegate _next;
        
        public DBMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, TravelAgencyContext db)
        {
            try
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";

                await httpContext.Response.WriteAsync("<h1 style='text-align:center'>" +
                                                      "<img src='img/logo.png' alt='' style='width: 40px'/>" +
                                                      "Туристична агенція</h1>");
                
                
                var customers = db.Customers
                    .Join(db.Trips, customers => customers.ID, trips => trips.CustomerID,
                        (c, tr) => new { c.ID, c.LastName, c.FirstName, c.Surname, c.PhoneNumber, c.Address })
                    .GroupBy(table => new { table.ID, table.LastName, table.FirstName, table.Surname, table.PhoneNumber, table.Address })
                    .OrderBy(customer => customer.Key.ID)
                    .Select(customerTrips => new { customerTrips.Key, ToursCount = customerTrips.Count() })
                    .ToList();
                
                await httpContext.Response.WriteAsync(
                    "<br><h4>" +
                    "ID, Прізвище, Ім'я, По-батькові, Номер телефону, Адреса, К-сть замовлених турів" +
                    "</h4>");
                foreach (var customer in customers)
                {
                    await httpContext.Response.WriteAsync(
                        $"{customer.Key.ID}, {customer.Key.LastName}, {customer.Key.FirstName}, " +
                        $"{customer.Key.Surname}, {customer.Key.PhoneNumber}, {customer.Key.Address}, " +
                        $"{customer.ToursCount}<br>");
                }
                await httpContext.Response.WriteAsync("<br>");


                var tours = db.Tours.ToList();
                
                await httpContext.Response.WriteAsync(
                    "<br><h4>" +
                    "ID, Назва, Тривалість (днів), Ціна (грн.), Опис" +
                    "</h4>");
                await httpContext.Response.WriteAsync(string.Join("<br>", tours));
                await httpContext.Response.WriteAsync("<br>");
                
                
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
                
                await httpContext.Response.WriteAsync(
                    "<br><h4>" +
                    "ID, Клієнт, Назва туру, Дата, Тривалість (днів), Знижка (%)" +
                    "</h4>");
                foreach (var trip in trips)
                {
                    await httpContext.Response.WriteAsync(
                        $"{trip.ID}, {trip.Customer}, {trip.Tour}, {trip.Date}, {trip.Duration}, {trip.Discount}<br>");
                }
            }
            catch (Exception exception)
            {
                await httpContext.Response.WriteAsync($"Error: {exception.Message}");
            }
        }
    }
}