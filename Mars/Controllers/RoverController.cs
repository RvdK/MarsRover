using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mars.Plateau;
using Microsoft.AspNetCore.Mvc;

namespace Mars.Controllers
{
    [Produces("application/json")]
    [Route("api/rover")]
    public class RoverController : Controller
    {

        [HttpPost]
        public void Post(string command)
        {
            Parse(command);
        }

        [Route("debug")]
        [HttpPost]
        public string Debug(string command)
        {
            return Parse(command);
        }

        private static string Parse(string command)
        {
            if (!ValidateInput(command))
                return "invalid syntax";

            var lines = command.Split('\n');

            var grid = Parser.ParseGrid(lines[0]);

            for (var i = 0; i < (lines.Length - 1) / 2; ++i)
            {
                var j = 2 * i + 1;
                if (!Parser.ParseRover(lines[j], lines[j + 1], grid))
                    return grid.DebugString();
            }

            grid.MoveRovers();

            return grid.DebugString();
        }

        // this is only syntax validation
        private static bool ValidateInput(string input)
        {
            // regex logic is as follows: 
            //                              1 line with 2 integers,
            //                              n sets of lines with the first line containing 2 integers and 1 cardinal direction and the second line consisting of a string with only command characters. 
            //                              1 set that is the same as the previous set(s) but has no linebreak at the end (this forces that at least one rover should be present in the command)
            
            var regex = new Regex(
                "([1-9]+) ([1-9]+)[\r\n](([1-9]+) ([1-9]+) ([NSEW])[\r\n]([LMR])*[\r\n])*(([1-9]+) ([1-9]+) ([NSEW])[\r\n]([LMR])*)$");
            return regex.IsMatch(input);
        }
    }
}