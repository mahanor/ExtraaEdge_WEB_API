
create database ExtraaEdge_API;

use ExtraaEdge_API;

--drop database ExtraaEdge_API;



select * from sales;
select * from mobiles;
select * from brands;
select * from login;
select * from customers;


INSERT INTO brands(BrandName)
VALUES ('SAMSUNG');

INSERT INTO mobiles (BrandID,Model,Price)
VALUES(1,'S12',20000);

INSERT INTO sales (MobileIdNumber,SaleDate,SaleAmount,DiscountApplied,MobileID)
VALUES (1, '2023-07-22', 40000, 1000,1);

INSERT INTO brands(BrandName)
VALUES ('Nokia');

INSERT INTO mobiles (BrandID,Model,Price)
VALUES(2,'SM1200',15000);

INSERT INTO sales (MobileIdNumber,SaleDate,SaleAmount,DiscountApplied,MobileID)
VALUES (2, '2023-08-22', 50000, 500,2);


INSERT INTO customers (CustName, CustPhoneNo, CustAddress, CustEmail, CustPassword)
VALUES
    ('Kiran Mahanor', '9763266350','Pune','Kiran@gmail.com', 'Kiran@123'),
    ('Vishal Mahanor','9876543210','Mumbai','Vishal@gmail.com', 'Vishal@123' );


INSERT INTO login(StoreOwnerName,Password)
VALUES ('Kiran','Kiran@123');

