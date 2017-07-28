(function() {
        "use strict";

    var TeamControllers = angular.module('TeamControllers', []);

    //Team

    TeamControllers.controller('ListController',
        [
            '$scope', '$http',
            function ($scope, $http)
            {
                $http.get("/api/Teams")
                        .then(function(data) {
                            $scope.Teamss = data.data;
                    }),
                    function(error) {
                        $scope.error = "Wystąpił bład podczas dodawania Team!" + error;
                    };
                $http.get("/api/Leagues").then(function (data) {
                    $scope.Id = data.data;
                });
            }
        ]);
        
    // ten controller odpowiada za pokazanie odpowiedniej druzyny oraz ma opcje usuwania
    TeamControllers.controller('DeleteController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function ($scope, $http, $routeParams, $location)
            {
                $scope.Id = $routeParams.id;
                $http.get("/api/Teams/" + $routeParams.id).then(function(data) {
                    $scope.TeamName = data.data.TeamName;
                    $scope.Town = data.data.Town;
                    $scope.LeagueId = data.data.LeagueId;

                });
                $scope.delete = function() {

                    $http.delete("/api/Teams/" + $scope.Id).then(function() {
                            $location.path("/list");
                        },
                        function(data) {
                            $scope.error = "Wystąpił bład podczas usuwania Team!" + data;
                        });
                };
                
            }
        ]);
            // ten controller odpowiada za pokazanie odpowiedniej druzynyu w Edit.cshtml 
            //i ma opcje dodawania oraz edytowania i zapisania druzyny w db
    TeamControllers.controller('EditController',
                [
                    '$scope', '$http', '$routeParams', '$location',
                    function ($scope, $http, $routeParams, $location) {
                     $http.get("/api/Leagues").then(function(data) {
                            $scope.Id = data.data;
                        });
                        
                        $scope.save = function () {
                            
                            var obj = {
                                TeamName: $scope.TeamName,
                                Town: $scope.Town,
                                LeagueId: $scope.LeagueId
                            };
                            if ($scope.Id === 0) {
                                $http.post("/api/Teams/", obj).then(function() {
                                    $location.path("/list");
                                }),
                                function(data) {
                                    $scope.error = "Błąd podczas dodawania drużyny!" + data.ExceptionInformation;
                                };
                            } else {
                                $http.post("/api/Teams/", obj).then(function() {
                                    $location.path("/list");
                                }), function(data) {
                                    console.log(data);
                                    $scope.error = "Bląd podczas zapisywania druzyny! " + data.ExceptionInformation;
                                };
                            }
                        };
                        if ($routeParams.id) {
                            $scope.Id = $routeParams.id;
                            $scope.title = "Edit Team";
                            $http.get("/api/Teams/" + $routeParams.id).then(function (data)
                            {
                                $scope.TeamName = data.data.TeamName;
                                $scope.Town = data.data.Town;
                                $scope.LeagueId = data.data.LeagueId;
                                
                            });
                        } else {
                            $scope.title = "Create New Team";
                        }
                    }
        ]);

    //Game

    TeamControllers.controller('GameListController',
        [
            '$scope', '$http',
            function ($scope, $http) {
                $http.get("/api/Games")
                        .then(function (data) {
                            $scope.Games = data.data;
                        }),
                    function (error) {
                        $scope.error = "Wystąpił bład podczas dodawania Game!" + error;
                    };
            }
        ]);


    TeamControllers.controller('GameDeleteController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function ($scope, $http, $routeParams, $location) {
                $scope.Id = $routeParams.id;
                $http.get("/api/Games/" + $routeParams.id).then(function (data) {
                    $scope.Host = data.data.Host;
                    $scope.Visior = data.data.Visitor;
                    $scope.Town = data.data.Town;
                    $scope.DateTime = data.data.DateTime;
                    $scope.LeagueId = data.data.LeagueId;

                });
                $scope.deleteGame = function () {

                    $http.delete("/api/Games/" + $scope.Id).then(function () {
                            $location.path("/gamelist");
                        },
                        function (data) {
                            $scope.error = "Wystąpił bład podczas usuwania Team!" + data;
                        });
                };

            }
        ]);

    TeamControllers.controller('GameEditController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function($scope, $http, $routeParams, $location) {
                $http.get("/api/Leagues").then(function(data) {
                    $scope.Id = data.data;

                    $http.get("/api/Teams").then(function(data) {
                        $scope.TeamId = data.data;
                    });

                    $scope.id = 0;
                    $scope.getVisitors = function() {
                        var host = $scope.Host;
                        if (host) {
                            $http.get('/api/Teams/' + host).then(function(data) {
                                $scope.visitors = data.data;
                            });
                        } else {
                            $scope.visitors = null;
                        }
                    }; 

                    $scope.saveGame = function() {

                        var obj = {
                            Host: $scope.Host,
                            Visitor: $scope.Visitor,
                            Town: $scope.Town,
                            LeagueId: $scope.LeagueId
                        };
                        if ($scope.Id === 0) {
                            $http.post("/api/Games/", obj).then(function() {
                                    $location.path("/gamelist");
                                }),
                                function(data) {
                                    $scope.error = "Błąd podczas dodawania Meczu!" + data.ExceptionInformation;
                                };
                        } else {
                            $http.post("/api/Games/", obj).then(function() {
                                $location.path("/gamelist");
                            }), function(data) {
                                console.log(data);
                                $scope.error = "Bląd podczas zapisywania Meczu! " + data.ExceptionInformation;
                            };
                        }
                    };
                    if ($routeParams.id) {
                        $scope.Id = $routeParams.id;
                        $scope.title = "Edit Game";
                        $http.get("/api/Games/" + $routeParams.id).then(function(data) {
                            $scope.Host = data.data.Host;
                            $scope.Visitor = data.data.Visitor;
                            $scope.Town = data.data.Town;
                            $scope.LeagueId = data.data.LeagueId;
                            $scope.getVisitors();

                        });
                    } else {
                        $scope.title = "Create New Game";
                    }
                });
            }
        ]);

    //Player

    TeamControllers.controller('PlayerListController',
        [
            '$scope', '$http',
            function ($scope, $http) {
                $http.get("/api/Players")
                        .then(function (data) {
                            $scope.Players = data.data;
                        }),
                    function (error) {
                        $scope.error = "Wystąpił bład podczas ToList Zawodników!" + error;
                    };
            }
        ]);

  
    TeamControllers.controller('PlayerDeleteController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function ($scope, $http, $routeParams, $location) {
                $scope.Id = $routeParams.id;
                $http.get("/api/Players/" + $routeParams.id).then(function (data) {
                    $scope.FirstName = data.data.FirstName;
                    $scope.LastName = data.data.LastName;
                    $scope.Age = data.data.Age;
                    $scope.TeamId = data.data.TeamId;

                });
                $scope.deletePlayer = function () {

                    $http.delete("/api/Players/" + $scope.Id).then(function () {
                            $location.path("/playerlist");
                        },
                        function (data) {
                            $scope.error = "Wystąpił bład podczas usuwania Zawodnika!" + data;
                        });
                };

            }
        ]);
    
    TeamControllers.controller('PlayerEditController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function ($scope, $http, $routeParams, $location) {
                $http.get("/api/Teams").then(function (data) {
                    $scope.Id = data.data;
                });

                $scope.savePlayer = function () {

                    var obj = {
                        FirstName: $scope.FirstName,
                        LastName: $scope.LastName,
                        Age: $scope.Age,
                        TeamId: $scope.TeamId
                    };
                    if ($scope.Id === 0) {
                        $http.post("/api/Players/", obj).then(function () {
                                $location.path("/playerlist");
                            }),
                            function (data) {
                                $scope.error = "Błąd podczas dodawania zawodnika!" + data.ExceptionInformation;
                            };
                    } else {
                        $http.post("/api/Players/", obj).then(function () {
                            $location.path("/playerlist");
                        }), function (data) {
                            console.log(data);
                            $scope.error = "Bląd podczas zapisywania Zawodnika! " + data.ExceptionInformation;
                        };
                    }
                };
                if ($routeParams.id) {
                    $scope.Id = $routeParams.id;
                    $scope.title = "Edit Player";
                    $http.get("/api/Players/" + $routeParams.id).then(function (data) {
                        $scope.FirstName = data.data.FirstName;
                        $scope.LastName = data.data.LastName;
                        $scope.Age = data.data.Age;
                        $scope.TeamId = data.data.TeamId;

                    });
                } else {
                    $scope.title = "Create New Player";
                }
            }
        ]);

    })();
