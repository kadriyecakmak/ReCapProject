create table Rentals
(
   RentalId int identity(1,1) not null,
   Id int not null,
   CustomerId int not null,
   RentDate datetime not null,
   ReturnDate datetime,
   CONSTRAINT PK_Rentals PRIMARY KEY (RentalId),
   foreign key(Id) references Cars(Id),
   
)