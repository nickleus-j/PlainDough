using System.Collections.ObjectModel;
using System.Text;
using PlainDough.DTO;
namespace PlainDough.Presentation;

public sealed partial class MainPage : Page
{
    public ObservableCollection<PlainObj> Properties { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        Properties = new ObservableCollection<PlainObj>();
        propertyListView.ItemsSource = Properties;
    }
    private void ResetPropertyForm()
    {
        txtPropertyName.Text = String.Empty;
        txtDataType.SelectedIndex = 0;
        isArray.IsChecked = false;
        OtherDataType.Text = String.Empty;
    }
    private void AddProperty_Click(object sender, RoutedEventArgs e)
    {
        string propertyName = txtPropertyName.Text;
        string dataType = txtDataType.SelectedValue?.GetType() == typeof(string) ? txtDataType.SelectedValue?.ToString(): OtherDataType.Text;
            //txtDataType.SelectedItem?.ToString();
        if (!string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(dataType))
        {
            Properties.Add(new PlainObj { Name = propertyName, DataType = dataType, IsCollection=isArray.IsChecked==true });
            ResetPropertyForm();
        }
        else
        {

        }
    }
    private void GeneratePOTSO_Click(object sender, RoutedEventArgs e)
    {
        string className = txtClassName.Text;
        string superclass = txtSuperclass.Text;
        ResultBox.IsReadOnly = true;
        if (!string.IsNullOrEmpty(className))
        {
            StringBuilder potsoCode = new StringBuilder();
            potsoCode.Append($"export class {className} ");
            potsoCode.AppendLine("{");
            foreach (var property in Properties)
            {
                potsoCode.AppendLine($"public  {property.Name}: {property.CompleteDataType};");
            }
            potsoCode.AppendLine("}");
            // Save to a text file
            ResultBox.Text = potsoCode.ToString();


        }
        else
        {

        }
    }
}
