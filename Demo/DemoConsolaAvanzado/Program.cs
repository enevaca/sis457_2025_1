using DemoConsolaAvanzado;

// Clases Abstractas
// FiguraGeometrica figura = new FiguraGeometrica(); // No se puede instancia
Cuadrado cuadrado = new Cuadrado(5);
Console.WriteLine("Área del cuadrado: " + cuadrado.area());
Console.WriteLine("Perímetro del cuadrado: " + cuadrado.perimetro());

Rectangulo rectangulo = new Rectangulo(10, 5);
Console.WriteLine("Área del rectángulo: " + rectangulo.area());
Console.WriteLine("Perímetro del rectángulo: " + rectangulo.perimetro());

// Manejo de Excepciones (try/catch/finally)
int dividendo, divisor, resultado;
try
{
    Console.WriteLine("Introduzca el dividendo: ");
    dividendo = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Introduzca el divisor: ");
    divisor = Convert.ToInt32(Console.ReadLine());

    resultado = dividendo / divisor;
    Console.WriteLine("El resultado es: " + resultado);
}
catch (DivideByZeroException)
{
    Console.WriteLine("No se puede dividir por cero");
}
catch (Exception ex)
{
    Console.WriteLine("Error en la división " + ex.Message);
}
finally
{
    resultado = 0;
    Console.WriteLine("Finalizado");
}

// Programación asíncrona
testAsyncAwaitMethod();
Console.WriteLine("Presione cualquier tecla para salir");
Console.ReadKey();

static async void testAsyncAwaitMethod()
{
    await longRunningMethod();
}

static async Task<int> longRunningMethod()
{
    Console.WriteLine("Iniciando tarea de larga duración");
    await Task.Delay(5000);
    Console.WriteLine("Fin de la tarea de larga duración");
    return 0;
}

// Inmutabilidad
Inmutable inmutable = new Inmutable(2014);
