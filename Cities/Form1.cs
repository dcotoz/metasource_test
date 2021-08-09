using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The two attached files (USCities.txt and CACities.txt) contain a list of cities that are sorted alphabetically.  
        /// The task is to merge the two input files into one output file, making sure that all the cities are in alphabetical order.
        /// The output of the solution should be the new file with the cities ordered alphabetically.
        /// This solution can be any type of project, console, winform, or web.
        /// Limitation
        /// Each data file cannot have its contents loaded entirely into memory at any time (e.g., no List<string>, string[] objects, or collections of any type).

        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // WE SET THE FILE LOCATIONS
                string CALocationsTxt = "CACities.txt";
                string USLocationsTxt = "USCities.txt";

                // Read the file and display it line by line.  
                System.IO.StreamReader fileUS = new System.IO.StreamReader(USLocationsTxt);
                System.IO.StreamReader fileCA = new System.IO.StreamReader(CALocationsTxt);
                var file = System.IO.File.CreateText("BothCountries.txt");
                bool readUsLine = true, readCaLine = true;
                string usline = null, caline = null;
                //WE DO AN INFINITE LOOP UNTIL WE REACH THE END OF BOTH FILES
                while (true)
                {
                    

                    if (readUsLine)
                    {
                        usline = fileUS.ReadLine();
                    }

                    if (readCaLine)
                    {
                        caline = fileCA.ReadLine();
                    }

                    // IF WE REACH THE END OF BOTH FILES, WE RETURN
                    if (string.IsNullOrWhiteSpace(usline) && string.IsNullOrWhiteSpace(caline))
                    {
                        break;
                    }

                    //WE WRITE THE US CITY IF THERE IS NO CANADA CITY
                    if (string.IsNullOrWhiteSpace(caline))
                    {
                        file.Write(usline);
                        readUsLine = true;
                        readCaLine = false;
                    }
                    else if (string.IsNullOrWhiteSpace(usline))
                    {
                        file.Write(caline);
                        readUsLine = false;
                        readCaLine = true;
                    }
                    else
                    {
                        //WE COMPARE WHICH IS FIRST ALPHABETICALLY AND WRITE THE LINE ACCORDINGLY, AFTER THAT WE SET THE VARIABLES THAT WILL TELL US WHICH FILE TO READ FROM
                        if (usline.CompareTo(caline) < 0)
                        {
                            file.Write(usline);
                            readUsLine = true;
                            readCaLine = false;
                        } else
                        {
                            file.Write(caline);
                            readUsLine = false;
                            readCaLine = true;
                        }
                    }
                    
                }

                //CLOSE THE FILE STREAMS
                fileUS.Close();
                fileCA.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
