(function () {
    'use strict';
    var TeamApp = angular.module('TeamControllers', []);
    TeamApp.controller('associateController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registerData = {
            userName: authService.externalAuthData.userName,
            provider: authService.externalAuthData.provider,
            externalAccessToken: authService.externalAuthData.externalAccessToken
        };
        var startTimer;
        $scope.registerExternal = function () {

            authService.registerExternal($scope.registerData).then(function (response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "User has been registered successfully, you will be redicted to orders page in 2 seconds.";
                    startTimer();

                },
                function (response) {
                    var errors = [];
                    for (var key in response.modelState) {
                        errors.push(response.modelState[key]);
                    }
                    $scope.message = "Failed to register user due to:" + errors.join(' ');
                });
        };
        startTimer = function() {
            var timer = $timeout(function() {
                    $timeout.cancel(timer);
                    $location.path('/list');
                },
                2000);
        };
    }]);
    
})();
