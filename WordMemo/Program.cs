using System;
using System.Drawing;
using System.Windows.Forms;
using WordMemo;
using System.IO;

class Program
{
    

    [STAThread]
    static void Main()
    {
        FileStream stream;

        if (System.IO.File.Exists(Const.FILE_NAME) == false)
        {
            stream = File.Create(Const.FILE_NAME);
            stream.Close();
        }

        Application.EnableVisualStyles();
        Application.Run(new Form_Edit());
    }
}
