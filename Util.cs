using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace
{

    public static class Util
    {
        public static string AskForString(string prompt, IUI ui)
        {
            bool success = false;
            string answer;

            do
            {
                ui.PrintString($"{prompt}: ");
                answer = ui.GetStringInput().ToUpper();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    ui.PrintString($"You must enter a {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt, IUI ui)
        {
            do
            {
                string input = AskForString(prompt, ui);
                if (uint.TryParse(input, out uint answer)) return answer;

            } while (true);
        }
    }
}