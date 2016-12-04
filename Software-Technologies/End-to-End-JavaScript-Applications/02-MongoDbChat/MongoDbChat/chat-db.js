'use strict'

var mongoose = require('mongoose');
var User = require('./models/user.js');
var Message = require('./models/message.js');

module.exports = {
    init: function (connectionString) {
        mongoose.connect(connectionString);
        var db = mongoose.connection;
        
        db.on('error', console.error.bind(console, 'Connection error: '));
        db.once('open', function (err) {
            if (err) {
                console.error(err.message);
            }
            
            console.log('Connected to: ' + connectionString);
        });
    },
    registerUser: function (user) {
        var newUser = new User({
            username: user.user,
            password: user.pass
        });
        
        return newUser.save(function (err, result) {
            if (err) {
                console.log(err.message);
                return err;
            }
            console.log('Registered user:' + result);
            return result;
        });
    },
    sendMessage: function (message) {
        User.findOne({ 'username': message.from }, function (err, result) {
            if (err) {
                return err;
            }
            
            var from = result.username;
            
            User.findOne({ 'username': message.to }, function (err, result) {
                if (err) {
                    return err;
                }
                
                var to = result.username;


                var newMessage = new Message({
                    from: from,
                    to: to,
                    text: message.text
                });

                newMessage.save(function (err, result) {
                    if (err) {
                        console.log(err.message);
                        return err;
                    }
                    console.log('Message sent:' + result);
                    return result;
                });
            });
        });
    },
    getMessages: function (request) {
        var messageWith;
        var messageAnd;
        
        User.findOne({ 'username': request['with'] }, function (err, result) {
            if (err) {
                return err;
            }
            
            messageWith = result.username;
        });
        
        User.findOne({ 'username': request.and }, function (err, result) {
            if (err) {
                return err;
            }
            
            messageAnd = result.username;
        });
        
        Message.find()
                .where('from').equals(messageWith)  //.in([messageWith, messageAnd])
                .where('to').equals(messageAnd)
                .select('text')
                .exec(function (err, result) {
            if (err) {
                console.log(err.message);
                        return err;
                    }
                    console.log('All messages: ' + result);
                    return result;
        });
    }
}