# WDapper
A minimal wrapper for Dapper that exposes query and command execution via interfaces, enabling proper unit testing without hitting a real database. Designed to support dependency injection, mocking, and separation of concerns in .NET data access layers.

**WDapper** is a simple, test-friendly wrapper for [Dapper](https://github.com/DapperLib/Dapper) that provides abstraction over direct SQL access through interfaces, enabling full unit testability in .NET applications.

---

## 🔧 Features

- Interface-based abstraction over Dapper methods
- Enables unit testing without a real database
- Supports both query and command execution
- Easy to mock using Moq or any mocking framework
- Designed for clean architecture and DI integration

---

## 📦 Installation

You can clone this repository or include the `GhitorNET.BMAP.WDapperForTesting` project into your solution.

---

## 🚀 Quick Start

### 1. Define the interface

```csharp
public class UserService
{
    private readonly IDapperConnection _dapper;

    public UserService(IDapperConnection dapper)
    {
        _dapper = dapper;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _dapper.Query<User>("SELECT * FROM Users");
    }
}

var mock = new Mock<IDapperConnection>();
mock.Setup(d => d.Query<User>(It.IsAny<string>(), null))
    .Returns(new List<User> { new User { Id = 1, Name = "Test" } });

var service = new UserService(mock.Object);
