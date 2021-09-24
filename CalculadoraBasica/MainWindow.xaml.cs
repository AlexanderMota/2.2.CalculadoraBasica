using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BotonCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                char c = char.Parse(operadorInput.Text);

                switch (c)
                {
                    case '+':
                        resultado.Text = Suma(int.Parse(num1Input.Text), int.Parse(num2Input.Text)).ToString();
                        break;
                    case '-':
                        resultado.Text = Resta(int.Parse(num1Input.Text), int.Parse(num2Input.Text)).ToString();
                        break;
                    case '/':
                        resultado.Text = Divide(int.Parse(num1Input.Text), int.Parse(num2Input.Text)).ToString();
                        break;
                    case '*':
                        resultado.Text = Multiplica(int.Parse(num1Input.Text), int.Parse(num2Input.Text)).ToString();
                        break;
                    default: throw new FormatException();
                }
            }
            catch (FormatException f)
            {
                const string message = "El formato del operador no es correcto";
                //const string caption = "Form Closing";
                var result = MessageBox.Show(message/*, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question*/);

                /*
                // If the no button was pressed ...
                if (result == DialogResult.Value)
                {
                    // cancel the closure of the form.
                    e.Cancel = true;
                }*/
            }
            catch (OverflowException f)
            {
                var result = MessageBox.Show("Mejor compra una calculadora de verdad...");
            }
            
        }
        /*private bool CompruebaOperador(char op)
            => new char[]{ '+', '-', '/', '*'}.Contains(op);*/
        private long Suma(int num1, int num2) => num1 + num2;
        private long Resta(int num1, int num2) => num1 - num2;
        private long Multiplica(int num1, int num2) => num1 * num2;
        private long Divide(int num1, int num2) => num1 / num2;

        private void BotonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            //InitializeComponent();
            this.resultado.Text = "";
            this.operadorInput.Text = "";
            this.num1Input.Text = "";
            this.num2Input.Text = "";
        }
    }
}
