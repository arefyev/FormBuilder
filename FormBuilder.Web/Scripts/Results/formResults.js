(function ($) {
    "use strict";

    $.widget("da.formResults",
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
            this.element.on("loadResults", function (evt, param) {
                self.loadResults(param);
            });
            /* END OF EXTERNAL EVENTS */
        },

        loadResults: function (id) {
            var self = this;
            var spinner = new CommonResources.Spinner($(this.element), 10);
            self.options.service.loadFormResults({ "id": id }, [spinner]).done(function (data) {
                if (data == null) {
                    self.element.trigger("noData");
                    return;
                }
                self.renderResults(data);
            });
        },

        renderResults: function (data) {
            var head = Handlebars.compile($("#form-data").html());
            var results = Handlebars.compile($("#form-results").html());

            $(".head", this.element).html(head(data.form));

            var schema = JSON.parse(data.form.form);

            $(".results", this.element).empty();

            if (data.results.length === 0) {
                $(".results", this.element).append("No data found");
            }
            $(".results", this.element).append($("<div class='result-head'>Results</div>"));
            for (var key in data.results) {
                schema.data = JSON.parse(data.results[key]);
                schema.view = "bootstrap-display";
                $(".results", this.element).append($("<div class='result-item item" + key + "'></div>"));
                $(".item" + key, this.element).alpaca(schema);
                if (key != data.results.length - 1)
                    $(".results", this.element).append($("<hr />"));
            }
        },

        _destroy: function () { }
    });
})(jQuery);