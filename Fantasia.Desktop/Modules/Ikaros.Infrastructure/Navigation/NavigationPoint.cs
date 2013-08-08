using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikaros.Infrastructure.Navigation
{
    public class NavigationPoint
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool ShowInJumpList { get; set; }
        public string Icon { get; set; }

        public string CreateArg()
        {
            return Name.Replace(' ', '_') + "_" + Category.Replace(' ', '_');
        }
    }
}
