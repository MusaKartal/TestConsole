using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestConsole
{
    public class Text
    {
        async Task <IEnumerable<string>> Split()
        {
            var textRead = await TextRead();
            var patates = textRead.Length % 64;
           
            var getLastValue = GetLast(textRead, patates);
            Console.WriteLine(patates);
            
            var textValue = Enumerable.Range(0, textRead.Length / 64)
                .Select(i => textRead.Substring(i * 64, 64));
            List<string> strings = textValue.ToList();
            strings.Add(getLastValue);
            
            textValue.Concat(new[] {getLastValue});
            Console.WriteLine(textRead.Length / 64);
            return strings;
        }

        public string GetLast(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        public async Task<string> TextRead()
        {
            string text = "MIICnzCCAYcCBgGCNONvEDANBgkqhkiG9w0BAQsFADATMREwDwYDVQQDDAhNb25hY2h1czAeFw0yMjA3MjUxMDIzMTZaFw0zMjA3MjUxMDI0NTZaMBMxETAPBgNVBAMMCE1vbmFjaHVzMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA17/hXGw+ggFFAhnfD7XrvT4wpOQcelf40pdVwCSkYkfUlXkG2l9YSqfbIxhM/094E0wxmIpxSdnCMeNI+3Q+AEfJYAITAsjs6B0/T4wDfYlG5GJ9i4aZw/Fcy3OgFD45ExIOlC+cJgIHd2XUH9Gkaysk5IbG2bilnXw7YYZ404H2O+FCz0PFT4JV9Q04Wwr8uMWEM22spKJnUJ38faJzVrnaUClW+xelUHrAJhuWOYGd1C4vx/9pW6aYbxt5oKfRGpValrYKNX976iIcCrhVs29fIy821+4SvrfTC0dfuya/Opke9rQDzyCuw+Mz30uyMShnIdlQgx3URdA3r0jk5wIDAQABMA0GCSqGSIb3DQEBCwUAA4IBAQCAOAG51yb2M3fFudFvg6XnyHP3g9pTuqm5TBV1nyZDoEPzOT+CnZGr5J51FbTOTRI5ZEoS4JZ680qPgqJb3Prl8P0T9lRp8sGcvBgnCKajLfgVOsa9+uJolJ+pXFTjOo+wv9ODVsgsdvFNTs4MdeOnV9Oaz2Py8Z1xNXat5+062J5XizYJNMmG88sk0wF5dgHKMdJq42V0atNueG7cw0WGXzw9yeOKYZF+ENmaWgRPkbWW4bELYbyvEms8o1kPb6oA2Oj4ZCMgv4ojnOxWbQbTdE47wlDhgLfrYQEoSvZr8T2VyHLIOSluCrt9FyCZgUJvPfkEhQbwzNOLr81PKBKA";        
            return text;         
        }

        public async void TextWriter(string path)
        {
            var spliteValue = await Split();
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("-----BEGIN CERTIFICATE-----");
            foreach (var item in spliteValue)
            {
                sw.WriteLine(item);
            }
            sw.WriteLine("-----END CERTIFICATE-----");
            sw.Close();
            Console.WriteLine("Kayıt Eklendi.");         
        }
    }

    public class Run
    {
        static void Main(string[] args)
        {
           
            Text text = new Text();
            
            text.TextWriter("C:\\Users\\Musa\\Documents\\Musa Vs-Projects\\TestConsole\\TestConsole\\TextWrite.txt");

        }

    }
}
