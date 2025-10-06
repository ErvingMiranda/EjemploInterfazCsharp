using System.Drawing;
using System.Windows.Forms;

namespace EjemploInterfaz
{
    internal class TextoGrandeForm : Form
    {
        private readonly TextBox _txt;
        private TextoGrandeForm(string titulo, string contenido)
        {
            Text = titulo;
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(800, 600);
            MinimumSize = new Size(600, 400);

            _txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font(FontFamily.GenericSansSerif, 14f, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Text = contenido
            };

            Controls.Add(_txt);
        }

        public static void Mostrar(Form owner, string titulo, string contenido)
        {
            using var f = new TextoGrandeForm(titulo, contenido);
            f.ShowDialog(owner);
        }
    }
}
