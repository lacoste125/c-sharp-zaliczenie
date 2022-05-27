using System;
using System.Drawing;
using System.Windows.Forms;

namespace _58873_IV_
{
    public partial class Proj : Form
    {
        MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        Proj MI_58873_workPanel;
        GroupBox resultBox;
        Matrix matrix;
        Bubble bubble;

        public static readonly Color panelColor = Color.FromKnownColor(KnownColor.Control);
        public static readonly Color foreColor = Color.Black;
        public static readonly Font buttonsFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
        public static readonly ContentAlignment lblTxtCenter = ContentAlignment.MiddleCenter;
        public static readonly BorderStyle lblBorderStyleFixed = BorderStyle.FixedSingle;
        public static readonly ContentAlignment labelAlignement = ContentAlignment.MiddleLeft;

        public Proj()
        {
            InitializeComponent();
            MI_58873_workPanel = this;
            this.Width = 1000;
            this.Height = 600;
            MI_58873_loadControlls();
            matrix = new Matrix(this, resultBox);
            bubble = new Bubble(this, resultBox);
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
            Button MI_58873_btnClear = MI_58873_ctrl.MI_58873_createButton("BtnClear", btnPositionX, 330, btnWidth, btnHeight, buttonsFont, foreColor, panelColor, "NOWE DZIAŁANIE");
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
            bubble.buildBubbleSection();
        }

        private void mainMathButton_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(false);
            matrix.buildMatrixSection();
        }

        //metoda wywoływana po kliknięciu w przucisk CLEAR
        private void MI_58873_btnClear_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(true);
        }

        //metoda wywoływana po kliknięciu w przycisk EXIT
        private void MI_58873_btnExit_Click(object sender, EventArgs e)
        {
            //zamknięcie aplikacji
            Application.Exit();
        }

        private void mainZipButton_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            MI_58873_changeVisibilityButtons(false);
        }

        //metoda odpowiedzialna za efekt po najechaniu na button myszką
        public static void MI_58873_MouseHover(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po najechaniu na button myszką zmieniamy jego kolor na pomarańczowy
            if (MI_58873_button != null) MI_58873_button.BackColor = Color.CornflowerBlue;
        }

        public static void MI_58873_MouseLeave(object sender, EventArgs e)
        {
            //informuję program że element o którym mowa to button
            Button MI_58873_button = sender as Button;
            //po zjechaniu myszką z buttona przypisue mu spowrotem inicjalną wartość
            if (MI_58873_button != null) MI_58873_button.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        
        private void clearResultPanel()
        {
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            //czyszcimy go
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();

            matrix.setShowEmptyTextFieldWarning(true);
        }

        private void MI_58873_changeVisibilityButtons(bool MI_58873_isVisible)
        {
            Button MI_58873_buttonAuto = (Button)this.Controls.Find("mainSortButton", true)[0];
            Button MI_58873_mainMathButton = (Button)this.Controls.Find("mainMathButton", true)[0];
            Button MI_58873_mainZipButton = (Button)this.Controls.Find("mainZipButton", true)[0];

            MI_58873_buttonAuto.Enabled = MI_58873_isVisible;
            MI_58873_mainMathButton.Enabled = MI_58873_isVisible;
            MI_58873_mainZipButton.Enabled = MI_58873_isVisible;
        }
    }
}
