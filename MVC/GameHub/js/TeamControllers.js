(function() {
    "use strict";

    var TeamControllers = angular.module('TeamControllers', []);

    //Team

    TeamControllers.controller('ListController',
        [
            '$scope', '$http',
            function($scope, $http) {
                $http.get("/api/Teams")
                        .then(function(data) {
                            $scope.Teamss = data.data;
                        }),
                    function(error) {
                        $scope.error = "Wystąpił bład podczas dodawania Team!" + error;
                    };
                $http.get("/api/Leagues").then(function(data) {
                    $scope.Id = data.data;
                });
            }
        ]);

    // ten controller odpowiada za pokazanie odpowiedniej druzyny oraz ma opcje usuwania
    TeamControllers.controller('DeleteController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function($scope, $http, $routeParams, $location) {


                $scope.Id = $routeParams.id;
                $http.get("/api/Teams/" + $routeParams.id).then(function(data) {
                    $scope.TeamName = data.data.TeamName;
                    $scope.Town = data.data.Town;
                    $scope.LeagueId = data.data.LeagueId;
                    $scope.LeagueName = data.data.LeagueName;

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
            function($scope, $http, $routeParams, $location) {
                $http.get("/api/Leagues").then(function(data) {
                    $scope.Id = data.data;
                });

                $scope.save = function() {

                    var obj = {
                        TeamName: $scope.TeamName,
                        Town: $scope.Town,
                        LeagueId: $scope.LeagueId,
                        UrlIcon: $scope.UrlIcon
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
                    $http.get("/api/Teams/" + $routeParams.id).then(function(data) {
                        $scope.TeamName = data.data.TeamName;
                        $scope.Town = data.data.Town;
                        $scope.LeagueId = data.data.LeagueId;
                        $scope.UrlIcon = data.data.UrlIcon;

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
            function($scope, $http) {
                $http.get("/api/Games")
                        .then(function(data) {
                            $scope.Games = data.data;
                        }),
                    function(error) {
                        $scope.error = "Wystąpił bład podczas dodawania Game!" + error;
                    };
            }
        ]);


    TeamControllers.controller("GameDeleteController",
        [
            "$scope", "$http", "$routeParams", "$location",
            function($scope, $http, $routeParams, $location) {
                $scope.Id = $routeParams.id;
                $http.get("/api/Games/" + $routeParams.id).then(function(data) {
                    $scope.Host = data.data.Host;
                    $scope.Visitor = data.data.Visitor;
                    $scope.DateTime = data.data.DateTime;
                    $scope.ScoreHost = data.data.ScoreHost;
                    $scope.ScoreVisitor = data.data.ScoreVisitor;
                    $scope.LeagueId = data.data.LeagueId;
                    $scope.Quatr1Host = data.data.Quatr1Host;
                    $scope.Quatr2Host = data.data.Quatr2Host;
                    $scope.Quatr3Host = data.data.Quatr3Host;
                    $scope.Quatr4Host = data.data.Quatr4Host;
                    $scope.Quatr1Visitor = data.data.Quatr1Visitor;
                    $scope.Quatr2Visitor = data.data.Quatr2Visitor;
                    $scope.Quatr3Visitor = data.data.Quatr3Visitor;
                    $scope.Quatr4Visitor = data.data.Quatr4Visitor;
                    $scope.LeagueName = data.data.LeagueName;
                    $scope.TeamName = data.data.TeamName;
                    $scope.TeamName1 = data.data.TeamName1;
                    $scope.Town = data.data.Town;
                    $scope.UrlIconHost = data.data.UrlIconHost;
                    $scope.UrlIconVisitor = data.data.UrlIconVisitor;
                    $scope.Date = data.data.Date;
                    $scope.Time = data.data.Time;


                });
                $scope.deleteGame = function() {

                    $http.delete("/api/Games/" + $scope.Id).then(function() {
                            $location.path("/gamelist");
                        },
                        function(data) {
                            $scope.error = "Wystąpił bład podczas usuwania Team!" + data;
                        });
                };

            }
        ]);

    TeamControllers.controller("GameEditController",
        [
            "$scope", "$http", "$routeParams", "$location",
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
                            $http.get("/api/Teams/" + host).then(function(data) {
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
                            Date: $scope.Date,
                            Time: $scope.Time,
                            ScoreHost: $scope.ScoreHost,
                            ScoreVisitor: $scope.ScoreVisitor,
                            LeagueId: $scope.LeagueId,
                            Quatr1Host: $scope.Quatr1Host,
                            Quatr2Host: $scope.Quatr2Host,
                            Quatr3Host: $scope.Quatr3Host,
                            Quatr4Host: $scope.Quatr4Host,
                            Quatr1Visitor: $scope.Quatr1Visitor,
                            Quatr2Visitor: $scope.Quatr2Visitor,
                            Quatr3Visitor: $scope.Quatr3Visitor,
                            Quatr4Visitor: $scope.Quatr4Visitor,
                            LeagueName: $scope.LeagueName

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
                            $scope.getVisitors();
                            $scope.Date = data.data.Date;
                            $scope.Time = data.data.Time;
                            $scope.LeagueId = data.data.LeagueId;
                            $scope.ScoreHost = data.data.ScoreHost;
                            $scope.ScoreVisitor = data.data.ScoreVisitor;
                            $scope.Quatr1Host = data.data.Quatr1Host;
                            $scope.Quatr2Host = data.data.Quatr2Host;
                            $scope.Quatr3Host = data.data.Quatr3Host;
                            $scope.Quatr4Host = data.data.Quatr4Host;
                            $scope.Quatr1Visitor = data.data.Quatr1Visitor;
                            $scope.Quatr2Visitor = data.data.Quatr2Visitor;
                            $scope.Quatr3Visitor = data.data.Quatr3Visitor;
                            $scope.Quatr4Visitor = data.data.Quatr4Visitor;


                        });
                    } else {
                        $scope.title = "Create New Game";
                    }
                });
            }
        ]);


    TeamControllers.controller("GameDetailsController",
        [
            "$scope", "$http", "$routeParams", "$location",
            function($scope, $http, $routeParams, $location) {
                $scope.Id = $routeParams.id;
                $http.get("/api/Games/" + $routeParams.id).then(function(data) {
                    $scope.Host = data.data.Host;
                    $scope.Visitor = data.data.Visitor;
                    $scope.DateTime = data.data.DateTime;
                    $scope.ScoreHost = data.data.ScoreHost;
                    $scope.ScoreVisitor = data.data.ScoreVisitor;
                    $scope.LeagueId = data.data.LeagueId;
                    $scope.Quatr1Host = data.data.Quatr1Host;
                    $scope.Quatr2Host = data.data.Quatr2Host;
                    $scope.Quatr3Host = data.data.Quatr3Host;
                    $scope.Quatr4Host = data.data.Quatr4Host;
                    $scope.Quatr1Visitor = data.data.Quatr1Visitor;
                    $scope.Quatr2Visitor = data.data.Quatr2Visitor;
                    $scope.Quatr3Visitor = data.data.Quatr3Visitor;
                    $scope.Quatr4Visitor = data.data.Quatr4Visitor;
                    $scope.LeagueName = data.data.LeagueName;
                    $scope.TeamName = data.data.TeamName;
                    $scope.TeamName1 = data.data.TeamName1;
                    $scope.Town = data.data.Town;
                    $scope.UrlIconHost = data.data.UrlIconHost;
                    $scope.UrlIconVisitor = data.data.UrlIconVisitor;
                    $scope.Date = data.data.Date;
                    $scope.Time = data.data.Time;


                });
            }
        ]);


    //Player

    TeamControllers.controller('PlayerListController',
        [
            '$scope', '$http',
            function($scope, $http) {
                $http.get("/api/Players")
                        .then(function(data) {
                            $scope.Players = data.data;
                        }),
                    function(error) {
                        $scope.error = "Wystąpił bład podczas ToList Zawodników!" + error;
                    };
            }
        ]);


    TeamControllers.controller('PlayerDeleteController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function($scope, $http, $routeParams, $location) {
                $scope.Id = $routeParams.id;
                $http.get("/api/Players/" + $routeParams.id).then(function(data) {
                    $scope.FirstName = data.data.FirstName;
                    $scope.LastName = data.data.LastName;
                    $scope.Age = data.data.Age;
                    $scope.TeamId = data.data.TeamId;

                });
                $scope.deletePlayer = function() {

                    $http.delete("/api/Players/" + $scope.Id).then(function() {
                            $location.path("/playerlist");
                        },
                        function(data) {
                            $scope.error = "Wystąpił bład podczas usuwania Zawodnika!" + data;
                        });
                };

            }
        ]);

    TeamControllers.controller('PlayerEditController',
        [
            '$scope', '$http', '$routeParams', '$location',
            function($scope, $http, $routeParams, $location) {
                $http.get("/api/Teams").then(function(data) {
                    $scope.Id = data.data;
                });

                $scope.savePlayer = function() {

                    var obj = {
                        FirstName: $scope.FirstName,
                        LastName: $scope.LastName,
                        Age: $scope.Age,
                        TeamId: $scope.TeamId
                    };
                    if ($scope.Id === 0) {
                        $http.post("/api/Players/", obj).then(function() {
                                $location.path("/playerlist");
                            }),
                            function(data) {
                                $scope.error = "Błąd podczas dodawania zawodnika!" + data.ExceptionInformation;
                            };
                    } else {
                        $http.post("/api/Players/", obj).then(function() {
                            $location.path("/playerlist");
                        }), function(data) {
                            console.log(data);
                            $scope.error = "Bląd podczas zapisywania Zawodnika! " + data.ExceptionInformation;
                        };
                    }
                };
                if ($routeParams.id) {
                    $scope.Id = $routeParams.id;
                    $scope.title = "Edit Player";
                    $http.get("/api/Players/" + $routeParams.id).then(function(data) {
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

    TeamControllers.controller('PlayersViewsListController',
        [
            '$scope', '$http', '$routeParams',
            function($scope, $http, $routeParams) {
                $scope.Id = $routeParams.id;
                $http.get("/api/PlayersViews/" + $routeParams.id).then(function(data) {

                    $scope.Players = data.data;
                });


            }
        ]);


    //TEST
    //
    //

    
    //TeamControllers.constant("appSettings",
    //    {
    //        serverPath: "http://localhost:55056"
    //    });

    //TeamControllers.factory("currentUser",
    //    currentUser);

    //function currentUser() {
    //    var profile = {
    //        isLoggedIn: false,
    //        username: "",
    //        token: ""
    //    };

    //    var setProfile = function (username, token) {
    //        profile.username = username;
    //        profile.token = token;
    //        profile.isLoggedIn = true;
    //    };

    //    var getProfile = function () {
    //        return profile;
    //    };

    //    return {
    //        setProfile: setProfile,
    //        getProfile: getProfile
    //    };
    //}

    //TeamControllers.controller('mainCtrl',
    //    [
    //        "userAccount", function(userAccount) {
    //            /* jshint validthis:true */
    //            var vm = this;
    //            vm.isLoggedIn = false;
    //            vm.message = "";
    //            vm.userData = {
    //                userName: '',
    //                password: '',
    //                confirmPassword: ''
    //            };

    //            vm.registerUser = function() {
    //                vm.userData.confirmPassword = vm.userData.password;

    //                userAccount.registration.registerUser(vm.userData,
    //                    function() {
    //                        vm.confirmPassword = "";
    //                        vm.message = "... Registration successful";
    //                        vm.login();
    //                    },
    //                    function(response) {
    //                        vm.isLoggedIn = false;
    //                        vm.message = response.statusText + "\r\n";
    //                        if (response.data.exceptionMessage)
    //                            vm.message += response.data.exceptionMessage;

    //                        // Validation errors
    //                        if (response.data.modelState) {
    //                            for (var key in response.data.modelState) {
    //                                if (response.data.modelState.hasOwnProperty(key)) {
    //                                    vm.message += response.data.modelState[key] + "\r\n";
    //                                }
    //                            }
    //                        }
    //                    });
    //            };

    //            vm.login = function() {
    //                vm.userData.grant_type = "password";
    //                vm.userData.userName = vm.userData.email;

    //                userAccount.login.loginUser(vm.userData,
    //                    function(data, currentUser) {
    //                        vm.message = "";
    //                        vm.password = "";
    //                        currentUser.setProfile(vm.userData.userName, data.access_token);
    //                    },
    //                    function(response) {
    //                        vm.password = "";
    //                        vm.message = response.statusText + "\r\n";
    //                        if (response.data.exceptionMessage)
    //                            vm.message += response.data.exceptionMessage;

    //                        if (response.data.error) {
    //                            vm.message += response.data.error;
    //                        }
    //                    });
    //            };
    //        }
    //    ]);
    //TeamControllers.factory("productResource",
    //    [
    //        "$resource",
    //        "appSettings",
    //        "currentUser", function($resource, appSettings, currentUser) {
    //            return $resource(appSettings.serverPath + "/api/players/:id",
    //                null,
    //                {
    //                    'get': {
    //                        headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
    //                    },

    //                    'save': {
    //                        headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
    //                    },

    //                    'update': {
    //                        method: 'PUT',
    //                        headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
    //                    }
    //                });
    //        }
    //    ]);

    //TeamControllers.factory("userAccount",
    //    [
    //        '$resource', 'appSettings', function ($resource, appSettings) {
    //            return {
    //                registration: $resource(appSettings.serverPath + "/api/Account/Register",
    //                    null,
    //                    {
    //                        'registerUser': { method: 'POST' }
    //                    }),
    //                login: $resource(appSettings.serverPath + "/Token",
    //                    null,
    //                    {
    //                        'loginUser': {
    //                            method: 'POST',
    //                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    //                            transformRequest: function (data, headersGetter) {
    //                                var str = [];
    //                                for (var d in data)
    //                                    if (data.hasOwnProperty(d))
    //                                        str.push(encodeURIComponent(d) +
    //                                            "=" +
    //                                            encodeURIComponent(data[d]));
    //                                return str.join("&");
    //                            }

    //                        }
    //                    })


    //            };
    //        }

    //    ]);
})();
