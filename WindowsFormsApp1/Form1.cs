using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Create a program – your program should have a function that will take a sentence, in the form of a string, and determine which lowercase character occurred the most.  
    /// The return value for your function should be both the character that occurred the most and the number of times it occurred.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //We get the string from the text box and check that if it's not null
                string input = textBox1.Text;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    // WE CREATE A DICTIONARY TO KEEP TRACK OF OUR LOWERCASE character appereance 
                    Dictionary<char, int> dictionary = new Dictionary<char, int>();

                    //WE GO THROUGH EACH CHARACTER 
                    foreach (char character in input)
                    {
                        //WE ASSUME WE DON'T WANT BLANK SPACES
                        if (Char.IsLower(character) && !char.IsWhiteSpace(character))
                        {
                            //WE LOOK FOR THE ENTRY IN THE DICTIONARY
                            var result = dictionary.Where(x => x.Key == character).FirstOrDefault();

                            //IF IT'S A NULL CHARACTER WE CREATE THE ENTRY
                            if (result.Key == '\0')
                            {
                                dictionary.Add(character, 1);
                            }
                            else
                            {
                                //WE INCREMENT
                                int currentCount = dictionary[character];
                                dictionary[character] = ++currentCount;
                            }
                        }
                    }

                    var highest = dictionary.OrderByDescending(x => x.Value).First();
                    //AT THE END OF THE COUNT, WE RETURN THE HIGHEST VALUE
                    lblResult.Text = $"The character that ocurred the most was {highest.Key} with {highest.Value} appereances.";
                }
                else
                {
                    lblResult.Text = "Please enter a non empty string";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
