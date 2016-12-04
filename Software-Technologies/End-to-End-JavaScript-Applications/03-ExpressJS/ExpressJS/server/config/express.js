var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    busboy = require('connect-busboy'),
    passport = require('passport'),
    stylus = require('stylus'),
    favicon = require('serve-favicon'),
    logger = require('morgan');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/server/views');
    //app.use(logger('dev'));
    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(busboy({ immediate: false }));
    app.use(session({ secret: 'magic unicorns', resave: true, saveUninitialized: true }));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(express.static(config.rootPath + '/public'));
    app.use(function (req, res, next) {
        if (req.session.error) {
            var msg = req.session.error;
            req.session.error = undefined;
            app.locals.errorMessage = msg;
        }
        else {
            app.locals.errorMessage = undefined;
        }
        
        next();
    });
    app.use(stylus.middleware(
        {
        src: config.rootPath + '/public',
        compile: function (str, path) {
            return stylus(str).set('filename', path);
        }
    }
));
    app.use(favicon(config.rootPath + '/public/favicon.ico'));
};