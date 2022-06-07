
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _58873_IV_
{
    class MI_58873_Compress
    {
        //instancje elementów
        readonly MI_58873_Controlls MI_58873_ctrl = new MI_58873_Controlls();
        readonly MI_58873_Proj MI_58873_workPanel;
        readonly GroupBox MI_58873_resultBox;

        //tu przechowuję tekst do skompresowania i po skompresowaniu
        string MI_58873_textDoSkompresowania = "";
        string MI_58873_textAfterDecompression = "";

        //konstruktor
        public MI_58873_Compress(MI_58873_Proj MI_58873_workPanel)
        {
            this.MI_58873_workPanel = MI_58873_workPanel;
            MI_58873_resultBox = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
        }

        //mertoda odpowiedzialna za zbudowanie ekranu do kompresji 
        public void MI_58873_buildCompressSection()
        {
            //przydatne zmienne
            int MI_58873_tbWidth = 450;
            int MI_58873_tbHeight = 35;
            int MI_58873_buttonsPositionY = 300;
            int MI_58873_tbPositionY = 84;
            int MI_58873_tbMaxlength = 20;
            Font MI_58873_tbFont = new Font("Arial", 23, FontStyle.Bold, GraphicsUnit.Pixel);
            Font MI_58873_titleFont = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            Font MI_58873_footerFont = new Font("Arial", 15, FontStyle.Regular, GraphicsUnit.Pixel);
            string MI_58873_description = "- Program realizuje kompresję oraz dekompresję metodą Hufmanna\n"
                + "- Input inicjalnie jest wypełniony ciągiem \"XADJSOSDAOUAZADXSXOD\"\n"
                + "- Input przyjmuje dowolne znaki z klawiatury, max 20 znaków\n"
                + "- Nie wszystkie ciągi są dobrze kompresowane i dekompresowane. Nie udało mi się ustalić co jest tego powodem\n"
                + "- Przycisk \"LOSUJ\" generuje losowy ciąg liter. Długość wygenerowanego tekstu to 6 znaków.";

            //labelki wykorzystywane w ekranie Kompresja
            Label MI_58873_lblTitle = MI_58873_ctrl.MI_58873_createLabel("lblTitle", new Point(100, 19), MI_58873_titleFont, 575, 35, "Kompresja Huffmanna", MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);
            Label MI_58873_lblfillField = MI_58873_ctrl.MI_58873_createLabel("lblfillField", new Point(195, 61), MI_58873_Proj.MI_58873_footerFont, 500, 18, "Wprowadź ciąg do skopresowania lub kliknij w przycisk \"LOSUJ\"", BorderStyle.None, MI_58873_Proj.MI_58873_labelAlignement);
            Label MI_58873_lblDescription = MI_58873_ctrl.MI_58873_createLabel("lblDescription", new Point(15, 353), MI_58873_footerFont, 746, 90, MI_58873_description, MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_labelAlignement);

            //textboxy wykorzystywane w ekranie Kompresja
            TextBox MI_58873_inputText = MI_58873_ctrl.MI_58873_createTextField("inputText", new Point(163, MI_58873_tbPositionY), MI_58873_tbWidth, MI_58873_tbHeight, MI_58873_tbFont, MI_58873_Proj.MI_58873_inputBackColor, MI_58873_Proj.MI_58873_foreColor, MI_58873_tbMaxlength);
            MI_58873_inputText.Text = "XADJSOSDAOUAZADXSXOD";

            //buttony wykorzystywane w ekranie Kompresja
            Button MI_58873_countButton = MI_58873_ctrl.MI_58873_createButton("countButton", 135, MI_58873_buttonsPositionY,  "KOMPRESUJ");
            Button MI_58873_clearButton = MI_58873_ctrl.MI_58873_createButton("clearResultPanel", 495, MI_58873_buttonsPositionY,  "WYCZYŚĆ");
            Button MI_58873_randomButton = MI_58873_ctrl.MI_58873_createButton("randomButton", 313, MI_58873_buttonsPositionY,"LOSUJ");

            //do klawiszy przypisuję metodę odpowiedzialne za reakcje po kliknięciu
            MI_58873_countButton.Click += new EventHandler(MI_58873_countButton_Button_Click);
            MI_58873_clearButton.Click += new EventHandler(MI_58873_clearResultPanel_Button_Click);
            MI_58873_randomButton.Click += new EventHandler(MI_58873_randomButton_Button_Click);

            //efekt po najechaniu myszką na button
            MI_58873_countButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_clearButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
            MI_58873_randomButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);

            //efety po zjechaniu z buttona myszką
            MI_58873_countButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_clearButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);
            MI_58873_randomButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);

            //przypisanie klawiszy do panelu wyników
            MI_58873_resultBox.Controls.Add(MI_58873_lblTitle);
            MI_58873_resultBox.Controls.Add(MI_58873_lblfillField);
            MI_58873_resultBox.Controls.Add(MI_58873_inputText);
            MI_58873_resultBox.Controls.Add(MI_58873_countButton);
            MI_58873_resultBox.Controls.Add(MI_58873_clearButton);
            MI_58873_resultBox.Controls.Add(MI_58873_randomButton);
            MI_58873_resultBox.Controls.Add(MI_58873_lblDescription);
        }

        //metoda wywoływana po kliknięciu w button KOMPRESUJ
        private void MI_58873_countButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wywołuję tworzenie elemetnów przechowujących wyniki i wywołuję kompresję
            MI_58873_buildCompressionResultSpace();
        }

        //metoda do blokowania przycisków LOSUJ i KOMPRESUJ
        private void MI_58873_blockResultButtons()
        {
            //robię to w bloku try catch bo jedej sytuacji przycik decompress jest nie dostępny i rzucany jest wyjątek
            try
            {
                //wyszukuję przyciski
                Button MI_58873_countButton = (Button)MI_58873_workPanel.Controls.Find("countButton", true)[0];
                Button MI_58873_randomButton = (Button)MI_58873_workPanel.Controls.Find("randomButton", true)[0];

                //blokuję ich klikalność
                MI_58873_countButton.Enabled = false;
                MI_58873_randomButton.Enabled = false;

                //to samo dla decompress button
                Button MI_58873_decompressButton = (Button)MI_58873_workPanel.Controls.Find("decompressButton", true)[0];
                MI_58873_decompressButton.Enabled = false;
            }
            catch (IndexOutOfRangeException)
            {
                //ignore
                //nie blokuje tu niczego bo nie ma takiej potrzeby
            }
        }

        //metoda odpowiedzialna za zbudowanie ekranu i wykonanie logiki
        private void MI_58873_buildCompressionResultSpace()
        {
            //sprawdzam czy pole jest uzupełnione poprawnie
            //jeśli nie to wychodzę z tej metody
            if (!MI_58873_checkInputText()) return;

            //metoda tworzy elementy które będą przechowywac wyniki kompresji
            MI_58873_createCompressionFields();

            //tworzę obiekty które będą przechowywały wyniki kompresji
            List<string> MI_58873_listaKompresji = new List<string>();
            List<MI_58873_WystepującyZnak> MI_58873_znaki = new List<MI_58873_WystepującyZnak>();

            //wykonuję kompresję a jej wynik przypisuje do odpowiedniej zmiennej 
            bool MI_58873_compressionResult = MI_58873_kompresuj(MI_58873_textDoSkompresowania, ref MI_58873_listaKompresji, ref MI_58873_znaki);

            //jeśli kompresja się udała to dopiero wtedy tworze pozostałe kontrolki prezentujące wyniki
            if (MI_58873_compressionResult)
            {
                //blokuję buttony żeby nie można było ich użyć 
                MI_58873_blockResultButtons();

                //wysokość poniższych labelek
                int MI_58873_labelY = 120;

                //labelki
                Label MI_58873_titleChars = MI_58873_ctrl.MI_58873_createLabel("titleChars", new Point(7, MI_58873_labelY), MI_58873_Proj.MI_58873_footerFont, 200, 18, "Zestawienie znaków:", BorderStyle.None, MI_58873_Proj.MI_58873_labelAlignement);
                Label MI_58873_compressedChars = MI_58873_ctrl.MI_58873_createLabel("compressedChars", new Point(228, MI_58873_labelY), MI_58873_Proj.MI_58873_footerFont, 500, 18, "Skompresowany ciąg znaków:", BorderStyle.None, MI_58873_Proj.MI_58873_labelAlignement);

                //buttony
                Button MI_58873_decompressButton = MI_58873_ctrl.MI_58873_createButton("decompressButton", 400, 192, "DEKOMPRESUJ");
                //do buttonu przypisuję metodę która się wywoła po kliknięciu
                MI_58873_decompressButton.Click += new EventHandler(MI_58873_decompressButton_Button_Click);
                //oraz standardowo hover i leave
                MI_58873_decompressButton.MouseHover += new EventHandler(MI_58873_Proj.MI_58873_MouseHover);
                MI_58873_decompressButton.MouseLeave += new EventHandler(MI_58873_Proj.MI_58873_MouseLeave);

                //i dodaję te przed chwilą utworzone elementy do sekcji Panel wyników
                MI_58873_resultBox.Controls.Add(MI_58873_decompressButton);
                MI_58873_resultBox.Controls.Add(MI_58873_titleChars);
                MI_58873_resultBox.Controls.Add(MI_58873_compressedChars);

                //wykonuję też dodatkowo dekompresje ale jej wyniku jeszcze nie wyświetlam użytkownikowi
                //wynik i pozostała logika została zaimplementowana po kliknięciu w button DEKOPRESJA
                MI_58873_textAfterDecompression = MI_58873_dekompresuj(MI_58873_znaki, MI_58873_listaKompresji);
            }
        }

        //metoda jest odpowiedzialna za wykonanie kompresji i przypisanie wyników do odpowiednich pól
        private bool MI_58873_kompresuj(string MI_58873_textDoSkompresowania, ref List<string> MI_58873_listaKompresji, ref List<MI_58873_WystepującyZnak> MI_58873_znaki)
        {
            //wywołanie metody kompresującej
            //wynik kompresji przechowuje w zmiennej bool
            bool MI_58873_compressionResult = MI_58873_Kompresja.MI_58873_KompresjaHuffmanna(MI_58873_textDoSkompresowania, ref MI_58873_listaKompresji, ref MI_58873_znaki);

            //wyszukuje listbox w której będę wyświetlał kody binarne
            ListBox MI_58873_resultSpace = (ListBox)MI_58873_workPanel.Controls.Find("binaryCodes", true)[0];

            //wyszukuje labelkę w której będę wyświetlał ciąg po skompresowaniu
            Label MI_58873_resultCodesSpace = (Label)MI_58873_workPanel.Controls.Find("lblAfterCompression", true)[0];

            //jeśli kompresja się udała
            if (MI_58873_compressionResult)
            {
                //jesli znaleziony został Listbox
                if (MI_58873_resultSpace != null)
                {
                    //włączam ten list box - presentuję go userowi
                    MI_58873_resultSpace.Visible = true;
                    //koloruję go na zielono
                    MI_58873_resultSpace.BackColor = MI_58873_Proj.MI_58873_succesColor;

                    //iteruję się po liście znaków i przypisuję jej wartości do kolejnych wierszy listBox
                    MI_58873_znaki.ForEach(MI_58873_x => MI_58873_resultSpace.Items.Add("Znak: " + MI_58873_x.MI_58873_Znak + " Ilość: " + MI_58873_x.MI_58873_Ilosc + " Kod Binarny: " + MI_58873_x.MI_58873_BinaryCode));
                }

                //jeśli znalazłem labelkę do printowania skompresowanego ciągu
                if (MI_58873_resultCodesSpace != null)
                {
                    //ustawiam jej obramowanie tak aby była labelka widoczna
                    //bo tak na prawdę to ta labelka była już tam wcześniej :)
                    MI_58873_resultCodesSpace.BorderStyle = MI_58873_Proj.MI_58873_lblBorderStyleFixed;
                    MI_58873_resultCodesSpace.BackColor = MI_58873_Proj.MI_58873_succesColor;

                    //dodaje do labelki znak rozpoczynający skompresowany ciąg
                    MI_58873_resultCodesSpace.Text = "[";

                    //iteruję się po liście i dodaje do labelki kolejne elementy z tej listy
                    MI_58873_listaKompresji.ForEach(x => MI_58873_resultCodesSpace.Text += x + " ");

                    //zamykam skompresowany ciąg
                    MI_58873_resultCodesSpace.Text += "EOF]";
                }
            }

            //zwracam wynik tej kompresji
            return MI_58873_compressionResult;
        }

        //metoda tworzy obiekty które będą przechowywać wyniki kompresji
        private void MI_58873_createCompressionFields()
        {
            //zmienna przechowująca czciąnkę labelki resultFont
            //robię to tutaj dopiero bo  bedzie ona utworzona tylko wtedy gdy wcześniejsza instrukcja nie przerwie działania metody
            Font MI_58873_resultFont = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);

            //labelka potrzebna do prezentacji 
            Label MI_58873_lblAfterCompression = MI_58873_ctrl.MI_58873_createLabel("lblAfterCompression", new Point(230, 140), MI_58873_resultFont, 535, 50, "", BorderStyle.None, MI_58873_Proj.MI_58873_lblTxtCenter);
            MI_58873_resultBox.Controls.Add(MI_58873_lblAfterCompression);

            //tworze list box który będzie przehowywał kody binarne
            ListBox MI_58873_binaryCodes = MI_58873_ctrl.MI_58873_createListBox("binaryCodes", new Point(8, 140), 215, 165);
            //inicjalnie ten list box jest wyłączony
            MI_58873_binaryCodes.Visible = false;
            //dodaję go do ekranu
            MI_58873_resultBox.Controls.Add(MI_58873_binaryCodes);
        }

        //metoda służy do sprawdzenia popawności wypełnienia inputa
        private bool MI_58873_checkInputText()
        {
            //wyszukuję textbox w którym znajduje się cąg do skompresowania
            TextBox MI_58873_textField = (TextBox)MI_58873_resultBox.Controls.Find("inputText", true)[0];

            //jeśli textbox znalazłem
            if (MI_58873_textField != null)
            {
                //jeśli wartość tekstu w inpucie jest pustym stringiem
                if (MI_58873_textField.Text.Equals(""))
                {
                    //wyświetlam userowi message box z info że pole nie może być puste
                    MessageBox.Show("Ciąg do kompresji nie może być pusty.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //informuję że 
                    return false;
                }
                else
                {
                    //jeśli input nie jest pusty to przypisuję jego wartość do odpowiedniej zmiennej
                    MI_58873_textDoSkompresowania = MI_58873_textField.Text;
                    //i blokuję ten input aby go nie można już było zmodyfikować
                    MI_58873_textField.Enabled = false;
                    return true;
                }
            }

            //jeśli nie znalazłem to zwracam takie info
            else return false;
        }


        //logika po kliknięciu w przycisk DEKOMPRESUJ
        //sama dekompresja była już wykonana wcześniej, tu tylko sprawdzam poprawność i tworzę odpowiednie elementy do prezentowania tego
        private void MI_58873_decompressButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //blokuję wszystkie znalezione przyciski w sekcji result panel
            MI_58873_blockResultButtons();

            //wywołuję sprawdzenie czy dekompresja się udała wywołując poniższą metodę
            MI_58873_checkDecompressionResult();
        }

        //metoda wywoływana po kliknięciu w przycisk WYCZYŚĆ
        private void MI_58873_clearResultPanel_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //czyszczę sekcję panel wyników
            MI_58873_clearResultPanel();

            //przywracam inicjalny wygląd ekranu do kompresji
            MI_58873_buildCompressSection();

            //tym razem już input nie będzie uzupełniony domyślną wartością
            TextBox MI_58873_input = (TextBox)MI_58873_workPanel.Controls.Find("inputText", true)[0];
            if (MI_58873_input != null) MI_58873_input.Text = "";
        }

        //metoda wywoływana po kliknięciu w button LOSUJ
        private void MI_58873_randomButton_Button_Click(object MI_58873_sender, EventArgs MI_58873_e)
        {
            //wyszukuję text box do wprowadzania danych
            foreach (var MI_58873_element in MI_58873_resultBox.Controls.OfType<TextBox>())
            {
                //przypisuję temu text boxowi nowo wygenerowany ciąg znaków - ciąg będzie zawierał 6 znaków
                //poniższy kod został pobrany z internetu
                //źródło http://csharp.net-informations.com/string/random.htm
                Random MI_58873_random = new Random();
                int MI_58873_length = 6;
                var MI_58873_randomString = "";
                for (var MI_58873_i = 0; MI_58873_i < MI_58873_length; MI_58873_i++)
                {
                    MI_58873_randomString += ((char)(MI_58873_random.Next(1, 26) + 64)).ToString().ToLower();
                }
                //wpisuję ten ciąg w pole tekstowe
                //ciąg jest wpisywany wielkimi znakami (ToUpper)
                MI_58873_element.Text = MI_58873_randomString.ToString().ToUpper(); ;
            }
        }

        //metoda odpowiedzialna za wyczysczenie sekcji panel wyników
        private void MI_58873_clearResultPanel()
        {
            //wyszukuję ten panel i czyszczę go
            GroupBox MI_58873_gb = (GroupBox)MI_58873_workPanel.Controls.Find("GbResult", true)[0];
            if (MI_58873_gb.Controls.Count > 0) MI_58873_gb.Controls.Clear();
        }

        //metoda weryfikuje wynik dekompresji
        private void MI_58873_checkDecompressionResult()
        {
            //przydatana zmienna 
            Font MI_58873_resultFont = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            //labelki przechowująca ciąg po dekompresji
            Label MI_58873_resultLabel = MI_58873_ctrl.MI_58873_createLabel("lblAfterCompression", new Point(230, 244), MI_58873_resultFont, 535, 50, MI_58873_textAfterDecompression, MI_58873_Proj.MI_58873_lblBorderStyleFixed, MI_58873_Proj.MI_58873_lblTxtCenter);

            //porównuję sobie tekst przed kompresją i po dekompresji
            if (MI_58873_textDoSkompresowania == MI_58873_textAfterDecompression)
            {
                //jeśli jest taki sam
                //koloruję labelkę z rezultatem na zielono
                MI_58873_resultLabel.BackColor = MI_58873_Proj.MI_58873_succesColor;

                //dodanie kontrolki do ekranu
                MI_58873_resultBox.Controls.Add(MI_58873_resultLabel);

                //informuję usera o sukcesie odpowiednim alertem
                MessageBox.Show("Dekompresja powiodła się.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //jesli tekst nie jest taki sam
                //koloruję na czerwono labelkę z tekstem wyniku
                MI_58873_resultLabel.BackColor = Color.OrangeRed;

                //dodanie kontrolki do ekranu
                MI_58873_resultBox.Controls.Add(MI_58873_resultLabel);

                //informuje usera o errorze
                MessageBox.Show("Dekompresja nie powiodła się.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MI_58873_dekompresuj(List<MI_58873_WystepującyZnak> MI_58873_znaki, List<string> MI_58873_listaKompresji)
        {
            //Lista w której przechowywać będziemy info o znakach oraz o przypisanych do nich kodach binarnych
            List<MI_58873_HuffmanSourceDictionary> MI_58873_dictionary;
            MI_58873_dictionary = new List<MI_58873_HuffmanSourceDictionary>();

            //teraz uzupełniam słownik który posłuży nam do rozkodowania 
            //każdy obiekt składa się z zestawu znak i przypisana do niego wartość binarna
            //a więc mapujemy wcześniej utworzony słownik na Listę typu MI_58873_HuffmanSourceDictionary
            //generując poniższy konstruktor dla obiektu new MI_58873_HuffmanSourceDictionary, posiłkowałem się https://www.tutorialsteacher.com/csharp/csharp-list
            MI_58873_znaki.ForEach(MI_58873_x => MI_58873_dictionary.Add(new MI_58873_HuffmanSourceDictionary()
            {
                MI_58873_SingleChar = MI_58873_x.MI_58873_Znak,
                MI_58873_BinaryCode = MI_58873_x.MI_58873_BinaryCode
            }));

            //wszystkie obiekty z listy zapisuję jako wartość jednej ciągu znaków string i wypisuję połączony ciąg na ekran
            string MI_58873_ciągBinarny = "";
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaKompresji.Count; MI_58873_i++)
            {
                MI_58873_ciągBinarny += MI_58873_listaKompresji[MI_58873_i];
            }
            MI_58873_ciągBinarny += "EOF";

            //deklaracja i inicjalizacja listy, która przechowywać będzie listę rozkodowanych ciągów binarnych
            List<string> MI_58873_listaRozkodowanych = new List<string>();
            //deklaracja zmiennej która przechowywać będzie wynik rozkodowania
            //wstęnie przydzielona jest wartość false- poprawnie wykonana dekompresja powinna zmienić jej wartość na true
            bool MI_58873_wynikRozkodowania = false;

            //wywołanie metody dekompresującej
            MI_58873_Dekompresja.MI_58873_DekompresjaHuffmana(MI_58873_dictionary, MI_58873_ciągBinarny, ref MI_58873_listaRozkodowanych, ref MI_58873_wynikRozkodowania);

            //deklaracja zmiennej która przechowywać będzie rozkodowany tekst
            string MI_58873_rozkodowanyTekst = "";

            //wszystkie obiekty z listy MI_58873_listaRozkodowanych łączę w jedną całość za pomocą pętli for
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaRozkodowanych.Count; MI_58873_i++)
            {
                MI_58873_rozkodowanyTekst += MI_58873_listaRozkodowanych[MI_58873_i];
            }

            //zwracam rozkodowany tekst
            return MI_58873_rozkodowanyTekst;
        }
    }

    //klasa do kompresji jest zaimplementowana dokładnie w takiej formie jak została dostarczona w trakcie zajęć
    //w klasie dodałem blok try-catch w celu obsłużenia wyjątku w sytuacji gdy kompreowany jest ciąg znaków np "AAAA" lub "BBB" - dzięki temu nie buduje zbędnie ekranu gdy taki błąd wystąpi
    //dodałem też zwracanie wartości po to by ocenić czy kompresja jest ok czy nie i żeby wiedzieć jak budować ekran z rezultatem
    //w klasie kompresja nie przerabiałem nic więcej bo za co się tylko nie wziąłem to przestawało mi całkowicie działać za co kolwiek się nie brałem
    //dodałem też kilka komentarzy ale mam wrażenie że algorytmy sortowania są dla mnie zbyt skomplikowane
    public class MI_58873_Kompresja
    {
        public static bool MI_58873_KompresjaHuffmanna(
        string MI_58873_source,
        ref List<string> MI_58873_resultCode,
        ref List<MI_58873_WystepującyZnak> MI_58873_listaZnaków)

        {
            //utworzona zmienna która będzie zwracana w celu informowania czy succes czy failure podczas kompresji
            bool MI_58873_compressionResult = true;
            string MI_58873_pozostaly = MI_58873_source;
            string MI_58873_roboczy = MI_58873_pozostaly;
            string MI_58873_kolejnyZnak = "";
            int MI_58873_indexListy = 0;
            List<MI_58873_DrzewoHuffmana> MI_58873_drzewoHuffmana = new List<MI_58873_DrzewoHuffmana>();
            List<MI_58873_WystepującyZnak> MI_58873_tymczasowaListaZnaków = new List<MI_58873_WystepującyZnak>();
            List<MI_58873_DrzewoHuffmana> MI_58873_tymczasoweDrzewoHuffmana = new List<MI_58873_DrzewoHuffmana>();

            do
            {
                //pobieramy ciąg znaków jaki pozostał do skompresowania
                MI_58873_roboczy = MI_58873_pozostaly;
                //pobieramy jeden znak z roboczego ciągu
                MI_58873_kolejnyZnak = MI_58873_roboczy.Substring(0, 1);
                //porównujemy to z listą znaków i zapisujemy index
                MI_58873_indexListy = MI_58873_tymczasowaListaZnaków.FindIndex(f => f.MI_58873_Znak == MI_58873_kolejnyZnak);
                if (MI_58873_indexListy == -1)
                {
                    //jeśli indeks się nie znalazł zachowujemy pobrany znak 
                    MI_58873_WystepującyZnak nowyZnak = new MI_58873_WystepującyZnak
                    {
                        MI_58873_Ilosc = 1,
                        MI_58873_Znak = MI_58873_kolejnyZnak
                    };
                    MI_58873_tymczasowaListaZnaków.Add(nowyZnak);
                }
                else
                {
                    //jeślil się znalazł to inkrementujemy ilość
                    MI_58873_tymczasowaListaZnaków.Where(MI_58873_w => MI_58873_w.MI_58873_Znak == MI_58873_kolejnyZnak).ToList().ForEach(MI_58873_s => MI_58873_s.MI_58873_Ilosc++);
                }
                //usuwamy z listy opracowywany znak
                MI_58873_pozostaly = MI_58873_roboczy.Remove(0, 1);
                //pętle kontynuujemy gdy są jeszcze jakieś znaki w ciągu
            } while (MI_58873_pozostaly.Length != 0);

            //deklarujemy kontenery na przechowywanie danych
            MI_58873_listaZnaków = MI_58873_tymczasowaListaZnaków.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();
            List<MI_58873_WystepującyZnak> MI_58873_posortowanaListaZnaków = new List<MI_58873_WystepującyZnak>(MI_58873_listaZnaków);

            //deklarujemy inicjalne wartości przed rozpoczęciem pętli
            int MI_58873_nrKorzenia = 0;
            int MI_58873_nowyKorzenWartosc = 0;
            string MI_58873_nowyKorzen = "node";

            //budowanie drzewa
            do
            {
                //jeśli lista znaków zawiera więcej niż jeden element
                if (MI_58873_posortowanaListaZnaków.Count > 1)
                {
                    //jeśli drzewo nie jest dopiero rozpoczynane
                    if (MI_58873_drzewoHuffmana.Count > 0)
                    {
                        //tworzymy korzeń 
                        if (MI_58873_drzewoHuffmana[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc > MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc)
                            MI_58873_nowyKorzenWartosc = MI_58873_drzewoHuffmana[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc;
                        else
                            MI_58873_nowyKorzenWartosc = MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc;
                    }
                    //tworzymy drzewo
                    else if (MI_58873_drzewoHuffmana.Count == 0)
                        MI_58873_nowyKorzenWartosc = MI_58873_posortowanaListaZnaków[0].MI_58873_Ilosc + MI_58873_posortowanaListaZnaków[1].MI_58873_Ilosc;

                    //podbijamy nr korzenia
                    if (MI_58873_posortowanaListaZnaków.Count > 2)
                    {
                        if (MI_58873_nowyKorzenWartosc >= MI_58873_posortowanaListaZnaków[2].MI_58873_Ilosc && MI_58873_posortowanaListaZnaków.Count >= 3)
                            MI_58873_nrKorzenia++;
                    }
                    else
                        MI_58873_nrKorzenia++;

                    //tworzymy i dodajemy do kontenera odnaleziony znak
                    MI_58873_WystepującyZnak MI_58873_nowyZnak = new MI_58873_WystepującyZnak
                    {
                        MI_58873_Ilosc = MI_58873_nowyKorzenWartosc,
                        MI_58873_Znak = MI_58873_nowyKorzen + MI_58873_nrKorzenia
                    };
                    MI_58873_posortowanaListaZnaków.Add(MI_58873_nowyZnak);

                    //pętla do zbudowania drzewa huffmanna
                    for (int MI_58873_i = 0; MI_58873_i <= 1; MI_58873_i++)
                    {
                        MI_58873_DrzewoHuffmana MI_58873_drzewoHuffmanaItem = new MI_58873_DrzewoHuffmana();
                        if (MI_58873_posortowanaListaZnaków.Count > 1)
                            MI_58873_drzewoHuffmanaItem.MI_58873_BinaryCode = MI_58873_i;
                        else
                            MI_58873_drzewoHuffmanaItem.MI_58873_BinaryCode = 2;
                        MI_58873_drzewoHuffmanaItem.MI_58873_Znak = MI_58873_posortowanaListaZnaków[MI_58873_i].MI_58873_Znak;
                        MI_58873_drzewoHuffmanaItem.MI_58873_Node = MI_58873_nowyKorzen + MI_58873_nrKorzenia.ToString();
                        MI_58873_drzewoHuffmanaItem.MI_58873_Ilosc = MI_58873_posortowanaListaZnaków[MI_58873_i].MI_58873_Ilosc;
                        MI_58873_drzewoHuffmana.Add(MI_58873_drzewoHuffmanaItem);
                    }
                    //przygotowujemy dane do kolejnej weryfikacji iteracji pętli
                    MI_58873_posortowanaListaZnaków.RemoveRange(0, 2);
                    MI_58873_tymczasowaListaZnaków = MI_58873_posortowanaListaZnaków.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();
                    MI_58873_tymczasoweDrzewoHuffmana = MI_58873_drzewoHuffmana.OrderByDescending(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();
                    MI_58873_drzewoHuffmana = MI_58873_tymczasoweDrzewoHuffmana;
                    MI_58873_posortowanaListaZnaków = MI_58873_tymczasowaListaZnaków;
                }
                else
                {
                    MI_58873_DrzewoHuffmana MI_58873_drzewoHuffmanaItem = new MI_58873_DrzewoHuffmana
                    {
                        MI_58873_BinaryCode = 2,
                        MI_58873_Znak = MI_58873_nowyKorzen + (MI_58873_nrKorzenia + 1).ToString(),
                        MI_58873_Node = "TOP"
                    };
                    MI_58873_drzewoHuffmana.Add(MI_58873_drzewoHuffmanaItem);
                    MI_58873_posortowanaListaZnaków.Clear();
                }
            } while (MI_58873_posortowanaListaZnaków.Count != 0);
            MI_58873_tymczasoweDrzewoHuffmana = MI_58873_drzewoHuffmana.OrderBy(MI_58873_o => MI_58873_o.MI_58873_Ilosc).ToList();

            string MI_58873_tempBinaryCode = "";
            string MI_58873_actualNode = "";

            for (int MI_58873_i = 0; MI_58873_i < MI_58873_drzewoHuffmana.Count - 1; MI_58873_i++)
            {
                if (MI_58873_drzewoHuffmana[MI_58873_i].MI_58873_Ilosc == MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_Ilosc &&
                    MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_Znak.Length > 1)
                {
                    MI_58873_DrzewoHuffmana MI_58873_tymczasowy = new MI_58873_DrzewoHuffmana();
                    MI_58873_tymczasowy = MI_58873_drzewoHuffmana[MI_58873_i];
                    MI_58873_drzewoHuffmana[MI_58873_i] = MI_58873_drzewoHuffmana[MI_58873_i + 1];
                    MI_58873_drzewoHuffmana[MI_58873_i + 1] = MI_58873_tymczasowy;
                    MI_58873_drzewoHuffmana[MI_58873_i].MI_58873_BinaryCode = 0;
                    MI_58873_drzewoHuffmana[MI_58873_i + 1].MI_58873_BinaryCode = 1;
                }
            }
            for (int MI_58873_i = 0; MI_58873_i < MI_58873_listaZnaków.Count; MI_58873_i++)
            {
                MI_58873_kolejnyZnak = MI_58873_listaZnaków[MI_58873_i].MI_58873_Znak;
                MI_58873_indexListy = MI_58873_drzewoHuffmana.FindIndex(f => f.MI_58873_Znak == MI_58873_kolejnyZnak);

                try
                {
                    MI_58873_actualNode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_Node;
                    MI_58873_tempBinaryCode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_BinaryCode.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kompresja nie powiodła się", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MI_58873_compressionResult = false;
                }

                do
                {
                    MI_58873_indexListy = MI_58873_drzewoHuffmana.FindIndex(f => f.MI_58873_Znak == MI_58873_actualNode);
                    if (MI_58873_indexListy != -1)
                    {
                        MI_58873_actualNode = MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_Node;
                        MI_58873_tempBinaryCode += MI_58873_drzewoHuffmana[MI_58873_indexListy].MI_58873_BinaryCode.ToString();

                        if (MI_58873_tempBinaryCode.Length > 1 && MI_58873_tempBinaryCode.Substring(0, 1) == "0")
                            MI_58873_tempBinaryCode = MI_58873_tempBinaryCode.Remove(0, 1);
                    }
                } while (MI_58873_indexListy != -1);
                MI_58873_listaZnaków[MI_58873_i].MI_58873_BinaryCode = MI_58873_tempBinaryCode;
            }

            for (int MI_58873_i = 0; MI_58873_i < MI_58873_source.Length; MI_58873_i++)
            {
                MI_58873_kolejnyZnak = MI_58873_source.Substring(MI_58873_i, 1);

                for (int MI_58873_j = 0; MI_58873_j <= MI_58873_listaZnaków.Count; MI_58873_j++)
                {
                    if (MI_58873_listaZnaków[MI_58873_j].MI_58873_Znak == MI_58873_kolejnyZnak)
                    {
                        MI_58873_resultCode.Add(MI_58873_listaZnaków[MI_58873_j].MI_58873_BinaryCode + ",");
                        MI_58873_j = MI_58873_listaZnaków.Count;
                    }
                }
            }
            return MI_58873_compressionResult;
        }
    }

    //klasa do kompresji jest zaimplementowana dokładnie w takiej formie jak została dostarczona w trakcie zajęć II
    public class MI_58873_Dekompresja
    {
        public static void MI_58873_DekompresjaHuffmana(List<MI_58873_HuffmanSourceDictionary> MI_58873_sourceDictionary, string MI_58873_source, ref List<string> MI_58873_resultCode, ref bool MI_58873_dictionaryComplete)
        {
            string MI_58873_kolejnyZnak = "";
            int MI_58873_zawiera = 0;

            try
            {
                //wykonanie dla wszystkich elemenów ciągu wejściowego
                do
                {
                    //usunięcie przecinka z początku ciągu
                    do
                    {
                        if (MI_58873_source.Length > 0 && MI_58873_source.Substring(0, 1) != "0" && MI_58873_source.Substring(0, 1) != "1")
                        {
                            MI_58873_source = MI_58873_source.Remove(0, 1);
                        }
                    } while (MI_58873_source.Length > 0 && MI_58873_source.Substring(0, 1) != "1" && MI_58873_source.Substring(0, 1) != "0");

                    //teraz wiadomo że nie ma przecinka na początku ciągu więc dla wszystkich elementów ciągu wykonujemy operację
                    if (MI_58873_source.Length > 0)
                    {
                        do
                        {
                            //pobieramy wartośc 1 lub 0 z przygotowanego ciągu znaków i dodajemy do zmiennej MI_58873_kolejnyZnak
                            MI_58873_kolejnyZnak += MI_58873_source.Substring(0, 1);
                            //pobrany znak usuwamy z ciągu MI_58873_source po to aby go kolejny raz nie pobrać
                            MI_58873_source = MI_58873_source.Remove(0, 1);
                            //pobieramy i dopisujemy do MI_58873_kolejnyZnak aż do momentu kiedy napotkamy inny znak niż 0 lub 1 (tu wiemy żę mamy przecinek i "EOF")
                        } while (MI_58873_source.Substring(0, 1) == "0" || MI_58873_source.Substring(0, 1) == "1");
                        //teraz znaleziony kod binarny który mamy zapisany w MI_58873_kolejnyZnak porównujemy ze słownikiem (MI_58873_sourceDictionary) -
                        //szukamy jaka wartość jest przypisana do podanego kodu binarnego
                        MI_58873_zawiera = MI_58873_sourceDictionary.FindIndex(MI_58873_f => MI_58873_f.MI_58873_BinaryCode == MI_58873_kolejnyZnak);
                        //odnalezioną wartość ze słownika przypisujemy jako kolejny element listy MI_58873_resultCode
                        MI_58873_resultCode.Add(MI_58873_sourceDictionary[MI_58873_zawiera].MI_58873_SingleChar);
                        //na koniec musimy wyczyścić zmienną MI_58873_kolejnyZnak aby wykonać rozkodowanie kolejnych znaków 
                        MI_58873_kolejnyZnak = "";
                    }
                    else
                    {
                        //ten blok jest wykonywany gdy ciąg znaków już nie zawiera elementów do rozkodowania
                        MI_58873_dictionaryComplete = true;
                        return;
                    }
                } while (MI_58873_source.Length > 0);
            }
            catch (Exception)
            {
                //w przypadku wystąpienia błędu podczas dekompresji,
                //zamiast przerywać działanie programu informujemy o błędzie ustawiając wartość false dla rezultatu dekompreji
                MI_58873_dictionaryComplete = false;
            }
        }
    }

    //kontener na przechowywanie kodów binarnych
    public class MI_58873_WystepującyZnak
    {
        public int MI_58873_Ilosc { get; set; }
        public string MI_58873_Znak { get; set; }
        public string MI_58873_BinaryCode { get; set; }
    }

    //kontener na przechowywanie rozkodowanego ciągu
    public class MI_58873_DrzewoHuffmana
    {
        public int MI_58873_BinaryCode { get; set; }
        public string MI_58873_Znak { get; set; }
        public string MI_58873_Node { get; set; }
        public int MI_58873_Ilosc { get; set; }
    }

    //kontener na przechowywanie słownika znaków i ich kodów binarnych
    public class MI_58873_HuffmanSourceDictionary
    {
        public string MI_58873_SingleChar { get; set; }
        public string MI_58873_BinaryCode { get; set; }
    }

}
