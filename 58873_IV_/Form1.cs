using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace _58873_IV_
{
    public partial class ProjektZaliczeniowy : Form
    {
        //główny panel
        public static ProjektZaliczeniowy MI_58873_workPanel;
        //instancja klasy którą będziemy wykorzysywać do tworzenia kontrolek w locie
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();

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
            GroupBox resultBox = MI_58873_ctrl.MI_58873_createGroupBox(15, 10, 775, 450, "Panel Wyników", "GbResult");
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
            mainMathButton.Click += new EventHandler(mainZipButton_Click);
            //przypisuję metodę wywoływaną gdy najedziemy na przycisk myszką
            mainMathButton.MouseHover += new EventHandler(MI_58873_MouseHover);
            //przypisuję metodę wywoływaną gdy z elkementu zjedziemy myszką
            mainMathButton.MouseLeave += new EventHandler(MI_58873_MouseLeave);

            Button mainZipButton = MI_58873_ctrl.MI_58873_createButton("mainZipButton", 12, 140, 145, 50, buttonsFont, fontColor, backColor, "ALGORYTM KOMPRESUJĄCY");
            //przypisuję do niego metodę wywoływaną po kliknięciu
            mainZipButton.Click += new EventHandler(mainSortButton_Click);
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
            //wywiołanie metody czyszczącej Work Panel
            //MI_58873_clearWorkPanel();
            //wywołanie metody odpowiedzialnej za przywrócenie widoczności dla przycisków AUTO i MANUAL
            MI_58873_changeVisibilityButtons(true);
            int c = 4 - 4;
            try
            {
                int r = 4 / c;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Dzielisz przez 0", "Wyjątek", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
