using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basedatos
{
    public class FileAccesHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
