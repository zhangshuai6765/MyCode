using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.DesignModel
{
    public interface IEvent
    {
        event EventHandler HungryChanged;
    }

    public class aabbcc:IEvent
    {

        public event EventHandler HungryChanged;

       
    }

    public class ccbbaa
    {
        public void aa()
        {
            aabbcc dd = new aabbcc();
            dd.HungryChanged += dd_HungryChanged;
        }

        void dd_HungryChanged(object sender, EventArgs e)
        {
            
        }
    }


}
