
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class MI_58873_Bubble
    {
        //instancje elementów używanych w klasie
        readonly MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        readonly MI_58873_Proj MI_58873_workPanel;
        readonly GroupBox MI_58873_resultBox;

        //konstruktor
        public MI_58873_Bubble(MI_58873_Proj MI_58873_workPanel)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            MI_58873_resultBox = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
        }

        //metoda do budowania sekcji result panel dla sortowania bąbelkowego
        public void MI_58873_buildBubbleSection()
        {
            //przydatne zmienne
            int MI_58873_tbWidth = 80;
            int MI_58873_tbHeight = 35;
            int MI_58873_buttonsPositionY = 235;
            int MI_58873_tbPositionY = 90;
            int MI_58873_tbMaxlength = 5;
            Font MI_58873_tbFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            string MI_58873_description = " - Program wykonuje sortowanie bąbelkowe na podstawie wprowadzonych lub wylosowanych liczb\n"
                + " - Wylosowane liczby są z zakresu <-9999, 99999>\n"
                + " - Program nie przyjmuje liter ani innych znaków oprócz \"-\"\n"
                + " - Każde pole tekstowe przyjmuje maxymalnie 5 znaków\n"
                + " - Program pracuje tylko na liczbach typu int\n"
                + " - Wszystkie niedozwolone operacje starałem się przewidziec i zaprezentować odpowiedni komunikat";

            //tworzę labelki używane w ekranie sortowania
            Label MI_58873_lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), MI_58873_Proj.MI_58873_titleFont, 575, 35, "Sortowanie bąbelkowe", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), MI_58873_Proj.MI_58873_footerFont, 725, 140, MI_58873_description, MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_lblfillFields = MI_58873_ctrl.MI_58873_createLabel("lblfillFields", new Point(195, 63), MI_58873_Proj.MI_58873_footerFont,  600, 18, "Wprowadź liczby do posortowania lub kliknij w przycisk \"LOSUJ\"", BorderStyle.None, MI_58873_Proj.MI_58873_labelAlignement);

            //tworzę textboxy używane w ekranie sortowania
            TextBox MI_58873_tf0 = MI_58873_ctrl.MI_58873_createTextField("tf0", new Point(30, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf1 = MI_58873_ctrl.MI_58873_createTextField("tf1", new Point(120, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf2 = MI_58873_ctrl.MI_58873_createTextField("tf2", new Point(210, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf3 = MI_58873_ctrl.MI_58873_createTextField("tf3", new Point(300, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf4 = MI_58873_ctrl.MI_58873_createTextField("tf4", new Point(390, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf5 = MI_58873_ctrl.MI_58873_createTextField("tf5", new Point(480, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf6 = MI_58873_ctrl.MI_58873_createTextField("tf6", new Point(570, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_tf7 = MI_58873_ctrl.MI_58873_createTextField("tf7", new Point(660, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);

            //tworzę butony używane w ekranie sortowania
            Button MI_58873_countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, MI_58873_buttonsPositionY, "SORTUJ");
            Button MI_58873_clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, MI_58873_buttonsPositionY, "WYCZYŚĆ");
            Button MI_58873_randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, MI_58873_buttonsPositionY, "LOSUJ");

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po wprowadzeniu tekstu w text fieldy
            MI_58873_tf0.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf1.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf2.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf3.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf4.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf5.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf6.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_tf7.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po kliknięciu w buttony
            MI_58873_countButton.Click += new EventHandler(MI_58873_countButton_Button_Click);
            MI_58873_clearButton.Click += new EventHandler(MI_58873_clearResultPanel_Button_Click);
            MI_58873_randomButton.Click += new EventHandler(MI_58873_randomButton_Button_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            MI_58873_countButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_clearButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_randomButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
            MI_58873_countButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_clearButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_randomButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);

            //wyswietlenie kontrolek w sekcji Panel Wyników
            MI_58873_resultBox.Controls.Add(MI_58873_lblTitle);
            MI_58873_resultBox.Controls.Add(MI_58873_lblfillFields);
            MI_58873_resultBox.Controls.Add(MI_58873_tf0);
            MI_58873_resultBox.Controls.Add(MI_58873_tf1);
            MI_58873_resultBox.Controls.Add(MI_58873_tf2);
            MI_58873_resultBox.Controls.Add(MI_58873_tf3);
            MI_58873_resultBox.Controls.Add(MI_58873_tf4);
            MI_58873_resultBox.Controls.Add(MI_58873_tf5);
            MI_58873_resultBox.Controls.Add(MI_58873_tf6);
            MI_58873_resultBox.Controls.Add(MI_58873_tf7);
            MI_58873_resultBox.Controls.Add(MI_58873_countButton);
            MI_58873_resultBox.Controls.Add(MI_58873_clearButton);
            MI_58873_resultBox.Controls.Add(MI_58873_randomButton);
            MI_58873_resultBox.Controls.Add(MI_58873_lblDescription);
        }

        //to jest metoda która jest odpowiedzalna za zbudowanie elementów do prezentowania wyników sortowania bąbelkowego
        private void MI_58873_buildBubbleResult()
        {
            //przyatne zmienne
            int MI_58873_lblPositionY = 160;
            Font MI_58873_tbFont = new Font("Arial", 23, FontStyle.Bold, GraphicsUnit.Pixel);

            Label MI_58873_lblResultsInfo = MI_58873_ctrl.MI_58873_createLabel("lblResultsInfo", new Point(292, 135), MI_58873_Proj.MI_58873_footerFont, 600, 18, "Wynik sortowania bąbelkowego:", BorderStyle.None, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_lbl0 = MI_58873_ctrl.MI_58873_createLabel("lbl0", new Point(30, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl1 = MI_58873_ctrl.MI_58873_createLabel("lbl1", new Point(120, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl2 = MI_58873_ctrl.MI_58873_createLabel("lbl2", new Point(210, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl3 = MI_58873_ctrl.MI_58873_createLabel("lbl3", new Point(300, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl4 = MI_58873_ctrl.MI_58873_createLabel("lbl4", new Point(390, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl5 = MI_58873_ctrl.MI_58873_createLabel("lbl5", new Point(480, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl6 = MI_58873_ctrl.MI_58873_createLabel("lbl6", new Point(570, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lbl7 = MI_58873_ctrl.MI_58873_createLabel("lbl7", new Point(660, MI_58873_lblPositionY), MI_58873_tbFont, 80, 35, "", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);

            //dodanie kontrolek do ekranu
            MI_58873_resultBox.Controls.Add(MI_58873_lblResultsInfo);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl0);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl1);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl2);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl3);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl4);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl5);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl6);
            MI_58873_resultBox.Controls.Add(MI_58873_lbl7);
        }

        //metoda odpowiedzialna za wykonanie sortowania bąbelkowego
        //metoda przyjmuje listę którą przetwarza i zwraca
        private List<int> MI_58873_bubbleSort(List<int> MI_58873_numbersList)
        {
            //wykonuje się dla każdego indexu znajdującego w liście
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_numbersList.Count; MI_58873_i++)
            {   
                //każdy znaleziony index jest poównywany z kolejmym znakiem dlatego j= i + 1
                for (int MI_58873_j = MI_58873_i + 1; MI_58873_j < MI_58873_numbersList.Count; MI_58873_j++)
                {
                    //pobieram te indexy do poniższych zmiennych
                    int MI_58873_a = MI_58873_numbersList[MI_58873_i];
                    int MI_58873_b = MI_58873_numbersList[MI_58873_j];

                    //jeżeli pierwszy jes większy od drugiego to zamieniam je miejscami
                    if (MI_58873_a > MI_58873_b)
                    {
                        MI_58873_numbersList[MI_58873_i] = MI_58873_b;
                        MI_58873_numbersList[MI_58873_j] = MI_58873_a;
                    }
                }
            }

            //zwracam postortowaną tę samą listę
            return MI_58873_numbersList;
        }

            //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace lub minusem
            private void MI_58873_keyPress(object MI_58873_sender, KeyPressEventArgs MI_58873_e)
        {
            //informuję program że sender jest textBoxem
            TextBox MI_58873_element = MI_58873_sender as TextBox;

            //sprawdzam czy wciśnięty klawisz jest cyfrą lub backspace lub minusem
            if (!char.IsDigit(MI_58873_e.KeyChar) && MI_58873_e.KeyChar != '\b' && MI_58873_e.KeyChar != '-')
            {   
                //jeśli tak to prezentuję userowi odpowiedni tooltip
                MI_58873_e.Handled = true;
                ToolTip MI_58873_tool = new ToolTip
                {
                    ToolTipTitle = "To pole przyjmuje tylko cyfry",
                    ShowAlways = true,
                    InitialDelay = 25
                };
                MI_58873_tool.Show("Wprowadź liczbę typu int", MI_58873_element, 3000);
            }
        }

        //metoda wywoływana po kliknięciuw przycisk SORTUJ
        private void MI_58873_countButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //tworzę zmienna która przechowuje info o tym czy text boxy są prawidłowo uzupełnione
            bool MI_58873_isReady = true;

            //wyszukuję wszystkie text boxy znajdujące się w sekcji Panel wyników
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //sprawdzam czy któryś z text boxów nie jest pusty lub nie posiada samego minusa(-)
                if (MI_58873_element.Text.Equals("") || MI_58873_element.Text == "-")
                {
                    //jeśli tak to presentuję userowi odpowiedni komunikat
                    MessageBox.Show("Conajmniej jedno pole w podanych text boxach jest puste albo zawiera znak\"-\".\n\nSprawdź poprawność danych.", "Nieprawidłowa wartość w text box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //i aktualizuję zmienną o informację że nie można zbudować ekranu
                    MI_58873_isReady = false;
                    //wychodze z pętli bo bez sensu już jest sprawdzać pozostałe text boxy - już wiemy że jest źle
                    break;
                }
            }

            //sprawdzam czy zmienna przechowująca info o tym czy text boxy są prawidłowo uzupełniony ma wartość true
            if (MI_58873_isReady)
            {
                //jeśl tak to buduję kontrolki w których będę przechowywał wyniki 
                MI_58873_buildBubbleResult();
                //wykonu i printuje wyniki na ekran
                MI_58873_solveNumbers();
                //blokuję inputy i odpowiednie buttony po wykonaniu sortowania
                MI_58873_blockElementsAfterCount();
            }
        }

        //metoda odpowiedzialna za wyczyszczeniu ekranu RESULT PANEl po kliknięciu w wyczyść
        private void MI_58873_clearResultPanel_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //czyszczę Sekcję Result panel
            MI_58873_clearResultPanel();
            //przywracam inicjalny wygląd sekcji Panel wyników
            MI_58873_buildBubbleSection();
        }

        //metoda wywoływana po kliknięciu LOSUJ
        private void MI_58873_randomButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wyszukuję wszystkie textfieldy które są w sekcji Panel wyników
             foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //i przypisuję do nich randomowe liczby
                Random MI_58873_random = new Random();
                int MI_58873_randomInt = MI_58873_random.Next(-9999, 99999);
                MI_58873_element.Text = MI_58873_randomInt.ToString();
            }
        }

        //metoda odpowiedzialna za wyczyszczenie sekcji Panel wyników
        private void MI_58873_clearResultPanel()
        {
            //wyszukuję sekcję panel wyników i czyszczę ją
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
        }

        //metoda odpowiedzialna za zablokowanie odpowiednich elementów po wykonaniu sortowania- tak aby user nie mógł już danych modyfikować
        private void MI_58873_blockElementsAfterCount()
        {
            //wyszukuję wszystkie text boxy w sekcji Panel wyników
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //zmianiam ich dostępność na false
                //dzięki temu są widoczne ale są nieklikalne
                MI_58873_element.Enabled = false;
            }

            //wyszukuję buttony SORTUJ i LOSUJ
            Button MI_58873_randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            Button MI_58873_countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];

            //blokuje ich klikalność
            if (MI_58873_countButton != null) MI_58873_countButton.Enabled = false;
            if (MI_58873_randomButton != null) MI_58873_randomButton.Enabled = false;
        }

        //metoda odpowiedzialna za pobranie numerów z textboxów, wykonanie sortowania i wyprintowanie wyników
        private void MI_58873_solveNumbers()
        {
            //pobieram dane z text boxów
            List<int> MI_58873_numbersList = new List<int>();
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                try
                {
                    MI_58873_numbersList.Add(Int32.Parse(MI_58873_element.Text));
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Sprawdź czy wszystkie pola są uzupełnione poprawnie", "Sortowanie nie powiodło się.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //sortuję i wyniki przypisuję do nowej listy
            List<int> MI_58873_sortedList = MI_58873_bubbleSort(MI_58873_numbersList);

            //wposortowane wartości z listy przypisuję do odpowiednich labelek
            Label MI_58873_lbl;
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_sortedList.Count; MI_58873_i++)
            {
                MI_58873_lbl = (Label)MI_58873_resultBox.Controls.Find("lbl" + MI_58873_i, true)[0];
                if (MI_58873_lbl != null) { 
                    MI_58873_lbl.Text = MI_58873_sortedList[MI_58873_i].ToString();
                    MI_58873_lbl.BackColor = MI_58873_Proj.MI_58873_succesColor;
                }
            }
        }
    }
}
