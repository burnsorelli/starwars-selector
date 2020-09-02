using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.Methods
{
    class ResetUniqueId
    {

        public static void Reset()
        {
            if (TrackerVariables.TrackedVariables.PilotList.Count <= 0)
            {
                TrackerVariables.TrackedVariables.UniqueID = 1;
            }
        }

        
    }
}
