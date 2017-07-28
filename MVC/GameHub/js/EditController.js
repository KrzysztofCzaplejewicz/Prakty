(function() {
        'use strict';

        angular
            .module('TeamApp', [])
            .controller('EditController', EditController);

        EditController.$inject = ['$scope', '$http', '$routeParams', '$location', '$filter'];

        function EditController($scope, $http, $routeParams, $location, $filter) {
            $http.get("/api/Leagues").then(function(data) {
                $scope.LeagueId = data;
            });
            $scope.Id = 0;
            $scope.getLeagues = function() {
                var league = $scope.LeagueId;
                if (league) {
                    $http.get("/api/Leagues" + league).success(function(data) {
                        $scope.leagues = data.data;
                    });
                } else {
                    $scope.leagues = null;
                }
            };
            $scope.save = function() {
                var obj = {
                    TeamName: $scope.TeamName,
                    Town: $scope.Town,
                    League: $scope.LeagueId
                };
                if ($scope.id === 0) {
                    $http.post("/api/Teams", obj).then(function() {
                        $location.path("/list");
                    }).error(function(data) {
                        $scope.error = "Błąd podczas dodawania drużyny!" + data.ExceptionInformation;
                    });
                } else {
                    $http.put("/api/Teams/", obj).then(function() {
                        $location.path("/list");
                    }).error(function(data) {
                        console.log(data);
                        $scope.error = "Bląd podczas zapisywania druzyny! " + data.ExceptionMessage;
                    });
                }
            };
            if ($routeParams.id) {
                $scope.id = $routeParams.id;
                $scope.title = "Edit Team";
                $http.get("/api/Teams" + $routeParams.id).then(function(data) {
                    $scope.TeamName = data.TeamName;
                    $scope.Town = data.Town;
                    $scope.LeagueId = data.LeagueId;
                    $scope.getLeagues();
                });
            } else
                $scope.title = "Create New Team";
        }
    }
)
();
