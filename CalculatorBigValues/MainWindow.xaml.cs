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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        BigIntegerValue value1;
        BigIntegerValue value2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            short value;

            // Only numbers are allowed
            if (!Int16.TryParse(e.Text, out value))
            {
                e.Handled = true;
            }
        }

        private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            value1 = new BigIntegerValue(textBox1.Text);
            value2 = new BigIntegerValue(textBox2.Text);

            int arrayLenght = Math.Max(value1.arrayValues.Length, value2.arrayValues.Length) + 1;

            int[] value3 = new int[arrayLenght];

            Array.Resize(ref value1.arrayValues, arrayLenght - 1);
            Array.Resize(ref value2.arrayValues, arrayLenght - 1);

            for (int i = 0; i < value3.Length - 1; i++)
            {
                value3[i] += (value1.arrayValues[i] + value2.arrayValues[i]);
                if (value3[i] > 9)
                {
                    value3[i] = (value1.arrayValues[i] + value2.arrayValues[i]) - 10;
                    if (i < value3.Length - 2)
                    {
                        value1.arrayValues[i + 1] += 1;
                    }
                    else
                    {
                        value3[i + 1] = 1;
                    }
                }
            }

            if (value3[value3.Length - 1] == 0)
            {
                Array.Resize(ref value3, value3.Length - 1);
            }

            Array.Reverse(value3);

            string resultValueText = null;

            for (int i = 0; i < value3.Length; i++)
            {
                resultValueText += value3[i];
            }

            textBox3.Text = resultValueText;
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            string resultValueText = null;

            if (textBox1.Text.Length > textBox2.Text.Length)
            {
                value1 = new BigIntegerValue(textBox1.Text);
                value2 = new BigIntegerValue(textBox2.Text);
            }
            else if (textBox2.Text.Length > textBox1.Text.Length)
            {
                value1 = new BigIntegerValue(textBox2.Text);
                value2 = new BigIntegerValue(textBox1.Text);

                resultValueText = "-";
            }
            else
            {
                if (textBox1.Text.Equals(textBox2.Text))
                {
                    textBox3.Text = "0";
                    return;
                }
                int compareVal = 0;
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    compareVal = textBox1.Text[i].CompareTo(textBox2.Text[i]);
                    if (compareVal != 0)
                    {
                        break;
                    }
                }
                if (compareVal > 0)
                {
                    value1 = new BigIntegerValue(textBox1.Text);
                    value2 = new BigIntegerValue(textBox2.Text);
                }
                if (compareVal < 0)
                {
                    value1 = new BigIntegerValue(textBox2.Text);
                    value2 = new BigIntegerValue(textBox1.Text);
                    resultValueText = "-";
                }
            }

            int arrayLenght = Math.Max(value1.arrayValues.Length, value2.arrayValues.Length) + 1;

            int[] value3 = new int[arrayLenght];

            Array.Resize(ref value1.arrayValues, arrayLenght - 1);
            Array.Resize(ref value2.arrayValues, arrayLenght - 1);

            for (int i = 0; i < value3.Length - 1; i++)
            {
                value3[i] = (value1.arrayValues[i] - value2.arrayValues[i]);
                if (value3[i] < 0)
                {
                    value3[i] += 10;
                    value1.arrayValues[i + 1] -= 1;
                }
            }

            if (value3[value3.Length - 1] == 0)
            {
                Array.Resize(ref value3, value3.Length - 1);
            }

            Array.Reverse(value3);

            for (int i = 0; i < value3.Length; i++)
            {
                resultValueText += value3[i];
            }

            string resultNoStartZeros = resultValueText.TrimStart('0');

            textBox3.Text = resultNoStartZeros;
        }

        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            value1 = new BigIntegerValue(textBox1.Text);
            value2 = new BigIntegerValue(textBox2.Text);

            int arrayMaxLenght = Math.Max(textBox1.Text.Length, textBox2.Text.Length);

            int[] resultArray = new int[arrayMaxLenght * 2];

            for (int i = 0; i < value2.arrayValues.Length; i++)
            {
                int carryOver = 0;

                for (int j = 0; j < value1.arrayValues.Length; j++)
                {
                    int t = (value2.arrayValues[i] * value1.arrayValues[j]) + resultArray[i + j] + carryOver;
                    carryOver = t / 10;
                    resultArray[i + j] = t % 10;
                }

                resultArray[i + value1.arrayValues.Length] = carryOver;
            }

            Array.Reverse(resultArray);

            string resultValueText = null;

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultValueText += resultArray[i];
            }

            string resultNoStartZeros = resultValueText.TrimStart('0');

            textBox3.Text = resultNoStartZeros;
        }

        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text == "0" || textBox2.Text == "")
            {
                textBox3.Text = "textBox2 text can't be empty or equal to 0!";
                return;
            }
            if (FirstIsBigger(textBox2.Text, textBox1.Text))
            {
                if (textBox2.Text == textBox1.Text)
                {
                    textBox3.Text = "1";
                    return;
                }
                textBox3.Text = "Result 0 Rest " + textBox2.Text;
                return;
            }

            int textBox2Length = textBox2.Text.Length;

            string result = null;
            string rest = null;

            string textBox1Text = textBox1.Text;
            string textBox2Text = textBox2.Text;

            string part1Textbox1 = null;
            string part2Textbox1 = null;

            while (textBox1Text != null)
            {
                int counter = -1;

                if (textBox1Text.Length > textBox2Text.Length)
                {
                     part1Textbox1 = textBox1Text.Remove(textBox2Length);
                     part2Textbox1 = textBox1Text.Substring(textBox2Length);

                    if (FirstIsBigger(part1Textbox1, textBox2Text))
                    {
                        while (part1Textbox1 != null)
                        {
                            part1Textbox1 = MinusResult(part1Textbox1, textBox2Text);
                            counter++;
                            rest = (part1Textbox1 != null) ? part1Textbox1 : rest;
                        }

                        part1Textbox1 = rest.TrimStart('0') + part2Textbox1.Substring(0, 1);
                        part2Textbox1 = part2Textbox1.Substring(1);

                        result += Convert.ToString(counter);

                        while (part2Textbox1 != "" && !FirstIsBigger(part1Textbox1, textBox2Text)  )
                        {
                            part1Textbox1 += part2Textbox1.Substring(0, 1);
                            part1Textbox1 = part1Textbox1.TrimStart('0');
                            part2Textbox1 = part2Textbox1.Substring(1);
                            result += "0";
                        }
                        textBox1Text = part1Textbox1 + part2Textbox1;
                    }

                    else
                    {
                        part1Textbox1 = textBox1Text.Substring(0, textBox2Length + 1);

                        part2Textbox1 = textBox1Text.Substring(textBox2Length + 1);

                        while (part1Textbox1 != null)
                        {
                            part1Textbox1 = MinusResult(part1Textbox1, textBox2Text);
                            counter++;
                            rest = (part1Textbox1 != null) ? part1Textbox1 : rest;

                        }
                        if (part2Textbox1 != "")
                        {
                            textBox1Text = (rest + part2Textbox1).TrimStart('0');
                        }
                        else
                        {
                            textBox1Text = null;
                        }

                        result += Convert.ToString(counter);
                    }
                }
                else
                {
                    while (textBox1Text != null)
                    {
                        textBox1Text = MinusResult(textBox1Text, textBox2Text);
                        counter++;
                        rest = (textBox1Text != null) ? textBox1Text : rest;
                    }

                    result += Convert.ToString(counter);
                }         

            }

            textBox3.Text = "Result " + result + " Rest " + rest;
        }

        public static string MinusResult(string textBox1Text, string textBox2Text)
        {
            string resultValueText = null;

            BigIntegerValue value1 = new BigIntegerValue(textBox1Text);
            BigIntegerValue value2 = new BigIntegerValue(textBox2Text);

            int arrayLenght = Math.Max(value1.arrayValues.Length, value2.arrayValues.Length) + 1;

            int[] value3 = new int[arrayLenght];

            Array.Resize(ref value1.arrayValues, arrayLenght - 1);
            Array.Resize(ref value2.arrayValues, arrayLenght - 1);

            for (int i = 0; i < value3.Length - 1; i++)
            {
                value3[i] = (value1.arrayValues[i] - value2.arrayValues[i]);
                if (value3[i] < 0)
                {
                    value3[i] += 10;
                    try
                    {
                        value1.arrayValues[i + 1] -= 1;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }

            Array.Reverse(value3);

            for (int i = 0; i < value3.Length; i++)
            {
                resultValueText += value3[i];
            }

            string resultNoStartZeros = resultValueText.TrimStart('0');

            return resultNoStartZeros;
        }

        public static bool FirstIsBigger(string first, string second)
        {
            if (first.Length > second.Length)
            {
                return true;
            }
            else if ( first.Length == second.Length )
            {
                for (int i = 0; i < first.Length; i++)
                {
                    double x = char.GetNumericValue(first[i]);
                    double y = char.GetNumericValue(second[i]);
                    if (x < y) return false;
                    else if (x == y) continue;
                    else return true;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
