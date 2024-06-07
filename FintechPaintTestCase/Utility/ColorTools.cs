using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FintechCase.Utility
{
    internal class ColorTools
    {

        public static Color findColorByName(string name)
        {
            switch (name)
            {
                case "Red":

                    return Color.Red;
                    break;
                case "Blue":

                    return Color.Blue;
                    break;
                case "Green":

                    return Color.Green;
                    break;
                case "Orange":

                    return Color.Orange;
                    break;
                case "Black":

                    return Color.Black;
                    break;
                case "Yellow":

                    return Color.Yellow;
                    break;
                case "Purple":

                    return Color.Purple;
                    break;
                case "Brown":

                    return Color.Brown;
                    break;
                case "White":
                    return Color.White;
                    break;
                default:
                    return Color.Wheat;
                    break;
            }
        }
    }
}
