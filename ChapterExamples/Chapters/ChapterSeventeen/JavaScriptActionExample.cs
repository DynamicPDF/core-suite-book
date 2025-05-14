

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFifteen
{
    public class JavaScriptActionExample
    {
        public static void Create(string uploadPath)
        {
            AutoChange(uploadPath);
            ValueValidation(uploadPath);
            Calculate(uploadPath);
        }

        public static void AutoChange(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));


            Label label = new("Favorite Color:", 0, 50, 100, 0);
            ComboBox comboBox = new ComboBox("favorite_color", 100, 45, 150, 25);
            comboBox.Items.Add("Red", true);
            comboBox.Items.Add("White");
            comboBox.Items.Add("Blue");
            comboBox.BorderStyle = BorderStyle.Solid;
            comboBox.Editable = true;
            comboBox.ToolTip = "Select favorite color.";
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(comboBox);


            TextField textField = new("color_desc", 0, 100, 200, 20);
            textField.DefaultValue = "no color chosen";

            doc.Pages[0].Elements.Add(textField);

            string javaScript = "this.getField(\"color_desc\").value = \"The color is: \" + this.getField(\"favorite_color\").value;";

            comboBox.ReaderEvents.OnBlur = new JavaScriptAction(javaScript);

            doc.Draw(outputPath + "javascript-value-change-out.pdf");

        }

        public static void ValueValidation(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label lbl = new Label("Age:", 0, 50, 150, 30);
            TextField txtField = new("age", 170, 30, 150, 30);
            txtField.ToolTip = "Age";

            string j0 = "function numonly(){";
            string j1 = "var age = this.getField(\"age\").value;";
            string j2 = "app.alert({cMsg:\"Only numbers are allowed.\", nIcon:1, cTitle:\"Not A Number\"});";
            string j3 = "app.alert({cMsg:\"You must be over 18.\", nIcon:1, cTitle:\"Must be 18\"});";
            string j4 = "this.getField(\"age\").value=\"\";";
            string j5 = "if(isNaN(age)) {" + j2 + j4 + "}";
            string j6 = "if(age < 18){" + j3 + j4 + "}";
            string j7 = "}";

            string javascript = j0+ j1 + j5 + j6 + j7;

            doc.JavaScripts.Add(new DocumentJavaScript("num_only", javascript));

            txtField.ReaderEvents.OnBlur = new JavaScriptAction("numonly();");
            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txtField);

            doc.Draw(outputPath + "javascript-validation-out.pdf");
        }

        public static void Calculate(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            TextField txtFld = new("val_1", 50, 50, 50, 20);
            txtFld.BorderStyle = BorderStyle.Solid;
            txtFld.DefaultValue = "0";
            Label lbl = new("+", 0, 75, 25, 0, Font.Courier, 24);

            TextField txtFld2 = new("val_2", 50, 110, 50, 20);
            txtFld2.BorderStyle = BorderStyle.Solid;
            txtFld2.DefaultValue = "0";

            Label lbl2 = new("=", 0, 135, 25, 0, Font.Courier, 24);

            TextField txtFldSum = new("txt_sum", 50, 170, 50, 20);
            txtFldSum.BorderStyle = BorderStyle.Solid;
            txtFldSum.DefaultValue = "0";
            txtFldSum.ReadOnly = true;

            string j1 = "var sum =  this.getField(\"val_1\").value + this.getField(\"val_2\").value;";
            string j2 = "this.getField(\"txt_sum\").value = sum;";            
            string j3 = "if(sum > 10){this.getField(\"txt_sum\").fillColor = color.red;}";
            string j4 = "else {this.getField(\"txt_sum\").fillColor = color.white;}";

            txtFld.ReaderEvents.OnBlur = new JavaScriptAction(j1 + j2 + j3 + j4);            
            txtFld2.ReaderEvents.OnBlur = new JavaScriptAction(j1+ j2 + j3 + j4);

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(lbl2);
            doc.Pages[0].Elements.Add(txtFld);
            doc.Pages[0].Elements.Add(txtFld2);
            doc.Pages[0].Elements.Add(txtFldSum);

            doc.Draw(outputPath + "javascript-sum-out.pdf");
        }



    }
}
