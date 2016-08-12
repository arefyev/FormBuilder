(function ($) {
    "use strict";

    $.widget("da.formDetails",
    {
        options: {
            service: null
        },

        _create: function () {
            this.initChildren();
            this.initEvents();
        },

        initChildren: function () {
            $(this.element).append($("<div class='form-description'></div>"));
            $(this.element).append($("<div class='form-details'></div>"));
        },

        initEvents: function () {
            var self = this;

            /* WIDGET EXTERNAL EVENTS */
            this.element.on("loadInfo", function (evt, param) { self.loadInfo(param); });
            /* END OF EXTERNAL EVENTS */
        },

        loadInfo: function (id) {
            var self = this;
            if (id) {
                self.Id = id;
                $(this.element).show();
                var spinner = new CommonResources.Spinner($(".content"), 10);

                if (!self.options.service)
                    self.element.trigger("noData");

                self.options.service.loadForm({ "id": id }, [spinner]).done(function (data) {
                    if (data == null) {
                        //no data found
                        self.element.trigger("noData");
                        return;
                    }
                    if (data.description)
                        $(".form-description", self.element).html(data.description);
                    else
                        $(".form-description", self.element).empty();

                    self.renderFormData(data.form);
                    self.element.trigger("formLoaded", self.Id);
                });
            }
        },

        renderFormData: function (data) {
            data = JSON.parse(data);

            $(".form-details", this.element).empty();
            this.addSubmitHandlerIfNeed(data);
            $(".form-details", this.element).alpaca(data);
        },

        addSubmitHandlerIfNeed: function (data) {
            var self = this;
            if (data.options && data.options.form)
                return;

            data.options.form = {
                "buttons": {
                    "submit": {
                        "title": "Send data"
                    }
                }
            };
            data.options.toggleSubmitValidState = false;
            data.postRender = function (renderedField) {
                var form = renderedField.form;
                if (form) {
                    form.registerSubmitHandler(function (e, form) {

                        if (!self.options.service)
                            throw "Service can't be empty";

                        form.validate(true);
                        form.refreshValidationState(true);

                        if (form.isFormValid()) {
                            var formData = form.getValue();
                            var spinner = new CommonResources.Spinner($(".content"), 10);

                            self.options.service.saveFormData({ "id": self.Id, "formData": JSON.stringify(formData) }, [spinner]).done(function () {
                                CommonResources.successNotification("Form data successfully saved");
                            });
                        }
                        e.stopPropagation();
                        return false;
                    });
                }
            }
        },
        _destroy: function () {
            this.element.off("loadInfo");
            $(this.element).alpaca("destroy");
        }
    });
})(jQuery);