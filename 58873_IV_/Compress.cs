
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class Compress
    {
        //instancje elementów
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        Proj MI_58873_workPanel;
        GroupBox resultBox;
        string MI_58873_textDoSkompresowania = "";
        string textAfterDecompression = "";
        readonly int btnHeight = 50;
        readonly int btnWidth = 170;
        readonly Font footerFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);

        //konstruktor
        public Compress(Proj MI_58873_workPanel, GroupBox resultBox)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            this.resultBox = resultBox;
        }

        public void buildCompressSection()
        {
            //przydatne zmienne
            int tbWidth = 450;
            int tbHeight = 35;
            int buttonsPositionY = 300;
            int tbPositionY = 84;
            int operatorTopPosion = 85;
            int tbMaxlength = 20;
            Color tfBackColor = Color.White;
            Font operatorFont = new Font("Arial", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font tbFont = new Font("Arial", 23, FontStyle.Bold, GraphicsUnit.Pixel);
            Font titleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            string description = " - Program realizuje kompresję oraz dekompresję metodą Hufmanna\n"
                + " - Input inicjalnie jest wypełniony ciągiem \"XADJSOSDAOUAZADXSXOD\"\n"
                + " - Input przyjmuje dowolne znaki z klawiatury, max 20 znaków\n"
                + " - Nie wszystkie ciągi są poprawnie kompresowane i dekompresowane. Nie udało mi się ustalić co jest tego powodem.\n"
                + " - Przycisk \"LOSUJ\" generuje losowy ciąg liter. Długość wygenerowanego tekstu to 6 znaków.";

            //labelki
            Label lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 19), titleFont, Proj.panelColor, Proj.foreColor, 575, 35, "Kompresja Huffmanna", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lblfillField = MI_58873_ctrl.MI_58873_createLabel("lblfillField", new Point(195, 61), footerFont, Proj.panelColor, Proj.foreColor, 500, 18, "Wprowadź ciąg do skopresowania lub kliknij w przycisk \"LOSUJ\"", BorderStyle.None, Proj.labelAlignement);
            Label lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 353), footerFont, Proj.panelColor, Proj.foreColor, 725, 90, description, Proj.lblBorderStyleFixed, Proj.labelAlignement);

            //textboxy
            TextBox inputText = MI_58873_ctrl.createTextField("inputText", new Point(163, tbPositionY), tbWidth, tbHeight, tbFont, tfBackColor, Proj.foreColor, tbMaxlength);
            inputText.Text = "XADJSOSDAOUAZADXSXOD";

            //buttony
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, buttonsPositionY, btnWidth, btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "KOMPRESUJ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, buttonsPositionY, btnWidth, btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, buttonsPositionY, btnWidth, btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "LOSUJ");

            //wciśnięcie klawisza
            inputText.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

            //kliknięcie w button
            countButton.Click += new EventHandler(countButton_Button_Click);
            clearButton.Click += new EventHandler(clearResultPanel_Button_Click);
            randomButton.Click += new EventHandler(randomButton_Button_Click);

            //hover
            countButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            clearButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            randomButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);

            //leave
            countButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            clearButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            randomButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);

            //przypisanie klawiszy do panelu wyników
            resultBox.Controls.Add(lblTitle);
            resultBox.Controls.Add(lblfillField);
            resultBox.Controls.Add(inputText);
            resultBox.Controls.Add(countButton);
            resultBox.Controls.Add(clearButton);
            resultBox.Controls.Add(randomButton);
            resultBox.Controls.Add(lblDescription);
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            TextBox textField = (TextBox)resultBox.Controls.Find("inputText", true)[0];
            if (textField != null)
            {
                if (textField.Text.Equals(""))
                {
                    MessageBox.Show("Ciąg do kompresji nie może być pusty.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MI_58873_textDoSkompresowania = textField.Text;
                    textField.Enabled = false;
                }
            }

            Font resultFont = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            //labelki
            Label lblAfterCompression = MI_58873_ctrl.MI_58873_createLabel("lblAfterCompression", new Point(230, 140), resultFont, Proj.panelColor, Proj.foreColor, 535, 50, "", BorderStyle.None, Proj.lblTxtCenter);
            resultBox.Controls.Add(lblAfterCompression);

            //listbox
            ListBox binaryCodes = MI_58873_ctrl.createListBox("binaryCodes", new Point(8, 140), 215, 165);
            binaryCodes.Visible = false;
            resultBox.Controls.Add(binaryCodes);

            List<string> MI_58873_listaKompresji = new List<string>();
            List<MI_58873_WystepującyZnak> MI_58873_znaki = new List<MI_58873_WystepującyZnak>();

            bool compressionResult = MI_58873_kompresuj(MI_58873_textDoSkompresowania, ref MI_58873_listaKompresji, ref MI_58873_znaki);

            if (compressionResult)
            {
                //labelki
                Label titleChars = MI_58873_ctrl.MI_58873_createLabel("titleChars", new Point(7, 124), footerFont, Proj.panelColor, Proj.foreColor, 200, 18, "Zestawienie znaków:", BorderStyle.None, Proj.labelAlignement);
                Label compressedChars = MI_58873_ctrl.MI_58873_createLabel("compressedChars", new Point(228, 124), footerFont, Proj.panelColor, Proj.foreColor, 500, 18, "Skompresowany ciąg znaków:", BorderStyle.None, Proj.labelAlignement);

                //buttony
                Button decompressButton = MI_58873_ctrl.MI_58873_createButton("decompressButton", 400, 192, btnWidth, btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "DEKOMPRESUJ");
                decompressButton.Click += new EventHandler(decompressButton_Button_Click);
                decompressButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
                decompressButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);

                //dodanie elementów do ekranu
                resultBox.Controls.Add(binaryCodes);
                resultBox.Controls.Add(decompressButton);
                resultBox.Controls.Add(titleChars);
                resultBox.Controls.Add(compressedChars);

                textAfterDecompression = MI_58873_dekompresuj(MI_58873_znaki, MI_58873_listaKompresji, MI_58873_textDoSkompresowania);
            }

            Button countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;

            Button randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            if (randomButton != null) randomButton.Enabled = false;
        }

        private void decompressButton_Button_Click(object sender, EventArgs e)
        {
            Font resultFont = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);

            //labelki
            Label lblDecompression = MI_58873_ctrl.MI_58873_createLabel("lblAfterCompression", new Point(230, 244), resultFont, Proj.panelColor, Proj.foreColor, 535, 50, textAfterDecompression, Proj.lblBorderStyleFixed, Proj.lblTxtCenter);

            bool decompressionResult = checkDecompressionResult();
            if (decompressionResult)
                lblDecompression.BackColor = Color.Green;
            else
                lblDecompression.BackColor = Color.OrangeRed;


            //dodanie kontrolki do ekranu
            resultBox.Controls.Add(lblDecompression);

            Button decompressButton = (Button)MI_58873_workPanel.Controls.Find("decompressButton", true)[0];
            if (decompressButton != null) decompressButton.Enabled = false;

            if (decompressionResult)
                MessageBox.Show("Dekompresja powiodła się.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Dekompresja nie powiodła się.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildCompressSection();
            TextBox input = (TextBox)MI_58873_workPanel.Controls.Find("inputText", true)[0];
            if (input != null) input.Text = "";
        }

        private void randomButton_Button_Click(object sender, EventArgs e)
        {
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //źródło http://csharp.net-informations.com/string/random.htm
                Random random = new Random();
                int length = 6;
                var randomString = "";
                for (var i = 0; i < length; i++)
                {
                    randomString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
                }
                element.Text = randomString.ToString().ToUpper(); ;
            }
        }

        //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace
        private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //informuję program że sender jest textBoxem
            TextBox element = sender as TextBox;
        }

        private void clearResultPanel()
        {
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
        }

        private bool checkDecompressionResult()
        {
            if (MI_58873_textDoSkompresowania == textAfterDecompression) return true;
            else return false;
        }

        private bool MI_58873_kompresuj(
            string MI_58873_textDoSkompresowania,
            ref List<string> MI_58873_listaKompresji,
            ref List<MI_58873_WystepującyZnak> MI_58873_znaki)
        {
            //wywołanie metody kompresującej 
            bool compressionResult = MI_58873_Kompresja.MI_58873_KompresjaHuffmanna(MI_58873_textDoSkompresowania, ref MI_58873_listaKompresji, ref MI_58873_znaki);
            ListBox resultSpace = (ListBox)MI_58873_workPanel.Controls.Find("binaryCodes", true)[0];
            Label resultCodesSpace = (Label)MI_58873_workPanel.Controls.Find("lblAfterCompression", true)[0];

            if (compressionResult) {
                //wypełnianie listy kodów
                
                if (resultSpace != null)
                {
                    resultSpace.Visible = true;
                    MI_58873_znaki.ForEach(x => resultSpace.Items.Add("Znak: " + x.MI_58873_Znak + " Ilość: " + x.MI_58873_Ilosc + " Kod Binarny: " + x.MI_58873_BinaryCode));
                }

                if (resultCodesSpace != null)
                {
                    resultCodesSpace.BorderStyle = Proj.lblBorderStyleFixed;
                    resultCodesSpace.Text = "[";
                    MI_58873_listaKompresji.ForEach(x => resultCodesSpace.Text += x + " ");
                    resultCodesSpace.Text += "EOF]";
                }
            }
            else
            {
                if (resultSpace != null) resultSpace.Visible = false;

                if (resultCodesSpace != null) resultCodesSpace.Visible = false;
            }

            return compressionResult;
        }

        private string MI_58873_dekompresuj(List<MI_58873_WystepującyZnak> MI_58873_znaki, List<string> MI_58873_listaKompresji, string MI_58873_tekstPrzedkompresja)
        {
            //Lista w której przechowywać będziemy info o znakach oraz o przypisanych do nich kodach binarnych
            List<MI_58873_HuffmanSourceDictionary> MI_58873_dictionary;
            MI_58873_dictionary = new List<MI_58873_HuffmanSourceDictionary>();

            //teraz uzupełniam słownik który posłuży nam do rozkodowania 
            //każdy obiekt składa się z zestawu znak i przypisana do niego wartość binarna
            //a więc mapujemy wcześniej utworzony słownik na Listę typu MI_58873_HuffmanSourceDictionary
            //generując poniższy konstruktor dla obiektu new MI_58873_HuffmanSourceDictionary, posiłkowałem się https://www.tutorialsteacher.com/csharp/csharp-list
            MI_58873_znaki.ForEach(MI_58873_x => MI_58873_dictionary.Add(new MI_58873_HuffmanSourceDictionary()
            {
                MI_58873_SingleChar = MI_58873_x.MI_58873_Znak,
                MI_58873_BinaryCode = MI_58873_x.MI_58873_BinaryCode
            }));

            //wszystkie obiekty z listy zapisuję jako wartość jednej ciągu znaków string i wypisuję połączony ciąg na ekran
            string MI_58873_ciągBinarny = "";
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaKompresji.Count; MI_58873_i++)
            {
                MI_58873_ciągBinarny += MI_58873_listaKompresji[MI_58873_i];
            }
            MI_58873_ciągBinarny += "EOF";

            //deklaracja i inicjalizacja listy, która przechowywać będzie listę rozkodowanych ciągów binarnych
            List<string> MI_58873_listaRozkodowanych = new List<string>();
            //deklaracja zmiennej która przechowywać będzie wynik rozkodowania
            //wstęnie przydzielona jest wartość false- poprawnie wykonana dekompresja powinna zmienić jej wartość na true
            bool MI_58873_wynikRozkodowania = false;

            //wywołanie metody dekompresującej
            MI_58873_Dekompresja.MI_58873_DekompresjaHuffmana(
                MI_58873_dictionary, MI_58873_ciągBinarny,
                ref MI_58873_listaRozkodowanych,
                ref MI_58873_wynikRozkodowania);

            //deklaracja zmiennej która przechowywać będzie rozkodowany tekst
            string MI_58873_rozkodowanyTekst = "";
            //wszystkie obiekty z listy MI_58873_listaRozkodowanych łączę w jedną całość za pomocą pętli for
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaRozkodowanych.Count; MI_58873_i++)
            {

                MI_58873_rozkodowanyTekst += MI_58873_listaRozkodowanych[MI_58873_i];
            }

            return MI_58873_rozkodowanyTekst;
        }
    }

    public class MI_58873_Kompresja
    {
        public static bool MI_58873_KompresjaHuffmanna(
        string MI_58873_source,
        ref List<string> MI_58873_resultCode,
        ref List<MI_58873_WystepującyZnak> MI_58873_listaZnaków)

        {
            bool compressionResult = true;
            string MI_58873_pozostaly = MI_58873_source;
            string MI_58873_roboczy = MI_58873_pozostaly;
            string MI_58873_kolejnyZnak = "";
            int MI_58873_indexListy = 0;
            List<MI_58873_DrzewoHuffmana> MI_58873_drzewoHuffmana = new List<MI_58873_DrzewoHuffmana>();
            List<MI_58873_WystepującyZnak> MI_58873_tymczasowaListaZnaków = new List<MI_58873_WystepującyZnak>();
            List<MI_58873_DrzewoHuffmana> MI_58873_tymczasoweDrzewoHuffmana = new List<MI_58873_DrzewoHuffmana>();

            do
            {
                MI_58873_roboczy = MI_58873_pozostaly;
                MI_58873_kolejnyZnak = MI_58873_roboczy.Substring(0, 1);
                MI_58873_indexListy = MI_58873_tymczasowaListaZnaków.FindIndex(f => f.MI_58873_Znak == MI_58873_kolejnyZnak);
                if (MI_58873_indexListy == -1)
                {
                    MI_58873_WystepującyZnak nowyZnak = new MI_58873_WystepującyZnak();
                    nowyZnak.MI_58873_Ilosc = 1;
                    nowyZnak.MI_58873_Znak = MI_58873_kolejnyZnak;
                    MI_58873_tymczasowaListaZnaków.Add(nowyZnak);
                }
                else
                {
                    MI_58873_tymczasowaListaZnaków.Where(MI_58873_w => MI_58873_w.MI_58873_Znak == MI_58873_kolejnyZnak).ToList().
                        ForEach(MI_58873_s => MI_58873_s.MI_58873_Ilosc = MI_58873_s.MI_58873_Ilosc + 1);
                }
                MI_58873_pozostaly = MI_58873_roboczy.Remove(0, 1);
            } while (MI_58873_pozostaly.Length != 0);

            MI_58873_listaZnaków = MI_58873_tymczasowaListaZnaków.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();
            List<MI_58873_WystepującyZnak> MI_58873_posortowanaListaZnaków = new List<MI_58873_WystepującyZnak>(MI_58873_listaZnaków);

            int MI_58873_nrKorzenia = 0;
            int MI_58873_nowyKorzenWartosc = 0;
            string MI_58873_nowyKorzen = "node";

            do
            {
                if (MI_58873_posortowanaListaZnaków.Count > 1)
                {
                    if (MI_58873_drzewoHuffmana.Count > 0)
                    {
                        if (MI_58873_drzewoHuffmana[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc >
                            MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc)
                            MI_58873_nowyKorzenWartosc = MI_58873_drzewoHuffmana[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc;
                        else
                            MI_58873_nowyKorzenWartosc = MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc;
                    }

                    else if (MI_58873_drzewoHuffmana.Count == 0)
                        MI_58873_nowyKorzenWartosc = MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc;

                    if (MI_58873_posortowanaListaZnaków.Count > 2)
                    {
                        if (MI_58873_nowyKorzenWartosc >= MI_58873_posortowanaListaZnaków[2].MI_58873_Ilosc &&
                            MI_58873_posortowanaListaZnaków.Count >= 3)
                            MI_58873_nrKorzenia++;
                    }
                    else
                        MI_58873_nrKorzenia++;

                    MI_58873_WystepującyZnak MI_58873_nowyZnak = new MI_58873_WystepującyZnak
                    {
                        MI_58873_Ilosc = MI_58873_nowyKorzenWartosc,
                        MI_58873_Znak = MI_58873_nowyKorzen + MI_58873_nrKorzenia
                    };
                    MI_58873_posortowanaListaZnaków.Add(MI_58873_nowyZnak);

                    for (int MI_58873_i = 0; MI_58873_i <= 1; MI_58873_i++)
                    {
                        MI_58873_DrzewoHuffmana MI_58873_drzewoHuffmanaItem = new MI_58873_DrzewoHuffmana();
                        if (MI_58873_posortowanaListaZnaków.Count > 1)
                            MI_58873_drzewoHuffmanaItem.MI_58873_BinaryCode = MI_58873_i;
                        else
                            MI_58873_drzewoHuffmanaItem.MI_58873_BinaryCode = 2;
                        MI_58873_drzewoHuffmanaItem.MI_58873_Znak = MI_58873_posortowanaListaZnaków[MI_58873_i].MI_58873_Znak;
                        MI_58873_drzewoHuffmanaItem.MI_58873_Node = MI_58873_nowyKorzen + MI_58873_nrKorzenia.ToString();
                        MI_58873_drzewoHuffmanaItem.MI_58873_Ilosc = MI_58873_posortowanaListaZnaków[MI_58873_i].MI_58873_Ilosc;
                        MI_58873_drzewoHuffmana.Add(MI_58873_drzewoHuffmanaItem);
                    }
                    MI_58873_posortowanaListaZnaków.RemoveRange(0, 2);
                    MI_58873_tymczasowaListaZnaków = MI_58873_posortowanaListaZnaków.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();
                    MI_58873_tymczasoweDrzewoHuffmana = MI_58873_drzewoHuffmana.OrderByDescending(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();

                    MI_58873_drzewoHuffmana = MI_58873_tymczasoweDrzewoHuffmana;
                    MI_58873_posortowanaListaZnaków = MI_58873_tymczasowaListaZnaków;
                }
                else
                {
                    MI_58873_DrzewoHuffmana MI_58873_drzewoHuffmanaItem = new MI_58873_DrzewoHuffmana
                    {
                        MI_58873_BinaryCode = 2,
                        MI_58873_Znak = MI_58873_nowyKorzen + (MI_58873_nrKorzenia + 1).ToString(),
                        MI_58873_Node = "TOP"
                    };
                    MI_58873_drzewoHuffmana.Add(MI_58873_drzewoHuffmanaItem);
                    MI_58873_posortowanaListaZnaków.Clear();
                }
            } while (MI_58873_posortowanaListaZnaków.Count != 0);
            MI_58873_tymczasoweDrzewoHuffmana = MI_58873_drzewoHuffmana.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();

            string MI_58873_tempBinaryCode = "";
            string MI_58873_actualNode = "";

            for (int MI_58873_i = 0; MI_58873_i < MI_58873_drzewoHuffmana.Count - 1; MI_58873_i++)
            {
                if (MI_58873_drzewoHuffmana[MI_58873_i].MI_58873_Ilosc == MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_Ilosc &&
                    MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_Znak.Length > 1)
                {
                    MI_58873_DrzewoHuffmana MI_58873_tymczasowy = new MI_58873_DrzewoHuffmana();
                    MI_58873_tymczasowy = MI_58873_drzewoHuffmana[MI_58873_i];
                    MI_58873_drzewoHuffmana[MI_58873_i] = MI_58873_drzewoHuffmana[MI_58873_i + 1];
                    MI_58873_drzewoHuffmana[MI_58873_i + 1] = MI_58873_tymczasowy;
                    MI_58873_drzewoHuffmana[MI_58873_i].MI_58873_BinaryCode = 0;
                    MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_BinaryCode = 1;
                }
            }
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaZnaków.Count; MI_58873_i++)
            {
                MI_58873_kolejnyZnak = MI_58873_listaZnaków[MI_58873_i].MI_58873_Znak;
                MI_58873_indexListy = MI_58873_drzewoHuffmana.FindIndex(f => f.MI_58873_Znak == MI_58873_kolejnyZnak);

                try
                {
                    MI_58873_actualNode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_Node;
                    MI_58873_tempBinaryCode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_BinaryCode.ToString();
                }
                catch(Exception) {
                    MessageBox.Show("Kompresja nie powiodła się", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    compressionResult = false;
                }

                do
                {
                    MI_58873_indexListy = MI_58873_drzewoHuffmana.FindIndex(f => f.MI_58873_Znak == MI_58873_actualNode);
                    if (MI_58873_indexListy != -1)
                    {
                        MI_58873_actualNode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_Node;
                        MI_58873_tempBinaryCode = MI_58873_tempBinaryCode + MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_BinaryCode.ToString();

                        if (MI_58873_tempBinaryCode.Length > 1 && MI_58873_tempBinaryCode.Substring(0, 1) == "0")
                            MI_58873_tempBinaryCode = MI_58873_tempBinaryCode.Remove(0, 1);
                    }
                } while (MI_58873_indexListy != -1);
                MI_58873_listaZnaków[MI_58873_i].MI_58873_BinaryCode = MI_58873_tempBinaryCode;
            }

            for (int MI_58873_i = 0; MI_58873_i < MI_58873_source.Length; MI_58873_i++)
            {
                MI_58873_kolejnyZnak = MI_58873_source.Substring(MI_58873_i, 1);

                for (int MI_58873_j = 0; MI_58873_j <= MI_58873_listaZnaków.Count; MI_58873_j++)
                {
                    if (MI_58873_listaZnaków[MI_58873_j].MI_58873_Znak == MI_58873_kolejnyZnak)
                    {
                        MI_58873_resultCode.Add(MI_58873_listaZnaków[MI_58873_j].MI_58873_BinaryCode + ",");
                        MI_58873_j = MI_58873_listaZnaków.Count;
                    }
                }
            }
            return compressionResult;
        }
    }

    public class MI_58873_Dekompresja
    {
        public static void MI_58873_DekompresjaHuffmana(
    List<MI_58873_HuffmanSourceDictionary> MI_58873_sourceDictionary,
    string MI_58873_source,
    ref List<string> MI_58873_resultCode,
    ref bool MI_58873_dictionaryComplete)
        {
            string MI_58873_kolejnyZnak = "";
            int MI_58873_zawiera = 0;

            try
            {
                //wykonanie dla wszystkich elemenów ciągu wejściowego
                do
                {
                    //usunięcie przecinka z początku ciągu
                    do
                    {
                        if (MI_58873_source.Length > 0 &&
                            MI_58873_source.Substring(0, 1) != "0" &&
                            MI_58873_source.Substring(0, 1) != "1")
                        {
                            MI_58873_source = MI_58873_source.Remove(0, 1);
                        }
                    } while (MI_58873_source.Length > 0 &&
                            MI_58873_source.Substring(0, 1) != "1" &&
                            MI_58873_source.Substring(0, 1) != "0");

                    //teraz wiadomo że nie ma przecinka na początku ciągu więc dla wszystkich elementów ciągu wykonujemy operację
                    if (MI_58873_source.Length > 0)
                    {
                        do
                        {
                            //pobieramy wartośc 1 lub 0 z przygotowanego ciągu znaków i dodajemy do zmiennej MI_58873_kolejnyZnak
                            MI_58873_kolejnyZnak = MI_58873_kolejnyZnak + MI_58873_source.Substring(0, 1);
                            //pobrany znak usuwamy z ciągu MI_58873_source po to aby go kolejny raz nie pobrać
                            MI_58873_source = MI_58873_source.Remove(0, 1);
                            //pobieramy i dopisujemy do MI_58873_kolejnyZnak aż do momentu kiedy napotkamy inny znak niż 0 lub 1 (tu wiemy żę mamy przecinek i "EOF")
                        } while (MI_58873_source.Substring(0, 1) == "0" || MI_58873_source.Substring(0, 1) == "1");
                        //teraz znaleziony kod binarny który mamy zapisany w MI_58873_kolejnyZnak porównujemy ze słownikiem (MI_58873_sourceDictionary) -
                        //szukamy jaka wartość jest przypisana do podanego kodu binarnego
                        MI_58873_zawiera = MI_58873_sourceDictionary.FindIndex(MI_58873_f => MI_58873_f.MI_58873_BinaryCode == MI_58873_kolejnyZnak);
                        //odnalezioną wartość ze słownika przypisujemy jako kolejny element listy MI_58873_resultCode
                        MI_58873_resultCode.Add(MI_58873_sourceDictionary[MI_58873_zawiera].MI_58873_SingleChar);
                        //na koniec musimy wyczyścić zmienną MI_58873_kolejnyZnak aby wykonać rozkodowanie kolejnych znaków 
                        MI_58873_kolejnyZnak = "";
                    }
                    else
                    {
                        //ten blok jest wykonywany gdy ciąg znaków już nie zawiera elementów do rozkodowania
                        MI_58873_dictionaryComplete = true;
                        return;
                    }
                } while (MI_58873_source.Length > 0);
            }
            catch (Exception MI_58873_ex)
            {
                //w przypadku wystąpienia błędu podczas dekompresji,
                //zamiast przerywać działanie programu informujemy o błędzie ustawiając wartość false dla rezultatu dekompreji
                MI_58873_dictionaryComplete = false;
            }
        }
    }

    public class MI_58873_WystepującyZnak
    {
        public int MI_58873_Ilosc { get; set; }
        public string MI_58873_Znak { get; set; }
        public string MI_58873_BinaryCode { get; set; }
    }

    public class MI_58873_DrzewoHuffmana
    {
        public int MI_58873_BinaryCode { get; set; }
        public string MI_58873_Znak { get; set; }
        public string MI_58873_Node { get; set; }
        public int MI_58873_Ilosc { get; set; }
    }

    public class MI_58873_HuffmanSourceDictionary
    {
        public string MI_58873_SingleChar { get; set; }
        public string MI_58873_BinaryCode { get; set; }
    }

}
