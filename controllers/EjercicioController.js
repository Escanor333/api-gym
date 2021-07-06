var Ejercicio = require("../models/ejercicio");

module.exports.getOne = (req, res, next) => {
  Ejercicio.findOne({
    id: req.params.idEjercicio,
  })
    .then((foundEjercicio) => {
      if (foundEjercicio) return res.status(200).json(foundEjercicio);
      else return res.status(400).json(null);
    })
    .catch((err) => {
      next(err);
    });
};

module.exports.getAll = (req, res, next) => {
  var perPage = Number(req.query.size) || 5,
    page = req.query.page > 0 ? req.query.page : 0;

  var sortProperty = req.query.sortby || "id",
    sort = req.query.sort || "asc";

  Ejercicio.find({})
    .limit(perPage)
    .skip(perPage * page)
    .sort({ [sortProperty]: sort })
    .then((ejercicios) => {
      return res.status(200).json(ejercicios);
    })
    .catch((err) => {
      next(err);
    });
};

module.exports.add = (req, res, next) => {
  const { id, dificultad, musculo, titulo, repeticiones } = req.body;

  let new_ejercicio = new Ejercicio({
    id,
    dificultad,
    musculo,
    titulo,
    repeticiones,
  });
  return new_ejercicio
    .save()
    .then((newEjercicio) => {
      res.status(201).json(newEjercicio);
    })
    .catch((err) => {
      next(err);
    });
};
