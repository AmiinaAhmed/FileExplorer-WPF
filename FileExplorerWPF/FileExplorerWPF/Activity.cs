using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerWPF
{
    public class Activity
    {
        public string userName;
        public string name;
        public string date;
        public string state;
        public Activity()
        {
            this.name = "";
            this.state = "";
            this.date = DateTime.Now.ToString();
            this.userName = System.Environment.MachineName;

        }

        public Activity(string name, string state)
        {
            this.name = name;
            this.state = state;
            this.date = DateTime.Now.ToString();
            this.userName = System.Environment.MachineName;

        }

    }
}
