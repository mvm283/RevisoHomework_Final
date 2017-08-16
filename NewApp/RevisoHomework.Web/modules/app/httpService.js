mainApp.service("httpService", function ($http) {
    var self = this;
    self.serviceUrl ="";

    this.getById = function(resourceName, id) {
        return $http({
            method: "GET",
            url: self.serviceUrl + "api/" + resourceName + "/" + id
        });
    };
    this.getForGrid = function (resourceName, options) {
        var filter = undefined;
        var sort = undefined;
        if (options.data.filter != undefined) {
            filter = JSON.stringify(options.data.filter);
        }
        if (options.data.sort != undefined) {
            sort = JSON.stringify(options.data.sort);
        }
        var pageSize = 10;
        var page = 1;

        if (options.data.pageSize != undefined)
            pageSize = options.data.pageSize;

        if (options.data.page != undefined)
            page = options.data.page;

        var tmpUrl = self.serviceUrl + "api/" + resourceName;
        tmpUrl += "?page=" + page + "&pageSize=" + pageSize +
            "&filter=" + filter + "&sort=" + sort;

        $http({
            method: "GET",
            url: tmpUrl
        }).then(function(response) {
            options.success(response.data);
        });
    }
    this.getForDropDown = function(resourceName, options) {
        this.getAll(resourceName).then(function(response) {
            options.success(response.data);
        });
    }
    this.getAll = function (resourceName) {
        return $http({
            method: "GET",
            url: self.serviceUrl + "api/" + resourceName
        });
    }
    this.getAllWithParameters = function (resourceName, options) {
         
        var tmpUrl = self.serviceUrl + "api/" + resourceName + "/?param=" + options;
        debugger;
        return $http({
            method: "GET",
            url: tmpUrl
        }).then(function (response) {
            options.success(response.data);
        });
    }

    this.saveResource = function(resourceName, model) {
        return $http({
            url : self.serviceUrl + "api/" + resourceName,
            method: "POST",
            data:model
        });
    };
    this.modifyResource = function (resourceName, model, id) {
        return $http({
            url: self.serviceUrl + "api/" + resourceName + "/" + id,
            method: "PUT",
            data: model
        });
    };
    this.deleteResource = function(resourceName, id) {
        return $http({
            url: self.serviceUrl + "api/" + resourceName + "/" + id,
            method: "DELETE"
        });
    }
});

mainApp.service("viewStateService", function($location) {
    this.setCurrentUrl = function () {
        window.sessionStorage["lastLocation"] = $location.path();
    }
});