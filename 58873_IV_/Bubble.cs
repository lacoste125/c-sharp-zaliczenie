
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class Bubble
    {
        //instancje elementów
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        Proj MI_58873_workPanel;
        GroupBox resultBox;

        Font footerFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);

        //konstruktor
        public Bubble(Proj MI_58873_workPanel, GroupBox resultBox)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            this.resultBox = resultBox;
        }

        //budowanie ekranu Result
        public void buildBubbleSection()
        {
            //przydatne zmienne
            int tbWidth = 80;
            int tbHeight = 35;
            int buttonsPositionY = 235;
            int tbPositionY = 90;
            int operatorTopPosion = 85;
            int tbMaxlength = 5;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font tbFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            string description = " - Program wynokonuje sortowanie bąbelkowe na podstawie wprowadzonych lub wylosowanych liczb\n"
                + " - Wylosowane liczby są z zakresu <-9999, 99999>\n"
                + " - Program nie przyjmuje liter ani innych znaków oprócz \"-\"\n"
                + " - Każde pole tekstowe przyjmuje maxymalnie 5 znaków\n"
                + " - Program pracuje tylko na liczbach typu int\n"
                + " - Wszystkie niedozwolone operacje starałem się przewidziec i zaprezentować odpowiedni komunikat";

            //labelki
            Label lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), Proj.titleFont, Proj.panelColor, Proj.foreColor, 575, 35, "Sortowanie bąbelkowe", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), footerFont, Proj.panelColor, Proj.foreColor, 725, 140, description, Proj.lblBorderStyleFixed, Proj.labelAlignement);
            Label lblfillFields = MI_58873_ctrl.MI_58873_createLabel("lblfillFields", new Point(195, 63), footerFont, Proj.panelColor, Proj.foreColor, 600, 18, "Wprowadź liczby do posortowania lub kliknij w przycisk \"LOSUJ\"", BorderStyle.None, Proj.labelAlignement);

            //textboxy
            TextBox tf0 = MI_58873_ctrl.createTextField("tf0", new Point(30, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf1 = MI_58873_ctrl.createTextField("tf1", new Point(120, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf2 = MI_58873_ctrl.createTextField("tf2", new Point(210, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf3 = MI_58873_ctrl.createTextField("tf3", new Point(300, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf4 = MI_58873_ctrl.createTextField("tf4", new Point(390, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf5 = MI_58873_ctrl.createTextField("tf5", new Point(480, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf6 = MI_58873_ctrl.createTextField("tf6", new Point(570, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox tf7 = MI_58873_ctrl.createTextField("tf7", new Point(660, tbPositionY), tbWidth, tbHeight, tbFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);

            //buttony
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "SORTUJ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "LOSUJ");

            //wciśnięcie klawisza
            tf0.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf1.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf2.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf3.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf4.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf5.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf6.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            tf7.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

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

        private void buildBubbleResult()
        {
            int lblPositionY = 160;
            Font tbFont = new Font("Arial", 23, FontStyle.Bold, GraphicsUnit.Pixel);

            Label lblResultsInfo = MI_58873_ctrl.MI_58873_createLabel("lblResultsInfo", new Point(292, 135), footerFont, Proj.panelColor, Proj.foreColor, 600, 18, "Wynik sortowania bąbelkowego:", BorderStyle.None, Proj.labelAlignement);
            Label lbl0 = MI_58873_ctrl.MI_58873_createLabel("lbl0", new Point(30, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl1 = MI_58873_ctrl.MI_58873_createLabel("lbl1", new Point(120, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl2 = MI_58873_ctrl.MI_58873_createLabel("lbl2", new Point(210, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl3 = MI_58873_ctrl.MI_58873_createLabel("lbl3", new Point(300, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl4 = MI_58873_ctrl.MI_58873_createLabel("lbl4", new Point(390, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl5 = MI_58873_ctrl.MI_58873_createLabel("lbl5", new Point(480, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl6 = MI_58873_ctrl.MI_58873_createLabel("lbl6", new Point(570, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label lbl7 = MI_58873_ctrl.MI_58873_createLabel("lbl7", new Point(660, lblPositionY), tbFont, Proj.panelColor, Proj.foreColor, 80, 35, "", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);

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
            for(int i = 0; i < sortedList.Count; i++)
            {
                lbl = (Label)resultBox.Controls.Find("lbl"+ i, true)[0];
                if (lbl != null) lbl.Text = sortedList[i].ToString();
            }
        }

        private List<int> bubbleSort(List<int> numbersList)
        {
            for (int i = 0; i < numbersList.Count; i++)
            {
                for (int j = i + 1; j < numbersList.Count; j++)
                {
                    int a = numbersList[i];
                    int b = numbersList[j];

                    if (a > b)
                    {
                        numbersList[i] = b;
                        numbersList[j] = a;
                    }
                }
            }
            return numbersList;
        }

            //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace
            private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //informuję program że sender jest textBoxem
            TextBox element = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {
                e.Handled = true;
                ToolTip tool = new ToolTip();
                tool.ToolTipTitle = "To pole przyjmuje tylko cyfry";
                tool.ShowAlways = true;
                tool.InitialDelay = 25;
                tool.Show("Wprowadź liczbę typu int", element, 3000);
            }
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            bool isReady = true;
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                if (element.Text.Equals("") || element.Text == "-")
                {
                    MessageBox.Show("Conajmniej jedno pole w podanych text boxach jest puste albo zawiera znak\"-\".\n\nSprawdź poprawność danych.", "Nieprawidłowa wartość w text box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isReady = false;
                    break;
                }
            }

            if (isReady)
            {
                buildBubbleResult();
                solveNumbers();
                blockElementsAfterCount();
            }
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildBubbleSection();
        }

        private void randomButton_Button_Click(object sender, EventArgs e)
        {
             foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                Random random = new Random();
                int randomInt = random.Next(-9999, 99999);
                element.Text = randomInt.ToString();
            }
        }

        private void clearResultPanel()
        {
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
        }

        private void blockElementsAfterCount()
        {
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                element.Enabled = false;
            }

            Button countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;

            Button randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            if (randomButton != null) randomButton.Enabled = false;
        }
    }
}
