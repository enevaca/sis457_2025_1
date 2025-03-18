using DemoConsola;
// Esto es un comentario
/* Esto es un
 * un comentario en múltiples líneas
 */

// Variables
var variable = "Cualquier valor";
bool esActivo = false;
int entero = 20;
long enteroLargo = 7545454545455;
double real = 3.1416;
decimal real2 = 3.1416m;
float real3 = 3.1416f;
char caracter = 'A';
string cadena = "Esto es una cadena";
Int16 enteroCorto = 3;
Int32 entero2 = 20;
Int64 enteroLargo2 = 7545454545455;
DateTime fecha = DateTime.Now;

// Constantes
const double PI = 3.1416;
const string SIGLA_MATERIA = "SIS457";

// Operadores y expresiones
entero = 15;
entero2 += 7;
entero2 %= 2;
bool esPar = entero2 % 2 == 0;
int a = 3 + 6 * 4;
int b = (3 + 6) * 4;

// Conversiones y cadenas
string conversionCadena = Convert.ToString(real);
int conversionEntero = Convert.ToInt32("20");
bool conversionBooleano = Convert.ToBoolean("true");

string materia = "Fundamentos de la Programación";
string concatenar = materia + " - " + SIGLA_MATERIA;
string concatenar2 = $"{materia} - {SIGLA_MATERIA}";
int longitudCadena = materia.Length;
string mayusculas = concatenar.ToUpper();
string minusculas = concatenar.ToLower();
string invertir = new string(materia.Reverse().ToArray());
string quitarEspaciosExtremos = materia.Trim();
string reemplazo = materia.Replace(" ", "");
string subcadena = materia.Substring(0, 5);
string[] separar = materia.Split(" ");

// Estructuras de control
bool esMayorCero;
if (cadena.Length > 0) esMayorCero = true; 
else esMayorCero = false;
esMayorCero = cadena.Length > 0 ? true : false;
esMayorCero = cadena.Length > 0;

switch (materia) 
{
    case "Informática": materia += " - SIS457"; break;
    default: materia = materia.ToUpper(); break;
}

int contador = 0;
while (contador < 3)
{
    Console.WriteLine($"Contador while: {contador}");
    contador++;
}

do
{
    Console.WriteLine($"Contador do-while: {contador}");
    contador--;
} while (contador > 0);

for (int i = 0; i < separar.Length; i++)
{
    Console.WriteLine($"Ciclo for -> Posición {i}: {separar[i]}");
}

foreach (string item in separar)
{
    Console.WriteLine($"Ciclo foreach: {item}");
}

// Métodos
void saludo(string nombre)
{
    Console.WriteLine($"Hola {nombre}");
}
saludo("Juan");

string revertirCadena(string cadena)
{
    return new string(cadena.Reverse().ToArray());
}
Console.WriteLine(revertirCadena("HOLA"));

int suma(int a, int b)
{
    return a + b;
}

// Factoral
Console.WriteLine("Ingrese un número para calcular el factorial: ");
int numero = Convert.ToInt32(Console.ReadLine());
int factorial = 1;
for (int i = 2; i <= Math.Abs(numero); i++) factorial *= i;
if (numero < 0) factorial *= -1;
Console.WriteLine($"El factorial de {numero} es {factorial}");

// POO
Persona persona = new Persona();
persona.cedulaIdentidad = "1234567";
persona.nombres = "Juan";
persona.primerApellido = "Pérez";
persona.segundoApellido = "García";
persona.fechaNacimiento = DateTime.Parse("2000-03-10");
persona.celular = 77777777;
persona.saludar();
Console.WriteLine($"Edad: {persona.edad()}");

Estudiante estudiante = new Estudiante();
estudiante.cedulaIdentidad = "7654321";
estudiante.nombres = "María";
estudiante.primerApellido = "Cortez";
estudiante.segundoApellido = "Gómez";
estudiante.fechaNacimiento = DateTime.Parse("2015-05-20");
estudiante.carnetUniversitario = "35-2860";
estudiante.saludar();

int cantidadEstudiantes = 2;
List<Estudiante> estudiantes = new List<Estudiante>();

for (int i = 1; i <= cantidadEstudiantes; i++)
{
    var itemEstudiante = new Estudiante();
    Console.WriteLine($"Ingrese el Nombre del estudiante {i}:");
    itemEstudiante.nombres = Console.ReadLine();

    Console.WriteLine($"Ingrese el Primer Apellido del estudiante {i}:");
    itemEstudiante.primerApellido = Console.ReadLine();

    Console.WriteLine($"Ingrese el CU del estudiante {i}:");
    itemEstudiante.carnetUniversitario = Console.ReadLine();

    estudiantes.Add(itemEstudiante);
}

foreach (var item in estudiantes) item.saludar();
