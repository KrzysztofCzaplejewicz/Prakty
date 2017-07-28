(function() {

    "use strict";

    //Getting a existing module
    angular.module("app-games",[])
        .controller("gamesController", gamesController);

    function gamesController($http) {

        var vm = this;
        vm.name = "Games";

        vm.games = [];

        vm.newGame = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/Leagues")
            .then(function(response) {
                    //success
                    angular.copy(response.data, vm.games);
                },
                function(error) {
                    //failure
                    vm.errorMessage = "Failed to load data " + error;
                })
            .finally(function() {
                vm.isBusy = false;
            });
            

        vm.addGame = function() {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/Leagues", vm.newGame)
                .then(function(response) {
                        //success
                        vm.Games.push(response.data);
                        vm.newGame = {};

                    },
                    function() {
                        vm.errorMessage = "Failed to save new League";
                    })
                .finally(function() {
                    vm.isBusy = false;
                });


        }

    }

})();