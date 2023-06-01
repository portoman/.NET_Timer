// See https://aka.ms/new-console-template for more information

//.NET CORE
string prueba = "2023-512985123123123123123123123123123123123123123";

int numeroPalabras = prueba.Length;

int limite = 20;

string hola = (numeroPalabras > limite) ? prueba.Substring(0, 20) : prueba;

int pp = hola.Length;
//Console.WriteLine(hola);

Console.WriteLine(
    "imprimir prueba");
Timer.Main();

List<int> parts = new List<int>();

// Add parts to the list.
parts.Add(1);
parts.Add(3);
parts.Add(4);

Boolean crawlerProcesando = true;

if (!crawlerProcesando)
{
    foreach (int i in parts)
    {
        crawlerProcesando = true;
        Console.WriteLine(i);
        crawlerProcesando = false;
    }
}









