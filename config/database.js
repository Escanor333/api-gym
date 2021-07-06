const mongoose = require('mongoose');

// Conect to database

const connect = ()=>{
    mongoose.connect(process.env.MONGO_URI, {
        useCreateIndex: true,
        useNewUrlParser: true,
        useUnifiedTopology: true 
    })
    .then(() => {
        console.log("success Connected to database")
    })
    .catch((err) => {
        console.log(err);
        process.exit(1);
    });
}


module.exports = { connect }