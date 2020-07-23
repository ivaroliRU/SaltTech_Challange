CREATE TABLE products(
   Id INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,product_url VARCHAR(199)
  ,Name VARCHAR(151) NOT NULL
  ,price INTEGER 
  ,ImageSource TEXT NOT NULL
  ,is_FK_Advantage_product VARCHAR(5)
  ,description TEXT
  ,product_rating VARCHAR(25) 
  ,overall_rating VARCHAR(25) 
  ,brand  TEXT
  ,stock INTEGER
);

CREATE TABLE orders(
  Id INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
  ProductId INTEGER NOT NULL
);

ALTER TABLE `orders` ADD FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`);