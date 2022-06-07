
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class Bubble
    {
        //instancje elementów używanych w klasie
        readonly MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        readonly Proj MI_58873_workPanel;
        readonly GroupBox resultBox;

        //konstruktor
        public Bubble(Proj MI_58873_workPanel)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            resultBox = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
        }

        //metoda do budowania sekcji result panel dla sortowania bąbelkowego
        public void buildBubbleSection()
        {
            //przydatne zmienne
            int tbWidth = 80;
            int tbHeight = 35;
            int buttonsPositionY = 235;
            int tbPositionY = 90;
            int tbMaxlength = 5;
            Font tbFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            string description = " - Program wykonuje sortowanie bąbelkowe na podstawie wprowadzonych lub wylosowanych liczb\n"
                + " - Wylosowane liczby są z zakresu <-9999, 99999>\n"
                + " - Program nie przyjmuje liter ani innych znaków oprócz \"-\"\n"
                + " - Każde pole tekstowe przyjmuje maxymalnie 5 znaków\n"
                + " - Program pracuje tylko na liczbach typu int\n"
                + " - Wszystkie niedozwolone operacje starałem się przewidziec i zaprezentować odpowiedni komunikat";

            //tworzę labelki używane w ekranie sortowania
            Label lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), Proj.titleFont, 575, 35, "Sortowanie bąbelkowe", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), Proj.footerFont, 725, 140, description, Proj.lblBorderStyleFixed, Proj.labelAlignement);
            Label lblfillFields = MI_58873_ctrl.MI_58873_createLabel("lblfillFields", new Point(195, 63), Proj.footerFont,  600, 18, "Wprowadź liczby do posortowania lub kliknij w przycisk \"LOSUJ\"", BorderStyle.None, Proj.labelAlignement);

            //tworzę textboxy używane w ekranie sortowania
            TextBox tf0 = MI_58873_ctrl.createTextField("tf0", new Point(30, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf1 = MI_58873_ctrl.createTextField("tf1", new Point(120, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf2 = MI_58873_ctrl.createTextField("tf2", new Point(210, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf3 = MI_58873_ctrl.createTextField("tf3", new Point(300, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf4 = MI_58873_ctrl.createTextField("tf4", new Point(390, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf5 = MI_58873_ctrl.createTextField("tf5", new Point(480, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf6 = MI_58873_ctrl.createTextField("tf6", new Point(570, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf7 = MI_58873_ctrl.createTextField("tf7", new Point(660, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);

            //tworzę butony używane w ekranie sortowania
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, buttonsPositionY, "SORTUJ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, buttonsPositionY, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, buttonsPositionY, "LOSUJ");

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po wprowadzeniu tekstu w text fieldy
            tf0.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf1.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf2.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf3.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf4.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf5.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf6.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf7.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po kliknięciu w buttony
            countButton.Click += new EventHandler(countButton_Button_Click);
            clearButton.Click += new EventHandler(clearResultPanel_Button_Click);
            randomButton.Click += new EventHandler(randomButton_Button_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            countButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            clearButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            randomButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
            countButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            clearButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            randomButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);

            //wyswietlenie kontrolek w sekcji Panel Wyników
            resultBox.Controls.Add(lblTitle);
            resultBox.Controls.Add(lblfillFields);
            resultBox.Controls.Add(tf0);
            resultBox.Controls.Add(tf1);
            resultBox.Controls.Add(tf2);
            resultBox.Controls.Add(tf3);
            resultBox.Controls.Add(tf4);
            resultBox.Controls.Add(tf5);
            resultBox.Controls.Add(tf6);
            resultBox.Controls.Add(tf7);
            resultBox.Controls.Add(countButton);
            resultBox.Controls.Add(clearButton);
            resultBox.Controls.Add(randomButton);
            resultBox.Controls.Add(lblDescription);
        }

        //to jest metoda która jest odpowiedzalna za zbudowanie elementów do prezentowania wyników sortowania bąbelkowego
        private void buildBubbleResult()
        {
            //przyatne zmienne
            int lblPositionY = 160;
            Font tbFont = new Font("Arial", 23, FontStyle.Bold, GraphicsUnit.Pixel);

            Label lblResultsInfo = MI_58873_ctrl.MI_58873_createLabel("lblResultsInfo", new Point(292, 135), Proj.footerFont, 600, 18, "Wynik sortowania bąbelkowego:", BorderStyle.None, Proj.labelAlignement);
            Label lbl0 = MI_58873_ctrl.MI_58873_createLabel("lbl0", new Point(30, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl1 = MI_58873_ctrl.MI_58873_createLabel("lbl1", new Point(120, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl2 = MI_58873_ctrl.MI_58873_createLabel("lbl2", new Point(210, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl3 = MI_58873_ctrl.MI_58873_createLabel("lbl3", new Point(300, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl4 = MI_58873_ctrl.MI_58873_createLabel("lbl4", new Point(390, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl5 = MI_58873_ctrl.MI_58873_createLabel("lbl5", new Point(480, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl6 = MI_58873_ctrl.MI_58873_createLabel("lbl6", new Point(570, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl7 = MI_58873_ctrl.MI_58873_createLabel("lbl7", new Point(660, lblPositionY), tbFont, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);

            //dodanie kontrolek do ekranu
            resultBox.Controls.Add(lblResultsInfo);
            resultBox.Controls.Add(lbl0);
            resultBox.Controls.Add(lbl1);
            resultBox.Controls.Add(lbl2);
            resultBox.Controls.Add(lbl3);
            resultBox.Controls.Add(lbl4);
            resultBox.Controls.Add(lbl5);
            resultBox.Controls.Add(lbl6);
            resultBox.Controls.Add(lbl7);
        }

        //metoda odpowiedzialna za wykonanie sortowania bąbelkowego
        //metoda przyjmuje listę którą przetwarza i zwraca
        private List<int> bubbleSort(List<int> numbersList)
        {
            //wykonuje się dla każdego indexu znajdującego w liście
            for (int i = 0; i < numbersList.Count; i++)
            {   
                //każdy znaleziony index jest poównywany z kolejmym znakiem dlatego j= i + 1
                for (int j = i + 1; j < numbersList.Count; j++)
                {
                    //pobieram te indexy do poniższych zmiennych
                    int a = numbersList[i];
                    int b = numbersList[j];

                    //jeżeli pierwszy jes większy od drugiego to zamieniam je miejscami
                    if (a > b)
                    {
                        numbersList[i] = b;
                        numbersList[j] = a;
                    }
                }
            }

            //zwracam postortowaną tę samą listę
            return numbersList;
        }

            //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace lub minusem
            private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //informuję program że sender jest textBoxem
            TextBox element = sender as TextBox;

            //sprawdzam czy wciśnięty klawisz jest cyfrą lub backspace lub minusem
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {   
                //jeśli tak to prezentuję userowi odpowiedni tooltip
                e.Handled = true;
                ToolTip tool = new ToolTip
                {
                    ToolTipTitle = "To pole przyjmuje tylko cyfry",
                    ShowAlways = true,
                    InitialDelay = 25
                };
                tool.Show("Wprowadź liczbę typu int", element, 3000);
            }
        }

        //metoda wywoływana po kliknięciuw przycisk SORTUJ
        private void countButton_Button_Click(object sender, EventArgs e)
        {
            //tworzę zmienna która przechowuje info o tym czy text boxy są prawidłowo uzupełnione
            bool isReady = true;

            //wyszukuję wszystkie text boxy znajdujące się w sekcji Panel wyników
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //sprawdzam czy któryś z text boxów nie jest pusty lub nie posiada samego minusa(-)
                if (element.Text.Equals("") || element.Text == "-")
                {
                    //jeśli tak to presentuję userowi odpowiedni komunikat
                    MessageBox.Show("Conajmniej jedno pole w podanych text boxach jest puste albo zawiera znak\"-\".\n\nSprawdź poprawność danych.", "Nieprawidłowa wartość w text box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //i aktualizuję zmienną o informację że nie można zbudować ekranu
                    isReady = false;
                    //wychodze z pętli bo bez sensu już jest sprawdzać pozostałe text boxy - już wiemy że jest źle
                    break;
                }
            }

            //sprawdzam czy zmienna przechowująca info o tym czy text boxy są prawidłowo uzupełniony ma wartość true
            if (isReady)
            {
                //jeśl tak to buduję kontrolki w których będę przechowywał wyniki 
                buildBubbleResult();
                //wykonu i printuje wyniki na ekran
                solveNumbers();
                //blokuję inputy i odpowiednie buttony po wykonaniu sortowania
                blockElementsAfterCount();
            }
        }

        //metoda odpowiedzialna za wyczyszczeniu ekranu RESULT PANEl po kliknięciu w wyczyść
        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            //czyszczę Sekcję Result panel
            clearResultPanel();
            //przywracam inicjalny wygląd sekcji Panel wyników
            buildBubbleSection();
        }

        //metoda wywoływana po kliknięciu LOSUJ
        private void randomButton_Button_Click(object sender, EventArgs e)
        {
            //wyszukuję wszystkie textfieldy które są w sekcji Panel wyników
             foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //i przypisuję do nich randomowe liczby
                Random random = new Random();
                int randomInt = random.Next(-9999, 99999);
                element.Text = randomInt.ToString();
            }
        }

        //metoda odpowiedzialna za wyczyszczenie sekcji Panel wyników
        private void clearResultPanel()
        {
            //wyszukuję sekcję panel wyników i czyszczę ją
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
        }

        //metoda odpowiedzialna za zablokowanie odpowiednich elementów po wykonaniu sortowania- tak aby user nie mógł już danych modyfikować
        private void blockElementsAfterCount()
        {
            //wyszukuję wszystkie text boxy w sekcji Panel wyników
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //zmianiam ich dostępność na false
                //dzięki temu są widoczne ale są nieklikalne
                element.Enabled = false;
            }

            //wyszukuję buttony SORTUJ i LOSUJ
            Button randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            Button countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];

            //blokuje ich klikalność
            if (countButton != null) countButton.Enabled = false;
            if (randomButton != null) randomButton.Enabled = false;
        }

        //metoda odpowiedzialna za pobranie numerów z textboxów, wykonanie sortowania i wyprintowanie wyników
        private void solveNumbers()
        {
            //pobieram dane z text boxów
            List<int> numbersList = new List<int>();
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                try
                {
                    numbersList.Add(Int32.Parse(element.Text));
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Sprawdź czy wszystkie pola są uzupełnione poprawnie", "Sortowanie nie powiodło się.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //sortuję i wyniki przypisuję do nowej listy
            List<int> sortedList = bubbleSort(numbersList);

            //wposortowane wartości z listy przypisuję do odpowiednich labelek
            Label lbl;
            for (int i = 0; i < sortedList.Count; i++)
            {
                lbl = (Label)resultBox.Controls.Find("lbl" + i, true)[0];
                if (lbl != null) { 
                    lbl.Text = sortedList[i].ToString();
                    lbl.BackColor = Proj.succesColor;
                }
            }
        }
    }
}
