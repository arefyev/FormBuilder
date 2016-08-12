(function ($) {
    "use strict";

    $.widget("da.formsList",
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
            this.element.on("reloadInfo", function () { self.renderList(); });
            /* END OF EXTERNAL EVENTS */
        },

        renderList: function () {
            var self = this;
            $(this.element).empty();
            $(this.element).alpaca({
                "data": self.selected ? self.selected : "",
                "options": {
                    "type": "formSelectField",
                    "multiple": false,
                    "hideNone": true,
                    "size": 3,
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
