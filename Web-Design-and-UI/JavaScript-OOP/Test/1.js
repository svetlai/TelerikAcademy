function solve() {
    var domElement = (function () {
        var domElement = {};
        Object.defineProperties(domElement, {
            init: {
                value: function (type) {
                    this.type = type;
                    this.content;
                    this.attributes;
                    this.children;
                    this.parent;
                    this.innerHTML;
                    return this;
                }
            },
            appendChild: {
                set : function (child) {
                    if (checkIfString(child) || checkIfDomEl(child)) {
                        if (!!this.content) {
                            this.content = null;
                        }

                        if (!this.children) {
                            this.children = [];
                        }

                        child.parent = this;

                        this.children.push(child);
                    } else {
                        throw new Error('Invalid child appended!')
                    }

                    return this;
                }
            },
            addAttribute: {
                set: function(name, value){
                    var reducedName = name.replace(/-/g, '')
                    if(checkIfString(name) && (!containsForboddenChars(reducedName))) {
                        if(!this._attributes) {
                            this._attributes = {};
                        }
                        this._attributes[name] = value;
                    } else {
                        throw new Error ('Invalid attribute name entered!');
                    }
                    return this;
                }
            },
            removeAttribute: {
                set: function(attribute) {
                    if(checkIfExistingAttribute(attirbute, this)){
                        delete this.attributes[attribute];
                    } else {
                        throw new Error('You are trying to remove an unexisting attribute!');
                    }
                    return this;
                }
            },



        get innerHTML(){
            var result;

            result = '\<' + this.type;
            result += getAttributes(this);
            result += '\>';
            result += getChildrenOrContent(this);
            result += '\<\/' + this.type + '\>'

            return result;
        },

        set type(value) {
            if ((typeof value == 'string' || value instanceof String) &&
                value && (!value.match(/\W/))) {
                this._type = value;
            } else {
                throw new Error('Invalid type entered!');
            }
        },
        get type() {
            return this._type;
        },

        set content(value) {
            if (!this.children) {
                if (checkIfString(value)) {
                    this._content = value;
                } else {
                    throw new Error('Invalid content entered!');
                }
            }
        },
        get content() {
            return this._content;
        },

        set attributes(value) {
            var i,
                len = value.len;

            this.attributes = {};

            for (i = 0; i < len; i++) {
                this.addAttribute(value[i]);
            }
        },
        get attributes() {
            return this._attributes;
        },

        set children(value) {
            var i,
                len = value.len;

            this._children = [];

            for (i = 0; i < len; i++) {
                this.appendChild(value[i]);
            }
        },
        get children() {
            return this._children;
        },

        set parent(value) {
            if (checkIfDomEl(value)) {
                this._parent = value;
            } else {
                throw new Error('You have entered invalid parent');
            }

        },
        get parent() {
            return this._parent;
        }
    });

    function checkIfString(obj) {
        if ((typeof obj == 'string' || obj instanceof String) && obj) {
            return true;
        }

        return false;
    }

    function checkIfDomEl(obj) {
        if (domElement.isPrototypeOf(obj)) {
            return true;
        }

        return false;
    }

    function checkIfExistingAttribute(attribute, self) {
        if (checkIfString(attribute)) {
            for (var attr in self.attributes) {
                if (attr == attribute) {
                    return true;
                }
            }

            return false;
        } else {
            return false;
        }
    }

    function containsForbiddenChars(str) {
        if (str.match(/\W/)) {
            return true;
        }

        return false;
    }

    function isEmpty(obj) {
        for(var key in obj) {
            if (obj.hasOwnProperty(key)) {
                return false;
            }
        }

        return true;
    }

    function getAttributes(self) {
        var attributesString = '',
            i,
            key,
            keys = [],
            len;

        if (!isEmpty(self.attributes)) {
            for (key in self.attributes)
            {
                if (self.attributes.hasOwnProperty(key))
                {
                    keys.push(key);
                }
            }

            keys.sort();
            len = keys.length;

            for (i = 0; i < len; i++)
            {
                attributesString += ' ' + keys[i] + '\=\"' + self.attributes[keys[i]] + '\"';
            }
        }

        return attributesString;
    }

    function getChildrenOrContent(self) {
        var childernOrContentToString = '',
            i,
            len;

        if (self.children && self.children.length > 0) {
            len = self.children.length;
            for (i = 0; i < len; i++) {
                if (checkIfString(self.children[i])) {
                    childernOrContentToString += self.children[i];
                } else {
                    childernOrContentToString += self.children[i].innerHTML;
                }
            };
        } else if (self.content) {
            childernOrContentToString += self.content;
        }

        return childernOrContentToString;
    }

    return domElement;
})();
    return domElement;
};