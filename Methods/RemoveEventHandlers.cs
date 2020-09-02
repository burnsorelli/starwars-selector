using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace Xwing.Methods
{
    class RemoveEventHandlers
    {
        public static void RemoveAllHandlers(Button _button)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(_button);
            PropertyInfo pi = _button.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(_button, null);
            list.RemoveHandler(obj, list[obj]);
        }
    }
}
