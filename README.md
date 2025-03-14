# Point of Sale (POS) Billing System

## Overview
This project is a **Point of Sale (POS) Billing System** built using **ASP.NET Core  MVC** with **ADO.NET**. It allows users to enter billing information, calculate final amounts, and store data in a SQL Server database.

## Features
- Automatically selects and stores **Date & Time** for each bill.
- Retrieves **items and their prices** from a SQL Server database.
- Allows users to enter **quantity and price**, then calculates the **subtotal**.
- Displays **billing details** in a dynamic grid upon adding an item.
- Supports **discount entry** for the bill (default 0 if not entered).
- Calculates **12% VAT** and includes it in the total.
- Uses **OOP concepts** and **domain-driven design (DDD)** principles.

## Technologies Used
- **.NET 8 (ASP.NET Core MVC)**
- **C#**
- **SQL Server**
- **Dapper**
- **ADO.NET** for data access
- **Bootstrap & jQuery** for UI enhancements

## Installation & Setup
### 1. Clone the Repository
```sh
git clone <repository-url>
cd pos-billing-system
```

### 2. Database Setup
- Create a SQL Server database named `POS_Billing`.
- Run the following SQL script to create tables:

```sql
CREATE TABLE Bills (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Date DATETIME DEFAULT GETDATE(),
    Discount DECIMAL(10,2),
    VAT DECIMAL(10,2),
    TotalAmount DECIMAL(10,2)
);

CREATE TABLE Items (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255),
    Price DECIMAL(10,2),
    AvailableQuantity INT
);

CREATE TABLE BillItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BillId INT FOREIGN KEY REFERENCES Bills(Id),
    ItemId INT FOREIGN KEY REFERENCES Items(Id),
    Quantity INT,
    Price DECIMAL(10,2),
    Amount DECIMAL(10,2)
);
```

- Insert sample items:
```sql
INSERT INTO Items (Name, Price) VALUES
('NSP Exercise Book 80 Pgs', 120.00),
('NSP Exercise Book 120 Pgs', 150.00),
('NSP Exercise Book 160 Pgs', 180.00),
('NSP Exercise Book 200 Pgs', 220.00);
```

### 3. Configure Database Connection
- Update the **`appsettings.json`** file with your SQL Server details:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=POS_Billing;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

### 4. Run the Application
- Open the project in **Visual Studio 2022**.
- Restore dependencies:
```sh
dotnet restore
```
- Run the application:
```sh
dotnet run
```
- Open your browser and go to `https://localhost:7093/`.

## Usage
1. Select an item from the dropdown.
2. Enter the quantity.
3. Click **"Add to Bill"**.
4. View the items added to the bill.
5. Enter a discount if applicable.
6. Click **"Amount Paid & Add New Bill"** to finalize the bill.

## Future Enhancements
- Implement user authentication for cashiers.
- Add payment methods (Cash, Card, Digital Wallets).
- Generate PDF invoices.
- Improve UI/UX with advanced styling.

## License
This project is open-source and available under the **MIT License**.

