'use strict'

var chatDb = require('./chat-db.js');
var connectionString = 'mongodb://localhost:27017/ChatDB';

chatDb.init(connectionString);

var newUser = {
    user: 'DonchoMinkov', 
    pass: '123456q'
}

var secondUser = {
    user: 'NikolayKostov', 
    pass: '123456q'
}

chatDb.registerUser(newUser);
chatDb.registerUser(secondUser);

var message = {
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
}

//uncomment to test after users have been registered
chatDb.sendMessage(message);

var messageRequest = {
    'with': 'DonchoMinkov',
    and: 'NikolayKostov'
}
//uncomment to test after message has been sent
chatDb.getMessages(messageRequest);

