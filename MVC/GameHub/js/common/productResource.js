(function () {
    "use strict";

    var app = angular.module("TeamApp");
        app.factory("productResource",
            [
                "$resource",
                "appSettings",
                "currentUser",
                productResource
            ]);

    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/players", null,
            {
                'get': {
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },

                'save': {
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },

                'update': {
                    method: 'PUT',
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                }
            });
    }
}());

