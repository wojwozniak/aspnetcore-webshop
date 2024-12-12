Use ShopDb;

-- 1. Table: Users
CREATE TABLE Users (
    User_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone_Number VARCHAR(15),
    Address TEXT,
    Role CHAR(1) DEFAULT 'C' NOT NULL -- e.g., customer or admin
);

-- 2. Table: Passwords
CREATE TABLE Passwords (
    Password_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    User_ID INT NOT NULL,
    Password_Hash VARCHAR(255) NOT NULL,
    Created_At DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE
);

-- 3. Table: Categories
CREATE TABLE Categories (
    Category_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Category_Name VARCHAR(100) NOT NULL,
    Parent_Category_ID INT NULL,
    FOREIGN KEY (Parent_Category_ID) REFERENCES Categories(Category_ID) ON DELETE NO ACTION
);

-- 4. Table: Products
CREATE TABLE Products (
    Product_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name VARCHAR(200) NOT NULL,
    Description TEXT,
    Category_ID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock_Quantity INT DEFAULT 0 NOT NULL,
    Image_URL VARCHAR(255),
    FOREIGN KEY (Category_ID) REFERENCES Categories(Category_ID) ON DELETE CASCADE
);

-- 5. Table: Orders
CREATE TABLE Orders (
    Order_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    User_ID INT NOT NULL,
    Order_Date DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
    Status VARCHAR(50) DEFAULT 'P' NOT NULL, -- e.g., Pending, Shipped, Delivered, Canceled
    Total_Amount DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE
);

-- 6. Table: Order_Items
CREATE TABLE Order_Items (
    Order_Item_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Order_ID INT NOT NULL,
    Product_ID INT NOT NULL,
    Quantity INT DEFAULT 1 NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID) ON DELETE CASCADE,
    FOREIGN KEY (Product_ID) REFERENCES Products(Product_ID) ON DELETE CASCADE
);

-- 7. Table: Cart
CREATE TABLE Cart (
    Cart_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    User_ID INT NOT NULL,
    Product_ID INT NOT NULL,
    Quantity INT DEFAULT 1 NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE,
    FOREIGN KEY (Product_ID) REFERENCES Products(Product_ID) ON DELETE CASCADE
);

-- 8. Table: Discounts
CREATE TABLE Discounts (
    Discount_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Code VARCHAR(50) UNIQUE NOT NULL,
    Description TEXT,
    Discount_Percentage DECIMAL(5,2) NOT NULL,
    Start_Date DATETIME NOT NULL,
    End_Date DATETIME NOT NULL
);

-- 9. Table: Payments
CREATE TABLE Payments (
    Payment_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Order_ID INT NOT NULL,
    Payment_Method VARCHAR(50) NOT NULL, -- e.g., Credit Card, PayPal, Bank Transfer
    Payment_Date DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
    Payment_Status VARCHAR(50) DEFAULT 'P' NOT NULL, -- e.g., Pending, Completed, Failed
    Amount DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID) ON DELETE CASCADE
);

-- Add needed columns
ALTER TABLE Passwords
ADD 
    [Salt] [nvarchar](100) NOT NULL,
	[HashRounds] [int] NOT NULL,
	[PasswordSetDate] [datetime] NOT NULL;