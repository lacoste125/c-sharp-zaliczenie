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

        //metoda wywoływana podczas budowania ekranu po wciśnięciu przycisku ALGORYTM MATEMATYCZNY
        public void buildMatrixSection()
        {
            //przydatne zmienne używane w metodzie
            int tbMaxlength = 2;
            int tbWidth = 25;
            int tbHeight = 25;
            int buttonsPositionY = 235;
            int operatorTopPosion = 85;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font inputFont = new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            Font operatorFont = new Font("Times New Roman", 60, FontStyle.Regular, GraphicsUnit.Pixel);
            string description = " - Program oblicza iloczyn dwóch macierzy\n"
                + " - Dostępna jest macierz 3x3\n"
                + " - Pola tekstowe przyjmują tylko liczby\n"
                + " - Pola tekstowe przyjmują maksymalnie dwa znaki\n"
                + " - Przycisk \"LOSUJ\" jest odpowiedzialny za losowe przydzielenie wartości do Text Boxów\n"
                + " - Przydzielane wartości są z zakresu <-99;99>";

            //utworzenie labelek używanych podczas budowania sekcji PANEL WYNIKÓW
            Label lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 20), Proj.titleFont, Proj.panelColor, Proj.foreColor, 575, 35, "Mnożenie macierzy kwadratowej 3x3", Proj.lblBorderStyleFixed, Proj.lblTxtCenter);
            Label leftBrackerL = MI_58873_ctrl.MI_58873_createLabel("leftBrackerL", new Point(60, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "[", laberBorder, Proj.labelAlignement);
            Label leftBracketR = MI_58873_ctrl.MI_58873_createLabel("leftBracketR", new Point(178, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "]", laberBorder, Proj.labelAlignement);
            Label rightBracketL = MI_58873_ctrl.MI_58873_createLabel("rightBracketL", new Point(270, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "[", laberBorder, Proj.labelAlignement);
            Label rightBracketR = MI_58873_ctrl.MI_58873_createLabel("rightBracketR", new Point(388, bracketTopPosition), labelFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "]", laberBorder, Proj.labelAlignement);
            Label xChar = MI_58873_ctrl.MI_58873_createLabel("xChar", new Point(235, operatorTopPosion), operatorFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "X", laberBorder, Proj.labelAlignement);
            Label equalChar = MI_58873_ctrl.MI_58873_createLabel("equalChar", new Point(442, operatorTopPosion), operatorFont, Proj.panelColor, Proj.foreColor, lblWidth, lblHeight, "=", laberBorder, Proj.labelAlignement);
            Label lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(25, 300), inputFont, Proj.panelColor, Proj.foreColor, 725, 140, description, Proj.lblBorderStyleFixed, Proj.labelAlignement);

            //utworzenie textboxów używanych podczas budowania sekcji PANEL WYNIKÓW
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

            //utworzenie buttonów używanych podczas budowania sekcji PANEL WYNIKÓW
            Button countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "OBLICZ");
            Button clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "WYCZYŚĆ");
            Button randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, buttonsPositionY, Proj.btnWidth, Proj.btnHeight, Proj.buttonsFont, Proj.foreColor, Proj.panelColor, "LOSUJ");

            //do wszystkich text boxów na ekranie, przypisuę logikę uruchamianą po wprowadzeniu danych w text box
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

            //przypisanie metod odpowiedzialnych za wykonanie odpowiednich akcji po kliknięciu w buttony
            countButton.Click += new EventHandler(countButton_Button_Click);
            clearButton.Click += new EventHandler(clearResultPanel_Button_Click);
            randomButton.Click += new EventHandler(randomButton_Button_Click);

            //do buttonów przypisuję efekt po najechaniu myszką
            countButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            clearButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);
            randomButton.MouseHover += new EventHandler(Proj.MI_58873_MouseHover);

            //do buttonów przypisuję efekt po zjechaniu myszką
            countButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            clearButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);
            randomButton.MouseLeave += new EventHandler(Proj.MI_58873_MouseLeave);

            //wszystkie utworzone wcześniej kontrolki, dodaję do panelu wyników
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

        //metoda jest odpowiedzialna za zbudowanie kontrolek w których będą przechowywane wyniki działania 
        private void createMatrixResultFields(int[,] wynik)
        {
            //przydatne zmienne
            int szerokoscLabelki = 45;
            int wysokoscLabelki = 25;
            Font labelFont = new Font("Times New Roman", 120, FontStyle.Regular, GraphicsUnit.Pixel);
            Font resultFont = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);

            //tworzę odpowiednie labelki
            //proszę zwrócić uwagę że każda labelka odwołuje się do innego indeksu z przysłanej tablicy wielowymiarowej
            //są to indeksy reprezentujące wyniki macierzy wynikowej
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

            //dodaję kontrolki do panelu wyników
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

        //metoda odpowiedzialna za liczenie macierzy
        private int[,] obliczMacierz()
        {
            //poniżej tworzę listę tablic dwuwymiarowych w których przechowuję pobrane wartości z odpowiednich text fieldów na ekranie
            //wywołuję metodę buildTables która nam taką listę zbuduje
            List<int[,]> macierze = buildTables();
            
            //deklaruję tablice w której będę przechowywał wartości macierzy
            //pierwsza macierz to tablica z indexem 0 na liście
            //druga macierz to tablica z indeksiem 1 na liście
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

            //zwracam tablicę wielowymiarową z wynikami mnożenia macierzy
            return Z;
        }

        //metoda odpowiedzialna za zbudowanie listy tablic dwuwymiarowych do przechowywania pobranych wartości z textfieldów
        private List<int[,]> buildTables()
        {
            //deklaruję listę którą będę uzupełniał o odpowiednie tablice
            List<int[,]> list = new List<int[,]>();
            
            //deklaruję pierwszą tablicę (wartości z pierwszej macierzy) i wywołuję metodę która te wartości przypisze
            int[,] pierwszaMacierz = pobierzWartosciMacierzy("left");
            //deklaruję drugą tablicę (wartości z drugiej macierzy) i wywołuję metodę która te wartości przypisze
            int[,] drugaMacierz = pobierzWartosciMacierzy("right"); ;

            //dodaję do listy wartości macierzy pobranych ekranu
            list.Add(pierwszaMacierz);
            list.Add(drugaMacierz);

            //zwracam tę listę macierzy
            return list;
        }

        //metoda służy do wyszukania text fieldów przechowujących dane macierzy i zbudowanie tablicy dwuwymiarowej która będzie przechowywać warrtości macierzy
        private int[,] pobierzWartosciMacierzy(string matrix)
        {
            //deklaruję textfield
            //robię to raz bo niżej będę tylko zmieniał wartość tej zmiennej
            TextBox textField;

            //w tej metodzie opiszę tylko wyszukanie jednego textfield bo pozostałe sątakie same
            //różnią się tylko wyszukiwanym indeksem i przypisaniem wartości do zmiennej reprezentującej jej index z macierzy

            //deklaruję zmienną odpwowiedzialną za wyszukiwany index
            int index00 = 0;
            //wyszukuję kontrolkę na ekranie - tu chodzi o kontrolkę left lub right z indexem 00
            textField = (TextBox)resultBox.Controls.Find(matrix + "00", true)[0];
            //jeśli kontrolka jest znaleziona to wywołuję metodę do pobrania jej konkretnej wartości
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

        //metoda odpowiedzialna za pobranie wartości z kontrolki textfield która przechowują wartości macierzy
        private int getValue(TextBox tb)
        {
            //pobieram tekst z kontrolki
            string returnNumber = tb.Text;

            //sprawdzam czy wartośc text boxa jest pusta i czy komunikat był już użytkownikowi zaprezentowany
            if (returnNumber.Equals("") && showEmptyTextFieldWarning)
            {
                //jeśli wartość text field jest pusta i komunikat nie był prezentowany - to wyświetlam ostrzerzenie
                MessageBox.Show("Conajmniej jedno pole w podanych macierzach jest puste.\n\nNieuzupełnione pola przyjmują wartość 0.", "Niewypełnione pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //i informuję program że użytkownik poinformowany
                //dzięki temu program nie będzie już informował o tym usera w sytuacji gdy więcej pól jest pustych
                setShowEmptyTextFieldWarning(false);
            }

            //na message box informuję usera że puste wartości będą przyjmowały wartość 0
            //czyli jeśli text field jest nullem to przypisuję mu wartość 0
            if (returnNumber == "") returnNumber = "0";

            //deklaruję zmienną do której przypisuję wartość zparsowanej wartości z textfielda
            int parsedReturnNumber = 0;
            try
            {   
                //parsuję pobrany text z textfielda na wartość typu int
                parsedReturnNumber = Int32.Parse(returnNumber);
            }
            catch (Exception)
            {
                //jeżeli podczas parsowania jest błąd to wyświetlam użytkownikowy poniższy message box
                //prawdopodobnie user wprowadził sam znak "-" albo np "3-" bo text fieldy przyjmują tylko numery, backspace i minus(-) 
                MessageBox.Show("Ups.\n\nCoś poszło nie tak.\nTextBox " +tb.Name +" prawdopodobnie zawiera nieprawidłowe dane: \"" + tb.Text + "\"" + "\nWynik działania jest nieprawidłowy." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //zwracam pobraną liczbę z textfielda
            return parsedReturnNumber;
        }

        //metoda wywoływanapo kliknięciu w przycisk LOSUJ
        private void randomButton_Button_Click(object sender, EventArgs e)
        {
            //wyszukuję wszystkie Text Boxy w panelu wyników
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //generuję losową liczbę
                Random random = new Random();
                int randomInt = random.Next(-99, 99);

                //wygenerowaną lliczbę przypisąję do iterowanego text boxa
                element.Text = randomInt.ToString();
            }
        }

        //metoda odpowiedzialna  za logikę po kliknięciu przycisku OBLICZ
        private void countButton_Button_Click(object sender, EventArgs e)
        {
            //deklaruję tablicę przechowującą wynik i wywołuję metodę która mi ten wynik zwróci
            int[,] wynik = obliczMacierz();
            //tworzę kontrolki w których ten wynik zaprezentuję
            createMatrixResultFields(wynik);
            //blokuję text boxy na ekranie aby nie można było już ich modyfikować
            blockTextField();

            //wyszukuję butony OBLICZ i LOSUJ
            Button countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
            Button randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];
            
            //jeśli je znalazłem to blokuję je abe nie można już ich było wcisnąć
            if (countButton != null) countButton.Enabled = false;
            if (randomButton != null) randomButton.Enabled = false;
        }

        private void clearResultPanel_Button_Click(object sender, EventArgs e)
        {
            clearResultPanel();
            buildMatrixSection();
        }

        //metoda sprawdzająca czy wciśnięty klawisz jest cyfrą lub backspace lub minusem(-)
        private void MI_58873_keyPress(object sender, KeyPressEventArgs e)
        {
            //informuję program że sender jest textBoxem
            TextBox element = sender as TextBox;

            //sprawdzam czy wciśnięty klawisz jest cyfrą lub backspace lub minusem(-)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {
                //jeśli tak to prezentuję userowi odpowiedni tooltip
                e.Handled = true;
                ToolTip tool = new ToolTip();
                tool.ToolTipTitle = "To pole przyjmuje tylko cyfry";
                tool.ShowAlways = true;
                tool.InitialDelay = 25;
                tool.Show("Wprowadź liczbę typu int", element, 3000);
            }
        }

        //metoda odppowiedzialna za zablokowanie wszystkich textfieldów które znajdzie na ekranie
        //chodzi o textfielde w której user wprowadza wartości macierzy
        //jest to po to ponieważ po kliknięciu OBLICZ nie chcemy żeby user mógł te dane jeszcze modyfikować
        private void blockTextField()
        {
            //wyszukuję wszystkie text boxy w panelu wyników
            foreach (var element in resultBox.Controls.OfType<TextBox>())
            {
                //blokuję wszystkie znalezione textboxy
                element.Enabled = false;
            }
        }

        //metoda która przywraca sekcję Panel wyników do inicjalnej wartości
        private void clearResultPanel()
        {
            //wyszukuję i czyszczę sekcję panel wyników
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();

            //zmienną przechowującą info o konieczności zaprezentowania komunikatu gdy jedno z pól było puste, przywracam do wartości inicjalnej
            setShowEmptyTextFieldWarning(true);
        }

        //setter dla flagi do wyświetlania komunikatu o pustym textfieldzie
        public void setShowEmptyTextFieldWarning(bool showEmptyTextFieldWarning)
        {
            this.showEmptyTextFieldWarning = showEmptyTextFieldWarning;
        }
    }
}
