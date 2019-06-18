using Biblioteca.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void WriteLineLog(String mensagem)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(WriteLineLog), new object[] { mensagem });
                return;
            }

            txtLog.AppendText(mensagem + Environment.NewLine);
        }

        private void btnTempo_Click(object sender, EventArgs e)
        {
            Contexto.Tempo = !Contexto.Tempo;
        }
    }
}
