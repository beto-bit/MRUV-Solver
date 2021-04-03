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

        // Función para averiguar si el problema es resoluble (o no)
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
    }
}
