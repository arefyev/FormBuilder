$.Results = $.Results || {};

$.Results.Data = function () { };

$.extend($.Results.Data.prototype, {
    loadFormResults: function (id, spinner) {
        return $.postJSON("/api/data/loadFormResults", id, spinner);
    }
});

$.Results.Page = function (options) {
    if (options != undefined)
        $.extend(this.options, options);
};

$.extend($.Results.Page.prototype, $.Resources.Page.prototype, {
    options: {
        service: new $.Results.Data(),
        title: "Form results"
    },

    init: function () {
        this.formResults = $(".results-page", this.element).formResults({ service: new $.Results.Data() });
    },

    onShow: function () {
        this.setTitle(this.options.title);
    },

    onHide: function () { },

    //TODO: configure callback for manuel hach change
    callback: function (params) {
        if (!params || !params.action)
            return;
        switch (params.action.toLowerCase()) {
            case "form":
                this.formResults.trigger("loadResults", params.data);
                break;

            default:
        }
    },
    destroy: function () {
        this.formResults.off("*");
    }
});