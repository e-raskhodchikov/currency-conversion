(function() {
    'use strict';

    angular.module('CurrencyConversion')
        .controller('ConversionController', [
            '$http', function($http) {
                var self = this;

                self.moneyAmount = 100;

                self.currencies = [];

                self.selectedCurrencyFrom = null;
                self.selectedCurrencyTo = null;

                self.converted = null;
                self.error = null;

                self.swapCurrencies = function() {
                    var selectedCurrencyTo = self.selectedCurrencyTo;
                    self.selectedCurrencyTo = self.selectedCurrencyFrom;
                    self.selectedCurrencyFrom = selectedCurrencyTo;
                };

                self.convert = function () {
                    self.converted = {
                        moneyAmount: self.moneyAmount,
                        currencyFrom: self.selectedCurrencyFrom,
                        currencyTo: self.selectedCurrencyTo
                    };

                    $http({
                        method: 'GET',
                        url: 'api/currency/' +
                            self.selectedCurrencyFrom.id +
                            '/to/' +
                            self.selectedCurrencyTo.id +
                            '/amount/' +
                            self.moneyAmount
                    }).then(function (response) {
                        self.error = null;

                        self.converted.exchangeRate = response.data.exchangeRate;
                        self.converted.date = response.data.date;
                    }, function() {
                        self.error = {
                            message: 'An error occurred. Please try again.'
                        };
                    });
                };

                self.initCurrencies = function() {
                    $http({
                        method: 'GET',
                        url: 'api/currency'
                    }).then(function(response) {
                        self.currencies = response.data;
                    });
                };

                self.initCurrencies();
            }
        ]);
})();
