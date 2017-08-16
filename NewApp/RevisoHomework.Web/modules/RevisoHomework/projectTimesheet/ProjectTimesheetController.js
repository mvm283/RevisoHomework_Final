mainApp.controller("ProjectTimesheetController", function ($scope, ProjectTimesheetService, $kWindow, $rootScope) {
    var mainService = ProjectTimesheetService;
     
    $scope.loadData = function () {  
        $scope.model.gridSource.read();
    }; 
    $scope.addEditItem = function (id) {

        $kWindow.open({
            modal:true,
            width: 600,
            templateUrl: "/modules/RevisoHomework/projectTimesheet/views/_add.html",
            controller: "ProjectTimesheetAddEditController",
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
                        StartTime: { type: "string" },
                        EndTime: { type: "string" },
                        ProjectTitle: { type: "string" }, 
                        Comment: { type: "string" },
                        Project_Id: { type: "number" },
                         
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

mainApp.controller("ProjectTimesheetAddEditController", function ($scope, ProjectTimesheetService, projectService, $rootScope, $windowInstance, ItemId) {

    var mainService = ProjectTimesheetService;
    $scope.model = {
            Id: 0,
            StartTime: '',
            EndTime: '',
            Comment: '',
            ProjectTitle: '',
            Project_Id: 0
        
         
    }; 


    $scope.projectDataSource = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                projectService.getAllForDropDown(options);
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
