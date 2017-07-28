(function () {
    "use strict";
    
    var TeamApp = angular.module('TeamApp', ["ngRoute", "TeamControllers"]);
   TeamApp.config([
       "$routeProvider", "$locationProvider", function ($routeProvider) {
            $routeProvider
                .when("/list",
                    {
                        templateUrl: "/home/list",
                        controller: "ListController"
                })
                .when("/gamelist",
                    {
                        templateUrl: "/home/gamelist",
                        controller: "GameListController"
                })
                .when("/playerlist",
                    {
                        templateUrl: "/home/playerlist",
                        controller: "PlayerListController"
                    })
                .when("/create",
                {
                    templateUrl: "/home/edit",
                    controller: "EditController"
                })
                .when("/gamecreate",
                    {
                        templateUrl: "/home/gameedit",
                        controller: "GameEditController"
                })
                .when("/playercreate",
                    {
                        templateUrl: "/home/playeredit",
                        controller: "PlayerEditController"
                    })
                .when("/edit/:id",
                {
                    templateUrl: "/home/edit",
                   controller: "EditController"
                })
                .when("/gameedit/:id",
                    {
                        templateUrl: "/home/gameedit",
                        controller: "GameEditController"
                })
                .when("/playeredit/:id",
                    {
                        templateUrl: "/home/playeredit",
                        controller: "PlayerEditController"
                    })
                .when("/delete/:id",
                {
                    templateUrl: "/home/delete",
                    controller: "DeleteController"
                })
                .when("/gamedelete/:id",
                    {
                        templateUrl: "/home/gamedelete",
                        controller: "GameDeleteController"
                })
                .when("/playerdelete/:id",
                    {
                        templateUrl: "/home/playerdelete",
                        controller: "PlayerDeleteController"
                    })
                .otherwise({
                redirectTo: "/list"
            });

           
       }
    ]);
})();