messageBox = {
    confirm: function(title, message, doneDelegate) {
        $.when(kendo.ui.ExtYesNoDialog
            .show(
            {
                title: title,
                message: message
            })).done(function (response) {
                if (response.button === "Yes") {
                    doneDelegate();
                }


          });
    }
};