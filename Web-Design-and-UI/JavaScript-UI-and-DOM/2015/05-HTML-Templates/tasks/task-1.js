/* globals $ */

function solve() {

    return function (selector) {
        var template = //$('#table-template').html();
            '<table class="items-table">' +
            '<thead>' +
            '<tr>' +
            '<th>#</th>' +
            '{{#each headers}}' +
            '<th>{{this}}</th>' +
            '{{/each}}' +
            '</tr>' +
            '</thead>' +
            '<tbody>' +
            '{{#each items}}' +
            '<tr>' +
            '<td>{{@index}}</td>' +
            '<td>{{col1}}</td>' +
            '<td>{{col2}}</td>' +
            '<td>{{col3}}</td>' +
            '</tr>' +
            '{{/each}}' +
            '</tbody>' +
            '</table>'

        $(selector).html(template);

        //console.log(template);
        //var data,
        //    tableTemplateHTML,
        //    tableTemplate;
        //
        //data = {
        //  headers : ['Vendor', 'Model', 'OS'],
        //  items : [{
        //    col1: 'Nokia',
        //    col2: 'Lumia 920',
        //    col3: 'Windows Phone'
        //  }, {
        //    col1: 'LG',
        //    col2: 'Nexus 5',
        //    col3: 'Android'
        //  }, {
        //    col1: 'Apple',
        //    col2: 'iPhone 6',
        //    col3: 'iOS'
        //  }]
        //};
        //
        //tableTemplateHTML = document.getElementById('table-template').innerHTML;
        //tableTemplate = Handlebars.compile(tableTemplateHTML);
        //document.getElementById('root').innerHTML = tableTemplate(data);
    };
};

module.exports = solve;