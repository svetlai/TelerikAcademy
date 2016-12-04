'use strict'

var mongoose = require('mongoose');

var messageSchema = new mongoose.Schema({
    from: String,
    to: String,
    text: String
});

var Message = mongoose.model('Message', messageSchema);

module.exports = Message;