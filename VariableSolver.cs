using System;
using System.Collections.Generic;

namespace MRUV_Solver
{
    class VariableSolver
    {
        // Fields
        public string name;
        public string indexString;
        public float value;
        public bool hasValueOfVariable;

        // LinkedList que contiene los indexStrings.
        public static LinkedList<String> indexStrings = new LinkedList<String>();

        // Variable pública que contiene todos los objetos variable cuyos valores vamos a obtener
        // para la resolución del problema.
        public static LinkedList<VariableSolver> variables = new LinkedList<VariableSolver>();


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

            // Añadir el objeto a "variables"
            variables.AddLast(this);
        }


        // Función para averiguar si el problema es resoluble (o no).
        public static bool IsProblemSolvable()
        {
            int counter = 0;

            // Contar cuantas variables tenemos
            foreach (VariableSolver variable in variables)
            {
                if (variable.hasValueOfVariable)
                {
                    counter++;
                }
            }

            // Si tenemos 3 o más, lo podemos resolver
            if (counter >= 3)
            {
                return true;
            }
            return false;
        }


        // Método para limpiar las LinkedList.
        public static void CleanLinkedLists()
        {
            indexStrings.Clear();
            variables.Clear();
        }


        // Método para dar unaa solución al problema. 
        public static float SolveProblem(string index, VariableSolver vf, VariableSolver vi, VariableSolver acc, VariableSolver tim, VariableSolver dis)
        {
            // Vaalores de los objetos variable.
            float vfV = vf.value;
            float viV = vi.value;
            float accV = acc.value;
            float timV = tim.value;
            float disV = dis.value;

            // Escanear sobre el estado de los objetos variable
            bool hasVf = vf.hasValueOfVariable;
            bool hasVi = vi.hasValueOfVariable;
            bool hasAcc = acc.hasValueOfVariable;
            bool hasTim = tim.hasValueOfVariable;
            bool hasDis = tim.hasValueOfVariable;

            // Cadena else-if para resolver el problema.
            // Buscar Velocidad Final.
            if (index == "VF")
            {
                if (!hasVi) return accV * timV / 2 + disV / timV;
                else if (!hasAcc) return 2 * disV / timV - viV;
                else if (!hasTim) return (float) Math.Sqrt((viV * viV + 2 * accV * disV));
                else return viV + accV * timV;
            } 

            // Buscar Velocidad Inicial
            else if (index == "VI")
            {
                if (!hasVf) return disV / timV - accV * timV / 2;
                else if (!hasAcc) return 2 * disV / timV - vfV;
                else if (!hasTim) return (float) Math.Sqrt(vfV * vfV - 2 * accV * disV);
                else return vfV - accV * timV;
            } 

            // Buscar Aceleración
            else if (index == "A") 
            {
                if (!hasVf) return 2 * (disV - viV * timV) / (timV * timV);
                else if (!hasVi) return 2 * (vfV * timV - disV) / (timV * timV);
                else if (!hasTim) return ((vfV * vfV) - (viV * viV)) / (2 * disV);
                else return (vfV - viV) / timV;
            } 

            // Buscar Tiempo
            else if (index == "T")
            {
                if (!hasVf) return (float) (-viV + Math.Sqrt(viV * viV + 2 *accV * disV)) / accV;
                else if (!hasVi) return (float) (vfV + Math.Sqrt(vfV * vfV + 2 *accV * disV)) / accV;
                else if (!hasAcc) return 2 * disV / (vfV + viV);
                else return (vfV - viV) / accV;
            } 

            // Buscar Posición
            else if (index == "X")
            {
                if (!hasVf) return viV * timV + accV * (timV * timV) / 2;
                else if (!hasVi) return vfV * timV - accV * timV * timV / 2;
                else if (!hasAcc) return timV * (vfV + viV) / 2;
                else return (vfV * vfV - viV * viV) / (2 * accV);
            }

            // En caso de ninguna...
            else
            {
                throw new Exception("Por alguna razón tu problema no se pudo resolver. Esto no debería ejecutarse nunca.");
            }
        }
    }
}
