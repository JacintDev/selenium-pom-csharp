# 🛒 SauceDemo - UI Test Automation

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Selenium](https://img.shields.io/badge/-selenium-%43B02A?style=for-the-badge&logo=selenium&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

## 📖 About the Project

This repository contains an automated **End-to-End (E2E)** test suite for the [SauceDemo (Swag Labs)](https://www.saucedemo.com/) e-commerce playground website. The project demonstrates the implementation of a robust test automation framework using **C#** and **Selenium WebDriver**.

The primary goal is to showcase best practices in test automation, including the **Page Object Model (POM)** design pattern, clean code principles, and efficient locator strategies.

### 🏗️ Architecture & Design Pattern

The solution is structured using the **Page Object Model (POM)** to separate the test logic from the UI elements.
- **Pages**: Maps the UI of SauceDemo (e.g., `LoginPage`, `ProductsPage`, `CartPage`).
- **Tests**: Contains the test scenarios
- **Widgets**: Containts the widgets

```csharp
public class LoginPage : BasePage
{
    private const string URL = "[https://www.saucedemo.com/](https://www.saucedemo.com/)";

    public LoginPage(IWebDriver driver) : base(driver) { }

    // Using Expression-bodied members and Custom Wait wrappers
    private IWebElement UsernameInput => WaitAndFind(By.Id("user-name"));
    private IWebElement PasswordInput => WaitAndFind(By.Id("password"));
    private IWebElement LoginButton => WaitAndFind(By.Id("login-button"));

    public LoginPage Open()
    {
        Driver.Navigate().GoToUrl(URL);
        return this; // Enables method chaining
    }

    // Encapsulated Business Logic returning the next Page Object
    public ProductsPage Login(string username, string password)
    {
        UsernameInput.SendKeys(username);
        PasswordInput.SendKeys(password);
        LoginButton.Click();

        return new ProductsPage(Driver);
    }
}

```

## 🚀Getting Started
#### 📋Prerequisites
  - .NET SDK (Version 6.0 or later)
  - Chrome Browser

🛠️ Installation

Clone the repository
```bash
   git clone (https://github.com/JacintDev/selenium-pom-csharp.git)
```

#### 🏃‍♂️ How to Run Tests

To execute the full test suite:
```bash
dotnet test
```

## 📋 Scenarios Covered
| Category | Test Case | Description |
| :--- | :--- | :--- |
| **Login** | Valid Credentials | Verifies successful login and redirection to products. |
| **Login** | Empty Fields | Checks if error message appears when fields are empty. |
| **Login** | State Persistence | Ensures dashboard is fully loaded after login. |
| **Cart** | Add Product | Verifies that a product added from inventory appears in the cart. |
| **Cart** | Item Count | Checks if the cart icon counter updates correctly. |
| **Navigation** | Sidebar Menu | Tests navigation via sidebar (Inventory, Cart, Logout) using efficient switch-expressions. |
| **Product** | Display | Verifies that product list is rendered and not empty. |
| **Product** | Specific Item | Searches for a specific product (e.g., "Sauce Labs Bike Light"). |
| **Reporting** | 📸 **Screenshot Demo** | *Intentionally failing test* to demonstrate automatic screenshot capture on failure. |


## 👤 Author

### Jácint Kovács

🌐  [Portfolio](https://jacintkovacs.hu)

💼  [LinkedIn](https://linkedin.com/in/jacint-kovacs)

---

<sub>*This project is for educational purposes using the Swag Labs demo site.*<sub>
