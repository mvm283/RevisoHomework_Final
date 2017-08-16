var mainApp = angular.module("mainApp", ["ngRoute","kendo.directives", "kendo.window"]);
 

mainApp.config(function($httpProvider) {
    $httpProvider.interceptors.push("errorHandlerInterceptor");
});

mainApp.config(function ($routeProvider) {
    $routeProvider.when("/", {
        templateUrl: 'modules/dashboard/views/index.html',
        controller: 'dashboardControllers'

    }).when("/project", {
        templateUrl: 'modules/RevisoHomework/project/views/index.html',
        controller: 'projectController'

    }).when("/customer", {
        templateUrl: 'modules/RevisoHomework/customer/views/index.html',
        controller: 'customerController'

    }).when("/ProjectTimesheet", {
        templateUrl: 'modules/RevisoHomework/ProjectTimesheet/views/index.html',
        controller: 'ProjectTimesheetController'

    })
});

mainApp.controller("baseController", function ($scope) {

    if (window.sessionStorage["lastLocation"] && window.sessionStorage["lastLocation"] !== "undefined") {
        window.location = "#" + window.sessionStorage["lastLocation"];
    }
     

    $scope.$on('$routeChangeStart', function (a, current) {
        var path = current.$$route.originalPath;

        if (path === "/")
            $scope.currentActiveMenu = "dashboard";
        else if (path === "/articles")
            $scope.currentActiveMenu = "article";

    });

});