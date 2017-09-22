(function() {
    'use strict';

    angular.module('CurrencyConversion')
        .directive('converted', function() {
            return {
                restrict: 'E',
                templateUrl: '/webapp/html/pages/conversion/converted.html'
            };
        });

    angular.module('CurrencyConversion')
        .directive('error-alert', function() {
            return {
                restrict: 'E',
                templateUrl: '/webapp/html/pages/conversion/error-alert.html'
            };
        });
})();
