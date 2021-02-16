CREATE TABLE Cars(
Id int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice decimal,
Descriptions varchar(50)

)

CREATE TABLE Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(50)



)
CREATE TABLE Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(50)

)
INSERT INTO Cars(BrandId, ColorId, ModelYear, DailyPrice, Descriptions) VALUES
(1, 12355, 2015,650,'Hyundai i x 35'),
(2, 12355, 2015,850,'Ford ecosport'),
(3, 12355, 2015,950,'Chevrolet Blazer'),
(4, 12355, 2015,100,'Dacia Duster');

INSERT INTO Brands(BrandName) VALUES
('Hyundai'),
('Ford'),
('Chevrolet'),
('Dacia');

INSERT INTO Colors(ColorName) VALUES
('Black'),
('Pink'),
('Yellow'),
('Green');

SELECT * FROM Cars;
SELECT * FROM Brands;
SELECT * FROM Colors;
EXEC sp_rename 'Cars.Destriptions','Descriptions';

DROP TABLE Cars;




