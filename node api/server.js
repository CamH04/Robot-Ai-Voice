// https://youtu.be/9OfL9H6AmhQ?t=465

var express = require('express')
const path = require('path');
var app = express()

const port = 3000

//sending html
app.get('/', function(req, res) {
  res.sendFile(path.join(__dirname, '/index.html'));
});


app.listen(port, () => {
  console.log(`Running On Port: ${port}`)
})