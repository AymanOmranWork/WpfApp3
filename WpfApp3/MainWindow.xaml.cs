using System;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.Data;

namespace WpfApp3;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public string AppPath = System.IO.Path.GetDirectoryName(Environment.ProcessPath);

    private void PrintButton_Click(object sender, RoutedEventArgs e)
    {
        // Get reference to the current MainWindow
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        // Assuming your main content is hosted inside a Frame or directly on the MainWindow
        Page currentPage = mainWindow.Content as Page;



        PrintDialog printDialog = new PrintDialog();

        if (printDialog.ShowDialog() == true)
        {
            FixedDocument document = CreateReportDocument();
          
            printDialog.PrintDocument(document.DocumentPaginator, "Report");
        }
    }

    private FixedDocument CreateReportDocument()
    {
        FixedDocument fixedDocument = new FixedDocument();

        // Create a FixedPage
        FixedPage fixedPage = new FixedPage();
     
        // Load your WPF page into a UserControl
        PrintPage printPage = new PrintPage();

        // Create a VisualBrush from the WPF page
        VisualBrush visualBrush = new VisualBrush(printPage);
        Rectangle rect = new Rectangle();
        rect.Width = printPage.Width; // Set width
        rect.Height = printPage.Height; // Set height
        rect.Fill = visualBrush;

        // Add the rectangle to the FixedPage
        fixedPage.Children.Add(rect);

        // Add the FixedPage to the FixedDocument
        PageContent pageContent = new PageContent();
        ((IAddChild)pageContent).AddChild(fixedPage);
        fixedDocument.Pages.Add(pageContent);


        return fixedDocument;
    }


    //private void PrintButton_Click(object sender, RoutedEventArgs e)
    //{
    //    PrintDialog printDialog = new PrintDialog();

    //    if (printDialog.ShowDialog() == true)
    //    {
    //        FixedDocument document = CreateReportDocument();
    //        printDialog.PrintDocument(document.DocumentPaginator, "Report");
    //    }
    //}

    //private FixedDocument CreateReportDocument()
    //{
    //    FixedDocument document = new FixedDocument();


    //    // Create the first page
    //    FixedPage page1 = CreatePage();
    //    AddContentToPage(page1, "Page 1 Content");
    //    AddContentToPage(page1, "يشبسبيجنسبيشسبيشسبيشجنخسبيشجنخسبيجنخجسبي");
    //    AddContentToPage(page1, "Paسليشسليشسيشبسبيشسبيشntent");
    //    AddContentToPage(page1, "Pشيسببسيب سبي");
    //    AddContentToPage(page1, "Pag432121434161 Content");
    //    AddContentToPage(page1, "Page 1 Co214363122392439243092430910-1892531ntent");
    //    AddContentToPage(page1, "12539س9يب-8ب-سيش8-0-243234");
    //    AddContentToPage(page1, "Page 1 Content");


    //    AddContentToPage(page1, "Page 1 Content", $"{AppPath}/Data/logo_01.png");
    //    AddContentToPage(page1, "صورة رقم 2", $"{AppPath}/Data/fluent-validation-logo.png");
    //    AddContentToPage(page1, "صورة رقم 3", $"{AppPath}/Data/Infinity.png");

    //    document.Pages.Add(CreatePageContent(page1));

    //    // Create the second page
    //    FixedPage page2 = CreatePage();
    //    AddContentToPage(page2, "Page 2 Content");
    //    document.Pages.Add(CreatePageContent(page2));

    //    // Create additional pages as needed

    //    return document;
    //}

    //private FixedPage CreatePage()
    //{
    //    FixedPage page = new FixedPage();
    //    page.Width = 96 * 8.5; // Page width in pixels (8.5 inches at 96 DPI)
    //    page.Height = 96 * 11; // Page height in pixels (11 inches at 96 DPI)
    //    page.Background = Brushes.White;

    //    return page;
    //}

    //private PageContent CreatePageContent(FixedPage page)
    //{
    //    PageContent pageContent = new PageContent();
    //    ((IAddChild)pageContent).AddChild(page);

    //    return pageContent;
    //}

    //private void AddContentToPage(FixedPage page, string content)
    //{
    //    TextBlock textBlock = new TextBlock();
    //    textBlock.Text = content ;
    //    textBlock.FontSize = 24;

    //    page.Children.Add(textBlock);
    //}


    //private void AddContentToPage(FixedPage page, string content, string imagePath)
    //{
    //    TextBlock textBlock = new TextBlock();
    //    textBlock.Text = content;
    //    textBlock.FontSize = 24;
    //    textBlock.Margin = new Thickness(96, 96, 96, 0); // Set the margin (1 inch from top)

    //    Image image = new Image();
    //    image.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
    //    image.Width = 200;
    //    image.Height = 200;
    //    image.Margin = new Thickness(96, 200, 0, 0); // Set the margin (1 inch from left, 2 inches from top)

    //    page.Children.Add(textBlock);
    //    page.Children.Add(image);
    //}
}