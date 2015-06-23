/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * // method removeAttribute(attribute)
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {
        function isString(value) {
            return typeof(value) === 'string';
        }

        function isNonEmptyString(value) {
            return typeof(value) === 'string' && value !== '';
        }

        function hasOnlyLatinLettersAndDigits(value) {
            return value.match(/^[0-9a-zA-Z]*$/);
        }

        function hasOnlyLatinLettersDigitsAndDash(value) {
            return value.match(/^[0-9a-zA-Z-]*$/);
        }

        function validateType(type){
            if (!isNonEmptyString(type)) {
                throw new Error('The type must be a non empty string.');
            }

            if (!hasOnlyLatinLettersAndDigits(type)) {
                throw new Error('The type must contain only latin letters or digits.');
            }
        }

        function validateAttribute(name){
            if (!isNonEmptyString(name)) {
                throw new Error('The name must be a non empty string.');
            }

            if (!hasOnlyLatinLettersDigitsAndDash(name)) {
                throw new Error('The name must contain only latin letters, digits or dash.');
            }
        }

        function validateChild(child){
            if (!(isString(child) || Object.getPrototypeOf(child) === domElement)) {
                throw new Error('Child must be either string or a domElement');
            }
        }

        function validateParent(value){
            if (Object.getPrototypeOf(value) !== domElement) {
                throw new Error('Parent must be a domElement.');
            }
        }

        function validateContent(value){
            if (!isString(value)) {
                throw new Error('Content must be a string.');
            }
        }

        function sortAttributes(attributes) {
            var sorted = [];
            for (var attr in attributes) {
                sorted.push([attr, attributes[attr]]);
            }

            sorted = sorted.sort(function (firstAttribute, secondAttribute) {
                if (firstAttribute[0] < secondAttribute[0]) {
                    return -1;
                }
                if (firstAttribute[0] > secondAttribute[0]) {
                    return 1;
                }
                return 0;
            });

            return sorted;
        }

        function parseHtml(type, attributes, children, content){
            var output = '<' + type;
            if (attributes) {
                var sortedAttributes = sortAttributes(attributes);
                for (var i = 0; i < sortedAttributes.length; i += 1) {
                    output += ' ' + sortedAttributes[i][0] + '="' + sortedAttributes[i][1] + '"';
                }
            }

            output += '>';

            if (children.length > 0) {
                for (i = 0; i < children.length; i += 1) {
                    if (typeof(children[i]) === 'string') {
                        output += children[i];
                    } else {
                        output += parseHtml(children[i].type, children[i].attributes, children[i].children, children[i].content);
                    }
                }
            } else {
                output += content;
            }

            output += '</' + type + '>';
            return output;
        }

        var domElement = {
            init: function (type) {
                validateType(type);
                this._attributes = {};
                this._children = [];
                this._type = type;
                this._content = '';
                this._parent = null;
                return this;
            },
            appendChild: function (child) {
                validateChild(child);
                child.parent = this;
                this._children.push(child);
                return this;
            },
            addAttribute: function (name, value) {
                validateAttribute(name);
                this._attributes[name] = value;
                return this;
            },
            removeAttribute: function (attribute) {
                if (!this.attributes[attribute]) {
                    throw new Error('You cannot remove a non-existing attribute.')
                }

                delete this.attributes[attribute];

                return this;
            },
            get innerHTML() {
                return parseHtml(this.type, this.attributes, this.children, this.content);
            },
            get type() {
                return this._type;
            },
            get content() {
                return this._content;
            },
            set content(value) {
                if (this.children.length === 0) {
                    validateContent(value);
                    this._content = value;
                }
            },
            get children() {
                return this._children;
            },
            set children(value) {
                this._children = value;
            },
            get attributes() {
                return this._attributes;
            },
            set attributes(value) {
                this._attributes = value;
            },
            get parent() {
                return this._parent;
            },
            set parent(value) {
                validateParent(value);
                this._parent = value;
            }
        };

        return domElement;
    }());
    return domElement;
}

module.exports = solve;

//var domElement = solve();
//
//var meta = Object.create(domElement)
//    .init('meta')
//    .addAttribute('charset', 'utf-8');
//
//var div = Object.create(domElement)
//    .init('div')
//    .addAttribute('style', 'font-size: 42px');
//
//div.content = 'Hello, world!';
//
//var body = Object.create(domElement)
//    .init('body')
//    .appendChild(div)
//    .addAttribute('id', 'cuki')
//    .addAttribute('bgcolor', '#012345');
//
//var root = Object.create(domElement)
//    .init('theGuiltyTag')
//    .addAttribute('adata', 'do not')
//    .addAttribute('bdata', 'see')
//    .addAttribute('adata', 'me');
//
//console.log(body.innerHTML);