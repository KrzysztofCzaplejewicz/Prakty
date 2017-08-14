(function () {
    "use strict";
    
    var TeamApp = angular.module("TeamApp", ["ngRoute", "TeamControllers", "mainCtrl"]);
   TeamApp.config([
       "$routeProvider", "$locationProvider", function ($routeProvider) {
           $routeProvider
               .when("/home",
               {
                   templateUrl: "/home/teams"
                   })
               .when("/index",
                   {
                       templateUrl: "/home/index"
               })
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

               .when("/playersviewslist/:id",
                   {
                       templateUrl: "/home/playersviewslist",
                       controller: "PlayersViewsListController"
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
               .when("/gamedetails/:id",
                   {
                       templateUrl: "/home/gamedetails",
                       controller: "GameDetailsController"
               })
               .when("/register",
                   {
                       templateUrl: "/account/register"
               })
               .when("/login",
                   {
                       templateUrl: "/account/login"
                   })
                .otherwise({
                redirectTo: "/index"
            });



       }


       
    ]);

   // //var serviceBase = 'http://localhost:55056/';
   //var serviceBase = 'http://localhost:55056/';
   // TeamApp.constant('ngAuthSettings', {
   //     apiServiceBaseUri: serviceBase,
   //     clientId: 'ngAuthApp'
   // });

   // TeamApp.config(function ($httpProvider) {
   //     $httpProvider.interceptors.push('authInterceptorService');
   // });

   // TeamApp.run(['authService', function (authService) {
   //     authService.fillAuthData();
   // }]);
    

    
})();