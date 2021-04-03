using System;

namespace MRUV_Solver
{
    class Program
    {
        static void Main(string[] args)
        {

            // Bucle de interfaz de usuario.
            do
            {
                // Crear los objetos "Variable".
                VariableSolver vf = new VariableSolver("Velocidad Final", "VF");
                VariableSolver vi = new VariableSolver("Velocidad Inicial", "VI");
                VariableSolver acc = new VariableSolver("Aceleración", "A");
                VariableSolver tim = new VariableSolver("Tiempo", "T");
                VariableSolver dis = new VariableSolver("Distancia", "X");

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

                // Declaramos la variable aquí indexString para que esté presente en el scope del do-while.
                string indexString;

                // Obtener la variable que se busca.
                while (true)
                {
                    Console.Write("Ingrese el Índice de la Variable que Busca: ");
                    indexString = Console.ReadLine();
                    indexString = indexString.ToUpper();

                    // Ver si existe ese índice.
                    if (VariableSolver.indexStrings.Contains(indexString)) break;

                    // En caso no exista.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor introduzca un índice válido.\n");
                    Console.ResetColor();

                }

                // Eliminar de la LinkedList el objeto variable que buscamos.
                foreach (VariableSolver variable in VariableSolver.variables)
                {
                    if (variable.indexString == indexString)
                    {
                        VariableSolver.variables.Remove(variable);
                        break;
                    }
                }

                // Obtener valores de las demás variables
                foreach (VariableSolver variable in VariableSolver.variables)
                {
                    // Preguntamos si posee la variable.
                    Console.Write($"\n¿Posee la variable \"{variable.name}\"? (S/N): ");
                    string userHasVariable = Console.ReadLine();
                    userHasVariable = userHasVariable.ToUpper();

                    if (userHasVariable == "S" || userHasVariable == "Y")
                    {
                        // Bucle para el try-catch
                        while (true)
                        {
                            try
                            {
                                // Obtener el valor de la variable
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Introduzca el valor de la variable: ");
                                variable.value = (float) Convert.ToDouble(Console.ReadLine());
                                Console.ResetColor();
                                break;
                            }
                            // En caso de error 
                            catch (System.Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Por favor introduzca un número.\n");
                                Console.ResetColor();
                            }
                        }

                    } 
                }

                // ¿Es posible resolver el problema?
                if (VariableSolver.IsProblemSolvable() == true)
                {
                    // Resolver el problema
                    // ===
                    // Aquí debería estar la función para resolver el pinche problema..
                    // ===

                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"El resultado es: pinche_resultado");
                    Console.ResetColor();
                }

                // ¿Desea seguir?
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n¿Desea salir del programa? (S/N): ");
                string exitProgram = Console.ReadLine();
                exitProgram = exitProgram.ToUpper();

                // Salir del Programa
                if (exitProgram == "S" || exitProgram == "Y") break;

                // ¿Limpiar consola?
                Console.Write("\n¿Desea limpiar la consola? (S/N): ");
                string cleanConsole = Console.ReadLine();
                cleanConsole = cleanConsole.ToUpper();

                // Limpiar Consola
                if (cleanConsole == "S" || cleanConsole == "Y") Console.Clear();

                // Limpiar las Listas
                VariableSolver.CleanLinkedLists();

            } while (true);

            // Salir
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ResetColor();
            Console.ReadKey(true);

        }
    }
}
