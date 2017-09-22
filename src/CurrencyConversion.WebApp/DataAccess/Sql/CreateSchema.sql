create table if not exists Country (
	Id				integer primary key autoincrement not null,
	Name			varchar(100) not null
);

create table if not exists Currency (
	Id				integer primary key autoincrement not null,
	AlphabeticCode	varchar(3) not null,
	Name			varchar(100) not null
);

create table if not exists CountryCurrency (
	Id				integer primary key autoincrement not null,
	CountryId		integer not null,
	CurrencyId		integer not null,
	ActiveFrom		date not null,
	ActiveTo		date,

	foreign key(CountryId) references Country(Id),
	foreign key(CurrencyId) references Currency(Id)
);

create table if not exists ExchangeRate (
	Id				integer primary key autoincrement not null,
    CurrencyFromId	integer not null,
	CurrencyToId	integer not null,
	ExchangeRate	real not null,
	Date			date not null,

	foreign key(CurrencyFromId) references Currency(Id),
	foreign key(CurrencyToId) references Currency(Id)
);
