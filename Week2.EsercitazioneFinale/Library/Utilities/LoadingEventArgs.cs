using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities
{
    public class LoadingEventArgs : EventArgs
    {
        public int NumLines { get; set; }
        public string[] Details { get; set; }

        public LoadingEventArgs() : base()
        {

        }
        public LoadingEventArgs(int lines) : base()
        {
            NumLines = lines;
        }
    }
}
