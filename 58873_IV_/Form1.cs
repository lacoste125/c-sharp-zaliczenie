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
            //tworze work panel w którem prezentowany będzie rezultat działania programu
            resultBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 10, 775, 450, "Panel Wyników", "GbResult");
            MI_58873_workPanel.Controls.Add(resultBox);

            //tworzę panel zawierający przyciski do zarządzania programem
            GroupBox buttonBox = MI_58873_ctrl.MI_58873_createGroupBox(800, 10, 170, 450, "Akcje", "GbManagement");
            MI_58873_workPanel.Controls.Add(buttonBox);

            //panel z moimi danymi
            GroupBox footerBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 465, 955, 80, "Dane studenta", "GbStopka");
            MI_58873_workPanel.Controls.Add(footerBox);

            //ponizej właśniwości dla przycisków w sekcji po prawej stronie
            Font buttonsFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            Color fontColor = Color.Black;
            Color backColor = Color.FromKnownColor(KnownColor.Control);

            Button mainSortButton = MI_58873_ctrl.MI_58873_createButton("mainSortButton", 12, 25, 145, 50, buttonsFont, fontColor, backColor, "ALGORYTM SORTUJĄCY");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            mainSortButton.Click += new EventHandler(mainSortButton_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            mainSortButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            mainSortButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            Button mainMathButton = MI_58873_ctrl.MI_58873_createButton("mainMathButton", 12, 85, 145, 50, buttonsFont, fontColor, backColor, "ALGORYTM MATEMATYCZNY");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            mainMathButton.Click += new EventHandler(mainMathButton_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            mainMathButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            mainMathButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            Button mainZipButton = MI_58873_ctrl.MI_58873_createButton("mainZipButton", 12, 140, 145, 50, buttonsFont, fontColor, backColor, "ALGORYTM KOMPRESUJĄCY");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            mainZipButton.Click += new EventHandler(mainZipButton_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            mainZipButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            mainZipButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //tworzę przycisk odpowiedzialny za wyczyszczenie ekranu - prezentacja ekrany jak podczas uruchomienia
            Button MI_58873_btnClear = MI_58873_ctrl.MI_58873_createButton("BtnClear", 12, 330, 145, 50, buttonsFont, fontColor, backColor, "CLEAR");
            //przypisuję do niego metodę wywoływaną po jego kliknięciu
            MI_58873_btnClear.Click += new EventHandler(MI_58873_btnClear_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            MI_58873_btnClear.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            MI_58873_btnClear.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //tworzę przycisk odpowiedzialny za zamknięcie aplikacji
            Button MI_58873_btnExit = MI_58873_ctrl.MI_58873_createButton("BtnExit", 12, 385, 145, 50, buttonsFont, fontColor, backColor, "EXIT");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            MI_58873_btnExit.Click += new EventHandler(MI_58873_btnExit_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            MI_58873_btnExit.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            MI_58873_btnExit.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //wszystkie wygenerowane powyżej kontrolki przypisuę do odpowiedniej sekcji w programie
            buttonBox.Controls.Add(mainSortButton);
            buttonBox.Controls.Add(mainMathButton);
            buttonBox.Controls.Add(mainZipButton);
            buttonBox.Controls.Add(MI_58873_btnExit);
            buttonBox.Controls.Add(MI_58873_btnClear);

            Font footerFont = new Font("Microsoft Sans Serif", 28, FontStyle.Bold);
            //string MI_58873_name, Point MI_58873_location, Font MI_58873_font, Color MI_58873_backColor, Color MI_58873_foreColor, int MI_58873_width, int MI_58873_height, string MI_58873_text
            Label personalData = MI_58873_ctrl.MI_58873_createLabel("personalData", new Point(100,25), footerFont, backColor, Color.Red, 750, 45, "Mariusz Iwański, Index: 58873, Grupa IV");
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
            buildResultPanel();
        }

        private void buildResultPanel()
        {
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font inputFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            Font buttonsFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            Color backColor = Color.FromKnownColor(KnownColor.Control);

            Label aBracketL = MI_58873_ctrl.MI_58873_createLabel("aBracketL", new Point(10, 20), labelFont, backColor, Color.Black, 60, 135, "[");
            TextBox aFirstDigit = MI_58873_ctrl.createTextField("oneOne", new Point(70, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aSecondDigit = MI_58873_ctrl.createTextField("oneTwo", new Point(70, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aThirdDigit = MI_58873_ctrl.createTextField("oneThree", new Point(70, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aFourthDigit = MI_58873_ctrl.createTextField("oneFour", new Point(100, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aFifthDigit = MI_58873_ctrl.createTextField("oneFive", new Point(100, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aSixthDigit = MI_58873_ctrl.createTextField("oneSix", new Point(100, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aSeventhDigit = MI_58873_ctrl.createTextField("oneSeven", new Point(130, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aEighthDigit = MI_58873_ctrl.createTextField("oneEight", new Point(130, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox aNinethDigit = MI_58873_ctrl.createTextField("oneNine", new Point(130, 111), 25, 25, inputFont, Color.White, Color.Black);
            Label aBracketR = MI_58873_ctrl.MI_58873_createLabel("aBracketR", new Point(128, 20), labelFont, backColor, Color.Black, 60, 135, "]");

            Label xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(185, 65), operatorFont, backColor, Color.Black, 60, 135, "X");

            Label bBracketL = MI_58873_ctrl.MI_58873_createLabel("bBracketL", new Point(220, 20), labelFont, backColor, Color.Black, 60, 135, "[");
            TextBox bFirstDigit = MI_58873_ctrl.createTextField("twoOne", new Point(280, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bSecondDigit = MI_58873_ctrl.createTextField("twoTwo", new Point(280, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bThirdDigit = MI_58873_ctrl.createTextField("twoThree", new Point(280, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bFourthDigit = MI_58873_ctrl.createTextField("twoFour", new Point(310, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bFifthDigit = MI_58873_ctrl.createTextField("twoFive", new Point(310, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bSixthDigit = MI_58873_ctrl.createTextField("twoSix", new Point(310, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bSeventhDigit = MI_58873_ctrl.createTextField("twoSeven", new Point(340, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox bEighthDigit = MI_58873_ctrl.createTextField("twoEight", new Point(340, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox vNinethDigit = MI_58873_ctrl.createTextField("twoNine", new Point(340, 111), 25, 25, inputFont, Color.White, Color.Black);
            Label bBracketR = MI_58873_ctrl.MI_58873_createLabel("bBracketR", new Point(338, 20), labelFont, backColor, Color.Black, 60, 135, "]");

            Label equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(392, 65), operatorFont, backColor, Color.Black, 60, 135, "=");

            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 25, 200, 145, 50, buttonsFont, Color.Black, backColor, "OBLICZ");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            countButton.Click += new EventHandler(countButton_Button_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            countButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            countButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 175, 200, 145, 50, buttonsFont, Color.Black, backColor, "WYCZYŚĆ");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            clearButton.Click += new EventHandler(clearResultPanel_Button_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            clearButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            clearButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            resultBox.Controls.Add(aBracketL);
            resultBox.Controls.Add(aFirstDigit);
            resultBox.Controls.Add(aSecondDigit);
            resultBox.Controls.Add(aThirdDigit);
            resultBox.Controls.Add(aFourthDigit);
            resultBox.Controls.Add(aFifthDigit);
            resultBox.Controls.Add(aSixthDigit);
            resultBox.Controls.Add(aSeventhDigit);
            resultBox.Controls.Add(aEighthDigit);
            resultBox.Controls.Add(aNinethDigit);
            resultBox.Controls.Add(aBracketR);

            resultBox.Controls.Add(xChar);

            resultBox.Controls.Add(bBracketL);
            resultBox.Controls.Add(bFirstDigit);
            resultBox.Controls.Add(bSecondDigit);
            resultBox.Controls.Add(bThirdDigit);
            resultBox.Controls.Add(bFourthDigit);
            resultBox.Controls.Add(bFifthDigit);
            resultBox.Controls.Add(bSixthDigit);
            resultBox.Controls.Add(bSeventhDigit);
            resultBox.Controls.Add(bEighthDigit);
            resultBox.Controls.Add(vNinethDigit);
            resultBox.Controls.Add(bBracketR);

            resultBox.Controls.Add(equalChar);

            resultBox.Controls.Add(countButton);
            resultBox.Controls.Add(clearButton);

        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildResultPanel();
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            obliczMacierz();

            Button countButton = (Button)this.Controls.Find( "countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;
        }

        private void obliczMacierz()
        {
            buildTables();
        }

        private List<int[,]> buildTables()
        {
            List<int[,]> list = new List<int[,]>();
            int[,] pierwszaMacierz = pobierzWartosciMacierzy("one");
            int[,] drugaMacierz = pobierzWartosciMacierzy("two"); ;

            list.Add(pierwszaMacierz);
            list.Add(drugaMacierz);

            return list;
        }

        private int[,] pobierzWartosciMacierzy(string matrix)
        {
            //int[,] macierz = new int[3,3];
            TextBox textField;

            int one = 0;
            textField = (TextBox)resultBox.Controls.Find(matrix +"One", true)[0];
            if (textField != null) one = getValue(textField);

            int two = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Two", true)[0];
            if (textField != null) two = getValue(textField);

            int three = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Three", true)[0];
            if (textField != null) two = getValue(textField);

            int four = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Four", true)[0];
            if (textField != null) four = getValue(textField);

            int five = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Five", true)[0];
            if (textField != null) five = getValue(textField);

            int six = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Six", true)[0];
            if (textField != null) six = getValue(textField);

            int seven = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Seven", true)[0];
            if (textField != null) seven = getValue(textField);

            int eight = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Eight", true)[0];
            if (textField != null) eight = getValue(textField);

            int nine = 0;
            textField = (TextBox)this.Controls.Find(matrix + "Nine", true)[0];
            if (textField != null) nine = getValue(textField);

            int[,] macierz = new int[3, 3] { { one, four, seven }, { two, five, eight }, { three, six, nine } };

            return macierz;
        }

        private int getValue(TextBox tb)
        {
            string returnNumber = tb.Text;

            if (returnNumber.Equals("") && showEmptyTextFieldWarning)
            {
                MessageBox.Show("Jedno z pól jest puste", "Jedno z pól jest puste", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showEmptyTextFieldWarning = false;
            }

            if (returnNumber == "")
            {
                returnNumber = "0";
            }

            return Int32.Parse(returnNumber);
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
