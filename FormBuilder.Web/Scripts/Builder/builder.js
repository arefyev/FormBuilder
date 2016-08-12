(function ($) {
    $.widget("da.builder",
    {
        options: {
            service: null
        },

        _create: function () {
            if (setupFormBuilder)
                setupFormBuilder.RegisterPage({ "save": $.proxy(this.onSave, this) });
        },

        onSave: function (params) {
            if (this.options.service)
                this.options.service.saveForm({ "name": params.common.name, "description": params.common.description, "form": JSON.stringify(params.form) }).done(function (data) {
                    CommonResources.successNotification("Form successfully created");
                });
        },

        _destroy: function () {
        }
    });
})(jQuery);