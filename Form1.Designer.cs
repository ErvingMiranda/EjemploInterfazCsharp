using System.Drawing;
using System.Windows.Forms;

namespace EjemploInterfaz
{
    // Parte del diseñador: crea y posiciona controles
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            lblColor = new Label();
            txtNombre = new TextBox();
            txtOtro = new TextBox();
            cboColor = new ComboBox();
            btnGuardar = new Button();
            btnResultados = new Button();
            btnSalir = new Button();
            btnHistorial = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(593, 41);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Encuesta color favorito";
            lblTitulo.Click += label1_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(199, 207);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(199, 266);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(104, 20);
            lblColor.TabIndex = 2;
            lblColor.Text = "Color favorito:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(264, 200);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(382, 27);
            txtNombre.TabIndex = 3;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // txtOtro
            // 
            txtOtro.Location = new Point(301, 292);
            txtOtro.Name = "txtOtro";
            txtOtro.Size = new Size(382, 27);
            txtOtro.TabIndex = 4;
            txtOtro.TextChanged += textBox2_TextChanged;
            // 
            // cboColor
            // 
            cboColor.FormattingEnabled = true;
            cboColor.Location = new Point(301, 258);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(408, 28);
            cboColor.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(32, 660);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(333, 72);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnResultados
            // 
            btnResultados.Location = new Point(399, 660);
            btnResultados.Name = "btnResultados";
            btnResultados.Size = new Size(265, 72);
            btnResultados.TabIndex = 7;
            btnResultados.Text = "Resultados";
            btnResultados.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1003, 660);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(265, 72);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(693, 660);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(286, 72);
            btnHistorial.TabIndex = 9;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 754);
            Controls.Add(btnHistorial);
            Controls.Add(btnSalir);
            Controls.Add(btnResultados);
            Controls.Add(btnGuardar);
            Controls.Add(cboColor);
            Controls.Add(txtOtro);
            Controls.Add(txtNombre);
            Controls.Add(lblColor);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        // Campos de controles
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblColor;
        private TextBox txtNombre;
        private TextBox txtOtro;
        private ComboBox cboColor;
        private Button btnGuardar;
        private Button btnResultados;
        private Button btnSalir;
        private Button btnHistorial; // NUEVO
    }
}
