using System;
using System.Collections.Generic;

namespace MRUV_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear los objetos "Variable".
            VariableSolver vf = new VariableSolver("Velocidad Final", "VF");
            VariableSolver vi = new VariableSolver("Velocidad Inicial", "VI");
            VariableSolver acc = new VariableSolver("Aceleración", "A");
            VariableSolver tim = new VariableSolver("Tiempo", "T");
            VariableSolver dis = new VariableSolver("Distancia", "X");

            // Bucle de interfaz de usuario.
            do
            {
                // Imprimir la interfaz de consola
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("|===========: Buenos Días :===========|\n" + 
                                  "<><><><><><><><><><><><>><><><><><><><>\n" + 
                                  "╔═════════════════════════════════════╗\n" +
                                  "║   Nombre Variable ------- Índice    ║\n" +
                                  "╠═════════════════════════════════════╣\n" +
                                  "║   Velocidad Final --------- VF      ║\n" +
                                  "║   Velocidad Inicial ------- VI      ║\n" +
                                  "║   Aceleración ------------- A       ║\n" +
                                  "║   Tiempo ------------------ T       ║\n" +
                                  "║   Distancia --------------- X       ║\n" +
                                  "╚═════════════════════════════════════╝\n");
                Console.ResetColor();

                // Obtener la variable que se busca.
                while (true)
                {
                    Console.Write("Ingrese el Índice de la Variable que Busca: ");
                    string indexString = Console.ReadLine();
                    indexString = indexString.ToUpper();

                    // Ver si existe ese índice
                    if (VariableSolver.indexStrings.Contains(indexString)) break;

                    // En caso no exista
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor introduzca un índice válido.\n");
                    Console.ResetColor();
                }
            
            } while (false);
        }
    }

    class VariableSolver
    {
        // Fields
        public string name;
        public string indexString;
        public float value;
        public bool hasValueOfVariable;

        // LinkedList que contiene los indexStrings.
        public static LinkedList<String> indexStrings = new LinkedList<String>();

        // Constructor de Clase.
        public VariableSolver(string aName, string aIndexString, float aValue = 0, bool aHasValueOfVariable = false) 
        {
            // Asignar los valores.
            name = aName;
            indexString = aIndexString;
            value = aValue;
            hasValueOfVariable = aHasValueOfVariable;

            // Añadir el indexString a la LinkedList indexStrings.
            indexStrings.AddLast(aIndexString);

        }
    }
}
