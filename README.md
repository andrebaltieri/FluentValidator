# Fluent Validator
Fluent Validator is a fluent way to use Notification Pattern with your entities

### Current Version
1.0.2 - Now supports multiples frameworks (4.4.2+, .NET Standards 1.6)

### How To Use
#### Inherit from Notifiable
The Notifiable class contains the notification list as it's methods to add new notifications, get notifications and check if the entity is valid.

* Notifications: Readonly colletion containing the entity's notifications
* AddNotification: Used to add a new notification to the entity.
* AddNotifications: Used to add multiple notifications to the entity.
* IsValid: Return false if entity has notifications.

Basically, you just need to inherit this class to start:
```
public class Customer : Notifiable
{
    ...
}
```

#### Create a Contract
Some time ago, Microsoft created a Design By Contract lib, called Code Contracts. That was awesome idea, but did not implemented the Notification Pattern. Istead, it threw exceptions, which have a high cost to CPU.

The contract idea is brilliant, as it make the code clean to read, avoid ifs, reducing the complexity, and allow us to reuse our validations.

The idea here is the same, let's check.
```
public class Customer : Notifiable
{
    public Customer(string name) 
    {
        Name = name;
        
        new ValidationContract<Customer>(this)
            .IsRequired(x => x.Name);
    }
    
    public string Name { get; private set; }
}
```

All you need to do is create a new ValidationContract of your class type when needed and start composing this contract.

#### Validation Methods
* IsRequired - Check if a string is required
* HasMinLenght - Check the min length of a string
* HasMaxLenght - Check the max length of a string
* IsFixedLenght - Check if the string has a fixed length
* IsEmail - Check if it is an E-mail
* IsUrl - Check if it is a URL
* IsGreaterThan - Check if int, double, decimal or date are greater than
* IsLowerThan - Check if int, double, decimal or date are lower than
* IsBetween - Check if int, double, decimal or date are between some values
* Contains - Check if a string contains some other

#### Custom Messages
When you call ".IsRequired(x => x.Name)" you're using the default messagens, which you can find on the code. If you need to pass a custom message, just set it as the last parameter as ".IsRequired(x => x.Name, "My custom message here!");"

#### Showing the Notifications
With all set, it's time to show the messages.
```
public void Main(args[])
{
    var customer = new Customer("André");
    
    if(!customer.IsValid())
    {
        foreach(var notification in customer.Notifications)
        {
            Console.WriteLine(notification.Message);
        }
    }
    Console.ReadKey();
}
```
