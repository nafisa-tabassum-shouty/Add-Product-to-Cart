CREATE TABLE users (
    userid INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    Passwords VARCHAR(255) NOT NULL,
    Firstname VARCHAR(255) NOT NULL,
    Lastname VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL
);

CREATE TABLE items (
    item_id INT IDENTITY(1,1) PRIMARY KEY,
    Names VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    image_url VARCHAR(255),
    quantity INT NOT NULL
);

CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    userid INT,
    item_id INT,
    quantity INT,
    order_date DATETIME DEFAULT GETDATE()
);
