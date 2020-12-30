using System;
using System.Diagnostics;
using System.IO;

namespace ReproWkhml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wkhtmltopdf",
                    Arguments =
                        "-q -B 8 -L 8 -R 8 -T 8 --print-media-type --enable-local-file-access -s Letter -O Portrait - -",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            })
            {
                process.Start();

                byte[] array;

                var html = "test";
                using (var standardInput = process.StandardInput)
                {
                    standardInput.WriteLine(html);
                }

                using (var memoryStream = new MemoryStream())
                {
                    using (var baseStream = process.StandardOutput.BaseStream)
                    {
                        var buffer = new byte[4096];
                        int count;
                        while ((count = baseStream.Read(buffer, 0, buffer.Length)) > 0)
                            memoryStream.Write(buffer, 0, count);
                    }

                    var end = process.StandardError.ReadToEnd();
                    if (memoryStream.Length == 0L)
                        throw new Exception(end);
                    process.WaitForExit();
                    array = memoryStream.ToArray();
                }

                Console.WriteLine(array.Length);
            }
        }
    }
}