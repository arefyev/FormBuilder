$.Details = $.Details || {};

$.Details.Data = function () { };

$.extend($.Details.Data.prototype, {
    loadFormList: function (spinner) {
        return $.postJSON("/api/data/loadFormList", null, spinner);
    },

    loadForm: function (data, spinner) {
        return $.postJSON("/api/data/loadForm", data, spinner);
    },

    saveFormData: function (data, spinner) {
        return $.postJSON("/api/Data/SaveFormData", data, spinner);
    }
});

$.Details.Page = function (options) {
    if (options != undefined)
        $.extend(this.options, options);
};

$.extend($.Details.Page.prototype, $.Resources.Page.prototype, {
    options: {
        service: new $.Details.Data(),
        title: 'Available forms'
    },

    init: function () {
        this.fList = $(".forms-list", this.element).formsList({ service: this.options.service });
        this.fDetails = $(".form-info", this.element).formDetails({ service: this.options.service });

        this.initEvents();
    },

    initEvents: function () {
        var self = this;

        /* EXTERNAL EVENTS */
        self.fList.on("clickItem", function (args, params) {
            self.fDetails.trigger("loadInfo", params);
        });

        self.fDetails.on("formLoaded", function () {
            $(".no-info").hide();
        });

        self.fDetails.on("formLoaded", function (args, params) {
            self.formLoaded(params);
        });

        self.fDetails.on("noData", function () {
            $(".no-info").show();
        });
        /* END OF EXTERNAL EVENTS */
    },

    formLoaded: function (id) {
        $(".result-link", self.element).attr("href", "#/Results/Form/" + id);
        $(".result-link", self.element).show();
    },

    onShow: function () {
        this.setTitle(this.options.title);

        if (this.fList)
            this.fList.trigger("reloadInfo");
    },

    onHide: function () { },

    destroy: function () { }
});