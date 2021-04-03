using System;

namespace MRUV_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Imprimir la interfaz de consola
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

                // Obtener la variable que se busca
                while (true)
                {
                    string indexString = Console.ReadLine();
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

        // Constructor de Clase
        public VariableSolver(string aName, string aIndexString, float aValue, bool aHasValueOfVariable) 
        {
            // Asignar los valores
            name = aName;
            indexString = aIndexString;
            value = aValue;
            hasValueOfVariable = aHasValueOfVariable;
        }
    }
}
