(function () {
    "use strict";

    var app = angular.module("mainCtrl");
    app.factory("userAccount",
        [
            "$resource",
            
            function($resource) {
                return {
                    registration: $resource( "/api/Account/Register",
                        null,
                        {
                            'registerUser': { method: 'POST' }
                        }),
                    login: $resource("/Token",
                        null,
                        {
                            'loginUser': {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
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
})();
