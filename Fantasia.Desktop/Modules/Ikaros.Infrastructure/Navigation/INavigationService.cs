using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikaros.Infrastructure.Navigation
{
    public interface INavigationService
    {
        void RegisterNavigationPoint(NavigationPoint point);
        NavigationPoint[] GetNavigationPoints();
        NavigationPoint GetNavigationPointFromArg(string arg);

        void CreateJumpList();
        void ClearJumpList();
    }
}
