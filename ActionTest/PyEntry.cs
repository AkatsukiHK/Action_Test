using System;
using Python.Runtime;
namespace ActionTest
{
    public class PyEntry
    {
        public static void Run()
        {
            Runtime.PythonDLL = "/path/to/libpython3.10.so";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                try
                {
                    string scriptPath = "./Scripts";
                    dynamic sys = Py.Import("sys");
                    sys.path.append(scriptPath);
                    dynamic process = Py.Import("mymodule");
                    process.greet("World");
                }
                catch (PythonException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            PythonEngine.Shutdown();
        }
    }
}