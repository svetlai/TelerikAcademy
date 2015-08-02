/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (element, contents) {
        if (!element || !contents) {
            throw new Error('You must provide both element id and array of contents.');
        }

        if (typeof (element) !== 'string' && !(element instanceof HTMLElement)) {
            throw new Error('Selector must be a string or a DOM element');
        }

        if (!Array.isArray(contents)){
            throw new Error('Contents must be an array');
        }

        for (var i = 0, len = contents.length; i < len; i += 1) {
            if (typeof (contents[i]) !== 'string' && typeof (contents[i]) !== 'number') {
                throw new Error('Contents must be either string or number');
            }
        }

        var domElement = typeof (element) == 'string' ? document.getElementById(element) : element;

        if (domElement === null) {
            throw new Error('The provided DOM element doesn\'t exist in the current document.');
        }

        while (domElement.children.length > 0) {
            var child = domElement.children[0];
            domElement.removeChild(child);
        }

        for (var i = 0, len = contents.length; i < len; i += 1) {
            var div = document.createElement('div');
            div.innerHTML = contents[i];
            domElement.appendChild(div);
        }
    };
};