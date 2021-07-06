var express = require('express');
var router = express.Router();
var ejercicioController = require('../controllers/EjercicioController');

router.get('/', ejercicioController.getAll)
router.get('/:idEjercicio', ejercicioController.getOne)
router.post('/', ejercicioController.add);

module.exports = router;