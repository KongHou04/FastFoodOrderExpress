--USE FFOE;
--SELECT * FROM [categories];
--SELECT * FROM [products];
--SELECT * FROM [discounts];
--DELETE FROM [categories];
--DELETE FROM [products];
--DELETE FROM [discounts];

BEGIN TRANSACTION;
GO

-- Insert data into categories table
INSERT INTO [categories] ([Id], [Name], [Description])
VALUES 
    ('303CF809-C86B-41A5-9D2E-03C93B19F0D2', 'Burgers', 'A variety of delicious burgers including beef, chicken, and vegetarian options'),
    ('1333C9DE-0D0A-43F5-953F-226F4209F192', 'Pizza', 'Assorted pizzas with different toppings and crust styles'),
    ('3FA85F64-5717-4562-B3FC-2C963F66AFA6', 'Drinks', 'Beverages including soft drinks, juices, and shakes'),
    ('5D8B0E10-C5A2-485A-82CC-3C0F6D9FF529', 'Sides', 'Side dishes such as fries, onion rings, and salads'),
    ('ADD55F27-5AB8-4458-836B-3F28F53908E4', 'Desserts', 'Sweet treats including ice cream, cakes, and pastries'),
    ('4EC426B3-972F-4BA0-A33D-4F8CDD15D0BF', 'Sandwiches', 'A selection of sandwiches including subs, wraps, and paninis'),
    ('6A3F2E0C-81B7-43DF-9344-8E84A69664FF', 'Chicken', 'Fried and grilled chicken dishes'),
    ('14FBD7F4-CB1C-4561-A98D-A9507F2CAB45', 'Breakfast', 'Breakfast items including eggs, pancakes, and coffee'),
    ('78E1BFD5-89E7-49FF-95D1-E6525531584B', 'Seafood', 'Seafood dishes such as fish fillets, shrimp, and crab cakes'),
    ('D3353EBE-83E3-4F6F-B043-EFB4457171C3', 'Vegan', 'A range of vegan-friendly meals and snacks');

COMMIT;
GO


BEGIN TRANSACTION;
GO

-- Example category IDs
DECLARE @BurgersId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Burgers');
DECLARE @PizzaId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Pizza');
DECLARE @DrinksId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Drinks');
DECLARE @SidesId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Sides');
DECLARE @DessertsId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Desserts');
DECLARE @SandwichesId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Sandwiches');
DECLARE @ChickenId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Chicken');
DECLARE @BreakfastId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Breakfast');
DECLARE @SeafoodId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Seafood');
DECLARE @VeganId uniqueidentifier = (SELECT Id FROM [categories] WHERE [Name] = 'Vegan');

-- Insert data into products table
INSERT INTO [products] ([Id], [Name], [UnitPrice], [Image], [Description], [CategoryId])
VALUES 
    ('17B42C17-D0D7-4FE3-A661-03851AEB4899', 'Classic Beef Burger', 5.99, '', 'Juicy beef patty with lettuce, tomato, and cheese', @BurgersId),
    ('FFA3C5AD-BBE1-4196-B0E9-061D30A786D1', 'Chicken Burger', 5.49, '', 'Grilled chicken burger with lettuce and mayo', @BurgersId),
    ('85329574-D3A6-4327-B4E2-2E78BBC41AD6', 'Veggie Burger', 5.29, '', 'Vegetarian burger with a blend of fresh veggies', @BurgersId),
    ('F4256849-9087-448A-9F1E-61A165709750', 'Cheeseburger', 6.49, '', 'Beef burger with melted cheese and pickles', @BurgersId),
    ('70949F54-BE46-44C0-94A5-678A3448F997', 'Bacon Burger', 6.99, '', 'Burger with crispy bacon and BBQ sauce', @BurgersId),
    ('BAAB492C-526B-4C15-8E7D-69FDB2213C71', 'Pepperoni Pizza', 8.99, '', 'Pizza topped with pepperoni and mozzarella cheese', @PizzaId),
    ('CAC25CAE-1533-47BD-91AA-7CD919BDE817', 'Margherita Pizza', 7.99, '', 'Classic pizza with fresh tomatoes, mozzarella, and basil', @PizzaId),
    ('FBB0AED3-CC6D-4ADC-B3FE-86750449C069', 'BBQ Chicken Pizza', 9.49, '', 'Pizza with BBQ chicken, onions, and cheese', @PizzaId),
    ('C21DEC2F-778A-4D0A-BEA3-869313D8A082', 'Veggie Pizza', 8.49, '', 'Pizza loaded with fresh vegetables', @PizzaId),
    ('C10FBD78-FF32-403F-BED9-8BE6209D7EA2', 'Hawaiian Pizza', 9.99, '', 'Pizza with ham and pineapple', @PizzaId),
    ('97C8B42D-978C-43E8-8E55-8C30C3DEFB57', 'Cola', 1.99, '', 'Refreshing cola drink', @DrinksId),
    ('DA58B999-4CF0-4C49-B14B-900468EDA135', 'Orange Juice', 2.49, '', 'Freshly squeezed orange juice', @DrinksId),
    ('1BF6092C-5F26-4DC1-9102-90F5C4FC2586', 'Milkshake', 3.49, '', 'Thick and creamy milkshake', @DrinksId),
    ('8F7ADF96-3A47-4029-BD19-A01317999B2E', 'Lemonade', 2.99, '', 'Fresh lemonade with a tangy twist', @DrinksId),
    ('AD5DB70A-2CA1-44CA-AB2B-A0E1EF2EC390', 'Iced Tea', 2.49, '', 'Cool and refreshing iced tea', @DrinksId),
    ('AE1BB559-2151-40CA-AB2E-AD6AFA171CC4', 'French Fries', 2.99, '', 'Crispy golden French fries', @SidesId),
    ('BB24B5DC-304F-4EDD-8C43-AD8F9E3C0E6C', 'Onion Rings', 3.49, '', 'Crispy and delicious onion rings', @SidesId),
    ('DC911956-87D7-4EB1-A012-B26F7DC24BA3', 'Mozzarella Sticks', 4.49, '', 'Breaded mozzarella sticks with marinara sauce', @SidesId),
    ('3ABBA483-513C-4387-840E-C10DC6DA96C2', 'Chicken Wings', 5.99, '', 'Spicy chicken wings', @SidesId),
    ('8628F7F6-E483-4E0B-B842-C2AE81410C6D', 'Garlic Bread', 3.99, '', 'Toasted garlic bread with herbs', @SidesId),
    ('EDF7A624-3083-4A32-8088-C569EFA994BA', 'Chocolate Cake', 3.99, '', 'Rich and moist chocolate cake slice', @DessertsId),
    ('F0842F77-FD74-4606-991A-C5975B9013C8', 'Ice Cream', 2.99, '', 'Creamy ice cream with various flavors', @DessertsId),
    ('A5FEEFB9-A7E9-413F-8706-C82AA6DB6E32', 'Apple Pie', 3.49, '', 'Classic apple pie with a flaky crust', @DessertsId),
    ('80C7F165-D7C9-4E75-8405-CD9E57A7EBD4', 'Brownie', 2.99, '', 'Chocolate brownie with nuts', @DessertsId),
    ('2B911869-D202-4FC2-B8A6-D77BB9876C8B', 'Cheesecake', 4.49, '', 'Creamy cheesecake with a graham cracker crust', @DessertsId),
    ('A36EE4C6-6770-4EE8-B5BA-D79795CABDBC', 'Ham Sandwich', 4.99, '', 'Sandwich with ham, cheese, and lettuce', @SandwichesId),
    ('EAC095A5-5ECC-498A-AE8B-DE29941B6246', 'Turkey Sandwich', 5.49, '', 'Sandwich with turkey, cranberry sauce, and lettuce', @SandwichesId),
    ('DF04378C-2BDD-4343-8D81-E9B57F97FBF7', 'Grilled Cheese', 3.99, '', 'Classic grilled cheese sandwich', @SandwichesId),
    ('CF067CFA-225A-4AAC-8261-EB0FE14C83A2', 'BLT Sandwich', 5.99, '', 'Bacon, lettuce, and tomato sandwich', @SandwichesId),
    ('FB14E769-35B2-49F9-86FB-FC81E34CC8D4', 'Egg Sandwich', 4.49, '', 'Egg sandwich with cheese and ham', @BreakfastId);

COMMIT;
GO

BEGIN TRANSACTION;
GO

-- Example product IDs
DECLARE @ProductId1 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Classic Beef Burger');
DECLARE @ProductId2 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Chicken Burger');
DECLARE @ProductId3 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Veggie Burger');
DECLARE @ProductId4 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Cheeseburger');
DECLARE @ProductId5 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Bacon Burger');
DECLARE @ProductId6 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Pepperoni Pizza');
DECLARE @ProductId7 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Margherita Pizza');
DECLARE @ProductId8 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'BBQ Chicken Pizza');
DECLARE @ProductId9 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Veggie Pizza');
DECLARE @ProductId10 uniqueidentifier = (SELECT TOP 1 Id FROM [products] WHERE [Name] = 'Hawaiian Pizza');

-- Insert data into discounts table
INSERT INTO [discounts] ([StartTime], [EndTime], [PercentValue], [HardValue], [ProductId])
VALUES 
    (GETDATE(), DATEADD(day, 30, GETDATE()), 10, 0, @ProductId1),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 15, 0, @ProductId2),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 0, 1.00, @ProductId3),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 5, 0, @ProductId4),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 20, 0, @ProductId5),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 0, 1.50, @ProductId6),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 10, 0, @ProductId7),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 25, 0, @ProductId8),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 0, 2.00, @ProductId9),
    (GETDATE(), DATEADD(day, 30, GETDATE()), 15, 0, @ProductId10);

COMMIT;
GO