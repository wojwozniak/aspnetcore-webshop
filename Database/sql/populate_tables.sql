-- Populate Categories with mock data
INSERT INTO Categories (Category_Name, Parent_Category_ID)
VALUES 
('Laptops', NULL),
('Desktops', NULL),
('Components', NULL),
('Peripherals', NULL),
('Accessories', NULL);

-- Populate Products with mock data
INSERT INTO Products (Name, Description, Category_ID, Price, Stock_Quantity, Image_URL)
VALUES 
('Gaming Laptop XYZ', 'High-performance gaming laptop with 16GB RAM and RTX 3060.', 1, 1500.00, 10, 'https://placehold.co/400'),
('Ultrabook Pro', 'Lightweight ultrabook with a powerful processor and 512GB SSD.', 1, 1200.00, 15, 'https://placehold.co/400'),
('Office Desktop ABC', 'Efficient desktop computer for office tasks.', 2, 800.00, 20, 'https://placehold.co/400'),
('Gaming Desktop DEF', 'High-performance desktop for gaming and multitasking.', 2, 2000.00, 8, 'https://placehold.co/400'),
('Processor XYZ', 'Latest-gen 12-core processor for enthusiasts.', 3, 400.00, 25, 'https://placehold.co/400'),
('Graphics Card RTX 4090', 'Ultimate GPU for extreme gaming and rendering.', 3, 2500.00, 5, 'https://placehold.co/400'),
('16GB DDR5 RAM', 'High-speed memory for modern systems.', 3, 100.00, 50, 'https://placehold.co/400'),
('Gaming Mouse Pro', 'Ergonomic mouse with customizable RGB lighting.', 4, 50.00, 30, 'https://placehold.co/400'),
('Mechanical Keyboard', 'Durable keyboard with tactile switches.', 4, 120.00, 25, 'https://placehold.co/400'),
('4K Monitor', '27-inch monitor with stunning 4K resolution.', 4, 350.00, 15, 'https://placehold.co/400'),
('External SSD 1TB', 'Portable and fast external storage.', 5, 150.00, 40, 'https://placehold.co/400'),
('USB-C Hub', '7-in-1 USB-C hub for multiple devices.', 5, 60.00, 35, 'https://placehold.co/400'),
('Gaming Chair', 'Ergonomic chair designed for long gaming sessions.', 5, 300.00, 10, 'https://placehold.co/400'),
('Wireless Earbuds', 'Compact earbuds with superior sound quality.', 5, 80.00, 50, 'https://placehold.co/400'),
('Laptop Stand', 'Adjustable laptop stand for better ergonomics.', 5, 40.00, 45, 'https://placehold.co/400'),
('Liquid CPU Cooler', 'Efficient cooling solution for overclocked CPUs.', 3, 130.00, 20, 'https://placehold.co/400'),
('Case Fans Pack', '3-pack of 120mm high-airflow case fans.', 3, 30.00, 60, 'https://placehold.co/400'),
('Power Supply 750W', 'Reliable power supply unit for gaming PCs.', 3, 100.00, 30, 'https://placehold.co/400'),
('Webcam HD', '1080p HD webcam for video conferencing.', 4, 70.00, 30, 'https://placehold.co/400'),
('Wireless Router', 'High-speed router with dual-band support.', 5, 90.00, 25, 'https://placehold.co/400'),
('Smartwatch', 'Stylish smartwatch with fitness tracking features.', 5, 200.00, 15, 'https://placehold.co/400'),
('Gaming Headset', 'Surround sound headset with a noise-canceling mic.', 4, 150.00, 20, 'https://placehold.co/400'),
('USB Flash Drive 64GB', 'Compact storage device for everyday use.', 5, 15.00, 100, 'https://placehold.co/400'),
('Docking Station', 'All-in-one docking station for laptops.', 5, 250.00, 10, 'https://placehold.co/400'),
('RGB Light Strip', 'Customizable RGB light strip for PC builds.', 5, 20.00, 50, 'https://placehold.co/400'),
('Anti-Virus Software', '1-year license for comprehensive security.', 5, 50.00, 200, 'https://placehold.co/400'),
('Wireless Keyboard and Mouse Combo', 'Convenient combo for wireless productivity.', 4, 70.00, 40, 'https://placehold.co/400'),
('Ethernet Cable 10m', 'High-quality Ethernet cable for reliable connections.', 5, 15.00, 70, 'https://placehold.co/400'),
('Thermal Paste', 'Premium thermal compound for CPU cooling.', 5, 10.00, 300, 'https://placehold.co/400');
