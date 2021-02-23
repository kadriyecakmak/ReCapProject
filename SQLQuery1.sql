CREATE TABLE Users(
UserId int primary key identity(1,1),
FirstName nvarchar (50)not null,
LastName nvarchar(50)not null,
Email nvarchar(50)not null,
Password nvarchar(50)not null

)
CREATE TABLE Customer(
UserId int primary key identity(1,1),
CustomerId int not null,
CampanyName nvarchar(50)not null

)
CREATE TABLE Rentals(
RentalId int primary key identity(1,1)not null,
CarId int not null,
CustomerId int not null,
RentDate datetime not null,
ReturnDate datetime 

)
