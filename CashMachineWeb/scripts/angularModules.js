angular.module('init', [])
.controller('ckCtrl', ['$scope', '$http', function ($scope, $http) {

    // Default value to withdraw
    $scope.amount = 120;

    $scope.withdraw = function () {
        $http.get('http://localhost:14926/api/Withdraw/' + $scope.amount + '/')
        .then(function mySucces(response) {
            let result = response.data;

            if (result !== undefined && !result.EnoughCash) {
                alert('There is no enough cash to withdraw');
            } else {
                $scope.balance = result.Balance;
                $scope.withdrawDetails = result.Withdraw;
            }
        }, function myError(response) {
            alert('Server error: ' + response.statusText);
        });
    };
}])
.directive('ckWithdraw', function () {
    return {
        templateUrl: './templates/withdraw.html',
        restrict: 'E',
        scope: {
            balance: '=balance',
            withdrawDetails: '=withdrawDetails'
        },
        controller: ['$scope', '$http', function ($scope, $http) {
            
        }]
    };
});