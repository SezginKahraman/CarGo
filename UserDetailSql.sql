
(select * from Users
full join  Customers on Customers.UserId = Users.Id
full join Rentals on Rentals.CustomerId = Customers.Id)

select * from Rentals

