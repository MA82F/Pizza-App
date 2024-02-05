using Pizza_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_App.Services
{
    public partial class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza
            {
                Name = "Pizza 1",
                Image = "pizza1",
                Price = 5.1
            },
            new Pizza
            {
                Name = "Pizza 2",
                Image = "pizza2",
                Price = 2.5
            },
            new Pizza
            {
                Name = "Pizza 3",
                Image = "pizza3",
                Price = 1.45
            },
            new Pizza
            {
                Name = "Pizza 4",
                Image = "pizza4",
                Price = 4.45
            },
            new Pizza
            {
                Name = "Pizza 5",
                Image = "pizza5",
                Price = 12.45
            },
            new Pizza
            {
                Name = "Pizza 6",
                Image = "pizza6",
                Price = 3.45
            },
            new Pizza
            {
                Name = "Pizza 7",
                Image = "pizza7",
                Price = 2.45
            },
            new Pizza
            {
                Name = "Pizza 8",
                Image = "pizza8",
                Price = 1.5
            },
            new Pizza
            {
                Name = "Pizza 9",
                Image = "pizza9",
                Price = 1.3
            },
            new Pizza
            {
                Name = "Pizza 10",
                Image = "pizza10",
                Price = 2.9
            }
        };
        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Pizza> GetPizzas(string searchTerm) => string.IsNullOrWhiteSpace(searchTerm) ? _pizzas : _pizzas.Where(p => p.Name.Contains(searchTerm,StringComparison.OrdinalIgnoreCase));

    }
}
