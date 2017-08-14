(function () {
    "use strict";

    var app = angular.module("productManagement",
        ["ngResource"]);
        app.constant("appSettings",
        {
            serverPath: "http://localhost:55056"
        });
}());
