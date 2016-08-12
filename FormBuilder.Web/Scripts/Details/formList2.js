(function ($) {
    "use strict";

    $.widget("da.formsList2",
    {
        options: {
            service: null
        },

        _create: function () {
            this.initEvents();
        },

        initEvents: function () {
            var self = this;

            /* WIDGET EXTERNAL EVENTS */
            this.element.on("reloadInfo", function (evt, param) { self.reloadInfo(param); });
            /* END OF EXTERNAL EVENTS */
        },

        reloadInfo: function () {
            var self = this;
            if (self.options.service) {
                self.progress = true;
                var spinner = new CommonResources.Spinner($(this.element), 10);
                self.options.service.loadFormList([spinner]).done(function (data) {
                    self.renderList(data);
                    self.progress = false;
                });
            }
        },

        renderList: function (data) {
            var self = this;
            $(this.element).empty();
            $(this.element).alpaca({
                "data": self.selected ? self.selected : "",
                "options": {
                    "type": "select",
                    "multiple": false,
                    "hideNone": true,
                    "size": 3,
                    "dataSource": data,
                    "onFieldChange": function () {
                        self.selected = this.getValue();
                        self.onItemClick(self.selected);
                    }
                }
            });
        },

        onItemClick: function (id) {
            this.element.trigger("clickItem", id);
        },
        _destroy: function () {
            this.element.off("reloadInfo");
            $(this.element).alpaca("destroy");
        }
    });
})(jQuery);
