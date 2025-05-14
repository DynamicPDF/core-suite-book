using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using System;

namespace ChapterExamples.Chapters.ChapterFifteen
{
    public class FormFieldsExample
    {


        public static Document CreateRetDoc(string outputPath, Boolean includeButtons)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            AddCheckBox(doc);
            AddRadioButton(doc);
            AddTextField(doc);
            AddMultiLineTextField(doc);
            AddListBox(doc);
            AddComboBox(doc);

            if (includeButtons)
            {
                AddButtons(doc);
            }

            return doc;
        }

        public static void Create(string outputPath)
        {

            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            AddCheckBox(doc);
            AddRadioButton(doc);
            AddTextField(doc);
            AddMultiLineTextField(doc);
            AddListBox(doc);
            AddComboBox(doc);

            AddButtons(doc);                   

            doc.Draw(outputPath + "buttonForm-out.pdf");

        }

        
        public static void AddMultiLineTextField(Document doc)
        {
            Label label = new Label("Description:", 0, 150, 75, 0);
            TextField textField = new TextField("description", 75, 150, 200, 200);
            textField.BorderStyle = BorderStyle.Solid;
            textField.MultiLine = true;
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(textField);
        }

        public static void AddListBox(Document doc)
        {
            Label label = new("Selected Days:", 0, 375, 100, 0);
            ListBox listBox = new ListBox("selected_days", 125, 375, 100, 150);
            listBox.Items.Add("Mon", true);
            listBox.Items.Add("Tue");
            listBox.Items.Add("Wed");
            listBox.Items.Add("Thu");
            listBox.Items.Add("Fri");
            listBox.Items.Add("Sat");
            listBox.Items.Add("Sun");
            listBox.BorderStyle = BorderStyle.Solid;
            listBox.Multiselect = true;
            listBox.ToolTip = "Select day(s).";
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(listBox);
        }

        public static void AddComboBox(Document doc)
        {
            Label label = new("Favorite Color:", 0, 575, 100, 0);
            ComboBox comboBox = new ComboBox("favorite_color", 110, 575, 150, 25);
            comboBox.Items.Add("Red", true);
            comboBox.Items.Add("White");
            comboBox.Items.Add("Blue");
            comboBox.BorderStyle = BorderStyle.Solid;
            comboBox.Editable = true;
            comboBox.ToolTip = "Select favorite color.";
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(comboBox);
        }

        public static void AddTextField(Document doc)
        {
            Label label = new Label("Full Name:", 0, 105, 75, 0);
            TextField textField = new TextField("full_name", 75, 100, 200, 25);
            textField.BorderStyle = BorderStyle.Solid;
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(textField);
        }



        public static void AddButtons(Document doc)
        {
            Button button = new Button("submit", 100, 625, 110, 20);

            button.BackgroundColor = RgbColor.LightBlue;
            button.BorderStyle = BorderStyle.Beveled;


            button.Action = new SubmitAction("https://localhost:44326/test.html", FormExportFormat.HtmlGet);
            button.Label = "Submit";

            Button button2 = new Button("reset", 220, 625, 100, 20);

            button2.BackgroundColor = RgbColor.Yellow;
            button2.BorderStyle = BorderStyle.Beveled;
            button2.Action = new ResetAction();
            button2.Label = "Reset";

            doc.Pages[0].Elements.Add(button);
            doc.Pages[0].Elements.Add(button2);
        }



        public static void AddCheckBox(Document doc)
        {
            Label label = new("Completed Book?", 0, 0, 100, 0);
            CheckBox checkBox = new("completed_book", label.Width + 5, 0, 20, 20);
            checkBox.DefaultChecked = false;
            checkBox.ToolTip = "Check if completed reading the book.";
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(checkBox);
        }

        public static void AddRadioButton(Document doc)
        {
            Label label = new("Position:", 0, 50, 100, 0);

            RadioButton radio1 = new("position", 100, 50, 20, 20);
            radio1.ExportValue = "red";
            radio1.ToolTip = "Red";
            radio1.BackgroundColor = RgbColor.Red;
            RadioButton radio2 = new("position", 150, 50, 20, 20);
            radio2.ExportValue = "yellow";
            radio2.ToolTip = "Yellow";
            radio2.BackgroundColor = RgbColor.Yellow;
            RadioButton radio3 = new("position", 200, 50, 20, 20);
            radio3.ExportValue = "blue";
            radio3.ToolTip = "Blue";
            radio3.BackgroundColor = RgbColor.Blue;

            Label label2 = new("(red, yellow, blue)", 250, 50, 100, 0);

            doc.Pages[0].Elements.Add(label);


            doc.Pages[0].Elements.Add(label2);

            doc.Pages[0].Elements.Add(radio1);
            doc.Pages[0].Elements.Add(radio2);
            doc.Pages[0].Elements.Add(radio3);
        }


    }
}
