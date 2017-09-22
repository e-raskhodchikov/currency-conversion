INSERT INTO Currency (AlphabeticCode, Name)
VALUES
	('EUR', 'Euro'),
	('USD', 'US Dollar');

INSERT INTO Country (Name)
VALUES
	('UNITED STATES OF AMERICA'),
	('PANAMA'),
	('ITALY'),
	('FRANCE');

INSERT INTO CountryCurrency (CountryId, CurrencyId, ActiveFrom, ActiveTo)
VALUES
	(1, 2, '2000-01-01', null),
	(2, 2, '2000-01-01', null),
	(3, 1, '2000-01-01', null),
	(4, 1, '2000-01-01', null);

INSERT INTO ExchangeRate (CurrencyFromId, CurrencyToId, ExchangeRate, Date)
VALUES
	(1, 2, 1.2, '2017-09-23'),
	(2, 1, 0.9, '2017-09-23');
