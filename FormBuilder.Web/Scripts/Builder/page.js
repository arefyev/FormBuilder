$.Builder = $.Builder || {};

$.Builder.Page = function (options) {
    if (options != undefined)
        $.extend(this.options, options);
};

$.Builder.Data = function () { };

$.extend($.Builder.Data.prototype, {
    loadExistingForms: function (spinner) {
        return $.postJSON("/api/Data/loadBuilderFormsList", null, spinner);
    },

    saveForm: function (data, spinner) {
        return $.postJSON("/api/Data/SaveBuilderForm", data, spinner);
    }
});

$.extend($.Builder.Page.prototype, $.Resources.Page.prototype, {
    options: {
        service: new $.Builder.Data(),
        title: "Form builder"
    },

    init: function () {
        $(".container.builder").builder({ service: this.options.service });
    },

    onShow: function () {
        this.setTitle(this.options.title);
    },

    onHide: function () { },

    destroy: function () { }
});

