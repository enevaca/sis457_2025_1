using DemoBiblioteca;

namespace DemoPruebaUnitaria
{
    [TestClass]
    public sealed class TestCalculadora
    {
        [TestMethod]
        public void TestSuma()
        {
            // Definimos las variables --> Arrage
            int numero1 = 8;
            int numero2 = 7;

            // Ejecutamos la prueba --> Act
            int resultado = Calculadora.sumar(numero1, numero2);

            // Comprobamos los resultados --> Assert
            int resultadoEsperado = 15;
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestResta()
        {
            int numero1 = 15, numero2 = 7;
            int resultado = Calculadora.restar(numero1, numero2);
            Assert.AreEqual(8, resultado);
        }

        [TestMethod]
        public void TestMultiplicacion()
        {
            int numero1 = 4, numero2 = 5;
            int resultado = Calculadora.multiplicar(numero1, numero2);
            Assert.AreEqual(20, resultado);
        }

        [TestMethod]
        public void TestDivision()
        {
            int numero1 = 30, numero2 = 5;
            int resultado = Calculadora.dividir(numero1, numero2);
            Assert.AreEqual(6, resultado);
        }

        [TestMethod]
        public void TestDivisionPorCero()
        {
            int numero1 = 15, numero2 = 0;
            Assert.ThrowsException<DivideByZeroException>(() => Calculadora.dividir(numero1, numero2));
        }

        [TestMethod]
        public void TestModulo()
        {
            int numero1 = 30, numero2 = 7;
            int resultado = Calculadora.modulo(numero1, numero2);
            Assert.AreEqual(2, resultado);
        }
    }
}
