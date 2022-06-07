using System;
using System.Drawing;
using System.Windows.Forms;

namespace _58873_IV_
{
    public partial class MI_58873_Proj : Form
    {
        //deklaracje instancji klas których będziemy używać 
        readonly MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        readonly MI_58873_Proj MI_58873_workPanel;
        readonly MI_58873_Matrix MI_58873_matrix;
        readonly MI_58873_Bubble MI_58873_bubble;
        readonly MI_58873_Compress MI_58873_compress;

        //zmienne wykorzystywane w klasach Form1, matrix i bubble
        public static readonly Color MI_58873_foreColor = Color.Black;
        public static readonly Color MI_58873_succesColor = Color.FromArgb(123, 186, 0);
        public static readonly ContentAlignment MI_58873_lblTxtCenter = ContentAlignment.MiddleCenter;
        public static readonly BorderStyle MI_58873_lblBorderStyleFixed = BorderStyle.FixedSingle;
        public static readonly ContentAlignment MI_58873_labelAlignement = ContentAlignment.MiddleLeft;
        public static readonly Font MI_58873_titleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
        public static readonly Color MI_58873_inputBackColor = Color.White;
        public static readonly Font MI_58873_footerFont = new Font("Arial", 15, FontStyle.Regular, GraphicsUnit.Pixel);

        public MI_58873_Proj()
        {   
            //inicjalizujemy komponenty
            MI_58873_InitializeComponent();
            MI_58873_workPanel = this;

            //ustawiamy rozmiar okna
            this.Width = 1000;
            this.Height = 600;
            //usunięcie przycisku maksymalizowania okienka
            this.MaximizeBox = false;
            //usunięcie przycisku minimalizowania okienka
            this.MinimizeBox = false;
            //zablokowanie możliwość zmiany wielkości okna za pomocą myszki
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //wywołuję metodą odpowiedzialną za zbudowanie głównego okna
            MI_58873_loadControlls();

            //inicjalizuje instancje klas reprezentujących poszczególne funkcjonalności
            MI_58873_matrix = new MI_58873_Matrix(this);
            MI_58873_bubble = new MI_58873_Bubble(this);
            MI_58873_compress = new MI_58873_Compress(this);
        }

        //poniższa meetoda służy do zbudowania ekranu od razu po uruchomieniu programu
        private void MI_58873_loadControlls()
        {
            //przydane zmienne
            Font MI_58873_footerFont = new Font("Arial", 28, FontStyle.Bold);
            int MI_58873_btnPositionX = 12;

            //inicjalizuję wszystkie groupoxy które będą na ekranie
            GroupBox MI_58873_resultBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 10, 775, 450, "Panel Wyników", "GbResult");
            GroupBox MI_58873_buttonBox = MI_58873_ctrl.MI_58873_createGroupBox(800, 10, 170, 450, "Akcje", "GbManagement");
            GroupBox MI_58873_footerBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 465, 955, 80, "Dane studenta", "GbStopka");

            //inicjalizuję labelkę na której będą prezentowane dane studenta
            Label MI_58873_personalData = MI_58873_ctrl.MI_58873_createLabel("personalData", new Point(100, 25), MI_58873_footerFont, 750, 45, "Mariusz Iwański, Index: 58873, Grupa IV", BorderStyle.None, ContentAlignment.MiddleLeft);
            MI_58873_personalData.ForeColor = Color.Green;

            //inicjalizuję buttony 
            Button MI_58873_mainSortButton = MI_58873_ctrl.MI_58873_createButton("mainSortButton", MI_58873_btnPositionX, 25, "ALGORYTM SORTUJĄCY");
            Button MI_58873_mainMathButton = MI_58873_ctrl.MI_58873_createButton("mainMathButton", MI_58873_btnPositionX, 85, "ALGORYTM MATEMATYCZNY");
            Button MI_58873_mainZipButton = MI_58873_ctrl.MI_58873_createButton("mainZipButton", MI_58873_btnPositionX, 140, "ALGORYTM KOMPRESUJĄCY");
            Button MI_58873_btnClear = MI_58873_ctrl.MI_58873_createButton("BtnClear", MI_58873_btnPositionX, 330, "WYCZYŚĆ EKRAN");
            //podczas uruchomienia aplikacji chcę aby przycisk WYCZYŚĆ EKRAN był niedostępny
            MI_58873_btnClear.Enabled = false;
            Button MI_58873_btnExit = MI_58873_ctrl.MI_58873_createButton("BtnExit", MI_58873_btnPositionX, 385, "EXIT");

            //przypisuję metody wywoływane po kliknięciu w buttony
            MI_58873_mainSortButton.Click += new EventHandler(MI_58873_mainSortButton_Click);
            MI_58873_mainMathButton.Click += new EventHandler(MI_58873_mainMathButton_Click);
            MI_58873_mainZipButton.Click += new EventHandler(MI_58873_mainZipButton_Click);
            MI_58873_btnClear.Click += new EventHandler(MI_58873_btnClear_Click);
            MI_58873_btnExit.Click += new EventHandler(MI_58873_btnExit_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            MI_58873_mainSortButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_mainMathButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_mainZipButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnClear.MouseHover += new EventHandler(MI_58873_MouseHover);
            MI_58873_btnExit.MouseHover += new EventHandler(MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
            MI_58873_mainSortButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_mainMathButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_mainZipButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_btnClear.MouseLeave += new EventHandler(MI_58873_MouseLeave);
            MI_58873_btnExit.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            //przypisanie groupBoxów do ekranu
            MI_58873_workPanel.Controls.Add(MI_58873_resultBox);
            MI_58873_workPanel.Controls.Add(MI_58873_buttonBox);
            MI_58873_workPanel.Controls.Add(MI_58873_footerBox);

            //przypisanie buttonów do panelu Akcje
            MI_58873_buttonBox.Controls.Add(MI_58873_mainSortButton);
            MI_58873_buttonBox.Controls.Add(MI_58873_mainMathButton);
            MI_58873_buttonBox.Controls.Add(MI_58873_mainZipButton);
            MI_58873_buttonBox.Controls.Add(MI_58873_btnExit);
            MI_58873_buttonBox.Controls.Add(MI_58873_btnClear);

            //usupełnienie sekcji dane studenta
            MI_58873_footerBox.Controls.Add(MI_58873_personalData);

            //wywołanie metody która printuje na ekran instrukcje dla przycisków
            MI_58873_printIntroduction();
        }

        //to jest metoda która jest wywoływana po kliknięciu w button "ALGORYTM SORTUJĄCY"
        private void MI_58873_mainSortButton_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            MI_58873_clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do sortowania
            //metoda znajduje się w klasie Bubble
            MI_58873_bubble.MI_58873_buildBubbleSection();
        }

        //to jest metoda wywoływana po kliknięciu w button "ALGORYTM MATEMATYCZNY"
        private void MI_58873_mainMathButton_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            MI_58873_clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do liczenia macierzy
            //metoda znajduje się w klasie Matrix
            MI_58873_matrix.MI_58873_buildMatrixSection();
        }

        //metoda wywoływana po kliknięciu w przucisk CLEAR
        private void MI_58873_btnClear_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //czyścimy panel wynikowy
            MI_58873_clearResultPanel();
            //przywracamy widoczność buttonów ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(true);
            //wywołujemy metodę printującą instrukcję
            MI_58873_printIntroduction();
        }

        //metoda wywoływana po kliknięciu w przycisk EXIT
        private void MI_58873_btnExit_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //zamknięcie aplikacji
            Application.Exit();
        }

        //to jest metoda wywoływana po kliknięciu w button "ALGORYTM KOMPRESUJĄCY"
        private void MI_58873_mainZipButton_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wywołanie metody czyszczącej panel wynikowy - na wypadek gdyby coś tam się w nim znajdowało
            MI_58873_clearResultPanel();
            //wywołanie metody odpowiedzialnej za ukrycie dostępności przycisków ALGORYTM SORTUJĄCY,MATEMATYCZNY i KOMPRESUJĄCY
            MI_58873_changeVisibilityButtons(false);
            //wywołanie metody która zbuduje nam ekran z kontrolkami do wykonania kompresji
            //metoda znajduje się w klasie Matrix
            MI_58873_compress.MI_58873_buildCompressSection();
        }

        //metoda odpowiedzialna za efekt po najechaniu na button myszką
        public static void MI_58873_MouseHover(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //jeśli element jest buttonem to po najechaniu na button myszką zmieniamy jego kolor na pomarańczowy
            if (MI_58873_sender is Button MI_58873_button) MI_58873_button.BackColor = Color.CornflowerBlue;
        }

        //ta metoda jest odpowiedzialna za efekt po zabraniu kursora myszki z elementu
        public static void MI_58873_MouseLeave(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //jeśli sender jest buttonem to po zjechaniu myszką z buttona przypisue mu spowrotem inicjalną wartość
            if (MI_58873_sender is Button MI_58873_button) MI_58873_button.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        //metoda odpowiedzialna za wyczysczenie kontrolek w panelu wyników
        private void MI_58873_clearResultPanel()
        {
            //wyszukujemy elementy które chcemy przywrócić do stanu inicjalnego
            GroupBox MI_58873_resultPanel = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            Button MI_58873_clearBtn = (Button)MI_58873_workPanel.Controls.Find("BtnClear", true)[0];

            //jeśli elementu zostały znalezione to
            // resultPanel czyścimy
            if (MI_58873_resultPanel.Controls.Count > 0) MI_58873_resultPanel.Controls.Clear();
            //button clear ustawiamy na dostępny
            if (MI_58873_clearBtn != null) MI_58873_clearBtn.Enabled = true;

            //w klasie matrix jest zmienna która jest modyfikowana gdy pojawi się MessageBox o nieuzupełnionym polu
            //przywracam wartość inicjalną dla tego pola
            MI_58873_matrix.MI_58873_setShowEmptyTextFieldWarning(true);
        }

        //metoda odpowiedzialna za sterowanie dostępności przycisków w sekcji AKCJE
        private void MI_58873_changeVisibilityButtons(bool MI_58873_isVisible)
        {   
            //wyszukuję buttony w aplikacji - tu chodzi o buttony z sekcji po prawej stronie
            Button MI_58873_buttonAuto = (Button)this.Controls.Find("mainSortButton", true)[0];
            Button MI_58873_mainMathButton = (Button)this.Controls.Find("mainMathButton", true)[0];
            Button MI_58873_mainZipButton = (Button)this.Controls.Find("mainZipButton", true)[0];
            Button MI_58873_clearBtn = (Button)MI_58873_workPanel.Controls.Find("BtnClear", true)[0];

            //jeśli powyższe butony zostaną znalezione to zmieniam ich dostępnośc na taką samą wartość jak w przysłanej wartości 
            if (MI_58873_buttonAuto != null) MI_58873_buttonAuto.Enabled = MI_58873_isVisible;
            if (MI_58873_mainMathButton != null) MI_58873_mainMathButton.Enabled = MI_58873_isVisible;
            if (MI_58873_mainZipButton != null) MI_58873_mainZipButton.Enabled = MI_58873_isVisible;
            //button CLEAR zawsze będzie miał przeciwną dostępnośc niz pozostałe buttony
            if (MI_58873_clearBtn != null) MI_58873_clearBtn.Enabled = !MI_58873_isVisible;
        }

        //metoda tworzy i dodaje do ekranu labelki z instrukcją dla buttonów nawigacyjnych
        private void MI_58873_printIntroduction()
        {
            //powtarzające się wartości wrzucone do zmiennych
            Font MI_58873_introductionFont = new Font("Arial", 17, FontStyle.Regular, GraphicsUnit.Pixel);
            BorderStyle MI_58873_noBorder = BorderStyle.None;
            ContentAlignment MI_58873_rightAlign = ContentAlignment.MiddleRight;
            int MI_58873_height = 25;
            int MI_58873_weight = 750;
            int MI_58873_x = 24;

            //tworzę odpowiednie labelki
            Label MI_58873_sortInfo = MI_58873_ctrl.MI_58873_createLabel("sortInfo", new Point(MI_58873_x, 40), MI_58873_introductionFont, MI_58873_weight, MI_58873_height, "Budowanie ekranu dla algorytmu sortującego >>>>", MI_58873_noBorder, MI_58873_rightAlign);
            Label MI_58873_mathInfo = MI_58873_ctrl.MI_58873_createLabel("mathInfo", new Point(MI_58873_x, 100), MI_58873_introductionFont, MI_58873_weight, MI_58873_height, "Budowanie ekranu dla algorytmu matematycznego >>>>", MI_58873_noBorder, MI_58873_rightAlign);
            Label MI_58873_compressInfo = MI_58873_ctrl.MI_58873_createLabel("compressInfo", new Point(MI_58873_x, 154), MI_58873_introductionFont, MI_58873_weight, MI_58873_height, "Budowanie ekranu dla algorytmu kompresującego >>>>", MI_58873_noBorder, MI_58873_rightAlign);
            Label MI_58873_clearInfo = MI_58873_ctrl.MI_58873_createLabel("clearInfo", new Point(MI_58873_x, 345), MI_58873_introductionFont, MI_58873_weight, MI_58873_height, "Przywrócenie programu do inicjalnego wyglądu >>>>", MI_58873_noBorder, MI_58873_rightAlign);
            Label MI_58873_exitInfo = MI_58873_ctrl.MI_58873_createLabel("exitInfo", new Point(MI_58873_x, 399), MI_58873_introductionFont, MI_58873_weight, MI_58873_height, "Zakończenie pracy programu >>>>", MI_58873_noBorder, MI_58873_rightAlign);

            //wyszukuje resultPanel w programie
            GroupBox MI_58873_resultBox = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];

            //dodaję labelki do ekranu
            MI_58873_resultBox.Controls.Add(MI_58873_sortInfo);
            MI_58873_resultBox.Controls.Add(MI_58873_mathInfo);
            MI_58873_resultBox.Controls.Add(MI_58873_compressInfo);
            MI_58873_resultBox.Controls.Add(MI_58873_clearInfo);
            MI_58873_resultBox.Controls.Add(MI_58873_exitInfo);
        }
    }
}
