using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class FileInput : IDisposable
{
    StreamReader s = new StreamReader("input.txt");
    StreamWriter w = new StreamWriter("output.txt");

    public void Dispose()
    {
        s.Dispose();
        w.Dispose();
    }

    public string ReadLine()
    {
        return s.ReadLine();
    }

    public void WriteLine(object o)
    {
        w.WriteLine(o);
    }

    public void Write(object o)
    {
        w.Write(o);
    }

    public int Read()
    {
        return s.Read();
    }

    public void ReadEachNumbers(Action<int> action)
    {
        char[] buffer = new char[100000];
        int pos = 0;
        while (true)
        {
            int i = Read();
            if (i == -1)
            {
                action(int.Parse(new string(buffer, 0, pos)));
                break;
            }
            char c = Convert.ToChar(i);
            if (c == ' ')
            {
                action(int.Parse(new string(buffer, 0, pos)));
                pos = 0;
            }
            else if (c == '\n')
            {
                action(int.Parse(new string(buffer, 0, pos)));
                pos = 0;
                break;
            }
            else if (c == '\r')
            {
                continue;
            }
            else
            {
                buffer[pos++] = c;
            }
        }
    }
}

