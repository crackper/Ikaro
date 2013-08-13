using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Microsoft.Practices.Prism.Events;

namespace Ikaros.Infrastructure.Toolbar
{
    public class ToolbarEvent:CompositePresentationEvent<ToolbarItem>
    {
    }
}
