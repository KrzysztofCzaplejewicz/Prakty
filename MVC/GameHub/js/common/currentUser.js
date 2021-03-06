﻿(function () {
    "use strict";

    var app = angular.module("common.services");
        app.factory("currentUser",
            currentUser);

    function currentUser() {
        var profile = {
            isLoggedIn: false,
            username: "",
            token: ""
        };

        var setProfile = function (username, token) {
            profile.username = username;
            profile.token = token;
            profile.isLoggedIn = true;
        };

        var getProfile = function() {
            return profile;
        };

        return {
            setProfile: setProfile,
            getProfile: getProfile
        };
    }
})();
