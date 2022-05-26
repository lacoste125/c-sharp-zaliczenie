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
            Label personalData = MI_58873_ctrl.MI_58873_createLabel("personalData", new Point(100,25), footerFont, backColor, Color.Red, 750, 45, "Mariusz Iwański, Index: 58873, Grupa IV", BorderStyle.None, ContentAlignment.MiddleLeft);
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
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            Font inputFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            Font buttonsFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            Color backColor = Color.FromKnownColor(KnownColor.Control);

            Label leftBrackerL = MI_58873_ctrl.MI_58873_createLabel("leftBrackerL", new Point(10, 20), labelFont, backColor, Color.Black, 60, 135, "[", BorderStyle.None, ContentAlignment.MiddleLeft);
            TextBox left00 = MI_58873_ctrl.createTextField("left00", new Point(70, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left01 = MI_58873_ctrl.createTextField("left01", new Point(70, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left02 = MI_58873_ctrl.createTextField("left02", new Point(70, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left10 = MI_58873_ctrl.createTextField("left10", new Point(100, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left11 = MI_58873_ctrl.createTextField("left11", new Point(100, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left12 = MI_58873_ctrl.createTextField("left12", new Point(100, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left20 = MI_58873_ctrl.createTextField("left20", new Point(130, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left21 = MI_58873_ctrl.createTextField("left21", new Point(130, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox left22 = MI_58873_ctrl.createTextField("left22", new Point(130, 111), 25, 25, inputFont, Color.White, Color.Black);
            Label leftBracketR = MI_58873_ctrl.MI_58873_createLabel("leftBracketR", new Point(128, 20), labelFont, backColor, Color.Black, 60, 135, "]", BorderStyle.None, ContentAlignment.MiddleLeft);

            Label xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(185, 35), operatorFont, backColor, Color.Black, 60, 135, "X", BorderStyle.None, ContentAlignment.MiddleLeft);

            Label rightBracketL = MI_58873_ctrl.MI_58873_createLabel("rightBracketL", new Point(220, 20), labelFont, backColor, Color.Black, 60, 135, "[", BorderStyle.None, ContentAlignment.MiddleLeft);
            TextBox right00 = MI_58873_ctrl.createTextField("right00", new Point(280, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right01 = MI_58873_ctrl.createTextField("right01", new Point(280, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right02 = MI_58873_ctrl.createTextField("right02", new Point(280, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right10 = MI_58873_ctrl.createTextField("right10", new Point(310, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right11 = MI_58873_ctrl.createTextField("right11", new Point(310, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right12 = MI_58873_ctrl.createTextField("right12", new Point(310, 111), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right20 = MI_58873_ctrl.createTextField("right20", new Point(340, 55), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right21 = MI_58873_ctrl.createTextField("right21", new Point(340, 83), 25, 25, inputFont, Color.White, Color.Black);
            TextBox right22 = MI_58873_ctrl.createTextField("right22", new Point(340, 111), 25, 25, inputFont, Color.White, Color.Black);
            Label rightBracketR = MI_58873_ctrl.MI_58873_createLabel("rightBracketR", new Point(338, 20), labelFont, backColor, Color.Black, 60, 135, "]", BorderStyle.None, ContentAlignment.MiddleLeft);

            Label equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(392, 35), operatorFont, backColor, Color.Black, 60, 135, "=", BorderStyle.None, ContentAlignment.MiddleLeft);

            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 25, 200, 145, 50, buttonsFont, Color.Black, backColor, "OBLICZ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 175, 200, 145, 50, buttonsFont, Color.Black, backColor, "WYCZYŚĆ");

            //.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

            countButton.Click += new EventHandler(countButton_Button_Click);
            clearButton.Click += new EventHandler(clearResultPanel_Button_Click);

            countButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            clearButton.MouseHover += new EventHandler(MI_58873_MouseHover);

            countButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            clearButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

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
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildMatrix();
        }

        private void countButton_Button_Click(object sender, EventArgs e)
        {
            int[,] wynik = obliczMacierz();
            printResult(wynik);

 /*           Button countButton = (Button)this.Controls.Find( "countButton", true)[0];
            if (countButton != null) countButton.Enabled = false;*/
        }

        private void printResult(int[,] wynik)
        {
            createMatrixResultFields(wynik);
        }

        private void createMatrixResultFields(int[,] wynik)
        {
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font resultFont = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            int szerokoscLabelki = 45;
            int wysokoscLabelki = 25;

            Label resultBracketL = MI_58873_ctrl.MI_58873_createLabel("resultBracketL", new Point(420, 20), labelFont, backColor, Color.Black, 60, 135, "[", BorderStyle.None, ContentAlignment.MiddleLeft);
            Label result00 = MI_58873_ctrl.MI_58873_createLabel("result00", new Point(480, 55), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[0, 0].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result10 = MI_58873_ctrl.MI_58873_createLabel("result10", new Point(480, 83), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[1, 0].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result20 = MI_58873_ctrl.MI_58873_createLabel("result20", new Point(480, 111), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[2, 0].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result01 = MI_58873_ctrl.MI_58873_createLabel("result01", new Point(530, 55), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[0, 1].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result11 = MI_58873_ctrl.MI_58873_createLabel("result11", new Point(530, 83), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[1, 1].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result21 = MI_58873_ctrl.MI_58873_createLabel("result21", new Point(530, 111), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[2, 1].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result02 = MI_58873_ctrl.MI_58873_createLabel("result02", new Point(580, 55), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[0, 2].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result12 = MI_58873_ctrl.MI_58873_createLabel("result12", new Point(580, 83), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[1, 2].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label result22 = MI_58873_ctrl.MI_58873_createLabel("result22", new Point(580, 111), resultFont, backColor, Color.Black, szerokoscLabelki, wysokoscLabelki, wynik[2, 2].ToString(), BorderStyle.FixedSingle, ContentAlignment.MiddleCenter);
            Label resultBracketR = MI_58873_ctrl.MI_58873_createLabel("resultBracketR", new Point(650, 20), labelFont, backColor, Color.Black, 60, 135, "]", BorderStyle.None, ContentAlignment.MiddleLeft);

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
            int[,] Z = new int[3,3];
            
            //iterowanie się po wierszach
            for (int i = 0; i < 3; i++)
            {
                //iterowanie się po kolumnach
                for (int j = 0; j < 3; j++)
                {
                    //inicjalnie wyliczony indeks tablicy wielowymiarowej musi mieć wartość 0 
                    Z[i,j] = 0;
                    //wykonanie mnożenia macierzy
                    for (int k = 0; k < 3; k++)
                    {
                        //wszystkie elementy z pierwszego wiersza macierzy A pomnożone przez wszystkie elementy pierwszej kolumny macieży B
                        //to wszystko razem ze sobą zsumowane dają nam wynikowy index macierzy result
                        Z[i,j] += X[i,k] * Y[k,j];
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
            textField = (TextBox)resultBox.Controls.Find(matrix +"00", true)[0];
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
                MessageBox.Show("Jest 0 a go nie podałeś");
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

        //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace
        private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //jeśli wciśnięty klawisz jest cyfrą - isDigit
            //lub jeśli jest klawiszem Backspace = '\b'
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                //przechwycenie i wyświetlenie odpowiedniego komunikatu dla usera
                e.Handled = true;
                MessageBox.Show("Proszę podać wartość typu int!", "Nieprawidłowy typ wejściowy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //metoda wywoływana po kliknięciu w przycisk EXIT
        private void MI_58873_btnExit_Click(object sender, EventArgs e)
        {
            //zamknięcie aplikacji
            Application.Exit();
        }
    }
}
