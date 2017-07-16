# About

Fluent Validator is a fluent way to use Notification Pattern with your entities

# Install FluentValidator via nuget
```
Install-Package FluentValidator
```

# Usage

On constructor of your entities you can do this:

```csharp
public class Customer
{
    public string Name { get; private set; }
  
    public Customer(string name)
    {
        Name = name;
  
        new ValidationContract<Customer>(this)
          .IsRequired(x => x.Name)
          .HasMinLenght(x => x.Name, 5);
    }
}
```

Verifying if the entity is in valid state:

```csharp
var customer = new Customer("");
if(customer.IsValid())
{
    //some code
}
```

Getting Validation Notifications:

```csharp
if(!customer.IsValid())
{
    foreach(var notification in customer.Notifications)
    {
        Console.WriteLine($"{notification.Property}: {notification.Message}");
    }
}
```

# Some supported validations

Validating Email's:

```csharp
new ValidationContract<Customer>(this)
    .IsEmail(x => x.Email);
```

Validating URL's:

```csharp
new ValidationContract<Customer>(this)
    .IsUrl(x => x.Website);
```

Validating if a string field has a maximum number of characters:

```csharp
new ValidationContract<Customer>(this)
    .HasMaxLength(x => x.Name, 60);
```

Validating if a integer, decimal, double or datetime value is greater than a value:

```csharp
new ValidationContract<Customer>(this)
    .IsGreaterThan(x => x.Age, 18);
```

Validating if a integer, decimal, double or datetime value is lower than a value:

```csharp
new ValidationContract<Customer>(this)
    .IsLowerThan(x => x.Age, 60);
```

Validating if a integer, decimal, double or datetime value is between two values:

```csharp
new ValidationContract<Customer>(this)
    .IsBetween(x => x.Age, 18, 60);
```

