(function() {
    "use strict";

    var app = angular.module("mainCtrl", ["ngResource"]);

    app.factory("productResource",
        [
            "$resource",
            "currentUser",
            productResource
        ]);

    function productResource($resource, currentUser) {
        return $resource("/api/Players",
            null,
            {
                'get': {
                    headers: { 'Authorization': "Bearer " + currentUser.getProfile().token }
                },

                'save': {
                    headers: { 'Authorization': "Bearer " + currentUser.getProfile().token }
                },

                'update': {
                    method: "POST",
                    headers: { 'Authorization': "Bearer " + currentUser.getProfile().token }
                },
                'delete': {
                    method: "DELETE",
                    headers: { 'Authorization': "Bearer " + currentUser.getProfile().token }
                }

            });
    }

    app.factory("userAccount",
        [
            "$resource",
            function($resource) {
                return {
                    registration: $resource("/api/Account/Register",
                        null,
                        {
                            'registerUser': { method: "POST" }
                        }),
                    login: $resource("/Token",
                        null,
                        {
                            'loginUser': {
                                method: "POST",
                                headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                                transformRequest: function(data, headersGetter) {
                                    var str = [];
                                    for (var d in data)
                                        if (data.hasOwnProperty(d))
                                            str.push(encodeURIComponent(d) +
                                                "=" +
                                                encodeURIComponent(data[d]));
                                    return str.join("&");
                                }

                            }
                        })
                };
            }
        ]);
    app.factory("currentUser",
        [
        function() {
            var profile = {
                isLoggedin: false,
                userName: "",
                token: ""
            };

            var setProfile = function(userName, token) {
                profile.userName = userName;
                profile.token = token;
                profile.isLoggedin = true;
            };

            var getProfile = function() {
                return profile;
            };

            return {
                setProfile: setProfile,
                getProfile: getProfile
            };
        }]);

    

    app.controller("mainCtrl", ["userAccount", "currentUser", mainCtrl]);

    mainCtrl.$inject = ["$location"];

    function mainCtrl(userAccount) {
       //*/jshint validthis:true */
        var vm = this;
        vm.isLoggedin = false;
        vm.message = "";
        vm.userData = {
            userName: "",
            password: "",
            confirmPassword: ""
        };

        vm.registerUser = function() {
            vm.userData.confirmPassword = vm.userData.password;

            userAccount.registration.registerUser(vm.userData,
                function() {
                    vm.confirmPassword = "";
                    vm.message = "... Registration successful";
                    vm.login();
                },
                function(response) {
                    vm.isLoggedin = false;
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;

                    // Validation errors
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            if (response.data.modelState.hasOwnProperty(key)) {
                                vm.message += response.data.modelState[key] + "\r\n";
                            }
                        }
                    }
                });
        };

        vm.login = function() {
            //var userLogin = {
            //    grant_type: "password",
            //    userName: vm.userData.email,
            //    password: vm.userData.password
            //};

            //vm.responseData = "";
            //var loginResult = userAccount.loginUser(userLogin);

            //loginResult.then(function(resp, currentUser) {
            //    vm.userData.userName = resp.data.userName;
            //    currentUser.setProfile(resp.data.userName, resp.data.access_token);
            //},
            vm.userData.grant_type = "password";
            vm.userData.userName = vm.userData.email;

            userAccount.login.loginUser(vm.userData,
                function (currentUser, data) {
                    vm.isLoggedin = true;
                    vm.message = "";
                    vm.password = "";
                    //vm.token = data.access_token;
                    sessionStorage.setItem(vm.userData.userName, data.access_token);
                    //currentUser.setProfile(vm.userData.userName, data.access_token);
                },
                function(response) {
                    vm.password = "";
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;

                    if (response.data.error) {
                        vm.message += response.data.error;
                    }
                });
        };
        vm.logOut = function(data, currentUser) {
            sessionStorage.removeItem(vm.userData.userName, data.access_token);
        };
    }
})();