using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    public partial class ProjektZaliczeniowy : Form
    {
        //główny panel
        public static ProjektZaliczeniowy MI_58873_workPanel;
        //instancja klasy którą będziemy wykorzysywać do tworzenia kontrolek w locie
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        GroupBox resultBox;
        bool showEmptyTextFieldWarning = true;

        int lblWidth = 60;
        int lblHeight = 135;
        private Color panelColor = Color.FromKnownColor(KnownColor.Control);
        private Color foreColor = Color.Black;
        private Font buttonsFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
        private BorderStyle laberBorder = BorderStyle.None;
        ContentAlignment labelAlignement = ContentAlignment.MiddleLeft;

        public ProjektZaliczeniowy()
        {
            //metoda odpowiedzialna za start aplikacji
            InitializeComponent();
            MI_58873_workPanel = this;
            this.Width = 1000;
            this.Height = 600;
            //wywołanie metody budującej kontrolki w locie
            MI_58873_loadControlls();
        }

        private void MI_58873_loadControlls()
        {
            //przydane zmienne
            Font footerFont = new Font("Microsoft Sans Serif", 28, FontStyle.Bold);
            int btnWidth = 145;
            int btnHeight = 50;
            int btnPositionX = 12;

            //groupboxy
            resultBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 10, 775, 450, "Panel Wyników", "GbResult");
            GroupBox buttonBox = MI_58873_ctrl.MI_58873_createGroupBox(800, 10, 170, 450, "Akcje", "GbManagement");
            GroupBox footerBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 465, 955, 80, "Dane studenta", "GbStopka");

            //labelki
            Label personalData = MI_58873_ctrl.MI_58873_createLabel("personalData", new Point(100, 25), footerFont, panelColor, Color.Red, 750, 45, "Mariusz Iwański, Index: 58873, Grupa IV", BorderStyle.None, ContentAlignment.MiddleLeft);

            //buttony
            Button mainSortButton = MI_58873_ctrl.MI_58873_createButton("mainSortButton", btnPositionX, 25, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "ALGORYTM SORTUJĄCY");
            Button mainMathButton = MI_58873_ctrl.MI_58873_createButton("mainMathButton", btnPositionX, 85, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "ALGORYTM MATEMATYCZNY");
            Button mainZipButton = MI_58873_ctrl.MI_58873_createButton("mainZipButton", btnPositionX, 140, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "ALGORYTM KOMPRESUJĄCY");
            Button MI_58873_btnClear = MI_58873_ctrl.MI_58873_createButton("BtnClear", btnPositionX, 330, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "CLEAR");
            Button MI_58873_btnExit = MI_58873_ctrl.MI_58873_createButton("BtnExit", btnPositionX, 385, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "EXIT");


            //kliknięcie w buttony
            mainSortButton.Click += new EventHandler(mainSortButton_Click);
            mainMathButton.Click += new EventHandler(mainMathButton_Click);
            mainZipButton.Click += new EventHandler(mainZipButton_Click);
            MI_58873_btnClear.Click += new EventHandler(MI_58873_btnClear_Click);
            MI_58873_btnExit.Click += new EventHandler(MI_58873_btnExit_Click);

            //hoover
            mainSortButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            mainMathButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            mainZipButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnClear.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnExit.MouseHover += new EventHandler(MI_58873_MouseHover);

            //leave
            mainSortButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            mainMathButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            mainZipButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_btnClear.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_btnExit.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //przypisanie groupBoxów do ekranu
            MI_58873_workPanel.Controls.Add(resultBox);
            MI_58873_workPanel.Controls.Add(buttonBox);
            MI_58873_workPanel.Controls.Add(footerBox);

            //przypisanie buttonów do panelu Akcje
            buttonBox.Controls.Add(mainSortButton);
            buttonBox.Controls.Add(mainMathButton);
            buttonBox.Controls.Add(mainZipButton);
            buttonBox.Controls.Add(MI_58873_btnExit);
            buttonBox.Controls.Add(MI_58873_btnClear);

            //usupełnienie sekcji dane studenta
            footerBox.Controls.Add(personalData);
        }

        private void mainSortButton_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(false);
        }

        private void mainMathButton_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(false);
            buildMatrix();
        }

        private void buildMatrix()
        {
            //przydatne zmienne
            int btnWidth = 145;
            int btnHeight = 50;
            int tbWidth = 25;
            int tbHeight = 25;
            int buttonsPositionY = 275;
            int bracketTopPosition = 20;
            int operatorTopPosion = 35;
            Color tfBackColor = Color.White;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font inputFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);

            //labelki
            Label leftBrackerL = MI_58873_ctrl.MI_58873_createLabel("leftBrackerL", new Point(10, bracketTopPosition), labelFont, panelColor, foreColor, lblWidth, lblHeight, "[", laberBorder, labelAlignement);
            Label leftBracketR = MI_58873_ctrl.MI_58873_createLabel("leftBracketR", new Point(128, bracketTopPosition), labelFont, panelColor, foreColor, lblWidth, lblHeight, "]", laberBorder, labelAlignement);
            Label rightBracketL = MI_58873_ctrl.MI_58873_createLabel("rightBracketL", new Point(220, bracketTopPosition), labelFont, panelColor, foreColor, lblWidth, lblHeight, "[", laberBorder, labelAlignement);
            Label rightBracketR = MI_58873_ctrl.MI_58873_createLabel("rightBracketR", new Point(338, bracketTopPosition), labelFont, panelColor, foreColor, lblWidth, lblHeight, "]", laberBorder, labelAlignement);
            Label xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(185, operatorTopPosion), operatorFont, panelColor, foreColor, lblWidth, lblHeight, "X", laberBorder, labelAlignement);
            Label equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(392, operatorTopPosion), operatorFont, panelColor, foreColor, lblWidth, lblHeight, "=", laberBorder, labelAlignement);

            //textboxy
            TextBox left00 = MI_58873_ctrl.createTextField("left00", new Point(70, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left01 = MI_58873_ctrl.createTextField("left01", new Point(70, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left02 = MI_58873_ctrl.createTextField("left02", new Point(70, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left10 = MI_58873_ctrl.createTextField("left10", new Point(100, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left11 = MI_58873_ctrl.createTextField("left11", new Point(100, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left12 = MI_58873_ctrl.createTextField("left12", new Point(100, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left20 = MI_58873_ctrl.createTextField("left20", new Point(130, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left21 = MI_58873_ctrl.createTextField("left21", new Point(130, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox left22 = MI_58873_ctrl.createTextField("left22", new Point(130, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right00 = MI_58873_ctrl.createTextField("right00", new Point(280, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right01 = MI_58873_ctrl.createTextField("right01", new Point(280, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right02 = MI_58873_ctrl.createTextField("right02", new Point(280, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right10 = MI_58873_ctrl.createTextField("right10", new Point(310, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right11 = MI_58873_ctrl.createTextField("right11", new Point(310, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right12 = MI_58873_ctrl.createTextField("right12", new Point(310, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right20 = MI_58873_ctrl.createTextField("right20", new Point(340, 55), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right21 = MI_58873_ctrl.createTextField("right21", new Point(340, 83), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);
            TextBox right22 = MI_58873_ctrl.createTextField("right22", new Point(340, 111), tbWidth, tbHeight, inputFont, tfBackColor, foreColor);

            //buttony
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 25, buttonsPositionY, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "OBLICZ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 175, buttonsPositionY, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 325, buttonsPositionY, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "LOSUJ");

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
            countButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            clearButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            randomButton.MouseHover += new EventHandler(MI_58873_MouseHover);

            //leave
            countButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            clearButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            randomButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //przypisanie klawiszy do panelu wyników
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
        }

        private void randomButton_Button_Click(object sender, EventArgs e)
        {
            foreach (var pb in resultBox.Controls.OfType<TextBox>())
            {
                Random random = new Random();
                int randomInt = random.Next(0, 99); 
                pb.Text = randomInt.ToString();
            }
        }

        private void blockTextField()
        {
            foreach (var pb in resultBox.Controls.OfType<TextBox>())
            {
                pb.Enabled = false;
            }
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildMatrix();
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            int[,] wynik = obliczMacierz();
            createMatrixResultFields(wynik);
            blockTextField();

            Button countButton = (Button)this.Controls.Find("countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;

            Button randomButton = (Button)this.Controls.Find("randomButton", true)[0];
            if (randomButton != null) randomButton.Enabled = false;
        }
        private void createMatrixResultFields(int[,] wynik)
        {
            int szerokoscLabelki = 45;
            int wysokoscLabelki = 25;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font resultFont = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            ContentAlignment lblTxtAlign = ContentAlignment.MiddleCenter;
            BorderStyle lblBorderStyle = BorderStyle.FixedSingle;

            Label result00 = MI_58873_ctrl.MI_58873_createLabel("result00", new Point(480, 55), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 0].ToString(), lblBorderStyle, lblTxtAlign);
            Label result10 = MI_58873_ctrl.MI_58873_createLabel("result10", new Point(480, 83), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 0].ToString(), lblBorderStyle, lblTxtAlign);
            Label result20 = MI_58873_ctrl.MI_58873_createLabel("result20", new Point(480, 111), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 0].ToString(), lblBorderStyle, lblTxtAlign);
            Label result01 = MI_58873_ctrl.MI_58873_createLabel("result01", new Point(530, 55), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 1].ToString(), lblBorderStyle, lblTxtAlign);
            Label result11 = MI_58873_ctrl.MI_58873_createLabel("result11", new Point(530, 83), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 1].ToString(), lblBorderStyle, lblTxtAlign);
            Label result21 = MI_58873_ctrl.MI_58873_createLabel("result21", new Point(530, 111), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 1].ToString(), lblBorderStyle, lblTxtAlign);
            Label result02 = MI_58873_ctrl.MI_58873_createLabel("result02", new Point(580, 55), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[0, 2].ToString(), lblBorderStyle, lblTxtAlign);
            Label result12 = MI_58873_ctrl.MI_58873_createLabel("result12", new Point(580, 83), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[1, 2].ToString(), lblBorderStyle, lblTxtAlign);
            Label result22 = MI_58873_ctrl.MI_58873_createLabel("result22", new Point(580, 111), resultFont, backColor, foreColor, szerokoscLabelki, wysokoscLabelki, wynik[2, 2].ToString(), lblBorderStyle, lblTxtAlign);
            Label resultBracketL = MI_58873_ctrl.MI_58873_createLabel("resultBracketL", new Point(420, 20), labelFont, backColor, foreColor, lblWidth, lblHeight, "[", laberBorder, labelAlignement);
            Label resultBracketR = MI_58873_ctrl.MI_58873_createLabel("resultBracketR", new Point(600, 20), labelFont, backColor, foreColor, lblWidth, lblHeight, "]", laberBorder, labelAlignement);

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
            textField = (TextBox)this.Controls.Find(matrix + "01", true)[0];
            if (textField != null) index01 = getValue(textField);

            int index02 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "02", true)[0];
            if (textField != null) index02 = getValue(textField);

            int index10 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "10", true)[0];
            if (textField != null) index10 = getValue(textField);

            int index11 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "11", true)[0];
            if (textField != null) index11 = getValue(textField);

            int index12 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "12", true)[0];
            if (textField != null) index12 = getValue(textField);

            int index20 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "20", true)[0];
            if (textField != null) index20 = getValue(textField);

            int index21 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "21", true)[0];
            if (textField != null) index21 = getValue(textField);

            int index22 = 0;
            textField = (TextBox)this.Controls.Find(matrix + "22", true)[0];
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
                showEmptyTextFieldWarning = false;
            }

            if (returnNumber == "")
            {
                returnNumber = "0";
            }

            return Int32.Parse(returnNumber);
        }

        //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace
        private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //informuję program że sender jest textBoxem
            TextBox element = sender as TextBox;

            //jeśli wciśnięty klawisz jest cyfrą - isDigit
            //lub jeśli jest klawiszem Backspace = '\b'
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                ToolTip tool = new ToolTip();
                tool.ToolTipTitle = "To pole przyjmuje tylko cyfry";
                tool.ShowAlways = true;
                tool.InitialDelay = 25;
                tool.Show("Wprowadź liczbę typu int", element, 3000);
            }
        }

        private void mainZipButton_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(false);
        }

        //metoda odpowiedzialna za efekt po najechaniu na button myszką
        private void MI_58873_MouseHover(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po najechaniu na button myszką zmieniamy jego kolor na pomarańczowy
            if (MI_58873_button != null) MI_58873_button.BackColor = Color.CornflowerBlue;
        }

        //metoda odpowiedzialna za zjechanie myszką z buttona
        private void MI_58873_MouseLeave(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po zjechaniu myszką z buttona przypisue mu spowrotem inicjalną wartość
            if (MI_58873_button != null) MI_58873_button.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        //metoda wywoływana po kliknięciu w przucisk CLEAR
        private void MI_58873_btnClear_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(true);
        }

        //metoda odpowiedzalna za wyczyszczenie sekcji Panel Wyników
        //metoda dostarczona przez wykładowcę
        private void clearResultPanel()
        {
            //wyszukujemy panel w programie
            GroupBox MI_58873_gb = (GroupBox)this.Controls.Find("GbResult", true)[0];
            //czyszcimy go
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
            //zwracamy ten panel

            showEmptyTextFieldWarning = true;
        }

        //metoda odpowiedzialna za sterowanie widocznością buttonów AUTO i MANUAL
        private void MI_58873_changeVisibilityButtons(bool MI_58873_isVisible)
        {
            Button MI_58873_buttonAuto = (Button)this.Controls.Find("mainSortButton", true)[0];
            Button MI_58873_mainMathButton = (Button)this.Controls.Find("mainMathButton", true)[0];
            Button MI_58873_mainZipButton = (Button)this.Controls.Find("mainZipButton", true)[0];

            MI_58873_buttonAuto.Enabled = MI_58873_isVisible;
            MI_58873_mainMathButton.Enabled = MI_58873_isVisible;
            MI_58873_mainZipButton.Enabled = MI_58873_isVisible;
        }

        //metoda wywoływana po kliknięciu w przycisk EXIT
        private void MI_58873_btnExit_Click(object sender, EventArgs e)
        {
            //zamknięcie aplikacji
            Application.Exit();
        }
    }
}
