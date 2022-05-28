using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class Matrix
    {
        //instancje elementów
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        Proj MI_58873_workPanel;
        GroupBox resultBox;

        //właściwości klasy
        bool showEmptyTextFieldWarning = true;
        readonly int lblWidth = 60;
        readonly int lblHeight = 135;
        readonly int bracketTopPosition = 70;
        readonly BorderStyle laberBorder = BorderStyle.None;

        //konstruktor
        public Matrix(Proj MI_58873_workPanel, GroupBox resultBox)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            this.resultBox = resultBox;
        }

        //budowanie ekranu Result
        public void buildMatrixSection()
        {
            //przydatne zmienne
            int tbMaxlength = 2;
            int tbWidth = 25;
            int tbHeight = 25;
            int buttonsPositionY = 235;
            int operatorTopPosion = 85;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font inputFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            string description = " - Program oblicza iloczyn dwóch macierzy\n"
                + " - Dostępna jest macierz 3x3\n"
                + " - Pola tekstowe przyjmują tylko liczby\n"
                + " - Pola tekstowe przyjmują maksymalnie dwa znaki\n"
                + " - Przycisk \"LOSUJ\" jest odpowiedzialny za losowe przydzielenie wartości do Text Boxów\n"
                + " - Przydzielane wartości są z zakresu <-99;99>";

            //labelki
            Label lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), Proj.titleFont, Proj.panelColor, Proj.foreColor, 575, 35, "Mnożenie macierzy kwadratowej 3x3", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label leftBrackerL = MI_58873_ctrl.MI_58873_createLabel("leftBrackerL", new Point(60, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "[", laberBorder, Proj.labelAlignement);
            Label leftBracketR = MI_58873_ctrl.MI_58873_createLabel("leftBracketR", new Point(178, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "]", laberBorder, Proj.labelAlignement);
            Label rightBracketL = MI_58873_ctrl.MI_58873_createLabel("rightBracketL", new Point(270, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "[", laberBorder, Proj.labelAlignement);
            Label rightBracketR = MI_58873_ctrl.MI_58873_createLabel("rightBracketR", new Point(388, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "]", laberBorder, Proj.labelAlignement);
            Label xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(235, operatorTopPosion), operatorFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "X", laberBorder, Proj.labelAlignement);
            Label equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(442, operatorTopPosion), operatorFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "=", laberBorder, Proj.labelAlignement);
            Label lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), inputFont, Proj.panelColor, Proj.foreColor, 725, 140, description, Proj.lblBorderStyleFixed, Proj.labelAlignement);

            //textboxy
            TextBox left00 = MI_58873_ctrl.createTextField("left00", new Point(120, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left01 = MI_58873_ctrl.createTextField("left01", new Point(120, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left02 = MI_58873_ctrl.createTextField("left02", new Point(120, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left10 = MI_58873_ctrl.createTextField("left10", new Point(150, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left11 = MI_58873_ctrl.createTextField("left11", new Point(150, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left12 = MI_58873_ctrl.createTextField("left12", new Point(150, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left20 = MI_58873_ctrl.createTextField("left20", new Point(180, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left21 = MI_58873_ctrl.createTextField("left21", new Point(180, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox left22 = MI_58873_ctrl.createTextField("left22", new Point(180, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right00 = MI_58873_ctrl.createTextField("right00", new Point(330, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right01 = MI_58873_ctrl.createTextField("right01", new Point(330, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right02 = MI_58873_ctrl.createTextField("right02", new Point(330, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right10 = MI_58873_ctrl.createTextField("right10", new Point(360, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right11 = MI_58873_ctrl.createTextField("right11", new Point(360, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right12 = MI_58873_ctrl.createTextField("right12", new Point(360, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right20 = MI_58873_ctrl.createTextField("right20", new Point(390, 105), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right21 = MI_58873_ctrl.createTextField("right21", new Point(390, 133), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);
            TextBox right22 = MI_58873_ctrl.createTextField("right22", new Point(390, 161), tbWidth, tbHeight, inputFont, Proj.inputBackColor, Proj.foreColor, tbMaxlength);

            //buttony
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "OBLICZ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "LOSUJ");

            //wciśnięcie klawisza
            left00.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left01.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left02.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left10.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left11.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left12.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left20.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left21.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            left22.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right00.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right01.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right02.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right10.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right11.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right12.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right20.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right21.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            right22.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

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
            resultBox.Controls.Add(leftBrackerL);
            resultBox.Controls.Add(left00);
            resultBox.Controls.Add(left01);
            resultBox.Controls.Add(left02);
            resultBox.Controls.Add(left10);
            resultBox.Controls.Add(left11);
            resultBox.Controls.Add(left12);
            resultBox.Controls.Add(left20);
            resultBox.Controls.Add(left21);
            resultBox.Controls.Add(left22);
            resultBox.Controls.Add(leftBracketR);
            resultBox.Controls.Add(xChar);
            resultBox.Controls.Add(rightBracketL);
            resultBox.Controls.Add(right00);
            resultBox.Controls.Add(right01);
            resultBox.Controls.Add(right02);
            resultBox.Controls.Add(right10);
            resultBox.Controls.Add(right11);
            resultBox.Controls.Add(right12);
            resultBox.Controls.Add(right20);
            resultBox.Controls.Add(right21);
            resultBox.Controls.Add(right22);
            resultBox.Controls.Add(rightBracketR);
            resultBox.Controls.Add(equalChar);
            resultBox.Controls.Add(countButton);
            resultBox.Controls.Add(clearButton);
            resultBox.Controls.Add(randomButton);
            resultBox.Controls.Add(lblDescription);
        }

        //budowanie wyników 
        private void createMatrixResultFields(int[,] wynik)
        {
            //przydatne zmienne
            int szerokoscLabelki = 45;
            int wysokoscLabelki = 25;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font resultFont = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);

            //labelki
            Label result00 = MI_58873_ctrl.MI_58873_createLabel("result00", new Point(530, 105), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 0].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result10 = MI_58873_ctrl.MI_58873_createLabel("result10", new Point(530, 133), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 0].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result20 = MI_58873_ctrl.MI_58873_createLabel("result20", new Point(530, 161), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 0].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result01 = MI_58873_ctrl.MI_58873_createLabel("result01", new Point(580, 105), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 1].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result11 = MI_58873_ctrl.MI_58873_createLabel("result11", new Point(580, 133), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 1].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result21 = MI_58873_ctrl.MI_58873_createLabel("result21", new Point(580, 161), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 1].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result02 = MI_58873_ctrl.MI_58873_createLabel("result02", new Point(630, 105), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 2].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result12 = MI_58873_ctrl.MI_58873_createLabel("result12", new Point(630, 133), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 2].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label result22 = MI_58873_ctrl.MI_58873_createLabel("result22", new Point(630, 161), resultFont, Proj.panelColor, Proj.foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 2].ToString(), Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label resultBracketL = MI_58873_ctrl.MI_58873_createLabel("resultBracketL", new Point(470, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "[", laberBorder, Proj.labelAlignement);
            Label resultBracketR = MI_58873_ctrl.MI_58873_createLabel("resultBracketR", new Point(650, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "]", laberBorder, Proj.labelAlignement);

            //dodanie kontrolek do ekranu
            resultBox.Controls.Add(resultBracketL);
            resultBox.Controls.Add(result00);
            resultBox.Controls.Add(result10);
            resultBox.Controls.Add(result20);
            resultBox.Controls.Add(result01);
            resultBox.Controls.Add(result11);
            resultBox.Controls.Add(result21);
            resultBox.Controls.Add(result02);
            resultBox.Controls.Add(result12);
            resultBox.Controls.Add(result22);
            resultBox.Controls.Add(resultBracketR);
        }

        private int[,] obliczMacierz()
        {
            List<int[,]> macierze = buildTables();
            int[,] X = macierze[0];
            int[,] Y = macierze[1];

            //deklaruję tablicę w której będę przechowywał wyniki mnożenia
            //3x3 no bo wynik dzielenia dwóch macierzy 3x3 daje nam również macież 3x3
            int[,] Z = new int[3, 3];

            //iterowanie się po wierszach
            for (int i = 0; i < 3; i++)
            {
                //iterowanie się po kolumnach
                for (int j = 0; j < 3; j++)
                {
                    //inicjalnie wyliczony indeks tablicy wielowymiarowej musi mieć wartość 0 
                    Z[i, j] = 0;
                    //wykonanie mnożenia macierzy
                    for (int k = 0; k < 3; k++)
                    {
                        //wszystkie elementy z pierwszego wiersza macierzy A pomnożone przez wszystkie elementy pierwszej kolumny macieży B
                        //to wszystko razem ze sobą zsumowane dają nam wynikowy index macierzy result
                        Z[i, j] += X[i, k] * Y[k, j];
                    }
                }
            }
            return Z;
        }

        private List<int[,]> buildTables()
        {
            List<int[,]> list = new List<int[,]>();
            int[,] pierwszaMacierz = pobierzWartosciMacierzy("left");
            int[,] drugaMacierz = pobierzWartosciMacierzy("right"); ;

            list.Add(pierwszaMacierz);
            list.Add(drugaMacierz);

            return list;
        }

        private int[,] pobierzWartosciMacierzy(string matrix)
        {
            TextBox textField;

            int index00 = 0;
            textField = (TextBox)resultBox.Controls.Find(matrix + "00", true)[0];
            if (textField != null) index00 = getValue(textField);

            int index01 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "01", true)[0];
            if (textField != null) index01 = getValue(textField);

            int index02 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "02", true)[0];
            if (textField != null) index02 = getValue(textField);

            int index10 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "10", true)[0];
            if (textField != null) index10 = getValue(textField);

            int index11 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "11", true)[0];
            if (textField != null) index11 = getValue(textField);

            int index12 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "12", true)[0];
            if (textField != null) index12 = getValue(textField);

            int index20 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "20", true)[0];
            if (textField != null) index20 = getValue(textField);

            int index21 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "21", true)[0];
            if (textField != null) index21 = getValue(textField);

            int index22 = 0;
            textField = (TextBox)MI_58873_workPanel.Controls.Find(matrix + "22", true)[0];
            if (textField != null) index22 = getValue(textField);

            int[,] macierz = new int[3, 3] { { index00, index10, index20 }, { index01, index11, index21 }, { index02, index12, index22 } };

            return macierz;
        }

        private int getValue(TextBox tb)
        {
            string returnNumber = tb.Text;
            if (returnNumber.Equals("") && showEmptyTextFieldWarning)
            {
                MessageBox.Show("Conajmniej jedno pole w podanych macierzach jest puste.\n\nNieuzupełnione pola przyjmują wartość 0.", "Niewypełnione pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setShowEmptyTextFieldWarning(false);
            }

            if (returnNumber == "")
            {
                returnNumber = "0";
            }

            return Int32.Parse(returnNumber);
        }

        private void randomButton_Button_Click(object sender, EventArgs e)
        {
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                Random random = new Random();
                int randomInt = random.Next(-99, 99);
                element.Text = randomInt.ToString();
            }
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            int[,] wynik = obliczMacierz();
            createMatrixResultFields(wynik);
            blockTextField();

            Button countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;

            Button randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            if (randomButton != null) randomButton.Enabled = false;
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildMatrixSection();
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

        private void blockTextField()
        {
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                element.Enabled = false;
            }
        }

        private void clearResultPanel()
        {
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
            setShowEmptyTextFieldWarning(true);
        }

        //setter dla flagi do wyświetlania komunikatu
        public void setShowEmptyTextFieldWarning(bool showEmptyTextFieldWarning)
        {
            this.showEmptyTextFieldWarning = showEmptyTextFieldWarning;
        }
    }
}
