mainApp.factory("errorHandlerInterceptor", function($q) {
    var interceptor = {
        'request': function (config) {
            var token = "Bearer " + window.localStorage["securityToken"];
            config.headers["Authorization"] = token;
            return config;
        },
        'response': function (response) {
            return response;
        },
        'requestError': function (response) {
            return $q.reject(response);
        },
        'responseError': function (response) {
            if (response.status === 404)
                alert("not found");

            if (response.status === 401)
                window.location = "/Login/Index";

            return $q.reject(response);
        }
    };

    return interceptor;
})