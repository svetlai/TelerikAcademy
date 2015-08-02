function solve() {
    return function () {
        $.fn.listview = function (data) {
            var $this = $(this),
                id = $this.attr('data-template'),
                templateHtml = $('#' + id).html(),
                template = handlebars.compile(templateHtml);

            for (var i = 0, len = data.length; i < len; i += 1) {
                $this.append(template(data[i]));
            }
        };

        //var books = [{
        //    id: 1,
        //    title: 'asd'
        //},
        //    {
        //        id: 2,
        //        title: 'dfg'
        //    }];
        //
        //$('#books-list').listview(books);
    };
}

module.exports = solve;