using ContossoPizzaApp.Models;

namespace ContossoPizzaApp.Services
{
    public class PizzaService
    {
        private static readonly List<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Classic pizza with tomato, cheese, and basil", Price = 8.99m, Size = "Medium" },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni pizza with mozzarella", Price = 9.99m, Size = "Large" },
            new Pizza { Id = 3, Name = "Vegetarian", Description = "A mix of vegetables on a pizza", Price = 7.99m, Size = "Small" },
            new Pizza { Id = 4, Name = "Hawaiian", Description = "Pizza with ham, pineapple, and cheese", Price = 10.99m, Size = "Medium" },
            new Pizza { Id = 5, Name = "BBQ Chicken", Description = "BBQ sauce, grilled chicken, and red onions", Price = 11.99m, Size = "Large" },
            new Pizza { Id = 6, Name = "Meat Lovers", Description = "Pepperoni, sausage, bacon, and ham", Price = 12.99m, Size = "Large" },
            new Pizza { Id = 7, Name = "Four Cheese", Description = "Mozzarella, cheddar, parmesan, and blue cheese", Price = 9.49m, Size = "Medium" },
            new Pizza { Id = 8, Name = "Seafood", Description = "A variety of seafood with a creamy sauce", Price = 13.49m, Size = "Large" },
            new Pizza { Id = 9, Name = "Buffalo Chicken", Description = "Spicy buffalo sauce with chicken and mozzarella", Price = 10.49m, Size = "Medium" },
            new Pizza { Id = 10, Name = "Mushroom", Description = "A classic pizza topped with fresh mushrooms", Price = 8.49m, Size = "Small" },
            new Pizza { Id = 11, Name = "Pesto Chicken", Description = "Grilled chicken with pesto sauce and mozzarella", Price = 11.49m, Size = "Medium" },

        };

        // Method to retrieve all pizzas
        public Task<List<Pizza>> GetPizzasAsync()
        {
            return Task.FromResult(_pizzas);
        }

        // Method to retrieve a pizza by ID
        public Task<Pizza> GetPizzaByIdAsync(int id)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pizza);
        }

        // Method to add a new pizza
        public Task<Pizza> AddPizzaAsync(Pizza pizza)
        {
            pizza.Id = _pizzas.Max(p => p.Id) + 1; // Auto-increment the ID
            _pizzas.Add(pizza);
            return Task.FromResult(pizza);
        }

        // Method to update an existing pizza
        public Task<Pizza> UpdatePizzaAsync(int id, Pizza updatedPizza)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                pizza.Name = updatedPizza.Name;
                pizza.Description = updatedPizza.Description;
                pizza.Price = updatedPizza.Price;
                pizza.Size = updatedPizza.Size;
            }
            return Task.FromResult(pizza);
        }

        // Method to delete a pizza by ID
        public Task<bool> DeletePizzaAsync(int id)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                _pizzas.Remove(pizza);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }


}

