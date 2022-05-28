using System;
using System.Drawing;
using System.Windows.Forms;

namespace _58873_IV_
{
    public partial class Proj : Form
    {
        //deklaracje instancji klas których będziemy używać 
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        Proj MI_58873_workPanel;
        GroupBox resultBox;
        Matrix matrix;
        Bubble bubble;
        Compress compress;

        //zmienne wykorzystywane w klasach Form1, matrix i bubble
        public static readonly Color foreColor = Color.Black;
        public static readonly Color buttonColor = Color.FromKnownColor(KnownColor.Control);
        public static readonly ContentAlignment lblTxtCenter = ContentAlignment.MiddleCenter;
        public static readonly BorderStyle lblBorderStyleFixed = BorderStyle.FixedSingle;
        public static readonly ContentAlignment labelAlignement = ContentAlignment.MiddleLeft;
        public static readonly Font titleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
        public static readonly Color inputBackColor = Color.White;
        public static readonly Font footerFont = new Font("Arial", 15, FontStyle.Regular, GraphicsUnit.Pixel);

        public Proj()
        {   
            //inicjalizujemy komponenty
            InitializeComponent();
            MI_58873_workPanel = this;
            //ustawiamy rozmiar okna
            this.Width = 1000;
            this.Height = 600;
            //wywołuję metodą odpowiedzialną za zbudowanie głównego okna
            MI_58873_loadControlls();

            //inicjalizuje instancje klas reprezentujących poszczególne funkcjonalności
            matrix = new Matrix(this, resultBox);
            bubble = new Bubble(this, resultBox);
            compress = new Compress(this, resultBox);
        }

        //poniższa meetoda służy do zbudowania ekranu od razu po uruchomieniu programu
        private void MI_58873_loadControlls()
        {
            //przydane zmienne
            Font footerFont = new Font("Arial", 28, FontStyle.Bold);
            int btnPositionX = 12;

            //inicjalizuję wszystkie groupoxy które będą na ekranie
            resultBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 10, 775, 450, "Panel Wyników", "GbResult");
            GroupBox buttonBox = MI_58873_ctrl.MI_58873_createGroupBox(800, 10, 170, 450, "Akcje", "GbManagement");
            GroupBox footerBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 465, 955, 80, "Dane studenta", "GbStopka");

            //inicjalizuję labelkę na której będą prezentowane dane studenta
            Label personalData = MI_58873_ctrl.MI_58873_createLabel("personalData", new Point(100, 25), footerFont, 750, 45, "Mariusz Iwański, Index: 58873, Grupa IV", BorderStyle.None, ContentAlignment.MiddleLeft);
            personalData.ForeColor = Color.Green;

            //inicjalizuję buttony 
            Button mainSortButton = MI_58873_ctrl.MI_58873_createButton("mainSortButton", btnPositionX, 25, "ALGORYTM SORTUJĄCY");
            Button mainMathButton = MI_58873_ctrl.MI_58873_createButton("mainMathButton", btnPositionX, 85, "ALGORYTM MATEMATYCZNY");
            Button mainZipButton = MI_58873_ctrl.MI_58873_createButton("mainZipButton", btnPositionX, 140, "ALGORYTM KOMPRESUJĄCY");
            Button MI_58873_btnClear = MI_58873_ctrl.MI_58873_createButton("BtnClear", btnPositionX, 330, "WYCZYŚĆ EKRAN");
            //podczas uruchomienia aplikacji chcę aby przycisk WYCZYŚĆ EKRAN był niedostępny
            MI_58873_btnClear.Enabled = false;
            Button MI_58873_btnExit = MI_58873_ctrl.MI_58873_createButton("BtnExit", btnPositionX, 385, "EXIT");

            //przypisuję metody wywoływane po kliknięciu w buttony
            mainSortButton.Click += new EventHandler(mainSortButton_Click);
            mainMathButton.Click += new EventHandler(mainMathButton_Click);
            mainZipButton.Click += new EventHandler(mainZipButton_Click);
            MI_58873_btnClear.Click += new EventHandler(MI_58873_btnClear_Click);
            MI_58873_btnExit.Click += new EventHandler(MI_58873_btnExit_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            mainSortButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            mainMathButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            mainZipButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnClear.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnExit.MouseHover += new EventHandler(MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
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

        //to jest metoda która jest wywoływana po kliknięciu w button "ALGORYTM SORTUJĄCY"
        private void mainSortButton_Click(object sender, EventArgs e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do sortowania
            //metoda znajduje się w klasie Bubble
            bubble.buildBubbleSection();
        }

        //to jest metoda wywoływana po kliknięciu w button "ALGORYTM MATEMATYCZNY"
        private void mainMathButton_Click(object sender, EventArgs e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do liczenia macierzy
            //metoda znajduje się w klasie Matrix
            matrix.buildMatrixSection();
        }

        //metoda wywoływana po kliknięciu w przucisk CLEAR
        private void MI_58873_btnClear_Click(object sender, EventArgs e)
        {
            //czyścimy panel wynikowy
            clearResultPanel();
            //przywracamy widoczność buttonów ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(true);
        }

        //metoda wywoływana po kliknięciu w przycisk EXIT
        private void MI_58873_btnExit_Click(object sender, EventArgs e)
        {
            //zamknięcie aplikacji
            Application.Exit();
        }

        //to jest metoda wywoływana po kliknięciu w button "ALGORYTM KOMPRESUJĄCY"
        private void mainZipButton_Click(object sender, EventArgs e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do wykonania kompresji
            //metoda znajduje się w klasie Matrix
            compress.buildCompressSection();
        }

        //metoda odpowiedzialna za efekt po najechaniu na button myszką
        public static void MI_58873_MouseHover(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po najechaniu na button myszką zmieniamy jego kolor na pomarańczowy
            if (MI_58873_button != null) MI_58873_button.BackColor = Color.CornflowerBlue;
        }

        //ta metoda jest odpowiedzialna za efekt po zabraniu kursora myszki z elementu
        public static void MI_58873_MouseLeave(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po zjechaniu myszką z buttona przypisue mu spowrotem inicjalną wartość
            if (MI_58873_button != null) MI_58873_button.BackColor = buttonColor;
        }

        //metoda odpowiedzialna za 
        private void clearResultPanel()
        {
            //wyszukujemy elementy które chcemy przywrócić do stanu inicjalnego
            GroupBox resultPanel = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            Button clearBtn = (Button)MI_58873_workPanel.Controls.Find("BtnClear", true)[0];

            //jeśli elementu zostały znalezione to
            // resultPanel czyścimy
            if (resultPanel.Controls.Count > 0) resultPanel.Controls.Clear();
            //button clear ustawiamy na dostępny
            if (clearBtn != null) clearBtn.Enabled = true;

            //w klasie matrix jest zmienna która jest modyfikowana gdy pojawi się MessageBox o nieuzupełnionym polu
            //przywracam wartość inicjalną dla tego pola
            matrix.setShowEmptyTextFieldWarning(true);
        }

        //metoda odpowiedzialna za sterowanie dostępności przycisków w sekcji AKCJE
        private void MI_58873_changeVisibilityButtons(bool MI_58873_isVisible)
        {   
            //wyszukuję buttony w aplikacji - tu chodzi o buttony z sekcji po prawej stronie
            Button MI_58873_buttonAuto = (Button)this.Controls.Find("mainSortButton", true)[0];
            Button MI_58873_mainMathButton = (Button)this.Controls.Find("mainMathButton", true)[0];
            Button MI_58873_mainZipButton = (Button)this.Controls.Find("mainZipButton", true)[0];
            Button clearBtn = (Button)MI_58873_workPanel.Controls.Find("BtnClear", true)[0];

            //jeśli powyższe butony zostaną znalezione to zmieniam ich dostępnośc na taką samą wartość jak w przysłanej wartości 
            if (MI_58873_buttonAuto != null) MI_58873_buttonAuto.Enabled = MI_58873_isVisible;
            if (MI_58873_mainMathButton != null) MI_58873_mainMathButton.Enabled = MI_58873_isVisible;
            if (MI_58873_mainZipButton != null) MI_58873_mainZipButton.Enabled = MI_58873_isVisible;
            //button CLEAR zawsze będzie miał przeciwną dostępnośc niz pozostałe buttony
            if (clearBtn != null) clearBtn.Enabled = !MI_58873_isVisible;
        }
    }
}
