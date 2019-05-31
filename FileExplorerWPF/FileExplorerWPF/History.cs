using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerWPF
{
    class Histrory
    {
        public string path = "";
        public bool isDrive = false;
        public Histrory(string path, bool isDrive)
        {
            this.path = path;
            this.isDrive = isDrive;
        }

    }
}
