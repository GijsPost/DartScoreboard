using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class CheckoutCalculator {

        private const int highestThrow = 20;

        private static Dictionary<int, string> map;

        public static string Calculate(int input)
        {
            // Create the map one time only
            if (map == null)
            {
                createMap();
            }

            // If the value is present in the map of high values, return that one.
            if (map.ContainsKey(input)) {
                return map[input];
            }
            
            if (input == 0 || input == 1)
            {
                return "";
            }

            if (CanBeDouble(input))
            {
                return "D" + (input / 2);
            } else
            {
                int oneLower = input - 1;
                if (CanBeDouble(oneLower))
                {
                    return "1, D" + (oneLower / 2);
                }
            }

            if (CanBeTriple(input))
            {
                int dividedByThree = input / 3;
                Debug.Log(dividedByThree);
                return dividedByThree + ", D" + dividedByThree;
            } else
            {
                int oneLower = input - 1;
                if (CanBeTriple(oneLower))
                {
                    int dividedByThree = oneLower / 3;
                    return "1, " + dividedByThree + ", D" + dividedByThree;
                }
            }

            if (map.ContainsKey(input))
            {
                return map[input];
            }

            return "";
        }

        private static bool CanBeDouble(decimal input)
        {
            if (IsLowerThanMaxThrow(input / 2))
            {
                return IsWhole(input / 2);
            }
            return false;
        }

        private static bool CanBeTriple(decimal input)
        {
            if (IsLowerThanMaxThrow(input / 3))
            {
                return IsWhole(input / 3);
            }
            return false;
        }

        private static bool IsWhole(decimal input)
        {
            Debug.Log(input);
            return input % 1 == 0;
        }

        private static bool IsLowerThanMaxThrow(decimal input)
        {
            return input <= highestThrow;
        }

        private static void createMap()
        {
            map = new Dictionary<int, string>
            {
                { 170, "T20, T20, BULL" },
                { 167, "T20, T19, BULL" },
                { 164, "T20, T18, BULL" },
                { 161, "T20, T17, BULL" },
                { 160, "T20, T20, D20" },
                { 158, "T20, T20, D19" },
                { 157, "T20, T19, D20" },
                { 156, "T20, T20, D18" },
                { 155, "T20, T19, D19" },
                { 154, "T20, T18, D20" },
                { 153, "T20, T19, D18" },
                { 152, "T20, T20, D16" },
                { 151, "T20, T17, D20" },
                { 150, "T20, T18, D18" },
                { 149, "T20, T19, D16" },
                { 148, "T20, T20, D14" },
                { 147, "T20, T17, D18" },
                { 146, "T20, T18, D16" },
                { 145, "T20, T19, D14" },
                { 144, "T20, T20, D12" },
                { 143, "T20, T17, D16" },
                { 142, "T20, T14, D20" },
                { 141, "T20, T19, D12" },
                { 140, "T20, T20, D10" },
                { 139, "T20, T13, D20" },
                { 138, "T20, T18, D12" },
                { 137, "T20, T19, D10" },
                { 136, "T20, T20, D8" },
                { 135, "T20, T17, D12" },
                { 134, "T20, T16, D13" },
                { 133, "T20, T19, D8" },
                { 132, "T20, T16, D12" },
                { 131, "T19, T14, D16" },
                { 130, "T20, T20, D5" },
                { 129, "T19, T16, D12" },
                { 128, "T18, T14, D16" },
                { 127, "T20, T17, D8" },
                { 126, "T19, T19, D6" },
                { 125, "T18, T19, D7" },
                { 124, "T20, T14, D11" },
                { 123, "T19, T16, D9" },
                { 122, "T18, T18, D7" },
                { 121, "T20, T11, D14" },
                { 120, "T20, 20, D20" },
                { 119, "T19, T12, D13" },
                { 118, "T20, 18, D20" },
                { 117, "T19, 20, D20" },
                { 116, "T19, 19, D20" },
                { 115, "T20, 15, D20" },
                { 114, "T19, 17, D20" },
                { 113, "T19, 16, D20" },
                { 112, "T20, T12, D8" },
                { 111, "T19, 14, D20" },
                { 110, "T20, T10, D10" },
                { 109, "T20, 9, D20" },
                { 108, "T20, 8, D20" },
                { 107, "T20, 7, D20" },
                { 106, "T20, 6, D20" },
                { 105, "T20, 5, D20" },
                { 104, "T20, 4, D20" },
                { 103, "T20, 3, D20" },
                { 102, "T20, 2, D20" },
                { 101, "T20, 1, D20" },
                { 100, "T20, D20" },
                { 99, "T19, 10, D16" },
                { 98, "T20, D19" },
                { 97, "T19, D20" },
                { 96, "T20, D18" },
                { 95, "T19, D19" },
                { 94, "T18, D20" },
                { 93, "T19, D18" },
                { 92, "T20, D16" },
                { 91, "T17, D20" },
                { 90, "T20, D15" },
                { 89, "T19, D16" },
                { 88, "T20, D14" },
                { 87, "T17, D18" },
                { 86, "T18, D16" },
                { 85, "T15, D20" },
                { 84, "T20, D12" },
                { 83, "T17, D16" },
                { 82, "BULL, D16" },
                { 81, "T19, D12" },
                { 80, "T20, D10" },
                { 79, "T19, D11" },
                { 78, "T18, D12" },
                { 77, "T19, D10" },
                { 76, "T20, D8" },
                { 75, "T17, D12" },
                { 74, "T14, D16" },
                { 73, "T19, D8" },
                { 72, "T16, D12" },
                { 71, "T13, D16" },
                { 70, "T18, D8" },
                { 69, "T19, D6" },
                { 68, "T16, D10" },
                { 67, "T9, D20" },
                { 66, "T10, D18" },
                { 65, "T11, D16" },
                { 64, "T16, D8" },
                { 63, "T13, D12" },
                { 62, "T10, D16" },
                { 61, "T15, D8" }
            };
        }
    }
}
