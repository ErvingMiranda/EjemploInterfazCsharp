using System;               
using System.Windows.Forms; 

namespace EjemploInterfaz
{
    // 'internal static' significa que esta clase solo puede usarse dentro del mismo proyecto
    // y que no se pueden crear instancias (solo ejecuta su contenido una vez).
    internal static class Program
    {
        // [STAThread] indica que el programa usa un "Single Thread Apartment",
        // necesario para que funciones gráficas (portapapeles, cuadros de diálogo, etc.)
        // trabajen correctamente en Windows Forms.
        [STAThread]
        static void Main()
        {
            // Activa los estilos visuales modernos de Windows (botones, fuentes, etc.)
            Application.EnableVisualStyles();

            // Define que el renderizado de texto sea el moderno (GDI+) en lugar del antiguo (GDI).
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia el bucle principal de la aplicación y muestra el formulario principal (Form1).
            // Mientras el formulario esté abierto, la aplicación se mantiene ejecutándose.
            Application.Run(new Form1());
        }
    }
}
