function solve(){
var playlists = (function(){
        var playlist = function(){

        }

    return playlist;
    });
}

var animal = (function (){
    var animal = Object.defineProperty (this, 'makeNoise', {
        value: function () {
            console.log('The ' + this.type +' makes noise"' + this.noise + '"');
        }
    });
    return animal;
}());

var dog = (function (parent){
    var dog = Object.defineProperties(parent, {
        type: {
            value: 'dog'
        },
        noise:  {
            value: 'Djaf'
        },
        barg: {
            value: function () {
                console.log('Makq!')
            }
        }
    } );
    return dog;
}(animal));

dog.barg();