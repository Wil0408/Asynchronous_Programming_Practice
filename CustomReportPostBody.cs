using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// api/CustomReport Method post body class definition
    /// </summary>
    public class CustomReportPostBody
    {
        /// <summary>
        /// dtno
        /// </summary>
        public int Dtno { get; set; }

        /// <summary>
        /// ftno
        /// </summary>
        public int Ftno { get; set; }

        /// <summary>
        /// params
        /// </summary>
        public string? Params { get; set; }

        /// <summary>
        /// keyMap
        /// </summary>
        public string? KeyMap { get; set; }

        /// <summary>
        /// assignSpic
        /// </summary>
        public string? AssignSpid { get; set; }
    }
}
