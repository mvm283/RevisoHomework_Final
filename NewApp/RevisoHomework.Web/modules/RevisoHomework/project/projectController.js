mainApp.controller("projectController", function ($scope, projectService, $kWindow, $rootScope) {
    var mainService = projectService;
     
    $scope.loadData = function () {  
        $scope.model.gridSource.read();
    }; 
    $scope.addEditItem = function (id) {

        $kWindow.open({
            modal: true,
            width: 600,
            templateUrl: "/modules/RevisoHomework/project/views/_add.html",
            controller: "projectAddEditController",
            resolve: {
                ItemId: function () { return id; }
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
            //data: $scope.tempData,
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
                        CustomerTitle: { type: "string" },
                        Price: { type: "number" },
                        Comment: { type: "string" },
                        Customer_Id: { type: "number" },
                        
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


    $scope.invoice = function (id) {
        $kWindow.open({
            modal: true,
            width: 900,
            templateUrl: "/modules/RevisoHomework/project/views/_repo.html",
            controller: "projectAddEditController",
            resolve: {
                ItemId: function () { return id; }
            }
        }); 
             
    }
 
});

mainApp.controller("projectAddEditController", function ($scope, projectService, customerService, ProjectTimesheetService, $rootScope, $windowInstance, ItemId ) {

    var mainService = projectService;
    $scope.model = {
            Id: 0,
            Code: '',
            Title: '',
            Comment: '',
            CustomerTitle: '',
            Customer_Id: 0,
            Price: 0
        
         
    }; 


    $scope.customerDataSource = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                customerService.getAllForDropDown(options);
            }
        },
    });
 

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
