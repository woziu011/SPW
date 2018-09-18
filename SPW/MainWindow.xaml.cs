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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SPW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float koszt = 0;
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in Enum.GetNames(typeof(cennik)))
            {
                comboList.Items.Add(item);
            }

        }
        enum cennik
        {
            [Description("Cwiartka do 120")]
            Cwiartkado120 = 150,
            [Description("Cwiartka powyżej 120")]
            Cwiartpapow120 = 250,
            [Description("Błotnik")]
            Blotnik = 80,
            [Description("Drzwi")]
            Drzwi = 120,
            [Description("Maska")]
            Maska = 150,
            [Description("Zderzak")]
            Zderzak = 100,
            [Description("Klapa z szybą")]
            Klapazszyba = 150
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewPaczki.Items.Count != 0)
            {
                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel._Workbook oWB;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;
                Microsoft.Office.Interop.Excel.Range oRng;
                object misvalue = System.Reflection.Missing.Value;
                try
                {
                    //Start Excel and get Application object.
                    if (!System.IO.File.Exists(@"C:\Users\Admin\Desktop\Lesz\test505.xlsx"))
                    {
                        oXL = new Microsoft.Office.Interop.Excel.Application();
                        oXL.Visible = true;

                        //Get a new workbook.
                        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                        //Add table headers going cell by cell.
                        oSheet.Cells[1, 1] = "Nazwa";
                        oSheet.Cells[1, 2] = "NIP";
                        oSheet.Cells[1, 3] = "Adres";
                        oSheet.Cells[1, 4] = "Miejscowość";
                        oSheet.Cells[1, 5] = "Telefon";
                        oSheet.Cells[1, 6] = "Nazwa";
                        oSheet.Cells[1, 7] = "Adres";
                        oSheet.Cells[1, 8] = "Miejscowosc";
                        oSheet.Cells[1, 9] = "Telefon";
                        oSheet.Cells[1, 10] = "Data";
                        oSheet.Cells[1, 11] = "Koszt";
                        oSheet.Cells[1, 12] = "Zawartosc";
                        oSheet.Cells[1, 13] = "Pobranie";
                        oSheet.Cells[1, 14] = "Nr konta";
                        


                        ZapiszNowyWiersz(oSheet);





                        /*-------------------SAMPLE--------------
                        //Format A1:D1 as bold, vertical alignment = center.
                        oSheet.get_Range("A1", "D1").Font.Bold = true;
                        oSheet.get_Range("A1", "D1").VerticalAlignment =
                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        // Create an array to multiple values at once.
                        string[,] saNames = new string[5, 2];

                        saNames[0, 0] = "John";
                        saNames[0, 1] = "Smith";
                        saNames[1, 0] = "Tom";

                        saNames[4, 1] = "Johnson";

                        //Fill A2:B6 with an array of values (First and Last Names).
                        oSheet.get_Range("A2", "B6").Value2 = saNames;

                        //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                        oRng = oSheet.get_Range("C2", "C6");
                        oRng.Formula = "=A2 & \" \" & B2";

                        //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                        oRng = oSheet.get_Range("D2", "D6");
                        oRng.Formula = "=RAND()*100000";
                        oRng.NumberFormat = "$0.00";

                        //AutoFit columns A:D.
                        oRng = oSheet.get_Range("A1", "D1");
                        oRng.EntireColumn.AutoFit();
                        -----------END SAMPLE */

                        oXL.Visible = false;
                        oXL.UserControl = false;
                        oWB.SaveAs("C:\\Users\\Admin\\Desktop\\Lesz\\test505.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        oWB.Close();
                        GC.Collect();
                    }
                    else
                    {
                        oXL = new Microsoft.Office.Interop.Excel.Application();
                        oXL.Visible = true;

                        //Get a new workbook.
                        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Open("C:\\Users\\Admin\\Desktop\\Lesz\\test505.xlsx", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false));
                        oWB.SaveCopyAs("C:\\Users\\Admin\\Desktop\\Lesz\\KOPIA - test505.xlsx");
                        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                        ZapiszNowyWiersz(oSheet);

                        oXL.Visible = false;
                        oXL.UserControl = false;
                        oWB.Save();


                        oWB.Close();
                        GC.Collect();
                    }


                }
                catch (Exception exeption)
                {




                }
                lstViewPaczki.Items.Clear();
                tbCena.Text = "";
                tbNadawcaAdres.Text = "";
                tbNadawcaMiejscowosc.Text = "";
                tbNadawcaNazwa.Text = "";
                tbNadawcaNIP.Text = "";
                tbNadawcaTelefon.Text = "";
                tbOdbiorcaAdres.Text = "";
                tbOdbiorcaMiejscowosc.Text = "";
                tbOdbiorcaNazwa.Text = "";
                tbOdbiorcaTelefon.Text = "";
                koszt = 0;
                lblKoszt.Content = koszt;

            }
            else
            { MessageBox.Show("Nie dodałeś paczek"); }
        }

        private void ZapiszNowyWiersz(Microsoft.Office.Interop.Excel._Worksheet oSheet)
        {
            int rowCount = oSheet.UsedRange.Rows.Count;
            oSheet.Cells[rowCount + 1, 1] = tbNadawcaNazwa.Text;
            oSheet.Cells[rowCount + 1, 2] = tbNadawcaNIP.Text;
            oSheet.Cells[rowCount + 1, 3] = tbNadawcaAdres.Text;
            oSheet.Cells[rowCount + 1, 4] = tbNadawcaMiejscowosc.Text;
            oSheet.Cells[rowCount + 1, 5] = tbNadawcaTelefon.Text;
            oSheet.Cells[rowCount + 1, 6] = tbOdbiorcaNazwa.Text;
            oSheet.Cells[rowCount + 1, 7] = tbOdbiorcaAdres.Text;
            oSheet.Cells[rowCount + 1, 8] = tbOdbiorcaMiejscowosc.Text;
            oSheet.Cells[rowCount + 1, 9] = tbOdbiorcaTelefon.Text;
            oSheet.Cells[rowCount + 1, 10] = datePicker.SelectedDate;
            oSheet.Cells[rowCount + 1, 11] = koszt;
            oSheet.Cells[rowCount + 1, 12] = koszt;
            oSheet.Cells[rowCount + 1, 13] = (chkPobranie.IsChecked.Value) ? "Tak" : "Nie";
            oSheet.Cells[rowCount + 1, 14] = (chkPobranie.IsChecked.Value) ? tbNrKonta.Text : " ----- ";
            string sb = "";
            foreach (Paczka p in lstViewPaczki.Items)
            {
                sb += p.Nazwa + " ";
            }
            oSheet.Cells[rowCount + 1, 12] = sb;
        }

        public class Paczka
        {
            public string Nazwa{ get; set; }
            public int Cena { get; set; }
            
        }

        private void btnDodajNaListePaczek_Click(object sender, RoutedEventArgs e)
        {
            koszt += Convert.ToInt32(tbCena.Text);
            lstViewPaczki.Items.Add(new Paczka { Nazwa = (string)comboList.SelectedItem, Cena = Convert.ToInt32(tbCena.Text) });

            lblIloscPaczek.Content = lstViewPaczki.Items.Count;
            
          
            //foreach (Paczka p in lstViewPaczki.Items)
            //{
            //    koszt += p.Cena;
            //}


            lblKoszt.Content = koszt;

        }

      private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
{
    Regex regex = new Regex("[^0-9]+");
    e.Handled = regex.IsMatch(e.Text);
}

        private void comboList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var wart = (int)Enum.Parse(typeof(cennik), (string)comboList.SelectedItem);
            tbCena.Text = Convert.ToString(wart);
            

        }

        private void btnUsunZListy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Paczka p = (Paczka)lstViewPaczki.SelectedItem;
                koszt -= p.Cena;

                lstViewPaczki.Items.RemoveAt(lstViewPaczki.SelectedIndex);
                lblKoszt.Content = koszt;
                lblIloscPaczek.Content = lstViewPaczki.Items.Count;
            }
            catch (Exception exe)
            {
                MessageBox.Show("Nic nie zaznaczyłeś!+\n" + exe.Message);
            }
        }

        private void chkPobranie_Checked(object sender, RoutedEventArgs e)
        {
            Nr_konta.Visibility = Visibility.Visible;
            tbNrKonta.Visibility = Visibility.Visible;
        }

        private void chkPobranie_Unchecked(object sender, RoutedEventArgs e)
        {
            Nr_konta.Visibility = Visibility.Hidden;
            tbNrKonta.Visibility = Visibility.Hidden;

        }
    }   
}
