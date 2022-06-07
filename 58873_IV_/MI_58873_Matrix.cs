using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class MI_58873_Matrix
    {
        //instancje elementów
        readonly MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        readonly MI_58873_Proj MI_58873_workPanel;
        readonly GroupBox MI_58873_resultBox;

        //właściwości klasy
        bool MI_58873_showEmptyTextFieldWarning = true;
        readonly int MI_58873_lblWidth = 60;
        readonly int MI_58873_lblHeight = 135;
        readonly int MI_58873_bracketTopPosition = 70;
        readonly BorderStyle MI_58873_laberBorder = BorderStyle.None;

        //konstruktor
        public MI_58873_Matrix(MI_58873_Proj MI_58873_workPanel)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            MI_58873_resultBox = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
        }

        //metoda wywoływana podczas budowania ekranu po wciśnięciu przycisku ALGORYTM MATEMATYCZNY
        public void MI_58873_buildMatrixSection()
        {
            //przydatne zmienne używane w metodzie
            int MI_58873_tbMaxlength = 2;
            int MI_58873_tbWidth = 25;
            int MI_58873_tbHeight = 25;
            int MI_58873_buttonsPositionY = 235;
            int MI_58873_operatorTopPosion = 85;
            Font MI_58873_labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font MI_58873_inputFont = new Font("Arial", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            Font MI_58873_operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            string MI_58873_description = " - Program oblicza iloczyn dwóch macierzy\n"
                + " - Dostępna jest macierz 3x3\n"
                + " - Pola tekstowe przyjmują tylko liczby\n"
                + " - Pola tekstowe przyjmują maksymalnie dwa znaki\n"
                + " - Przycisk \"LOSUJ\" jest odpowiedzialny za losowe przydzielenie wartości do Text Boxów\n"
                + " - Przydzielane wartości są z zakresu <-99;99>";

            //utworzenie labelek używanych podczas budowania sekcji PANEL WYNIKÓW
            Label MI_58873_lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), MI_58873_Proj.MI_58873_titleFont, 575, 35, "Mnożenie macierzy kwadratowej 3x3", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_leftBrackerL = MI_58873_ctrl.MI_58873_createLabel("leftBrackerL", new Point(60, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "[", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_leftBracketR = MI_58873_ctrl.MI_58873_createLabel("leftBracketR", new Point(178, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "]", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_rightBracketL = MI_58873_ctrl.MI_58873_createLabel("rightBracketL", new Point(270, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "[", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_rightBracketR = MI_58873_ctrl.MI_58873_createLabel("rightBracketR", new Point(388, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "]", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(235, MI_58873_operatorTopPosion), MI_58873_operatorFont, MI_58873_lblWidth, MI_58873_lblHeight, "X", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(442, MI_58873_operatorTopPosion), MI_58873_operatorFont, MI_58873_lblWidth, MI_58873_lblHeight, "=", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), MI_58873_inputFont, 725, 140, MI_58873_description, MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_labelAlignement);

            //utworzenie textboxów używanych podczas budowania sekcji PANEL WYNIKÓW
            TextBox MI_58873_left00 = MI_58873_ctrl.createTextField("left00", new Point(120, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left01 = MI_58873_ctrl.createTextField("left01", new Point(120, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left02 = MI_58873_ctrl.createTextField("left02", new Point(120, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left10 = MI_58873_ctrl.createTextField("left10", new Point(150, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left11 = MI_58873_ctrl.createTextField("left11", new Point(150, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left12 = MI_58873_ctrl.createTextField("left12", new Point(150, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left20 = MI_58873_ctrl.createTextField("left20", new Point(180, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left21 = MI_58873_ctrl.createTextField("left21", new Point(180, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_left22 = MI_58873_ctrl.createTextField("left22", new Point(180, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right00 = MI_58873_ctrl.createTextField("right00", new Point(330, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right01 = MI_58873_ctrl.createTextField("right01", new Point(330, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right02 = MI_58873_ctrl.createTextField("right02", new Point(330, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right10 = MI_58873_ctrl.createTextField("right10", new Point(360, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right11 = MI_58873_ctrl.createTextField("right11", new Point(360, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right12 = MI_58873_ctrl.createTextField("right12", new Point(360, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right20 = MI_58873_ctrl.createTextField("right20", new Point(390, 105), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right21 = MI_58873_ctrl.createTextField("right21", new Point(390, 133), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            TextBox MI_58873_right22 = MI_58873_ctrl.createTextField("right22", new Point(390, 161), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_inputFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);

            //utworzenie buttonów używanych podczas budowania sekcji PANEL WYNIKÓW
            Button MI_58873_countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, MI_58873_buttonsPositionY, "OBLICZ");
            Button MI_58873_clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, MI_58873_buttonsPositionY, "WYCZYŚĆ");
            Button MI_58873_randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, MI_58873_buttonsPositionY, "LOSUJ");

            //do wszystkich text boxów na ekranie, przypisuę logikę uruchamianą po wprowadzeniu danych w text box
            MI_58873_left00.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left01.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left02.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left10.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left11.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left12.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left20.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left21.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_left22.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right00.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right01.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right02.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right10.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right11.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right12.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right20.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right21.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);
            MI_58873_right22.KeyPress += new KeyPressEventHandler(MI_58873_keyPress);

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po kliknięciu w buttony
            MI_58873_countButton.Click += new EventHandler(MI_58873_countButton_Button_Click);
            MI_58873_clearButton.Click += new EventHandler(MI_58873_clearResultPanel_Button_Click);
            MI_58873_randomButton.Click += new EventHandler(MI_58873_randomButton_Button_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            MI_58873_countButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_clearButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_randomButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
            MI_58873_countButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_clearButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_randomButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);

            //wszystkie utworzone wcześniej kontrolki, dodaję do panelu wyników
            MI_58873_resultBox.Controls.Add(MI_58873_lblTitle);
            MI_58873_resultBox.Controls.Add(MI_58873_leftBrackerL);
            MI_58873_resultBox.Controls.Add(MI_58873_left00);
            MI_58873_resultBox.Controls.Add(MI_58873_left01);
            MI_58873_resultBox.Controls.Add(MI_58873_left02);
            MI_58873_resultBox.Controls.Add(MI_58873_left10);
            MI_58873_resultBox.Controls.Add(MI_58873_left11);
            MI_58873_resultBox.Controls.Add(MI_58873_left12);
            MI_58873_resultBox.Controls.Add(MI_58873_left20);
            MI_58873_resultBox.Controls.Add(MI_58873_left21);
            MI_58873_resultBox.Controls.Add(MI_58873_left22);
            MI_58873_resultBox.Controls.Add(MI_58873_leftBracketR);
            MI_58873_resultBox.Controls.Add(MI_58873_xChar);
            MI_58873_resultBox.Controls.Add(MI_58873_rightBracketL);
            MI_58873_resultBox.Controls.Add(MI_58873_right00);
            MI_58873_resultBox.Controls.Add(MI_58873_right01);
            MI_58873_resultBox.Controls.Add(MI_58873_right02);
            MI_58873_resultBox.Controls.Add(MI_58873_right10);
            MI_58873_resultBox.Controls.Add(MI_58873_right11);
            MI_58873_resultBox.Controls.Add(MI_58873_right12);
            MI_58873_resultBox.Controls.Add(MI_58873_right20);
            MI_58873_resultBox.Controls.Add(MI_58873_right21);
            MI_58873_resultBox.Controls.Add(MI_58873_right22);
            MI_58873_resultBox.Controls.Add(MI_58873_rightBracketR);
            MI_58873_resultBox.Controls.Add(MI_58873_equalChar);
            MI_58873_resultBox.Controls.Add(MI_58873_countButton);
            MI_58873_resultBox.Controls.Add(MI_58873_clearButton);
            MI_58873_resultBox.Controls.Add(MI_58873_randomButton);
            MI_58873_resultBox.Controls.Add(MI_58873_lblDescription);
        }

        //metoda jest odpowiedzialna za zbudowanie kontrolek w których będą przechowywane wyniki działania 
        private void MI_58873_createMatrixResultFields(int[,] MI_58873_wynik)
        {
            //przydatne zmienne
            int MI_58873_szerokoscLabelki = 45;
            int MI_58873_wysokoscLabelki = 25;
            Font MI_58873_labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font MI_58873_resultFont = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);

            //tworzę odpowiednie labelki
            //proszę zwrócić uwagę że każda labelka odwołuje się do innego indeksu z przysłanej tablicy wielowymiarowej
            //są to indeksy reprezentujące wyniki macierzy wynikowej
            Label MI_58873_result00 = MI_58873_ctrl.MI_58873_createLabel("result00", new Point(530, 105), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[0, 0].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result00.BackColor = MI_58873_Proj.MI_58873_succesColor;
            Label MI_58873_result10 = MI_58873_ctrl.MI_58873_createLabel("result10", new Point(530, 133), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[1, 0].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result10.BackColor = MI_58873_Proj.MI_58873_succesColor;
            Label MI_58873_result20 = MI_58873_ctrl.MI_58873_createLabel("result20", new Point(530, 161), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[2, 0].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result20.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result01 = MI_58873_ctrl.MI_58873_createLabel("result01", new Point(580, 105), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[0, 1].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result01.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result11 = MI_58873_ctrl.MI_58873_createLabel("result11", new Point(580, 133), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[1, 1].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result11.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result21 = MI_58873_ctrl.MI_58873_createLabel("result21", new Point(580, 161), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[2, 1].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result21.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result02 = MI_58873_ctrl.MI_58873_createLabel("result02", new Point(630, 105), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[0, 2].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result02.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result12 = MI_58873_ctrl.MI_58873_createLabel("result12", new Point(630, 133), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[1, 2].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result12.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_result22 = MI_58873_ctrl.MI_58873_createLabel("result22", new Point(630, 161), MI_58873_resultFont, MI_58873_szerokoscLabelki, MI_58873_wysokoscLabelki, MI_58873_wynik[2, 2].ToString(), MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_result22.BackColor = MI_58873_Proj.MI_58873_succesColor; 
            Label MI_58873_resultBracketL = MI_58873_ctrl.MI_58873_createLabel("resultBracketL", new Point(470, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "[", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_resultBracketR = MI_58873_ctrl.MI_58873_createLabel("resultBracketR", new Point(650, MI_58873_bracketTopPosition), MI_58873_labelFont, MI_58873_lblWidth, MI_58873_lblHeight, "]", MI_58873_laberBorder, MI_58873_Proj.MI_58873_labelAlignement);

            //dodaję kontrolki do panelu wyników
            MI_58873_resultBox.Controls.Add(MI_58873_resultBracketL);
            MI_58873_resultBox.Controls.Add(MI_58873_result00);
            MI_58873_resultBox.Controls.Add(MI_58873_result10);
            MI_58873_resultBox.Controls.Add(MI_58873_result20);
            MI_58873_resultBox.Controls.Add(MI_58873_result01);
            MI_58873_resultBox.Controls.Add(MI_58873_result11);
            MI_58873_resultBox.Controls.Add(MI_58873_result21);
            MI_58873_resultBox.Controls.Add(MI_58873_result02);
            MI_58873_resultBox.Controls.Add(MI_58873_result12);
            MI_58873_resultBox.Controls.Add(MI_58873_result22);
            MI_58873_resultBox.Controls.Add(MI_58873_resultBracketR);
        }

        //metoda odpowiedzialna za liczenie macierzy
        private int[,] MI_58873_obliczMacierz()
        {
            //poniżej tworzę listę tablic dwuwymiarowych w których przechowuję pobrane wartości z odpowiednich text fieldów na ekranie
            //wywołuję metodę buildTables która nam taką listę zbuduje
            List<int[,]> MI_58873_macierze = MI_58873_buildTables();

            //deklaruję tablice w której będę przechowywał wartości macierzy
            //pierwsza macierz to tablica z indexem 0 na liście
            //druga macierz to tablica z indeksiem 1 na liście
            int[,] MI_58873_X = MI_58873_macierze[0];
            int[,] MI_58873_Y = MI_58873_macierze[1];

            //deklaruję tablicę w której będę przechowywał wyniki mnożenia
            //3x3 no bo wynik dzielenia dwóch macierzy 3x3 daje nam również macież 3x3
            int[,] MI_58873_Z = new int[3, 3];

            //iterowanie się po wierszach
            for (int MI_58873_i = 0; MI_58873_i < 3; MI_58873_i++)
            {
                //iterowanie się po kolumnach
                for (int MI_58873_j = 0; MI_58873_j < 3; MI_58873_j++)
                {
                    //inicjalnie wyliczony indeks tablicy wielowymiarowej musi mieć wartość 0 
                    MI_58873_Z[MI_58873_i, MI_58873_j] = 0;
                    //wykonanie mnożenia macierzy
                    for (int MI_58873_k = 0; MI_58873_k < 3; MI_58873_k++)
                    {
                        //wszystkie elementy z pierwszego wiersza macierzy A pomnożone przez wszystkie elementy pierwszej kolumny macieży B
                        //to wszystko razem ze sobą zsumowane dają nam wynikowy index macierzy result
                        MI_58873_Z[MI_58873_i, MI_58873_j] += MI_58873_X[MI_58873_i, MI_58873_k] * MI_58873_Y[MI_58873_k, MI_58873_j];
                    }
                }
            }

            //zwracam tablicę wielowymiarową z wynikami mnożenia macierzy
            return MI_58873_Z;
        }

        //metoda odpowiedzialna za zbudowanie listy tablic dwuwymiarowych do przechowywania pobranych wartości z textfieldów
        private List<int[,]> MI_58873_buildTables()
        {
            //deklaruję listę którą będę uzupełniał o odpowiednie tablice
            List<int[,]> MI_58873_list = new List<int[,]>();

            //deklaruję pierwszą tablicę (wartości z pierwszej macierzy) i wywołuję metodę która te wartości przypisze
            int[,] MI_58873_pierwszaMacierz = MI_58873_pobierzWartosciMacierzy("left");
            //deklaruję drugą tablicę (wartości z drugiej macierzy) i wywołuję metodę która te wartości przypisze
            int[,] MI_58873_drugaMacierz = MI_58873_pobierzWartosciMacierzy("right"); ;

            //dodaję do listy wartości macierzy pobranych ekranu
            MI_58873_list.Add(MI_58873_pierwszaMacierz);
            MI_58873_list.Add(MI_58873_drugaMacierz);

            //zwracam tę listę macierzy
            return MI_58873_list;
        }

        //metoda służy do wyszukania text fieldów przechowujących dane macierzy i zbudowanie tablicy dwuwymiarowej która będzie przechowywać warrtości macierzy
        private int[,] MI_58873_pobierzWartosciMacierzy(string MI_58873_matrix)
        {
            //deklaruję textfield
            //robię to raz bo niżej będę tylko zmieniał wartość tej zmiennej
            TextBox MI_58873_textField;

            //w tej metodzie opiszę tylko wyszukanie jednego textfield bo pozostałe sątakie same
            //różnią się tylko wyszukiwanym indeksem i przypisaniem wartości do zmiennej reprezentującej jej index z macierzy

            //deklaruję zmienną odpwowiedzialną za wyszukiwany index
            int MI_58873_index00 = 0;
            //wyszukuję kontrolkę na ekranie - tu chodzi o kontrolkę left lub right z indexem 00
            MI_58873_textField = (TextBox)MI_58873_resultBox.Controls.Find(MI_58873_matrix + "00", true)[0];
            //jeśli kontrolka jest znaleziona to wywołuję metodę do pobrania jej konkretnej wartości
            if (MI_58873_textField != null) MI_58873_index00 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index01 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "01", true)[0];
            if (MI_58873_textField != null) MI_58873_index01 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index02 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "02", true)[0];
            if (MI_58873_textField != null) MI_58873_index02 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index10 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "10", true)[0];
            if (MI_58873_textField != null) MI_58873_index10 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index11 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "11", true)[0];
            if (MI_58873_textField != null) MI_58873_index11 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index12 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "12", true)[0];
            if (MI_58873_textField != null) MI_58873_index12 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index20 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "20", true)[0];
            if (MI_58873_textField != null) MI_58873_index20 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index21 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "21", true)[0];
            if (MI_58873_textField != null) MI_58873_index21 = MI_58873_getValue(MI_58873_textField);

            int MI_58873_index22 = 0;
            MI_58873_textField = (TextBox)MI_58873_workPanel.Controls.Find(MI_58873_matrix + "22", true)[0];
            if (MI_58873_textField != null) MI_58873_index22 = MI_58873_getValue(MI_58873_textField);

            int[,] MI_58873_macierz = new int[3, 3] { { MI_58873_index00, MI_58873_index10, MI_58873_index20 }, { MI_58873_index01, MI_58873_index11, MI_58873_index21 }, { MI_58873_index02, MI_58873_index12, MI_58873_index22 } };

            return MI_58873_macierz;
        }

        //metoda odpowiedzialna za pobranie wartości z kontrolki textfield która przechowują wartości macierzy
        private int MI_58873_getValue(TextBox MI_58873_tb)
        {
            //pobieram tekst z kontrolki
            string MI_58873_returnNumber = MI_58873_tb.Text;

            //sprawdzam czy wartośc text boxa jest pusta i czy komunikat był już użytkownikowi zaprezentowany
            if (MI_58873_returnNumber.Equals("") && MI_58873_showEmptyTextFieldWarning)
            {
                //jeśli wartość text field jest pusta i komunikat nie był prezentowany - to wyświetlam ostrzerzenie
                MessageBox.Show("Conajmniej jedno pole w podanych macierzach jest puste.\n\nNieuzupełnione pola przyjmują wartość 0.", "Niewypełnione pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //i informuję program że użytkownik poinformowany
                //dzięki temu program nie będzie już informował o tym usera w sytuacji gdy więcej pól jest pustych
                MI_58873_setShowEmptyTextFieldWarning(false);
            }

            //na message box informuję usera że puste wartości będą przyjmowały wartość 0
            //czyli jeśli text field jest nullem to przypisuję mu wartość 0
            if (MI_58873_returnNumber == "") MI_58873_returnNumber = "0";

            //deklaruję zmienną do której przypisuję wartość zparsowanej wartości z textfielda
            int MI_58873_parsedReturnNumber = 0;
            try
            {
                //parsuję pobrany text z textfielda na wartość typu int
                MI_58873_parsedReturnNumber = Int32.Parse(MI_58873_returnNumber);
            }
            catch (Exception)
            {
                //jeżeli podczas parsowania jest błąd to wyświetlam użytkownikowy poniższy message box
                //prawdopodobnie user wprowadził sam znak "-" albo np "3-" bo text fieldy przyjmują tylko numery, backspace i minus(-) 
                MessageBox.Show("Ups.\n\nCoś poszło nie tak.\nTextBox " + MI_58873_tb.Name + " prawdopodobnie zawiera nieprawidłowe dane: \"" + MI_58873_tb.Text + "\"" + "\nW miejsce nieprawidłowego elementu zostało podstawione 0 !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //zwracam pobraną liczbę z textfielda
            return MI_58873_parsedReturnNumber;
        }

        //metoda wywoływanapo kliknięciu w przycisk LOSUJ
        private void MI_58873_randomButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wyszukuję wszystkie Text Boxy w panelu wyników
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //generuję losową liczbę
                Random MI_58873_random = new Random();
                int MI_58873_randomInt = MI_58873_random.Next(-99, 99);

                //wygenerowaną lliczbę przypisąję do iterowanego text boxa
                MI_58873_element.Text = MI_58873_randomInt.ToString();
            }
        }

        //metoda odpowiedzialna  za logikę po kliknięciu przycisku OBLICZ
        private void MI_58873_countButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //deklaruję tablicę przechowującą wynik i wywołuję metodę która mi ten wynik zwróci
            int[,] MI_58873_wynik = MI_58873_obliczMacierz();
            //tworzę kontrolki w których ten wynik zaprezentuję
            MI_58873_createMatrixResultFields(MI_58873_wynik);
            //blokuję text boxy na ekranie aby nie można było już ich modyfikować
            MI_58873_blockTextField();

            //wyszukuję butony OBLICZ i LOSUJ
            Button MI_58873_countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
            Button MI_58873_randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];

            //jeśli je znalazłem to blokuję je abe nie można już ich było wcisnąć
            if (MI_58873_countButton != null) MI_58873_countButton.Enabled = false;
            if (MI_58873_randomButton != null) MI_58873_randomButton.Enabled = false;
        }

        //metoda wywoływana po kliknięciu przycisku WYCZYŚĆ
        private void MI_58873_clearResultPanel_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //czyszcze panel wyników
            MI_58873_clearResultPanel();
            //i buduję go inicjalnym wyglądem
            MI_58873_buildMatrixSection();
        }

        //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace lub minusem(-)
        private void MI_58873_keyPress(object MI_58873_sender, KeyPressEventArgs MI_58873_e)
        {
            //informuję program że sender jest textBoxem
            TextBox MI_58873_element = MI_58873_sender as TextBox;

            //sprawdzam czy wciśnięty klawisz jest cyfrą lub backspace lub minusem(-)
            if (!char.IsDigit(MI_58873_e.KeyChar) && MI_58873_e.KeyChar != '\b' && MI_58873_e.KeyChar != '-')
            {
                //jeśli tak to prezentuję userowi odpowiedni tooltip
                MI_58873_e.Handled = true;
                ToolTip MI_58873_tool = new ToolTip
                {
                    ToolTipTitle = "To pole przyjmuje tylko cyfry",
                    ShowAlways = true,
                    InitialDelay = 25
                };
                MI_58873_tool.Show("Wprowadź liczbę typu int", MI_58873_element, 3000);
            }
        }

        //metoda odppowiedzialna za zablokowanie wszystkich textfieldów które znajdzie na ekranie
        //chodzi o textfielde w której user wprowadza wartości macierzy
        //jest to po to ponieważ po kliknięciu OBLICZ nie chcemy żeby user mógł te dane jeszcze modyfikować
        private void MI_58873_blockTextField()
        {
            //wyszukuję wszystkie text boxy w panelu wyników
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //blokuję wszystkie znalezione textboxy
                MI_58873_element.Enabled = false;
            }
        }

        //metoda która przywraca sekcję Panel wyników do inicjalnej wartości
        private void MI_58873_clearResultPanel()
        {
            //wyszukuję i czyszczę sekcję panel wyników
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();

            //zmienną przechowującą info o konieczności zaprezentowania komunikatu gdy jedno z pól było puste, przywracam do wartości inicjalnej
            MI_58873_setShowEmptyTextFieldWarning(true);
        }

        //setter dla flagi do wyświetlania komunikatu o pustym textfieldzie
        public void MI_58873_setShowEmptyTextFieldWarning(bool MI_58873_showEmptyTextFieldWarning)
        {
            this.MI_58873_showEmptyTextFieldWarning = MI_58873_showEmptyTextFieldWarning;
        }
    }
}
