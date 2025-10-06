using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace EjemploInterfaz
{
    // Lógica del formulario (eventos, validaciones, etc.)
    public partial class Form1 : Form
    {
        // Conteo por color
        private readonly Dictionary<string, int> votos = new()
        {
            {"Rojo",0}, {"Azul",0}, {"Amarillo",0}, {"Otro",0}
        };

        // Historial: "Nombre → Azul" o "Nombre → Otro: Verde"
        private readonly List<string> detalles = new();

        // Regex: solo letras (incluye acentos y ñ) y espacios
        private static readonly Regex RegexNombre = new("^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ ]+$", RegexOptions.Compiled);

        public Form1()
        {
            InitializeComponent();   // Crea/posiciona controles del Designer
            InicializarLogica();     // Ajusta textos, items y conecta eventos
        }

        private void InicializarLogica()
        {
            // Textos visibles
            Text = "Encuesta de Colores";
            lblTitulo.Text = "Encuesta color favorito";
            lblNombre.Text = "Nombre:";
            lblColor.Text = "Color favorito:";
            btnGuardar.Text = "Guardar";
            btnResultados.Text = "Resultados";
            btnSalir.Text = "Salir";
            btnHistorial.Text = "Historial";

            // ComboBox
            cboColor.Items.Clear();
            cboColor.Items.AddRange(new object[] { "Rojo", "Azul", "Amarillo", "Otro" });
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;

            // "Otro" oculto al inicio
            txtOtro.Visible = false;

            // Eventos
            cboColor.SelectedIndexChanged += CboColor_SelectedIndexChanged;
            btnGuardar.Click += BtnGuardar_Click;
            btnResultados.Click += BtnResultados_Click;
            btnHistorial.Click += BtnHistorial_Click;
            btnSalir.Click += (s, e) => Close();
            Resize += (s, e) => AjustarLayout();

            // Accesibilidad
            AcceptButton = btnGuardar;  // Enter = Guardar
            CancelButton = btnSalir;    // Esc = Salir

            // Tamaño inicial más cómodo
            if (ClientSize.Width < 1000 || ClientSize.Height < 700)
                ClientSize = new Size(1100, 750);

            AjustarLayout();
        }

        // Ajusta posiciones y tamaños proporcionalmente al tamaño de la ventana
        private void AjustarLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int margin = Math.Max(20, w / 45);
            int sepY = (int)(h * 0.09); // separación vertical

            int labelWidth = (int)(w * 0.20);
            int inputWidth = (int)(w * 0.45);
            int controlHeight = Math.Max(34, (int)(h * 0.06));
            int startY = (int)(h * 0.20);

            float baseFontSize = Math.Min(30f, Math.Max(14f, h * 0.035f));
            var baseFont = new Font(Font.FontFamily, baseFontSize, FontStyle.Regular, GraphicsUnit.Point);
            var titleFont = new Font(Font.FontFamily, baseFontSize * 1.4f, FontStyle.Bold, GraphicsUnit.Point);

            // Título centrado arriba
            lblTitulo.Font = titleFont;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point((w - lblTitulo.Width) / 2, (int)(h * 0.08));

            // Nombre
            lblNombre.Font = baseFont;
            lblNombre.Location = new Point(margin, startY);
            lblNombre.Size = new Size(labelWidth, controlHeight);

            txtNombre.Font = baseFont;
            txtNombre.Location = new Point(margin + labelWidth + 10, startY);
            txtNombre.Size = new Size(inputWidth, controlHeight);

            // Color
            lblColor.Font = baseFont;
            lblColor.Location = new Point(margin, startY + sepY);
            lblColor.Size = new Size(labelWidth, controlHeight);

            cboColor.Font = baseFont;
            cboColor.Location = new Point(margin + labelWidth + 10, startY + sepY);
            cboColor.Size = new Size(inputWidth, controlHeight);

            // Texto Otro
            if (txtOtro.Visible)
            {
                txtOtro.Font = baseFont;
                txtOtro.Location = new Point(margin + labelWidth + 10, startY + sepY * 2);
                txtOtro.Size = new Size(inputWidth, controlHeight);
            }

            // Botones: fila inferior
            int buttonWidth = (int)(w * 0.18);
            int buttonHeight = Math.Max(48, (int)(h * 0.09));
            int bottomY = h - buttonHeight - margin;
            int spaceBetween = (w - (buttonWidth * 4) - margin * 2) / 3; // 4 botones

            var buttons = new[] { btnGuardar, btnResultados, btnHistorial, btnSalir };
            for (int i = 0; i < buttons.Length; i++)
            {
                var b = buttons[i];
                b.Font = baseFont;
                b.Size = new Size(buttonWidth, buttonHeight);
                b.Location = new Point(margin + i * (buttonWidth + spaceBetween), bottomY);
            }
        }

        private bool ValidarTextoSinNumeros(string texto)
        {
            return RegexNombre.IsMatch(texto);
        }

        private void MostrarError(string mensaje, Control? focus = null)
        {
            MessageBox.Show(this, mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus?.Focus();
        }

        // Muestra u oculta la caja de "Otro" según la selección
        private void CboColor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboColor.SelectedItem is null)
            {
                txtOtro.Visible = false;
                txtOtro.Clear();
                AjustarLayout();
                return;
            }

            txtOtro.Visible = string.Equals(
                cboColor.SelectedItem.ToString(),
                "Otro",
                StringComparison.OrdinalIgnoreCase
            );

            if (!txtOtro.Visible)
            {
                txtOtro.Clear();
            }
            else
            {
                txtOtro.Focus();
            }
            AjustarLayout();
        }

        // Guardar respuesta con validaciones
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarError("Por favor, escribe tu nombre.", txtNombre);
                return;
            }
            if (!ValidarTextoSinNumeros(nombre))
            {
                MostrarError("El nombre solo puede contener letras y espacios (sin números).", txtNombre);
                return;
            }

            if (cboColor.SelectedItem is null)
            {
                MostrarError("Selecciona un color favorito.", cboColor);
                cboColor.DroppedDown = true;
                return;
            }

            string color = cboColor.SelectedItem!.ToString()!;

            if (color == "Otro")
            {
                string otro = txtOtro.Text.Trim();

                if (string.IsNullOrWhiteSpace(otro))
                {
                    MostrarError("Escribe el color en la caja 'Otro'.", txtOtro);
                    return;
                }
                if (!ValidarTextoSinNumeros(otro))
                {
                    MostrarError("El color 'Otro' no debe contener números ni símbolos.", txtOtro);
                    return;
                }

                // Evita duplicar colores predefinidos dentro de "Otro"
                string[] predef = { "Rojo", "Azul", "Amarillo" };
                if (predef.Contains(otro, StringComparer.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        this,
                        $"El color \"{otro}\" ya existe en la lista de opciones. Elígelo directamente.",
                        "Color duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    txtOtro.Clear();
                    cboColor.SelectedItem = predef.First(p => p.Equals(otro, StringComparison.OrdinalIgnoreCase));
                    return;
                }

                votos["Otro"]++;
                detalles.Add($"{nombre} → Otro: {otro}");
            }
            else
            {
                votos[color]++;
                detalles.Add($"{nombre} → {color}");
            }

            MessageBox.Show(this, "¡Respuesta guardada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpieza para el siguiente encuestado
            txtNombre.Clear();
            txtOtro.Clear();
            cboColor.SelectedIndex = -1;
            txtOtro.Visible = false;
            txtNombre.Focus();
            AjustarLayout();
        }

        // Resultados: SOLO conteos
        private void BtnResultados_Click(object? sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("RESULTADOS ACTUALES");
            sb.AppendLine(new string('-', 40));
            sb.AppendLine($"Rojo:      {votos["Rojo"]}");
            sb.AppendLine($"Azul:      {votos["Azul"]}");
            sb.AppendLine($"Amarillo:  {votos["Amarillo"]}");
            sb.AppendLine($"Otro:      {votos["Otro"]}");

            // Desglose de "Otro" por color SIN nombres (p.ej., Verde: 2)
            var otrosPorColor = detalles
                .Where(d => d.Contains("→ Otro:"))
                .Select(d => d.Split(new[] { "→ Otro:" }, StringSplitOptions.None)[1].Trim())
                .GroupBy(x => x, StringComparer.OrdinalIgnoreCase)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key);

            if (otrosPorColor.Any())
            {
                sb.AppendLine();
                sb.AppendLine("Otros (por color):");
                foreach (var g in otrosPorColor)
                    sb.AppendLine($"  {g.Key}: {g.Count()}");
            }

            TextoGrandeForm.Mostrar(this, "Resultados", sb.ToString());
        }

        // Historial: "X votó por Y"
        private void BtnHistorial_Click(object? sender, EventArgs e)
        {
            if (detalles.Count == 0)
            {
                MessageBox.Show(this, "Aún no hay votos registrados.", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("HISTORIAL DE VOTOS");
            sb.AppendLine(new string('-', 40));
            foreach (var d in detalles)
                sb.AppendLine(d);

            TextoGrandeForm.Mostrar(this, "Historial", sb.ToString());
        }

        // Handlers autogenerados por el diseñador (opcionales / vacíos)
        private void Form1_Load(object? sender, EventArgs e) { }
        private void label1_Click(object? sender, EventArgs e) { }
        private void textBox1_TextChanged(object? sender, EventArgs e) { }
        private void textBox2_TextChanged(object? sender, EventArgs e) { }

        private void btnGuardar_Click_1(object sender, EventArgs e) { }
        private void btnSalir_Click(object sender, EventArgs e) { }
    }
}
