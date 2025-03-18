using DemoBiblioteca;
using DemoConsolaAvanzado;

// Biblioteca de Clases
int suma = Calculadora.sumar(30, 17);
int resta = Calculadora.restar(20, 15);
int mult = Calculadora.multiplicar(6, 8);
int division = Calculadora.dividir(16, 4);
int modulo = Calculadora.modulo(16, 4);
Console.WriteLine($"Suma: {suma}, Resta: {resta}...");

// Delegados
static string revertirCadena(string cadena)
{
    return new string(cadena.Reverse().ToArray());
}
Revertir revertir = revertirCadena;
Console.WriteLine(revertir("Hola Delegado"));

void imprimir(string cadena)
{
    Console.WriteLine($"Delegado Action: {cadena}");
}
Action<string> imp = imprimir;
imp("Fundamentos de la Programación");

Func<int, int, int> multiplicar = (n1, n2) => n1 * n2;
int multiplicacion = multiplicar(3, 4);
Console.WriteLine($"Func -> El resultado de la multiplicación es: {multiplicacion}");

Predicate<int> mayorEdad = edad => edad >= 18;
bool esMayorEdad = mayorEdad(22);
Console.WriteLine($"Predicate -> Mayor de edad: {esMayorEdad}");

// Genéricos
Generico<int, string> generico = new Generico<int, string>();
generico.campo1 = 56;
generico.campo2 = "Esto es un Genérico";
generico.imprimir(10);

Generico<bool, Automovil> generico2 = new Generico<bool, Automovil>();
generico2.campo1 = true;
generico2.campo2 = new Automovil();
generico2.imprimir(false);

// Interfaces
Automovil automovil = new Automovil();
automovil.acelerar(80);
automovil.frenar();
automovil.girar(15);

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
