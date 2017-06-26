create table CarAdverts (
    Id integer primary key autoincrement,
	Title text not null,
	Fuel int not null,
	Price decimal not null,
	IsNew bit not null,
	Mileage int null,
	FirstRegistration datetime null
)