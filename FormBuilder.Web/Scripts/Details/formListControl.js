//custom select form list
$.alpaca.Fields.FormSelectField = $.alpaca.Fields.SelectField.extend({

    getFormListUrl: function () {
        return "/api/Data/loadFormList";
    },

    getFieldType: function () {
        return "select";
    },

    getTitle: function () {
        return "Customized form list";
    },

    getDescription: function () {
        return "Provides a selector of all forms";
    },

    setup: function () {
        this.schema["enum"] = [];
        this.options.optionLabels = [];
        var self = this;
        var spinner = new CommonResources.Spinner($(this.element), 10);
        $.postJSON(self.getFormListUrl(), null, [spinner], false).done(function (data) {
            data.forEach(function (elem) {
                self.schema["enum"].push(elem.value);
                self.options.optionLabels.push(elem.text);
            });
            self.base();
        });
    }
});

Alpaca.registerFieldClass("formSelectField", Alpaca.Fields.FormSelectField);