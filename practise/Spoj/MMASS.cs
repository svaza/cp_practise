
using System;
using System.Collections.Generic;

namespace Practise.Spoj
{
    public class MMASS
    {
        public static void Main(string[] args)
        {
            string formula = Console.ReadLine().Trim().Split(' ')[0];
            Console.Write(CalculateMass(formula));
        }

        private static int CalculateMass(string formula)
        {
            int c = 0;
            Stack<int> scopeStack = new Stack<int>(formula.Length);
            scopeStack.Push(0); // root scope
            Stack<char> formulaStack = new Stack<char>(formula.Length);
            while (c < formula.Length)
            {
                bool isGroupRep = false;
                int reps = (int)char.GetNumericValue(formula[c]);
                if (c > 0 && formula[c - 1] == ')') // group was ended before current element
                {
                    var scope = scopeStack.Pop();
                    int parentScope = 0;
                    if (scopeStack.Count > 0) parentScope = scopeStack.Pop();
                    scopeStack.Push(parentScope + (scope * (reps < 0 ? 1 : reps)));
                    isGroupRep = reps > -1;
                }

                if (formula[c] == '(')
                {
                    scopeStack.Push(0);
                    formulaStack.Push(formula[c]);
                }
                else if (formula[c] == ')')
                {
                    var scope = scopeStack.Pop();
                    scopeStack.Push(scope + CalculateGroupMass(formulaStack));
                }
                else if(!isGroupRep)
                {
                    formulaStack.Push(formula[c]);
                }

                // calculate the remaining elements at root scope level
                if (c == formula.Length - 1 && formulaStack.Count > 0)
                {
                    var scope = scopeStack.Pop();
                    scopeStack.Push(scope + CalculateGroupMass(formulaStack));
                }

                c++;
            }

            // The latest element in the scope stack is the mass of molecule
            return scopeStack.Pop();
        }

        private static int CalculateGroupMass(Stack<char> stack)
        {
            int totalMass = 0;
            while (stack.Count > 0)
            {
                char element = stack.Pop();
                if (element == '(') break;
                int mass = 0;
                if (TryGetElementMass(element, out mass))
                {
                    totalMass += mass;
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        int rep = mass;
                        if (TryGetElementMass(stack.Pop(), out mass))
                        {
                            totalMass += mass * rep;
                        }
                        else
                        {
                            // this should not have happened, probably input is wrong
                            throw new ApplicationException("Improper input - Invalid molecule grouping");
                        }
                    }
                }
            }
            return totalMass;
        }

        private static bool TryGetElementMass(char element, out int mass)
        {
            if (element == 'O')
            {
                mass = 16;
                return true;
            }
            if (element == 'H')
            {
                mass = 1;
                return true;
            }
            if (element == 'C')
            {
                mass = 12;
                return true;
            }

            mass = (int)char.GetNumericValue(element);
            return false;
        }

    }
}