const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

const ejercicioSchema = Schema({
    id:{
        type: Number,
        required: true
    },
    dificultad: {
        type: String,
        required: true
    },
    musculo: {
        type: String,
        required: true
    },
    titulo: {
        type: String,
        required: true
    },
    repeticiones: {
        type: String,
        required: true
    },
})

module.exports = mongoose.model('Ejercicio', ejercicioSchema)