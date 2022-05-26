using System.Drawing;
using System.Windows.Forms;

namespace _58873_IV_
{
    //klasa przechowująca metody do dynamicznego budowania kontrolek
    //jest to dokładnie ta sama klasa której używałem do tworzenia kontrolek w projekcie VI
    class MI_58873_Controlls
    {
        //metoda tworząca button
        //metoda dostarczona przez wykładowcę
        public Button MI_58873_createButton(string MI_58873_name, int MI_58873_x, int MI_58873_y, int MI_58873_width, int MI_58873_height, Font MI_58873_font, Color MI_58873_foreColor, Color MI_58873_backColor, string MI_58873_text)
        {
            Button MI_58873_element = new Button
            {
                Name = MI_58873_name,
                Location = new Point(MI_58873_x, MI_58873_y),
                Width = MI_58873_width,
                Height = MI_58873_height,
                AutoSize = false,
                Font = MI_58873_font,
                ForeColor = MI_58873_foreColor,
                BackColor = MI_58873_backColor,
                Text = MI_58873_text,
                TextAlign = ContentAlignment.MiddleCenter,
                
        };
            return MI_58873_element;
        }

        //metoda tworząca checkBox
        //metoda dostarczona przez wykładowcę
        public CheckBox MI_58873_createCheckBox(string MI_58873_name, Point MI_58873_location, int MI_58873_width, Font MI_58873_font, Color MI_58873_foreColor, bool MI_58873_selected, string MI_58873_text)
        {
            CheckBox MI_58873_element = new CheckBox
            {
                Name = MI_58873_name,
                Location = MI_58873_location,
                Width = MI_58873_width,
                Font = MI_58873_font,
                ForeColor = MI_58873_foreColor,
                Checked = MI_58873_selected,
                Text = MI_58873_text,
                TextAlign = ContentAlignment.MiddleLeft
            };

            return MI_58873_element;
        }

        //metoda tworząca groupBox
        //metoda dostarczona przez wykładowcę
        public GroupBox MI_58873_createGroupBox(int MI_58873_x, int MI_58873_y, int MI_58873_width, int MI_58873_height, string MI_58873_text, string MI_58873_name)
        {
            GroupBox MI_58873_element = new GroupBox
            {
                Location = new Point(MI_58873_x, MI_58873_y),
                Width = MI_58873_width,
                Height = MI_58873_height,
                Text = MI_58873_text,
                Name = MI_58873_name
            };

            return MI_58873_element;
        }

        //metoda tworząca labelkę
        //metoda dostarczona przez wykładowcę
        public Label MI_58873_createLabel(
            string MI_58873_name, 
            Point MI_58873_location, 
            Font MI_58873_font, 
            Color MI_58873_backColor, 
            Color MI_58873_foreColor, 
            int MI_58873_width, 
            int MI_58873_height, 
            string MI_58873_text, 
            BorderStyle MI_58873_borderStyle, 
            ContentAlignment MI_58873_textAlign
            )
        {
            Label MI_58873_element = new Label
            {
                Location = MI_58873_location,
                Width = MI_58873_width,
                Height = MI_58873_height,
                Font = MI_58873_font,
                BackColor = MI_58873_backColor,
                ForeColor = MI_58873_foreColor,
                Name = MI_58873_name,
                Text = MI_58873_text,
                AutoSize = false,
                BorderStyle = MI_58873_borderStyle,
                TextAlign = MI_58873_textAlign
            };

            return MI_58873_element;
        }

        //metoda tworząca Text box
        //metoda dostarczona przez wykładowcę
        public TextBox createTextField(string MI_58873_name, Point MI_58873_location, int MI_58873_width, int MI_58873_height, Font MI_58873_font, Color MI_58873_backColor, Color MI_58873_foreColor)
        {
            TextBox MI_58873_element = new TextBox
            {
                Location = MI_58873_location,
                Width = MI_58873_width,
                Height = MI_58873_height,
                Name = MI_58873_name,
                Font = MI_58873_font,
                BackColor = MI_58873_backColor,
                ForeColor = MI_58873_foreColor,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = HorizontalAlignment.Center,
                MaxLength = 2
            };

            return MI_58873_element;
        }
    }
}
