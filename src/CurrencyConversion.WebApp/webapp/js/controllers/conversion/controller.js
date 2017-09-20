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

                $http({
                    method: 'GET',
                    url: 'api/currency'
                }).then(function(response) {
                    self.currencies = response.data;
                });

                // todo separate
                self.converted = null;

                self.swapCurrencies = function() {
                    var selectedCurrencyTo = self.selectedCurrencyTo;
                    self.selectedCurrencyTo = self.selectedCurrencyFrom;
                    self.selectedCurrencyFrom = selectedCurrencyTo;
                };

                self.convert = function() {
                    $http({
                        method: 'GET',
                        url: 'api/currency/' +
                            self.selectedCurrencyFrom.id +
                            '/to/' +
                            self.selectedCurrencyTo.id +
                            '/of/' +
                            self.moneyAmount
                    }).then(function (response) {
                        self.converted = response.data;
                    });
                };
            }
        ]);
})();
