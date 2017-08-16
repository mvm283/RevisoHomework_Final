mainApp.service("projectService", function (httpService) {
    var self = this;
    self.resourceName = "Projects";


    this.getById = function(id) {
        return httpService.getById(self.resourceName,id);
    }
    this.getAllForGrid = function (options) {
        httpService.getForGrid(self.resourceName, options);
    }
    this.getAllForDropDown = function (options) {
        httpService.getForDropDown(self.resourceName, options);
    }
    this.getAll = function () {
        return httpService.getAll(self.resourceName);
    }

    this. saveItem= function (model) {
         

        if (!model.Id)
            return httpService.saveResource(self.resourceName, model);
        else 
            return httpService.modifyResource(self.resourceName, model, model.Id);

    }
    this.deleteItem = function (id) {
        return httpService.deleteResource(self.resourceName, id);
    }

  
});