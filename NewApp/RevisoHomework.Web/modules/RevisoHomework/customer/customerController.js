mainApp.controller("customerController", function ($scope, customerService, $kWindow, $rootScope) {
    var mainService = customerService;
     
    $scope.loadData = function () {  
        $scope.model.gridSource.read();
    }; 
    $scope.addEditItem = function (id) {

        $kWindow.open({
            modal:true,
            width: 600,
            templateUrl:  "/modules/RevisoHomework/customer/views/_add.html" ,
            controller: "customerAddEditController",
            resolve: {
                ItemId: function () {  return id; }
            }
        });
    }
    $scope.deleteItem = function (id) {

        messageBox.confirm("Warning", "Do you want to delete this row?", function() {
            mainService.deleteItem(id).then(function (response) {
                $scope.model.gridSource.read();
            });
        });
    }
    $rootScope.$on("ItemAdded", function() {
        $scope.model.gridSource.read();
    });
    //loading grid
    $scope.model = {
        md: [],
        gridSource: new kendo.data.DataSource({ 
            transport: {
                read: function (options) {
                    mainService.getAllForGrid(options);
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                model: {
                    fields: {
                        Id: { type: "number" },
                        Code: { type: "string" },
                        Title: { type: "string" },
                        Comment: { type: "string" },
                        Phone: { type: "string" },
                        Mobile: { type: "string" },
                        Address: { type: "string" } 
                    }
                }
            },

            pageSize: 10,
            page: 1,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        }),


    };

 
});

mainApp.controller("customerAddEditController", function ($scope, customerService, $rootScope, $windowInstance, ItemId) {

    var mainService = customerService;
    $scope.model = {
            Id: 0,
            Code: '',
            Title: '',
            Comment: '',
            Phone: '',
            Mobile: '',
            Address: '' 
    }; 

    if (ItemId) {
        mainService.getById(ItemId).then(function (response) {
            $scope.model = response.data;
            debugger;

        });
    } 

    $scope.save = function () {
        mainService.saveItem($scope.model).then(function (response) {
            $rootScope.$broadcast("ItemAdded");

            $windowInstance.close();

        }, function (response) {
            //error
        });
    }
    $scope.close = function () {
        $windowInstance.close();
    }
});
