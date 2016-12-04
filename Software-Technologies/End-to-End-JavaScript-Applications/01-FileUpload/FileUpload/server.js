var http = require('http');
var fs = require('fs');
var formidable = require('formidable');
var url = require('url');

var port = 1234;

var fileName;
var filePath;

fs.readFile('./index.html', function (err, html) {
    if (err) {
        throw err;
    }
    
    http.createServer(function (req, res) {
        if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            // parse a file upload
            var form = new formidable.IncomingForm();
            form.encoding = 'utf-8';
            
            if (!fs.existsSync('uploads')) {
                fs.mkdirSync('uploads');
            }
            
            form.uploadDir = "./uploads";
            form.keepExtensions = true;
            form.multiples = false;
            
            form.on('error', function (err) {
                res.write(err);
                console.error(err);
            });
            
            form.parse(req, function (err, fields, files) {    
 
            });
            
            form.on('fileBegin', function (name, file) {
                //rename the incoming file to the file's name
                file.path = form.uploadDir + "/" + file.name;
            });
            
            form.on('progress', function (bytesReceived, bytesExpected) {
                var completed = (bytesReceived / bytesExpected) * 100;
                res.write('-');
                if (completed == 100) {
                    fileName = this.openedFiles[0].name;
                    filePath = this.openedFiles[0].path;
                    
                    res.write("<p>File Upload Complete</p>");
                    res.write('<a href="' + filePath + '">Download link</a>');
                    res.end();
                }
            });
        } else if (req.url == '/uploads/' + fileName) {
            var stat = fs.statSync(filePath);
            res.writeHead(200, {
                'Content-Length': stat.size
            });
            var readStream = fs.createReadStream(filePath);
            readStream.pipe(res);
    
            fs.readFile(filePath, function (err, data) {
                if (err) {
                    throw err;
                }
                //console.log(data);
            });

        } else {
            res.writeHeader(200, { "Content-Type": "text/html" });
            res.write(html);
            res.end();
        }

    }).listen(port);
});
console.log('Server is running on port ' + 1234);