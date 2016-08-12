var CommonResources = function () {
};

CommonResources.RequestState =
{
    SUCCESS: 0,
    FAIL: 1
};

CommonResources.NotifyType = {
    Success: "success",
    Info: "info",
    Warning: "warn",
    Error: "error"
};

CommonResources.GetFeedbackConfiguration = function (context) {
    var schema = {
        "type": "object",
        "properties": {
            "feedback": {
                "type": "text",
                //"required": true
            },
            "name": {
                "type": "string",
                //"required": true
            },
            "phone": {
                "type": "phone",
                "format": "phone",
                //"required": true
            },
            "region":
            {
                "type": "string"
            },
            "address": {
                "type": "string"
            }
        }
    };

    var options = {
        "form": {
            "attributes": {},
            "buttons": {
                "submit": {
                    "click": function () {
                        var val = this.getValue();
                        debugger;
                        if (this.isValid(true) && context) {

                            if (context && context.submit)
                                context.submit.call(null, val);

                            //context.createFeedback(val).done(function (data) {

                            //});
                        } else {
                            alert("Invalid value: " + JSON.stringify(val, null, "  "));
                        }
                    }
                }
            }
        },
        "fields": {
            "name": {
                "type": "text",
                "label": "Name"
            },
            "phone": {
                "type": "phone",
                "label": "Phone"
                ,
                "format": "phone"
            },
            "feedback": {
                "type": "textarea",
                "label": "Fedback",
                "helper": "Type a feedback with all details"
            },
            "region":
           {
               "type": "selectRegion1",
               "label": "Region",
               "helper": "Custom data from server"
           },
            "address": {
                "type": "text",
                "label": "Home addres"
            }
        }

        //,
        //"postRender": function (renderedField) {
        //    var form = renderedField.form;
        //    if (form) {
        //        debugger;
        //        form.registerSubmitHandler(function (e, form) {
        //            // validate the entire form (top control + all children)
        //            form.validate(true);
        //            // draw the validation state (top control + all children)
        //            form.refreshValidationState(true);
        //            // now display something
        //            if (form.isFormValid()) {
        //                var value = form.getValue();
        //                alert("The form looks good!  Name: " + value.name + ", Birthday: " + value.birthday + ", Preference: " + value.preference);
        //            } else {
        //                alert("There are problems with the form.  Please make the any necessary corrections.");
        //            }
        //            e.stopPropagation();
        //            return false;
        //        });
        //    }
        //}
    };
    return { "schema": schema, "options": options };
};

CommonResources.Spinner = function (element, radius) {
    this.radius = radius || 10;
    this.element = element;
};

CommonResources.highlightMenuItem = function (controller) {
    var url = "/" + controller;
    $("header ul.navigation li").removeClass("active");
    var $a = $("header ul.navigation li a[href$=\"#" + url + "\"]");
    $a.parent().addClass("active");
};

CommonResources.successNotification = function (message) {
    $.notify(message, CommonResources.NotifyType.Success);
}
CommonResources.errorNotification = function (message) {
    $.notify(message, CommonResources.NotifyType.Error);
}