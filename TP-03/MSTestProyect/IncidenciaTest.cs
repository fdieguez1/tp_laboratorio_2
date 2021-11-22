using Entidades;
using Entidades.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MSTestProyect
{
    [TestClass]
    public class IncidenciaTest
    {
        /// <summary>
        /// Prueba de carga de incidencia, se debe cargar una incidencia, utilizando la sobrecarga del operador +
        /// </summary>
        [TestMethod]
        public void TestCargaIncidencia()
        {
            Usuario auxUser = new Usuario(20, ESexo.Masculino);
            List<ErrorDetalle<int, string, DateTime>> errorDescriptions = new List<ErrorDetalle<int, string, DateTime>>();
            errorDescriptions.Add(new ErrorDetalle<int, string, DateTime>(1, "No se encontro la referencia al objeto", DateTime.Now));

            Error auxError = new Error("Null reference exception", errorDescriptions, ETipo.Crash);
            Incidencia auxIncidencia = new Incidencia(auxUser, auxError);
            bool cargaOk = NucleoDelSistema.Incidencias + auxIncidencia;
            Assert.IsTrue(cargaOk, "No se logro crear la incidencia");
            Assert.IsNotNull(NucleoDelSistema.Incidencias[0]);
            Assert.IsTrue(NucleoDelSistema.Incidencias[0].Id == 1);
            Assert.IsTrue(NucleoDelSistema.Incidencias[0].Usuario.Edad == 20);
            Assert.IsTrue(NucleoDelSistema.Incidencias[0].Usuario.Genero == ESexo.Masculino);
        }
        /// <summary>
        /// Prueba de cierre de incidencia, se debe cargar una incidencia y luego cambiar el estado de la misma a cerrada, utilizando la sobrecarga del operador -
        /// </summary>
        [TestMethod]
        public void TestCerrarIncidencia()
        {
            NucleoDelSistema.Incidencias.Clear();
            Usuario auxUser = new Usuario(20, ESexo.Masculino);
            List<ErrorDetalle<int, string, DateTime>> errorDescriptions = new List<ErrorDetalle<int, string, DateTime>>();
            errorDescriptions.Add(new ErrorDetalle<int, string, DateTime>(1, "No se encontro la referencia al objeto", DateTime.Now));

            Error auxError = new Error("Null reference exception", errorDescriptions, ETipo.Crash);
            Incidencia auxIncidencia = new Incidencia(auxUser, auxError);
            bool cargaOk = NucleoDelSistema.Incidencias + auxIncidencia;
            bool cierreOk = NucleoDelSistema.Incidencias - auxIncidencia;
            Assert.IsTrue(cargaOk, "No se logro crear la incidencia");
            Assert.IsTrue(cierreOk, "No se logro cerrar la incidencia");
            Assert.IsNotNull(NucleoDelSistema.Incidencias[0], "La incidencia es null");
            Assert.IsTrue(NucleoDelSistema.Incidencias[0].Estado == EEstado.Cerrada, "No se visualiza la incidencia como cerrada");
        }
    }
}
