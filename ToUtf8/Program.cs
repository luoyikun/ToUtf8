using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ToUtf8
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            var files = new DirectoryInfo(dir).GetFiles("*.*", SearchOption.AllDirectories).Where(s => s.FullName.EndsWith(".cs") || s.FullName.EndsWith(".txt") || s.FullName.EndsWith(".shader"));

            foreach (var f in files)
            {
                var s = File.ReadAllText(f.FullName, Encoding.Default);
                try
                {
                    File.WriteAllText(f.FullName, s, Encoding.UTF8);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                    continue;
                }
            }
        }
    }
}
