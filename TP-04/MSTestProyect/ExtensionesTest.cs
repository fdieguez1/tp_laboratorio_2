using Entidades.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestProyect
{
    [TestClass]
    public class ExtensionesTest
    {
        /// <summary>
        /// Valido que las excepciones esperadas esten funcionando correctamente
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ColleccionNulaDaArgumentNullException()
        {
            int[] intArray = null;
            var result = intArray.FiltrarColleccion(x => x < 4);

            Assert.IsNull(result, "Filter result was not null, exception expected");
        }
        /// <summary>
        /// Valido que las excepciones esperadas esten funcionando correctamente
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DelegadoNuloDaArgumentNullException()
        {
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> evaluate = null;
            var result = intArray.FiltrarColleccion(evaluate);

            Assert.IsNull(result, "Filter result was not null, exception expected");
        }
        /// <summary>
        /// Valido que el filtro de extension este funcionando correctamente
        /// </summary>
        [TestMethod]
        public void Test_FiltrarColleccion_StringList()
        {
            List<string> stringList = new List<string>() { "uno", "dos", "tres", "cuatro", "cinco" };

            List<string> result = new List<string>(stringList.FiltrarColleccion(x => x.Contains("c")));
            List<string> onlyCList = stringList.Where(w => w.Contains("c")).ToList();
            
            foreach (string item in onlyCList)
            {
                Assert.IsTrue(result.Contains(item));
            }
            Assert.IsFalse(result.Any(a => !a.Contains("c")));
            Assert.IsNotNull(result, "Filter result was null");
            foreach (string str in result)
            {
                Assert.IsTrue(str.Contains("o"));
            }
        }
    }
}
