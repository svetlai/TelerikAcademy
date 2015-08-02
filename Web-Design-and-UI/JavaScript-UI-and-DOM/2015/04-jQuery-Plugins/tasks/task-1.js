//These references should enable intellisense within this file
///<reference path="https://code.jquery.com/jquery-2.1.4.js" />
function solve() {
    return function (selector) {
        var $select = $(selector).hide();

        var $dropdownList = $('<div />')
            .addClass('dropdown-list')
            .append($select);

        var $current = $('<div/>')
            .addClass('current')
            .attr('data-value', '')
            .html('Select a value')
            .appendTo($dropdownList);

        var $optionsContainer = $('<div/>')
            .addClass('options-container')
            .css('position', 'absolute')
            .hide()
            .appendTo($dropdownList);

        var $options = $select.find('option');

        for (var i = 0, len = $options.length; i < len; i += 1) {
            var $optionDiv = $('<div/>')
                .addClass('dropdown-item')
                .attr('data-value', $($options[i]).val())
                .attr('data-index', i)
                .html($($options[i]).html())
                .appendTo($optionsContainer);
        }

        var $body = $('body')
            .append($dropdownList);

        $current.on('click', function(){
            $(this).html('Select a value');
            $optionsContainer.toggle();
        });

        $optionsContainer.on('click', 'div', function(){
           var $clicked = $(this),
               value = $clicked.attr('data-value');

            $current.html($clicked.html())
                .attr('data-value', value);

           $select.find('option' + '[value="' + value + '"]')
                .attr('selected', '');

            //for (var i = 0, len = $options.length; i < len; i += 1) {
            //    if ($($options[i]).val() == value){
            //        $($options[i]).attr('selected', '');
            //    }
            //}

            $optionsContainer.toggle();
        });
    };
}

module.exports = solve;