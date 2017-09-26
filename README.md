# FluentValidator
Fluent Validator is a fluent way to use Notification Pattern with your entities

## Dependencies
.NET Standar 1.6+

## Instalation
This package is available through Nuget Packages: https://www.nuget.org/packages/FluentValidator
```
Install-Package FluentValidator
```

## Older Versions
We are moving to a new structure, with new namespaces, if you need to use our old version, try this:
```
Install-Package FluentValidator -Version 1.0.5
```
1.0.5 was the latest stable version

# Using Notifications
To use notifications, simply inherit from Notifiable class:

```
using System;
using System.Collections.Generic;
using FluentValidator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.AddItem(null);

            if (!order.IsValid)
                Console.WriteLine("Your order is invalid");

            foreach (var item in order.Notifications)
            {
                Console.WriteLine(item.Message);
            }

            Console.ReadKey();
        }
    }

    public class Order : Notifiable
    {
        public IList<OrderItem> OrderItems { get; set; }

        public void AddItem(OrderItem item)
        {
            if (item == null)
                AddNotification("OrderItem", "Invalid item");
        }
    }

    public class OrderItem
    {
        public OrderItem(string product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public string Product { get; private set; }
        public int Quantity { get; private set; }
    }
}
```

# Using Validation Contracts

# Putting all Together

# Globalization

# Fail Fast Validations

# Complex Cenarios (DDD, CQRS)
