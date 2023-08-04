using ASodium;
using Avalonia.Controls;
using Avalonia.Media;
using BCASodium;
using PKDSA_ClientApp.Helper;
using System;
using System.IO;
using System.Runtime.InteropServices;
using PKDSA_ClientApp.APIMethodHelper;
using PKDSA_ClientApp.Model;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace PKDSA_ClientApp.Views;

public partial class MainView : UserControl
{
    private static int SigningAppUIChooser;
    private static int ManagementAppUIChooser;
    private static RadioButton[] FirstSAppmyRBArray = new RadioButton[] { };
    private static RadioButton[] ThirdSAppmyRBArray = new RadioButton[] { };
    private static RadioButton[] ThirdMAAppmyRBArray = new RadioButton[] { };
    private static RadioButton[] FourthMAAppmyRBArray = new RadioButton[] { };
    private static RadioButton[] SixthMAAppmyRBArray = new RadioButton[] { };
    private static RadioButton[] LastMAAppmyRBArray = new RadioButton[] { };
    private static TextBlock[] FirstSAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] SecondSAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] ThirdSAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] FourthSAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] FifthSAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] FirstMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] SecondMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] ThirdMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] FourthMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] FifthMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] SixthMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBlock[] LastMAAppmyTextBlockArray = new TextBlock[] { };
    private static TextBox[] FirstSAppmyTBArray = new TextBox[] { };
    private static TextBox[] SecondSAppmyTBArray = new TextBox[] { };
    private static TextBox[] ThirdSAppmyTBArray = new TextBox[] { };
    private static TextBox[] FourthSAppmyTBArray = new TextBox[] { };
    private static TextBox[] FifthSAppmyTBArray = new TextBox[] { };
    private static TextBox[] FirstMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] SecondMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] ThirdMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] FourthMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] FifthMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] SixthMAAppmyTBArray = new TextBox[] { };
    private static TextBox[] LastMAAppmyTBArray = new TextBox[] { };
    private static ComboBox[] SecondSAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] ThirdSAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] FourthSAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] FifthSAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] FirstMAAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] SecondMAAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] ThirdMAAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] FourthMAAppmyCBArray = new ComboBox[] { };
    private static ComboBox[] FifthMAAppmyCBArray = new ComboBox[] { };
    private static Button[] FirstSAppmyButtonArray = new Button[] { };
    private static Button[] SecondSAppmyButtonArray = new Button[] { };
    private static Button[] ThirdSAppmyButtonArray = new Button[] { };
    private static Button[] FourthSAppmyButtonArray = new Button[] { };
    private static Button[] FifthSAppmyButtonArray = new Button[] { };
    private static Button[] FirstMAAppmyButtonArray = new Button[] { };
    private static Button[] SecondMAAppmyButtonArray = new Button[] { };
    private static Button[] ThirdMAAppmyButtonArray = new Button[] { };
    private static Button[] FourthMAAppmyButtonArray = new Button[] { };
    private static Button[] FifthMAAppmyButtonArray = new Button[] { };
    private static Button[] SixthMAAppmyButtonArray = new Button[] { };
    private static Button[] LastMAAppmyButtonArray = new Button[] { };
    private static String SigningAppRootFolder = "";
    private static String ManagementAppServerRootFolder = "";
    private static String ManagementAppUserRootFolder = "";
    private static String ManagementAppMasterKeyRootFolder = "";
    private static String ManagementAppTORRootFolder = "";
    private static Boolean HasUIRendered = false;
    private static Boolean MAHasUIRendered = false;

    public MainView()
    {
        InitializeComponent();
        SAppInitialization();
        MAppInitialization();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
        {
            SigningAppRootFolder = AppContext.BaseDirectory + "\\SAppDSKP\\";
            ManagementAppServerRootFolder = AppContext.BaseDirectory + "\\ServerIP\\";
            ManagementAppUserRootFolder = AppContext.BaseDirectory + "\\User\\";
            ManagementAppMasterKeyRootFolder = AppContext.BaseDirectory + "\\MasterKey\\";
            ManagementAppTORRootFolder = AppContext.BaseDirectory + "\\TOR_Proxy\\";
        }
        else
        {
            SigningAppRootFolder = AppContext.BaseDirectory + "/SAppDSKP/";
            ManagementAppServerRootFolder = AppContext.BaseDirectory + "/ServerIP/";
            ManagementAppUserRootFolder = AppContext.BaseDirectory + "/User/";
            ManagementAppMasterKeyRootFolder = AppContext.BaseDirectory + "/MasterKey/";
            ManagementAppTORRootFolder = AppContext.BaseDirectory + "/TOR_Proxy/";
        }
        if (Directory.Exists(SigningAppRootFolder) == false)
        {
            Directory.CreateDirectory(SigningAppRootFolder);
        }
        if (Directory.Exists(ManagementAppServerRootFolder) == false)
        {
            Directory.CreateDirectory(ManagementAppServerRootFolder);
        }
        if (Directory.Exists(ManagementAppUserRootFolder) == false)
        {
            Directory.CreateDirectory(ManagementAppUserRootFolder);
        }
        if (Directory.Exists(ManagementAppMasterKeyRootFolder) == false)
        {
            Directory.CreateDirectory(ManagementAppMasterKeyRootFolder);
        }
        if (Directory.Exists(ManagementAppTORRootFolder) == false)
        {
            Directory.CreateDirectory(ManagementAppTORRootFolder);
        }
        StartUpFunction();
    }

    private async void StartUpFunction()
    {
        if (Directory.Exists(ManagementAppServerRootFolder) == true)
        {
            if (File.Exists(ManagementAppServerRootFolder + "IP.txt") == true)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == true && Directory.Exists(ManagementAppTORRootFolder + "Extracted") == true)
                {
                    if (Directory.GetFileSystemEntries(ManagementAppTORRootFolder + "Zipped").Length == 1 && Directory.GetDirectories(ManagementAppTORRootFolder + "Extracted").Length == 1)
                    {
                        TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                        String TORStatus = await TORMainOperations.StartTORWithConnectionToServer();
                        TORStatusTB.Text = TORStatus;
                        ServerIPStatusTB.Text = EstablishConnection.ConnectionStatus;
                    }
                }
                else
                {
                    EstablishConnection.CreateLinkWithServer();
                    ServerIPStatusTB.Text = EstablishConnection.ConnectionStatus;
                }
            }
        }
    }

    //SAppDSKP = Signing App Digital Signature Key Pair, I have to use short form or abbreviation form here due to
    //the directory length concern.

    private void SAppInitialization() 
    {
        /*Button TestButton = new Button();
        TestButton.Content = "Test Button";
        TestButton.Margin = Avalonia.Thickness.Parse("0,5,0,0");
        TestSP.Children.Add(TestButton);*/
        SigningAppUIChooser = 0;
        SigningAppToggleBTN1.IsCheckedChanged += SigningAppToggleBTNSFunction;
        SigningAppToggleBTN2.IsCheckedChanged += SigningAppToggleBTNSFunction;
        SigningAppToggleBTN3.IsCheckedChanged += SigningAppToggleBTNSFunction;
        SigningAppToggleBTN4.IsCheckedChanged += SigningAppToggleBTNSFunction;
        SigningAppToggleBTN5.IsCheckedChanged += SigningAppToggleBTNSFunction;
        SigningAppSBTN1.Click += SigningAppResetToggledButtons;
        SigningAppSBTN2.Click += SigningAppRefreshComboBoxElements;
    }



    private void SigningAppRefreshComboBoxElements(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoadSigningAppSubKeyIdentifiers();
    }

    private void SigningAppResetToggledButtons(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ResetSigningAppUI();
    }

    private void SigningAppToggleBTNSFunction(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SigningAppToggleBTN1.IsChecked == true)
        {
            SigningAppToggleBTN2.IsChecked = false;
            SigningAppToggleBTN3.IsChecked = false;
            SigningAppToggleBTN4.IsChecked = false;
            SigningAppToggleBTN5.IsChecked = false;
            SigningAppUIChooser = 1;
        }
        else if (SigningAppToggleBTN2.IsChecked == true)
        {
            SigningAppToggleBTN1.IsChecked = false;
            SigningAppToggleBTN3.IsChecked = false;
            SigningAppToggleBTN4.IsChecked = false;
            SigningAppToggleBTN5.IsChecked = false;
            SigningAppUIChooser = 2;
        }
        else if (SigningAppToggleBTN3.IsChecked == true)
        {
            SigningAppToggleBTN1.IsChecked = false;
            SigningAppToggleBTN2.IsChecked = false;
            SigningAppToggleBTN4.IsChecked = false;
            SigningAppToggleBTN5.IsChecked = false;
            SigningAppUIChooser = 3;
        }
        else if (SigningAppToggleBTN4.IsChecked == true)
        {
            SigningAppToggleBTN1.IsChecked = false;
            SigningAppToggleBTN2.IsChecked = false;
            SigningAppToggleBTN3.IsChecked = false;
            SigningAppToggleBTN5.IsChecked = false;
            SigningAppUIChooser = 4;
        }
        else if (SigningAppToggleBTN5.IsChecked == true)
        {
            SigningAppToggleBTN1.IsChecked = false;
            SigningAppToggleBTN2.IsChecked = false;
            SigningAppToggleBTN3.IsChecked = false;
            SigningAppToggleBTN4.IsChecked = false;
            SigningAppUIChooser = 5;
        }
        else
        {
            ResetSigningAppUITB();
        }
        SigningAppDrawUI();
    }

    private void SigningAppDrawUI() 
    {
        if (SigningAppUIChooser == 1)
        {
            if (HasUIRendered == false) 
            {
                FirstSAppmyTextBlockArray = new TextBlock[3];
                FirstSAppmyTextBlockArray[0] = new TextBlock();
                FirstSAppmyTextBlockArray[1] = new TextBlock();
                FirstSAppmyTextBlockArray[2] = new TextBlock();
                FirstSAppmyTextBlockArray[0].Text = "Choose a Digital Signature Algorithm";
                FirstSAppmyTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                FirstSAppmyTextBlockArray[2].Text = "Digital Signature Key Pair Generation Status (Read Only)";
                FirstSAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FirstSAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FirstSAppmyTBArray = new TextBox[2];
                FirstSAppmyTBArray[0] = new TextBox();
                FirstSAppmyTBArray[1] = new TextBox();
                FirstSAppmyTBArray[0].IsReadOnly = true;
                FirstSAppmyTBArray[1].IsReadOnly = true;
                FirstSAppmyTBArray[0].AcceptsReturn = true;
                FirstSAppmyTBArray[1].AcceptsReturn = true;
                FirstSAppmyTBArray[0].Height = 50;
                FirstSAppmyTBArray[1].Height = 50;
                FirstSAppmyTBArray[0].TextWrapping = TextWrapping.Wrap;
                FirstSAppmyTBArray[1].TextWrapping = TextWrapping.Wrap;
                FirstSAppmyRBArray = new RadioButton[2];
                FirstSAppmyRBArray[0] = new RadioButton();
                FirstSAppmyRBArray[1] = new RadioButton();
                FirstSAppmyRBArray[0].GroupName = "CurveTypes";
                FirstSAppmyRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                FirstSAppmyRBArray[0].IsChecked = true;
                FirstSAppmyRBArray[1].GroupName = "CurveTypes";
                FirstSAppmyRBArray[1].Content = "Curve448 - ED448 (Experimental)";
                FirstSAppmyButtonArray = new Button[1];
                FirstSAppmyButtonArray[0] = new Button();
                FirstSAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FirstSAppmyButtonArray[0].Content = "Generate Key Pair";
                FirstSAppmyButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(FirstSAppmyTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyRBArray[0]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyRBArray[1]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyTBArray[0]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyTBArray[1]);
                SigningAppLowerRightSP.Children.Add(FirstSAppmyButtonArray[0]);
                HasUIRendered = true;
            }            
        }
        else if (SigningAppUIChooser == 2)
        {
            if (HasUIRendered == false) 
            {
                SecondSAppmyTextBlockArray = new TextBlock[5];
                SecondSAppmyTextBlockArray[0] = new TextBlock();
                SecondSAppmyTextBlockArray[1] = new TextBlock();
                SecondSAppmyTextBlockArray[2] = new TextBlock();
                SecondSAppmyTextBlockArray[3] = new TextBlock();
                SecondSAppmyTextBlockArray[4] = new TextBlock();
                SecondSAppmyTextBlockArray[0].Text = "Select a sub key identifier";
                SecondSAppmyTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                SecondSAppmyTextBlockArray[2].Text = "Corresponding Public Key (Base64) (Read Only)";
                SecondSAppmyTextBlockArray[3].Text = "Corresponding Signed Public Key (Base64) (Read Only)";
                SecondSAppmyTextBlockArray[4].Text = "View sub key identifier error (Read Only)";
                SecondSAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondSAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondSAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondSAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondSAppmyCBArray = new ComboBox[1];
                SecondSAppmyCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                SecondSAppmyCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                SecondSAppmyTBArray = new TextBox[4];
                SecondSAppmyTBArray[0] = new TextBox();
                SecondSAppmyTBArray[1] = new TextBox();
                SecondSAppmyTBArray[2] = new TextBox();
                SecondSAppmyTBArray[3] = new TextBox();
                SecondSAppmyTBArray[0].IsReadOnly = true;
                SecondSAppmyTBArray[1].IsReadOnly = true;
                SecondSAppmyTBArray[2].IsReadOnly = true;
                SecondSAppmyTBArray[3].IsReadOnly = true;
                SecondSAppmyTBArray[0].AcceptsReturn = true;
                SecondSAppmyTBArray[1].AcceptsReturn = true;
                SecondSAppmyTBArray[2].AcceptsReturn = true;
                SecondSAppmyTBArray[0].Height = 75;
                SecondSAppmyTBArray[1].Height = 75;
                SecondSAppmyTBArray[2].Height = 75;
                SecondSAppmyTBArray[0].Width = 370;
                SecondSAppmyTBArray[1].Width = 370;
                SecondSAppmyTBArray[2].Width = 370;
                SecondSAppmyButtonArray = new Button[1];
                SecondSAppmyButtonArray[0] = new Button();
                SecondSAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                SecondSAppmyButtonArray[0].Content = "View Public Keys";
                SecondSAppmyButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyCBArray[0]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTBArray[0]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTBArray[1]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTextBlockArray[3]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTBArray[2]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTextBlockArray[4]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyTBArray[3]);
                SigningAppLowerRightSP.Children.Add(SecondSAppmyButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 3)
        {
            if (HasUIRendered == false)
            {
                ThirdSAppmyTextBlockArray = new TextBlock[3];
                ThirdSAppmyTextBlockArray[0] = new TextBlock();
                ThirdSAppmyTextBlockArray[1] = new TextBlock();
                ThirdSAppmyTextBlockArray[2] = new TextBlock();
                ThirdSAppmyTextBlockArray[0].Text = "Select a sub key identifier";
                ThirdSAppmyTextBlockArray[1].Text = "Choose a digital signature algorithm";
                ThirdSAppmyTextBlockArray[2].Text = "Change Digital Signature Key Pair Status (Read Only)";
                ThirdSAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdSAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdSAppmyCBArray = new ComboBox[1];
                ThirdSAppmyCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                ThirdSAppmyCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                ThirdSAppmyRBArray = new RadioButton[2];
                ThirdSAppmyRBArray[0] = new RadioButton();
                ThirdSAppmyRBArray[1] = new RadioButton();
                ThirdSAppmyRBArray[0].GroupName = "CurveTypes";
                ThirdSAppmyRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                ThirdSAppmyRBArray[0].IsChecked = true;
                ThirdSAppmyRBArray[1].GroupName = "CurveTypes";
                ThirdSAppmyRBArray[1].Content = "Curve448 - ED448 (Experimental)";
                ThirdSAppmyTBArray = new TextBox[1];
                ThirdSAppmyTBArray[0] = new TextBox();
                ThirdSAppmyTBArray[0].IsReadOnly = true;
                ThirdSAppmyButtonArray = new Button[1];
                ThirdSAppmyButtonArray[0] = new Button();
                ThirdSAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                ThirdSAppmyButtonArray[0].Content = "Change Digital Signature Key Pair";
                ThirdSAppmyButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyCBArray[0]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyRBArray[0]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyRBArray[1]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyTBArray[0]);
                SigningAppLowerRightSP.Children.Add(ThirdSAppmyButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 4)
        {
            if (HasUIRendered == false)
            {
                FourthSAppmyTextBlockArray = new TextBlock[2];
                FourthSAppmyTextBlockArray[0] = new TextBlock();
                FourthSAppmyTextBlockArray[1] = new TextBlock();
                FourthSAppmyTextBlockArray[0].Text = "Select a sub key identifier";
                FourthSAppmyTextBlockArray[1].Text = "Delete Digital Signature Key Pair Status (Read Only)";
                FourthSAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthSAppmyCBArray = new ComboBox[1];
                FourthSAppmyCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                FourthSAppmyCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                FourthSAppmyTBArray = new TextBox[1];
                FourthSAppmyTBArray[0] = new TextBox();
                FourthSAppmyTBArray[0].IsReadOnly = true;
                FourthSAppmyButtonArray = new Button[1];
                FourthSAppmyButtonArray[0] = new Button();
                FourthSAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FourthSAppmyButtonArray[0].Content = "Delete Digital Signature Key Pair";
                FourthSAppmyButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(FourthSAppmyTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(FourthSAppmyCBArray[0]);
                SigningAppLowerRightSP.Children.Add(FourthSAppmyTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(FourthSAppmyTBArray[0]);
                SigningAppLowerRightSP.Children.Add(FourthSAppmyButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 5)
        {
            if (HasUIRendered == false)
            {
                FifthSAppmyTextBlockArray = new TextBlock[6];
                FifthSAppmyTextBlockArray[0] = new TextBlock();
                FifthSAppmyTextBlockArray[1] = new TextBlock();
                FifthSAppmyTextBlockArray[2] = new TextBlock();
                FifthSAppmyTextBlockArray[3] = new TextBlock();
                FifthSAppmyTextBlockArray[4] = new TextBlock();
                FifthSAppmyTextBlockArray[5] = new TextBlock();
                FifthSAppmyTextBlockArray[0].Text = "Select a sub key identifier";
                FifthSAppmyTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                FifthSAppmyTextBlockArray[2].Text = "Challenge (Base64) From Provider";
                FifthSAppmyTextBlockArray[3].Text = "Local Signed Challenge (Base64) (Read Only)";
                FifthSAppmyTextBlockArray[4].Text = "Digital Signature Key Pair Curve Type (Read Only)";
                FifthSAppmyTextBlockArray[5].Text = "Sign Challenge Error Status (Read Only)";
                FifthSAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthSAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthSAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthSAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthSAppmyTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthSAppmyCBArray = new ComboBox[1];
                FifthSAppmyCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                FifthSAppmyCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                FifthSAppmyTBArray = new TextBox[5];
                FifthSAppmyTBArray[0] = new TextBox();
                FifthSAppmyTBArray[1] = new TextBox();
                FifthSAppmyTBArray[2] = new TextBox();
                FifthSAppmyTBArray[3] = new TextBox();
                FifthSAppmyTBArray[4] = new TextBox();
                FifthSAppmyTBArray[0].IsReadOnly = true;
                FifthSAppmyTBArray[2].IsReadOnly = true;
                FifthSAppmyTBArray[3].IsReadOnly = true;
                FifthSAppmyTBArray[4].IsReadOnly = true;
                FifthSAppmyTBArray[0].AcceptsReturn = true;
                FifthSAppmyTBArray[1].AcceptsReturn = true;
                FifthSAppmyTBArray[2].AcceptsReturn = true;
                FifthSAppmyTBArray[0].Height = 75;
                FifthSAppmyTBArray[1].Height = 75;
                FifthSAppmyTBArray[2].Height = 75;
                FifthSAppmyTBArray[0].Width = 370;
                FifthSAppmyTBArray[1].Width = 370;
                FifthSAppmyTBArray[2].Width = 370;
                FifthSAppmyButtonArray = new Button[1];
                FifthSAppmyButtonArray[0] = new Button();
                FifthSAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FifthSAppmyButtonArray[0].Content = "Sign Challenge";
                FifthSAppmyButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyCBArray[0]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTBArray[0]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTBArray[1]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[3]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTBArray[2]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[4]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTBArray[3]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTextBlockArray[5]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyTBArray[4]);
                SigningAppLowerRightSP.Children.Add(FifthSAppmyButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else
        {
            ResetSigningAppUI();            
        }
    }

    private void SigningAppComboBoxSelectedItemsChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SigningAppUIChooser == 2)
        {
            if (SecondSAppmyCBArray[0].SelectedIndex != -1)
            {
                SecondSAppmyTBArray[0].Text = SecondSAppmyCBArray[0].SelectedItem.ToString();
            }
        }
        else if (SigningAppUIChooser == 5)
        {
            if (FifthSAppmyCBArray[0].SelectedIndex != -1)
            {
                FifthSAppmyTBArray[0].Text = FifthSAppmyCBArray[0].SelectedItem.ToString();
            }
        }
    }

    private void LoadSigningAppSubKeyIdentifiers()
    {
        if (SigningAppUIChooser == 2 || SigningAppUIChooser == 5)
        {
            String[] Sub_Key_Identifiers_FullPath = Directory.GetDirectories(SigningAppRootFolder);
            int Loop = 0;
            String[] Sub_Key_Identifiers = new String[Sub_Key_Identifiers_FullPath.Length];
            int RootDirectoryPathLength = SigningAppRootFolder.Length;
            while (Loop < Sub_Key_Identifiers_FullPath.Length)
            {
                Sub_Key_Identifiers[Loop] = Sub_Key_Identifiers_FullPath[Loop].Remove(0, RootDirectoryPathLength);
                Loop += 1;
            }
            if (SigningAppUIChooser == 2)
            {
                SecondSAppmyCBArray[0].Items.Clear();
            }
            else if (SigningAppUIChooser == 5)
            {
                FifthSAppmyCBArray[0].Items.Clear();
            }
            Loop = 0;
            if (SigningAppUIChooser == 2)
            {
                while (Loop < Sub_Key_Identifiers_FullPath.Length)
                {
                    SecondSAppmyCBArray[0].Items.Add(Sub_Key_Identifiers[Loop]);
                    Loop += 1;
                }
            }
            else if (SigningAppUIChooser == 5)
            {
                while (Loop < Sub_Key_Identifiers_FullPath.Length)
                {
                    FifthSAppmyCBArray[0].Items.Add(Sub_Key_Identifiers[Loop]);
                    Loop += 1;
                }
            }
            if (SigningAppUIChooser == 2)
            {
                if (SecondSAppmyTBArray.Length != 0)
                {
                    SecondSAppmyTBArray[0].Text = "";
                }
            }
            else if (SigningAppUIChooser == 5)
            {
                if (FifthSAppmyTBArray.Length != 0)
                {
                    FifthSAppmyTBArray[0].Text = "";
                }
            }
        }
        else if (SigningAppUIChooser == 3 || SigningAppUIChooser == 4) 
        {
            String[] Sub_Key_Identifiers_FullPath = Directory.GetDirectories(SigningAppRootFolder);
            int Loop = 0;
            String[] Sub_Key_Identifiers = new String[Sub_Key_Identifiers_FullPath.Length];
            int RootDirectoryPathLength = SigningAppRootFolder.Length;
            while (Loop < Sub_Key_Identifiers_FullPath.Length)
            {
                Sub_Key_Identifiers[Loop] = Sub_Key_Identifiers_FullPath[Loop].Remove(0, RootDirectoryPathLength);
                Loop += 1;
            }
            if (SigningAppUIChooser == 3)
            {
                ThirdSAppmyCBArray[0].Items.Clear();
            }
            else if (SigningAppUIChooser == 4)
            {
                FourthSAppmyCBArray[0].Items.Clear();
            }
            Loop = 0;
            if (SigningAppUIChooser == 3)
            {
                while (Loop < Sub_Key_Identifiers_FullPath.Length)
                {
                    ThirdSAppmyCBArray[0].Items.Add(Sub_Key_Identifiers[Loop]);
                    Loop += 1;
                }
            }
            else if (SigningAppUIChooser == 4)
            {
                while (Loop < Sub_Key_Identifiers_FullPath.Length)
                {
                    FourthSAppmyCBArray[0].Items.Add(Sub_Key_Identifiers[Loop]);
                    Loop += 1;
                }
            }
        }
    }

    private void ResetSigningAppUI() 
    {
        SigningAppToggleBTN1.IsChecked = false;
        SigningAppToggleBTN2.IsChecked = false;
        SigningAppToggleBTN3.IsChecked = false;
        SigningAppToggleBTN4.IsChecked = false;
        SigningAppToggleBTN5.IsChecked = false;
        SigningAppUIChooser = 0;
        SigningAppLowerRightSP.Children.Clear();
        FirstSAppmyRBArray = new RadioButton[] { };
        ThirdSAppmyRBArray = new RadioButton[] { };
        FirstSAppmyTextBlockArray = new TextBlock[] { };
        SecondSAppmyTextBlockArray = new TextBlock[] { };
        ThirdSAppmyTextBlockArray = new TextBlock[] { };
        FourthSAppmyTextBlockArray = new TextBlock[] { };
        FifthSAppmyTextBlockArray = new TextBlock[] { };
        FirstSAppmyTBArray = new TextBox[] { };
        SecondSAppmyTBArray = new TextBox[] { };
        ThirdSAppmyTBArray = new TextBox[] { };
        FourthSAppmyTBArray = new TextBox[] { };
        FifthSAppmyTBArray = new TextBox[] { };
        SecondSAppmyCBArray = new ComboBox[] { };
        ThirdSAppmyCBArray = new ComboBox[] { };
        FourthSAppmyCBArray = new ComboBox[] { };
        FifthSAppmyCBArray = new ComboBox[] { };
        FirstSAppmyButtonArray = new Button[] { };
        SecondSAppmyButtonArray = new Button[] { };
        ThirdSAppmyButtonArray = new Button[] { };
        FourthSAppmyButtonArray = new Button[] { };
        FifthSAppmyButtonArray = new Button[] { };
        HasUIRendered = false;
    }

    private void ResetSigningAppUITB() 
    {
        SigningAppUIChooser = 0;
        SigningAppLowerRightSP.Children.Clear();
        FirstSAppmyRBArray = new RadioButton[] { };
        ThirdSAppmyRBArray = new RadioButton[] { };
        FirstSAppmyTextBlockArray = new TextBlock[] { };
        SecondSAppmyTextBlockArray = new TextBlock[] { };
        ThirdSAppmyTextBlockArray = new TextBlock[] { };
        FourthSAppmyTextBlockArray = new TextBlock[] { };
        FifthSAppmyTextBlockArray = new TextBlock[] { };
        FirstSAppmyTBArray = new TextBox[] { };
        SecondSAppmyTBArray = new TextBox[] { };
        ThirdSAppmyTBArray = new TextBox[] { };
        FourthSAppmyTBArray = new TextBox[] { };
        FifthSAppmyTBArray = new TextBox[] { };
        SecondSAppmyCBArray = new ComboBox[] { };
        ThirdSAppmyCBArray = new ComboBox[] { };
        FourthSAppmyCBArray = new ComboBox[] { };
        FifthSAppmyCBArray = new ComboBox[] { };
        FirstSAppmyButtonArray = new Button[] { };
        SecondSAppmyButtonArray = new Button[] { };
        ThirdSAppmyButtonArray = new Button[] { };
        FourthSAppmyButtonArray = new Button[] { };
        FifthSAppmyButtonArray = new Button[] { };
        HasUIRendered = false;
    }

    private void SigningAppBTN_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SigningAppUIChooser == 1)
        {
            String Sub_Key_Identifier = CryptographicSecureIDGenerator.GenerateUniqueString();
            if (Sub_Key_Identifier.Length > 48)
            {
                Sub_Key_Identifier = Sub_Key_Identifier.Substring(0, 48);
            }
            RevampedKeyPair MyED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            ED448RevampedKeyPair MyED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
            Byte[] SignedPublicKey = new Byte[] { };
            while (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
            {
                Sub_Key_Identifier = CryptographicSecureIDGenerator.GenerateUniqueString();
                if (Sub_Key_Identifier.Length > 48)
                {
                    Sub_Key_Identifier = Sub_Key_Identifier.Substring(0, 48);
                }
            }
            Directory.CreateDirectory(SigningAppRootFolder + Sub_Key_Identifier);
            //Strongly secured elliptic curves which was highly tested by cryptographers and recommended by D.J.B
            if (FirstSAppmyRBArray[0].IsChecked == true)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                {
                    File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "\\CurveType.txt", "IsCurve25519");
                    SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Private_Key.txt", MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Public_Key.txt", MyED25519KeyPair.PublicKey);
                }
                else
                {
                    File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "/CurveType.txt", "IsCurve25519");
                    SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Private_Key.txt", MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Public_Key.txt", MyED25519KeyPair.PublicKey);
                }
                //As the function copies and doesn't modify the keypair object's private key
                //That's why we need to clear the private key after signing ASAP in memory given that
                //you are able to understand security or cryptography               
            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                {
                    File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "\\CurveType.txt", "IsCurve448");
                    SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey, MyED448KeyPair.PublicKey, new Byte[] { });
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Private_Key.txt", MyED448KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Public_Key.txt", MyED448KeyPair.PublicKey);
                }
                else
                {
                    File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "/CurveType.txt", "IsCurve448");
                    SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey, MyED448KeyPair.PublicKey, new Byte[] { });
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Private_Key.txt", MyED448KeyPair.PrivateKey);
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Public_Key.txt", MyED448KeyPair.PublicKey);
                }
            }
            //I was not quite sure whether this is an industry standard but personally storing both public key and signed public
            //key can be used to prove the legitimacy of the public key given I and A aspects in C.I.A. was properly implemented
            //However, this does not mean the owner of the public key can be proven
            //There's identity issue here which men doesn't have proper solutions to this unsolvable and addressable issue
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
            {
                File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Signed_Public_Key.txt", SignedPublicKey);
            }
            else
            {
                File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Signed_Public_Key.txt", SignedPublicKey);
            }
            FirstSAppmyTBArray[0].Text = Sub_Key_Identifier;
            FirstSAppmyTBArray[1].Text = "The signature keypairs have been created";
            MyED448KeyPair.Clear();
            MyED25519KeyPair.Clear();
        }
        else if (SigningAppUIChooser == 2)
        {
            Byte[] PublicKey = new Byte[] { };
            Byte[] SignedPublicKey = new Byte[] { };
            String Sub_Key_Identifier = SecondSAppmyCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                SecondSAppmyTBArray[3].Text = "There's no keypairs created or you have not choose any keypairs";
            }
            else
            {
                if (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                    {
                        PublicKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Public_Key.txt");
                        SignedPublicKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Signed_Public_Key.txt");
                    }
                    else
                    {
                        PublicKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Public_Key.txt");
                        SignedPublicKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Signed_Public_Key.txt");
                        SigningAppRootFolder = AppContext.BaseDirectory + "/SAppDSKP/";
                    }
                    SecondSAppmyTBArray[1].Text = Convert.ToBase64String(PublicKey);
                    SecondSAppmyTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                }
                else
                {
                    SecondSAppmyTBArray[3].Text = "The specified sub key identifier can't be found";
                }
            }
        }
        else if (SigningAppUIChooser == 3)
        {
            if (ThirdSAppmyCBArray[0].SelectedIndex != -1)
            {
                String Sub_Key_Identifier = ThirdSAppmyCBArray[0].SelectedItem.ToString();
                RevampedKeyPair MyED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                ED448RevampedKeyPair MyED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                Byte[] SignedPublicKey = new Byte[] { };
                if (ThirdSAppmyRBArray[0].IsChecked == true)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                    {
                        File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "\\CurveType.txt", "IsCurve25519");
                        SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Private_Key.txt", MyED25519KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Public_Key.txt", MyED25519KeyPair.PublicKey);
                    }
                    else
                    {
                        File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "/CurveType.txt", "IsCurve25519");
                        SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Private_Key.txt", MyED25519KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Public_Key.txt", MyED25519KeyPair.PublicKey);
                    }
                }
                else
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                    {
                        File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "\\CurveType.txt", "IsCurve448");
                        SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey, MyED448KeyPair.PublicKey, new Byte[] { });
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Private_Key.txt", MyED448KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Public_Key.txt", MyED448KeyPair.PublicKey);
                    }
                    else
                    {
                        File.WriteAllText(SigningAppRootFolder + Sub_Key_Identifier + "/CurveType.txt", "IsCurve448");
                        SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey, MyED448KeyPair.PublicKey, new Byte[] { });
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Private_Key.txt", MyED448KeyPair.PrivateKey);
                        File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Public_Key.txt", MyED448KeyPair.PublicKey);
                    }
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                {
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Signed_Public_Key.txt", SignedPublicKey);
                }
                else
                {
                    File.WriteAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Signed_Public_Key.txt", SignedPublicKey);
                }
                ThirdSAppmyTBArray[0].Text = "The signature keypair in specified sub key identifier has been changed";
                MyED448KeyPair.Clear();
                MyED25519KeyPair.Clear();
            }
        }
        else if (SigningAppUIChooser == 4)
        {
            String Sub_Key_Identifier = FourthSAppmyCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                FourthSAppmyTBArray[0].Text = "There's no keypairs created or you have not choose any keypairs";
            }
            else
            {
                if (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
                {
                    Directory.Delete(SigningAppRootFolder + Sub_Key_Identifier, true);
                    FourthSAppmyTBArray[0].Text = "The specified sub key identifier has been deleted";
                }
                else
                {
                    FourthSAppmyTBArray[0].Text = "The specified sub key identifier can't be found";
                }
            }
            LoadSigningAppSubKeyIdentifiers();
        }
        else if (SigningAppUIChooser == 5)
        {
            Byte[] PrivateKey = new Byte[] { };
            Byte[] Challenge = new Byte[] { };
            Byte[] SignedChallenge = new Byte[] { };
            Boolean TryParseFromBase64String = true;
            String CurveDeterminer = "";
            String ChallengeString = FifthSAppmyTBArray[1].Text;
            String Sub_Key_Identifier = FifthSAppmyCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                FifthSAppmyTBArray[4].Text = "There's no keypairs created or you have not choose any keypairs";
            }
            else
            {
                if (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
                {
                    if (String.IsNullOrEmpty(ChallengeString) == true)
                    {
                        FifthSAppmyTBArray[4].Text = "Please get the base 64 encoded challenge from provider";
                    }
                    else
                    {
                        try
                        {
                            Challenge = Convert.FromBase64String(ChallengeString);
                        }
                        catch
                        {
                            TryParseFromBase64String = false;
                        }
                        if (TryParseFromBase64String == true)
                        {
                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
                            {
                                PrivateKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "\\Private_Key.txt");
                                CurveDeterminer = File.ReadAllText(SigningAppRootFolder + Sub_Key_Identifier + "\\CurveType.txt");
                            }
                            else
                            {
                                PrivateKey = File.ReadAllBytes(SigningAppRootFolder + Sub_Key_Identifier + "/Private_Key.txt");
                                CurveDeterminer = File.ReadAllText(SigningAppRootFolder + Sub_Key_Identifier + "/CurveType.txt");
                            }
                            if (CurveDeterminer.CompareTo("IsCurve25519") == 0)
                            {
                                SignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, PrivateKey);
                                FifthSAppmyTBArray[2].Text = Convert.ToBase64String(SignedChallenge);
                                FifthSAppmyTBArray[3].Text = CurveDeterminer;
                            }
                            else if (CurveDeterminer.CompareTo("IsCurve448") == 0)
                            {
                                SignedChallenge = SecureED448.GenerateSignatureMessage(PrivateKey, Challenge, new Byte[] { });
                                FifthSAppmyTBArray[2].Text = Convert.ToBase64String(SignedChallenge);
                                FifthSAppmyTBArray[3].Text = CurveDeterminer;
                            }
                            else
                            {
                                FifthSAppmyTBArray[4].Text = "Something's wrong with the Curve Type File";
                            }
                            SodiumSecureMemory.SecureClearBytes(PrivateKey);
                        }
                        else
                        {
                            FifthSAppmyTBArray[4].Text = "This is not a valid Base 64 encoded string/challenge";
                        }
                    }
                }
                else
                {
                    FifthSAppmyTBArray[4].Text = "The specified sub key identifier can't be found";
                }
            }
        }
    }

    private void MAppInitialization()
    {
        /*Button TestButton = new Button();
        TestButton.Content = "Test Button";
        TestButton.Margin = Avalonia.Thickness.Parse("0,5,0,0");
        TestSP.Children.Add(TestButton);*/
        ManagementAppUIChooser = 0;
        ManagementAppToggleBTN1.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN2.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN3.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN4.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN5.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN6.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppToggleBTN7.IsCheckedChanged += ManagementAppToggleBTNSFunction;
        ManagementAppSBTN.Click += ManagementAppResetToggledButtons;
    }

    private void ManagementAppResetToggledButtons(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ResetManagementAppUI();
    }

    private void ManagementAppToggleBTNSFunction(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ManagementAppToggleBTN1.IsChecked == true)
        {
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false;
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 1;
        }
        else if (ManagementAppToggleBTN2.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false;
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 2;
        }
        else if (ManagementAppToggleBTN3.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false;
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 3;
        }
        else if (ManagementAppToggleBTN4.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false;
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 4;
        }
        else if (ManagementAppToggleBTN5.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 5;
        }
        else if (ManagementAppToggleBTN6.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false;
            ManagementAppToggleBTN7.IsChecked = false;
            ManagementAppUIChooser = 6;
        }
        else if (ManagementAppToggleBTN7.IsChecked == true)
        {
            ManagementAppToggleBTN1.IsChecked = false;
            ManagementAppToggleBTN2.IsChecked = false;
            ManagementAppToggleBTN3.IsChecked = false;
            ManagementAppToggleBTN4.IsChecked = false;
            ManagementAppToggleBTN5.IsChecked = false; 
            ManagementAppToggleBTN6.IsChecked = false;
            ManagementAppUIChooser = 7;
        }
        else
        {
            ResetManagementAppUITB();
        }
        ManagementAppDrawUI();
    }

    private void ManagementAppDrawUI()
    {
        if (ManagementAppUIChooser == 1)
        {
            if (MAHasUIRendered == false)
            {
                FirstMAAppmyTextBlockArray = new TextBlock[2];
                FirstMAAppmyTextBlockArray[0] = new TextBlock();
                FirstMAAppmyTextBlockArray[1] = new TextBlock();
                FirstMAAppmyTextBlockArray[0].Text = "Choose an action";
                FirstMAAppmyTextBlockArray[1].Text = "TOR Status (Read Only)";
                FirstMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FirstMAAppmyCBArray = new ComboBox[1];
                FirstMAAppmyCBArray[0] = new ComboBox();
                FirstMAAppmyCBArray[0].Items.Add("1. Download TOR");
                FirstMAAppmyCBArray[0].Items.Add("1/2. Start TOR");
                FirstMAAppmyCBArray[0].Items.Add("2/3. Stop TOR");
                FirstMAAppmyTBArray = new TextBox[1];
                FirstMAAppmyTBArray[0] = new TextBox();
                FirstMAAppmyTBArray[0].IsReadOnly = true;
                FirstMAAppmyTBArray[0].Height = 75;
                FirstMAAppmyTBArray[0].Width = 370;
                FirstMAAppmyButtonArray = new Button[1];
                FirstMAAppmyButtonArray[0] = new Button();
                FirstMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FirstMAAppmyButtonArray[0].Content = "TOR operation action";
                FirstMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(FirstMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FirstMAAppmyCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FirstMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FirstMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FirstMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 2)
        {
            if (MAHasUIRendered == false)
            {
                SecondMAAppmyTextBlockArray = new TextBlock[3];
                SecondMAAppmyTextBlockArray[0] = new TextBlock();
                SecondMAAppmyTextBlockArray[1] = new TextBlock();
                SecondMAAppmyTextBlockArray[2] = new TextBlock();
                SecondMAAppmyTextBlockArray[0].Text = "The server IP address of PKDSA provider";
                SecondMAAppmyTextBlockArray[1].Text = "Choose an action";
                SecondMAAppmyTextBlockArray[2].Text = "Server IP address status (Read Only)";
                SecondMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SecondMAAppmyTBArray = new TextBox[2];
                SecondMAAppmyTBArray[0] = new TextBox();
                SecondMAAppmyTBArray[1] = new TextBox();
                SecondMAAppmyTBArray[1].IsReadOnly = true;
                SecondMAAppmyTBArray[0].AcceptsReturn = true;
                SecondMAAppmyTBArray[1].AcceptsReturn = true;
                SecondMAAppmyTBArray[0].Height = 75;
                SecondMAAppmyTBArray[1].Height = 75;
                SecondMAAppmyTBArray[0].Height = 100;
                SecondMAAppmyTBArray[1].Height = 100;
                SecondMAAppmyTBArray[0].TextWrapping = TextWrapping.Wrap;
                SecondMAAppmyTBArray[1].TextWrapping = TextWrapping.Wrap;
                SecondMAAppmyCBArray = new ComboBox[1];
                SecondMAAppmyCBArray[0] = new ComboBox();
                SecondMAAppmyCBArray[0].Items.Add("1. Add provider IP");
                SecondMAAppmyCBArray[0].Items.Add("1/2. Establish a connection with provider IP");
                SecondMAAppmyButtonArray = new Button[1];
                SecondMAAppmyButtonArray[0] = new Button();
                SecondMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                SecondMAAppmyButtonArray[0].Content = "Set or establish server connection";
                SecondMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(SecondMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 3)
        {
            if (MAHasUIRendered == false)
            {
                ThirdMAAppmyTextBlockArray = new TextBlock[7];
                ThirdMAAppmyTextBlockArray[0] = new TextBlock();
                ThirdMAAppmyTextBlockArray[1] = new TextBlock();
                ThirdMAAppmyTextBlockArray[2] = new TextBlock();
                ThirdMAAppmyTextBlockArray[3] = new TextBlock();
                ThirdMAAppmyTextBlockArray[4] = new TextBlock();
                ThirdMAAppmyTextBlockArray[5] = new TextBlock();
                ThirdMAAppmyTextBlockArray[6] = new TextBlock();
                ThirdMAAppmyTextBlockArray[0].Text = "Randomly generated user ID (Read only)";
                ThirdMAAppmyTextBlockArray[1].Text = "Randomly generated public key (Read Only)";
                ThirdMAAppmyTextBlockArray[2].Text = "Randomly generated signed public key (Read Only)";
                ThirdMAAppmyTextBlockArray[3].Text = "Session messenger user ID (Hexa)";
                ThirdMAAppmyTextBlockArray[4].Text = "Choose a digital signature algorithm";
                ThirdMAAppmyTextBlockArray[5].Text = "Choose an action";
                ThirdMAAppmyTextBlockArray[6].Text = "Status (Read Only)";
                ThirdMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTextBlockArray[6].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                ThirdMAAppmyTBArray = new TextBox[5];
                ThirdMAAppmyTBArray[0] = new TextBox();
                ThirdMAAppmyTBArray[1] = new TextBox();
                ThirdMAAppmyTBArray[2] = new TextBox();
                ThirdMAAppmyTBArray[3] = new TextBox();
                ThirdMAAppmyTBArray[4] = new TextBox();
                ThirdMAAppmyTBArray[0].IsReadOnly = true;
                ThirdMAAppmyTBArray[1].IsReadOnly = true;
                ThirdMAAppmyTBArray[2].IsReadOnly = true;
                ThirdMAAppmyTBArray[4].IsReadOnly = true;
                ThirdMAAppmyTBArray[0].Height = 50;
                ThirdMAAppmyTBArray[0].Width = 370;
                ThirdMAAppmyTBArray[1].Height = 50;
                ThirdMAAppmyTBArray[1].Width = 370;
                ThirdMAAppmyTBArray[2].Height = 50;
                ThirdMAAppmyTBArray[2].Width = 370;
                ThirdMAAppmyTBArray[3].Height = 50;
                ThirdMAAppmyTBArray[3].Width = 370;
                ThirdMAAppmyTBArray[4].Height = 100;
                ThirdMAAppmyTBArray[4].Width = 370;
                ThirdMAAppmyCBArray = new ComboBox[1];
                ThirdMAAppmyCBArray[0] = new ComboBox();
                ThirdMAAppmyCBArray[0].Items.Add("1. Generate Keys Locally");
                ThirdMAAppmyCBArray[0].Items.Add("2. Register an account");
                ThirdMAAppmyRBArray = new RadioButton[2];
                ThirdMAAppmyRBArray[0] = new RadioButton();
                ThirdMAAppmyRBArray[1] = new RadioButton();
                ThirdMAAppmyRBArray[0].GroupName = "CurveTypes";
                ThirdMAAppmyRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                ThirdMAAppmyRBArray[0].IsChecked = true;
                ThirdMAAppmyRBArray[1].GroupName = "CurveTypes";
                ThirdMAAppmyRBArray[1].Content = "Curve448 - ED448 (Experimental)";
                ThirdMAAppmyButtonArray = new Button[1];
                ThirdMAAppmyButtonArray[0] = new Button();
                ThirdMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                ThirdMAAppmyButtonArray[0].Content = "Generate or submit information";
                ThirdMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTextBlockArray[6]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(ThirdMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 4)
        {
            if (MAHasUIRendered == false)
            {
                FourthMAAppmyTextBlockArray = new TextBlock[6];
                FourthMAAppmyTextBlockArray[0] = new TextBlock();
                FourthMAAppmyTextBlockArray[1] = new TextBlock();
                FourthMAAppmyTextBlockArray[2] = new TextBlock();
                FourthMAAppmyTextBlockArray[3] = new TextBlock();
                FourthMAAppmyTextBlockArray[4] = new TextBlock();
                FourthMAAppmyTextBlockArray[5] = new TextBlock();
                FourthMAAppmyTextBlockArray[0].Text = "Randomly generated user ID (Read only)";
                FourthMAAppmyTextBlockArray[1].Text = "Randomly generated public key (Read Only)";
                FourthMAAppmyTextBlockArray[2].Text = "Randomly generated signed public key (Read Only)";
                FourthMAAppmyTextBlockArray[3].Text = "Choose a digital signature algorithm";
                FourthMAAppmyTextBlockArray[4].Text = "Choose an action";
                FourthMAAppmyTextBlockArray[5].Text = "Status (Read Only)";
                FourthMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthMAAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthMAAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthMAAppmyTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FourthMAAppmyTBArray = new TextBox[4];
                FourthMAAppmyTBArray[0] = new TextBox();
                FourthMAAppmyTBArray[1] = new TextBox();
                FourthMAAppmyTBArray[2] = new TextBox();
                FourthMAAppmyTBArray[3] = new TextBox();
                FourthMAAppmyTBArray[0].IsReadOnly = true;
                FourthMAAppmyTBArray[1].IsReadOnly = true;
                FourthMAAppmyTBArray[2].IsReadOnly = true;
                FourthMAAppmyTBArray[3].IsReadOnly = true;
                FourthMAAppmyTBArray[0].Height = 50;
                FourthMAAppmyTBArray[0].Width = 370;
                FourthMAAppmyTBArray[1].Height = 50;
                FourthMAAppmyTBArray[1].Width = 370;
                FourthMAAppmyTBArray[2].Height = 50;
                FourthMAAppmyTBArray[2].Width = 370;
                FourthMAAppmyTBArray[3].Height = 50;
                FourthMAAppmyTBArray[3].Width = 370;
                FourthMAAppmyCBArray = new ComboBox[1];
                FourthMAAppmyCBArray[0] = new ComboBox();
                FourthMAAppmyCBArray[0].Items.Add("1. Generate Keys Locally");
                FourthMAAppmyCBArray[0].Items.Add("2. Change master key");
                FourthMAAppmyRBArray = new RadioButton[2];
                FourthMAAppmyRBArray[0] = new RadioButton();
                FourthMAAppmyRBArray[1] = new RadioButton();
                FourthMAAppmyRBArray[0].GroupName = "CurveTypes";
                FourthMAAppmyRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                FourthMAAppmyRBArray[0].IsChecked = true;
                FourthMAAppmyRBArray[1].GroupName = "CurveTypes";
                FourthMAAppmyRBArray[1].Content = "Curve448 - ED448 (Experimental)";
                FourthMAAppmyButtonArray = new Button[1];
                FourthMAAppmyButtonArray[0] = new Button();
                FourthMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FourthMAAppmyButtonArray[0].Content = "Generate or change information";
                FourthMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(FourthMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 5)
        {
            if (MAHasUIRendered == false)
            {
                FifthMAAppmyTextBlockArray = new TextBlock[6];
                FifthMAAppmyTextBlockArray[0] = new TextBlock();
                FifthMAAppmyTextBlockArray[1] = new TextBlock();
                FifthMAAppmyTextBlockArray[2] = new TextBlock();
                FifthMAAppmyTextBlockArray[3] = new TextBlock();
                FifthMAAppmyTextBlockArray[4] = new TextBlock();
                FifthMAAppmyTextBlockArray[5] = new TextBlock();
                FifthMAAppmyTextBlockArray[0].Text = "User ID (Read only)";
                FifthMAAppmyTextBlockArray[1].Text = "Device public key digest (Read Only)";
                FifthMAAppmyTextBlockArray[2].Text = "Server public key digest (Read Only)";
                FifthMAAppmyTextBlockArray[3].Text = "Session messenger contact (Read Only)";
                FifthMAAppmyTextBlockArray[4].Text = "Choose an action";
                FifthMAAppmyTextBlockArray[5].Text = "Status (Read Only)";
                FifthMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthMAAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthMAAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthMAAppmyTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                FifthMAAppmyTBArray = new TextBox[5];
                FifthMAAppmyTBArray[0] = new TextBox();
                FifthMAAppmyTBArray[1] = new TextBox();
                FifthMAAppmyTBArray[2] = new TextBox();
                FifthMAAppmyTBArray[3] = new TextBox();
                FifthMAAppmyTBArray[4] = new TextBox();
                FifthMAAppmyTBArray[0].IsReadOnly = true;
                FifthMAAppmyTBArray[1].IsReadOnly = true;
                FifthMAAppmyTBArray[2].IsReadOnly = true;
                FifthMAAppmyTBArray[3].IsReadOnly = true;
                FifthMAAppmyTBArray[4].IsReadOnly = true;
                FifthMAAppmyTBArray[0].Height = 50;
                FifthMAAppmyTBArray[0].Width = 370;
                FifthMAAppmyTBArray[1].Height = 50;
                FifthMAAppmyTBArray[1].Width = 370;
                FifthMAAppmyTBArray[2].Height = 50;
                FifthMAAppmyTBArray[2].Width = 370;
                FifthMAAppmyTBArray[3].Height = 50;
                FifthMAAppmyTBArray[3].Width = 370;
                FifthMAAppmyTBArray[4].Height = 50;
                FifthMAAppmyTBArray[4].Width = 370;
                FifthMAAppmyTBArray[3].Text = "05573054e242144d0df881e763d4806d9eee207a81900d790d49401b5bd2f44c36";
                FifthMAAppmyCBArray = new ComboBox[1];
                FifthMAAppmyCBArray[0] = new ComboBox();
                FifthMAAppmyCBArray[0].Items.Add("1/2. Compute pub key digest");
                FifthMAAppmyCBArray[0].Items.Add("1/2. Fetch pub key digest");
                FifthMAAppmyCBArray[0].Items.Add("3. Compare digests");
                FifthMAAppmyButtonArray = new Button[1];
                FifthMAAppmyButtonArray[0] = new Button();
                FifthMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                FifthMAAppmyButtonArray[0].Content = "Fetch and compare digest";
                FifthMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(FifthMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 6)
        {
            if (MAHasUIRendered == false)
            {
                SixthMAAppmyTextBlockArray = new TextBlock[4];
                SixthMAAppmyTextBlockArray[0] = new TextBlock();
                SixthMAAppmyTextBlockArray[1] = new TextBlock();
                SixthMAAppmyTextBlockArray[2] = new TextBlock();
                SixthMAAppmyTextBlockArray[3] = new TextBlock();
                SixthMAAppmyTextBlockArray[0].Text = "User ID (Read only)";
                SixthMAAppmyTextBlockArray[1].Text = "SApp key identifier";
                SixthMAAppmyTextBlockArray[2].Text = "Choose an action";
                SixthMAAppmyTextBlockArray[3].Text = "Status (Read Only)";
                SixthMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SixthMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SixthMAAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                SixthMAAppmyTBArray = new TextBox[3];
                SixthMAAppmyTBArray[0] = new TextBox();
                SixthMAAppmyTBArray[1] = new TextBox();
                SixthMAAppmyTBArray[2] = new TextBox();
                SixthMAAppmyTBArray[0].IsReadOnly = true;
                SixthMAAppmyTBArray[2].IsReadOnly = true;
                SixthMAAppmyTBArray[0].Height = 50;
                SixthMAAppmyTBArray[0].Width = 370;
                SixthMAAppmyTBArray[1].Height = 50;
                SixthMAAppmyTBArray[1].Width = 370;
                SixthMAAppmyTBArray[2].Height = 50;
                SixthMAAppmyTBArray[2].Width = 370;
                SixthMAAppmyRBArray = new RadioButton[2];
                SixthMAAppmyRBArray[0] = new RadioButton();
                SixthMAAppmyRBArray[1] = new RadioButton();
                SixthMAAppmyRBArray[0].GroupName = "KeyIdentifierAction";
                SixthMAAppmyRBArray[0].Content = "Add sub key identifier";
                SixthMAAppmyRBArray[0].IsChecked = true;
                SixthMAAppmyRBArray[1].GroupName = "KeyIdentifierAction";
                SixthMAAppmyRBArray[1].Content = "Remove sub key identifier";
                SixthMAAppmyButtonArray = new Button[1];
                SixthMAAppmyButtonArray[0] = new Button();
                SixthMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                SixthMAAppmyButtonArray[0].Content = "Add/remove key identifier";
                SixthMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(SixthMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 7)
        {
            if (MAHasUIRendered == false)
            {
                LastMAAppmyTextBlockArray = new TextBlock[6];
                LastMAAppmyTextBlockArray[0] = new TextBlock();
                LastMAAppmyTextBlockArray[1] = new TextBlock();
                LastMAAppmyTextBlockArray[2] = new TextBlock();
                LastMAAppmyTextBlockArray[3] = new TextBlock();
                LastMAAppmyTextBlockArray[4] = new TextBlock();
                LastMAAppmyTextBlockArray[5] = new TextBlock();
                LastMAAppmyTextBlockArray[0].Text = "User ID (Read only)";
                LastMAAppmyTextBlockArray[1].Text = "SApp key identifier";
                LastMAAppmyTextBlockArray[2].Text = "SApp public key";
                LastMAAppmyTextBlockArray[3].Text = "SApp signed public key";
                LastMAAppmyTextBlockArray[4].Text = "Choose an action";
                LastMAAppmyTextBlockArray[5].Text = "Status (Read Only)";
                LastMAAppmyTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                LastMAAppmyTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                LastMAAppmyTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                LastMAAppmyTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                LastMAAppmyTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                LastMAAppmyTBArray = new TextBox[5];
                LastMAAppmyTBArray[0] = new TextBox();
                LastMAAppmyTBArray[1] = new TextBox();
                LastMAAppmyTBArray[2] = new TextBox();
                LastMAAppmyTBArray[3] = new TextBox();
                LastMAAppmyTBArray[4] = new TextBox();
                LastMAAppmyTBArray[0].IsReadOnly = true;
                LastMAAppmyTBArray[4].IsReadOnly = true;
                LastMAAppmyTBArray[0].Height = 50;
                LastMAAppmyTBArray[0].Width = 370;
                LastMAAppmyTBArray[1].Height = 50;
                LastMAAppmyTBArray[1].Width = 370;
                LastMAAppmyTBArray[2].Height = 50;
                LastMAAppmyTBArray[2].Width = 370;
                LastMAAppmyTBArray[3].Height = 50;
                LastMAAppmyTBArray[3].Width = 370;
                LastMAAppmyTBArray[4].Height = 50;
                LastMAAppmyTBArray[4].Width = 370;
                LastMAAppmyRBArray = new RadioButton[2];
                LastMAAppmyRBArray[0] = new RadioButton();
                LastMAAppmyRBArray[1] = new RadioButton();
                LastMAAppmyRBArray[0].GroupName = "KeyIdentifierAction";
                LastMAAppmyRBArray[0].Content = "Add sub key";
                LastMAAppmyRBArray[0].IsChecked = true;
                LastMAAppmyRBArray[1].GroupName = "KeyIdentifierAction";
                LastMAAppmyRBArray[1].Content = "Change sub key";
                LastMAAppmyButtonArray = new Button[1];
                LastMAAppmyButtonArray[0] = new Button();
                LastMAAppmyButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                LastMAAppmyButtonArray[0].Content = "Add or change sub key";
                LastMAAppmyButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(LastMAAppmyButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else
        {
            ResetManagementAppUI();
        }
    }

    private void ResetManagementAppUI()
    {
        ManagementAppToggleBTN1.IsChecked = false;
        ManagementAppToggleBTN2.IsChecked = false;
        ManagementAppToggleBTN3.IsChecked = false;
        ManagementAppToggleBTN4.IsChecked = false;
        ManagementAppToggleBTN5.IsChecked = false;
        ManagementAppToggleBTN6.IsChecked = false;
        ManagementAppToggleBTN7.IsChecked = false;
        ManagementAppUIChooser = 0;
        ManagementAppLowerRightLPSP.Children.Clear();
        ThirdMAAppmyRBArray = new RadioButton[] { };
        FourthMAAppmyRBArray = new RadioButton[] { };
        SixthMAAppmyRBArray = new RadioButton[] { };
        LastMAAppmyRBArray = new RadioButton[] { };
        FirstMAAppmyTextBlockArray = new TextBlock[] { };
        SecondMAAppmyTextBlockArray = new TextBlock[] { };
        ThirdMAAppmyTextBlockArray = new TextBlock[] { };
        FourthMAAppmyTextBlockArray = new TextBlock[] { };
        FifthMAAppmyTextBlockArray = new TextBlock[] { };
        SixthMAAppmyTextBlockArray = new TextBlock[] { };
        LastMAAppmyTextBlockArray = new TextBlock[] { };
        FirstMAAppmyTBArray = new TextBox[] { };
        SecondMAAppmyTBArray = new TextBox[] { };
        ThirdMAAppmyTBArray = new TextBox[] { };
        FourthMAAppmyTBArray = new TextBox[] { };
        FifthMAAppmyTBArray = new TextBox[] { };
        SixthMAAppmyTBArray = new TextBox[] { };
        LastMAAppmyTBArray = new TextBox[] { };
        FirstMAAppmyCBArray = new ComboBox[] { };
        SecondMAAppmyCBArray = new ComboBox[] { };
        ThirdMAAppmyCBArray = new ComboBox[] { };
        FourthMAAppmyCBArray = new ComboBox[] { };
        FifthMAAppmyCBArray = new ComboBox[] { };
        FirstMAAppmyButtonArray = new Button[] { };
        SecondMAAppmyButtonArray = new Button[] { };
        ThirdMAAppmyButtonArray = new Button[] { };
        FourthMAAppmyButtonArray = new Button[] { };
        FifthMAAppmyButtonArray = new Button[] { };
        SixthMAAppmyButtonArray = new Button[] { };
        LastMAAppmyButtonArray = new Button[] { };
        MAHasUIRendered = false;
    }

    private void ResetManagementAppUITB()
    {
        ManagementAppUIChooser = 0;
        ManagementAppLowerRightLPSP.Children.Clear();
        ThirdMAAppmyRBArray = new RadioButton[] { };
        FourthMAAppmyRBArray = new RadioButton[] { };
        SixthMAAppmyRBArray = new RadioButton[] { };
        LastMAAppmyRBArray = new RadioButton[] { };
        FirstMAAppmyTextBlockArray = new TextBlock[] { };
        SecondMAAppmyTextBlockArray = new TextBlock[] { };
        ThirdMAAppmyTextBlockArray = new TextBlock[] { };
        FourthMAAppmyTextBlockArray = new TextBlock[] { };
        FifthMAAppmyTextBlockArray = new TextBlock[] { };
        SixthMAAppmyTextBlockArray = new TextBlock[] { };
        LastMAAppmyTextBlockArray = new TextBlock[] { };
        FirstMAAppmyTBArray = new TextBox[] { };
        SecondMAAppmyTBArray = new TextBox[] { };
        ThirdMAAppmyTBArray = new TextBox[] { };
        FourthMAAppmyTBArray = new TextBox[] { };
        FifthMAAppmyTBArray = new TextBox[] { };
        SixthMAAppmyTBArray = new TextBox[] { };
        LastMAAppmyTBArray = new TextBox[] { };
        FirstMAAppmyCBArray = new ComboBox[] { };
        SecondMAAppmyCBArray = new ComboBox[] { };
        ThirdMAAppmyCBArray = new ComboBox[] { };
        FourthMAAppmyCBArray = new ComboBox[] { };
        FifthMAAppmyCBArray = new ComboBox[] { };
        FirstMAAppmyButtonArray = new Button[] { };
        SecondMAAppmyButtonArray = new Button[] { };
        ThirdMAAppmyButtonArray = new Button[] { };
        FourthMAAppmyButtonArray = new Button[] { };
        FifthMAAppmyButtonArray = new Button[] { };
        SixthMAAppmyButtonArray = new Button[] { };
        LastMAAppmyButtonArray = new Button[] { };
        MAHasUIRendered = false;
    }

    

    private async void ManagementAppBTN_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ManagementAppUIChooser == 1)
        {
            int ComboBoxIndex = FirstMAAppmyCBArray[0].SelectedIndex;
            if (ComboBoxIndex == 0)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == false)
                {
                    Directory.CreateDirectory(ManagementAppTORRootFolder + "Zipped");
                }
                if (Directory.Exists(ManagementAppTORRootFolder + "Extracted") == false)
                {
                    Directory.CreateDirectory(ManagementAppTORRootFolder + "Extracted");
                }
                TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                String TORDownloadStatus = await TORMainOperations.DownloadTOR();
                FirstMAAppmyTBArray[0].Text= TORDownloadStatus;
            }
            else if (ComboBoxIndex == 1)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == false || Directory.Exists(ManagementAppTORRootFolder + "Extracted") == false)
                {
                    FirstMAAppmyTBArray[0].Text = "You have not downloaded the TOR software";
                }
                else
                {
                    TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                    String TORStartStatus = await TORMainOperations.StartTOR();
                    FirstMAAppmyTBArray[0].Text = TORStartStatus;
                }
            }
            else if (ComboBoxIndex == 2)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == false || Directory.Exists(ManagementAppTORRootFolder + "Extracted") == false)
                {
                    FirstMAAppmyTBArray[0].Text = "You have not downloaded the TOR software";
                }
                else
                {
                    TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                    String TORStopStatus = TORMainOperations.StopTOR();
                    FirstMAAppmyTBArray[0].Text = TORStopStatus;
                }
            }
        }
        else if (ManagementAppUIChooser == 2)
        {
            int ComboBoxIndex = SecondMAAppmyCBArray[0].SelectedIndex;
            if (ComboBoxIndex == 0)
            {
                String ServerIP = "";
                ServerIP = SecondMAAppmyTBArray[0].Text;
                if (String.IsNullOrEmpty(ServerIP) == true)
                {
                    SecondMAAppmyTBArray[1].Text = "Please enter a valid server IP address";
                }
                else
                {
                    File.WriteAllText(ManagementAppServerRootFolder + "IP.txt", ServerIP);
                    SecondMAAppmyTBArray[1].Text = "The server IP address has been recorded";
                }
            }
            else if (ComboBoxIndex == 1)
            {
                EstablishConnection.CreateLinkWithServer();
                SecondMAAppmyTBArray[1].Text = EstablishConnection.ConnectionStatus;
            }
        }
        else if (ManagementAppUIChooser == 3)
        {
            int ComboBoxIndex = ThirdMAAppmyCBArray[0].SelectedIndex;
            if (ComboBoxIndex == 0)
            {
                if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == false)
                {
                    String User_ID = CryptographicSecureIDGenerator.GenerateUniqueString();
                    if (User_ID.Length > 48)
                    {
                        User_ID = User_ID.Substring(0, 48);
                    }
                    File.WriteAllText(ManagementAppUserRootFolder + "User_ID.txt", User_ID);
                    ThirdMAAppmyTBArray[0].Text = User_ID;
                    if (ThirdMAAppmyRBArray[0].IsChecked == true)
                    {
                        RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                        ThirdMAAppmyTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        ThirdMAAppmyTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                    else
                    {
                        ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey, MyKeyPair.PublicKey, new Byte[] { });
                        ThirdMAAppmyTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        ThirdMAAppmyTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                }
                else
                {
                    ThirdMAAppmyTBArray[4].Text = "If you want to have multiple account that resides within this device," + Environment.NewLine +
                        "kindly copies the folder without all the data and paste it other location" + Environment.NewLine +
                        "within this device."+Environment.NewLine+
                        "This might have some security risks that you need to accept"+Environment.NewLine+
                        "because you're storing the essential and private information that used in other sites"+
                        Environment.NewLine+"authentication and the server side only stores the public information";
                }
            }
            else if (ComboBoxIndex == 1)
            {
                String UserID = ThirdMAAppmyTBArray[0].Text;
                String PublicKey = ThirdMAAppmyTBArray[1].Text;
                String SignedPublicKey = ThirdMAAppmyTBArray[2].Text;
                String Session_ID = ThirdMAAppmyTBArray[3].Text;
                if ((UserID!=null && UserID.CompareTo("") != 0) && (PublicKey!=null &&PublicKey.CompareTo("") != 0) && (SignedPublicKey!=null && SignedPublicKey.CompareTo("") != 0) && (Session_ID!=null && Session_ID.CompareTo("") != 0))
                {
                    if (TORMainOperations.UsingTor == true)
                    {
                        String ResultText = await TORProxySubmitInfo(UserID, Session_ID, SignedPublicKey, PublicKey);
                        ThirdMAAppmyTBArray[4].Text = ResultText;
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync("RegisterAccount?User_ID=" + UserID + "&Session_ID=" + Session_ID + "&URLEncoded_Master_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKey) + "&URLEncoded_Master_PK=" + System.Web.HttpUtility.UrlEncode(PublicKey));
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;
                                ThirdMAAppmyTBArray[4].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                ThirdMAAppmyTBArray[4].Text="There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    ThirdMAAppmyTBArray[4].Text="You didn't generate keys locally or fill in the required information";
                }
            }
        }
        else if (ManagementAppUIChooser == 4)
        {
            int ComboBoxIndex = FourthMAAppmyCBArray[0].SelectedIndex;
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (ComboBoxIndex == 0)
                {
                    FourthMAAppmyTBArray[0].Text = User_ID;
                    if (FourthMAAppmyRBArray[0].IsChecked == true)
                    {
                        RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                        FourthMAAppmyTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        FourthMAAppmyTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                    else
                    {
                        ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey, MyKeyPair.PublicKey, new Byte[] { });
                        FourthMAAppmyTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        FourthMAAppmyTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                }
                else if (ComboBoxIndex == 1)
                {
                    LoginModels myLoginModel = new LoginModels();
                    Byte[] Signed_Challenge = new Byte[] { };
                    Byte[] Challenge = new Byte[] { };
                    Byte[] UserSignedChallenge = new Byte[] { };
                    Byte[] Server_PublicKey = new Byte[] { };
                    Byte[] OldPrivateKey = File.ReadAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                    try
                    {
                        myLoginModel = await MasterChallengeRequestor.RequestMasterChallengeFromServer(User_ID);
                    }
                    catch
                    {
                        myLoginModel = await MasterChallengeRequestor.GetLostChallengeFromServer(User_ID);
                    }
                    Server_PublicKey = Convert.FromBase64String(myLoginModel.ServerECDSAPKBase64String);
                    Signed_Challenge = Convert.FromBase64String(myLoginModel.SignedRandomChallengeBase64String);
                    Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, Server_PublicKey);
                    if (OldPrivateKey.Length == 57)
                    {
                        UserSignedChallenge = SecureED448.GenerateSignatureMessage(OldPrivateKey, Challenge, new Byte[] { }, true);
                    }
                    else
                    {
                        UserSignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, OldPrivateKey, true);
                    }
                    if (TORMainOperations.UsingTor == true)
                    {
                        FourthMAAppmyTBArray[3].Text = await TORProxyChangeMasterKey(User_ID, UserSignedChallenge);
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(FourthMAAppmyTBArray[2].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(FourthMAAppmyTBArray[1].Text));
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;

                                FourthMAAppmyTBArray[3].Text = Result.Substring(1, Result.Length - 2);

                                File.Delete(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                                File.Delete(ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                                File.Move(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                                File.Move(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                            }
                            else
                            {
                                FourthMAAppmyTBArray[3].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
            }
            else 
            {
                FourthMAAppmyTBArray[3].Text = "You have not yet register an account";
            }            
        }
        else if (ManagementAppUIChooser == 5)
        {
            int ComboBoxIndex = FifthMAAppmyCBArray[0].SelectedIndex;
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (ComboBoxIndex == 0)
                {
                    FifthMAAppmyTBArray[0].Text = User_ID;
                    Byte[] MasterPublicKey = File.ReadAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                    Byte[] MasterPublicKeyDigest = SodiumGenericHash.ComputeHash(64, MasterPublicKey);
                    FifthMAAppmyTBArray[1].Text = Convert.ToBase64String(MasterPublicKeyDigest);
                }
                else if (ComboBoxIndex == 1)
                {
                    if (TORMainOperations.UsingTor == true)
                    {
                        FifthMAAppmyTBArray[2].Text = await TORProxyFetchDigest(User_ID);
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync("UserPublicKeyDigest?User_ID=" + User_ID);
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;
                                FifthMAAppmyTBArray[2].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                FifthMAAppmyTBArray[4].Text="There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else if (ComboBoxIndex == 2) 
                {
                    String SystemMasterPublicKeyDigest = FifthMAAppmyTBArray[1].Text;
                    String ServerMasterPublicKeyDigest = FifthMAAppmyTBArray[2].Text;
                    if (SystemMasterPublicKeyDigest.CompareTo("") != 0 && ServerMasterPublicKeyDigest.CompareTo("") != 0)
                    {
                        //Not really that important if it's constant time compare
                        //Ultimately these are publicly disclosable data
                        //The digest of public keys are as well
                        Boolean Comparison = SystemMasterPublicKeyDigest.CompareTo(ServerMasterPublicKeyDigest) == 0;
                        if (Comparison == true)
                        {
                            FifthMAAppmyTBArray[4].Text= "Both digest matched.. Yay..";
                        }
                        else
                        {
                            FifthMAAppmyTBArray[4].Text= "Please refer to the GUI for more information";
                        }
                    }
                    else
                    {
                        FifthMAAppmyTBArray[4].Text="If you don't fetch the digest from server and compute a digest locally, comparison operations couldn't be done";
                    }
                }
            }
            else 
            {
                FifthMAAppmyTBArray[4].Text = "You have not yet register an account";
            }
        }
        else if (ManagementAppUIChooser == 6)
        {
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (SixthMAAppmyTBArray[1].Text!=null && SixthMAAppmyTBArray[1].Text.CompareTo("") != 0)
                {
                    LoginModels myLoginModel = new LoginModels();
                    SixthMAAppmyTBArray[0].Text = User_ID;
                    String URL = "";
                    Byte[] Signed_Challenge = new Byte[] { };
                    Byte[] Challenge = new Byte[] { };
                    Byte[] UserSignedChallenge = new Byte[] { };
                    Byte[] Server_PublicKey = new Byte[] { };
                    Byte[] OldPrivateKey = File.ReadAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                    try
                    {
                        myLoginModel = await MasterChallengeRequestor.RequestMasterChallengeFromServer(User_ID);
                    }
                    catch
                    {
                        myLoginModel = await MasterChallengeRequestor.GetLostChallengeFromServer(User_ID);
                    }
                    Server_PublicKey = Convert.FromBase64String(myLoginModel.ServerECDSAPKBase64String);
                    Signed_Challenge = Convert.FromBase64String(myLoginModel.SignedRandomChallengeBase64String);
                    Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, Server_PublicKey);
                    if (OldPrivateKey.Length == 57)
                    {
                        UserSignedChallenge = SecureED448.GenerateSignatureMessage(OldPrivateKey, Challenge, new Byte[] { }, true);
                    }
                    else
                    {
                        UserSignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, OldPrivateKey, true);
                    }
                    if (SixthMAAppmyRBArray[0].IsChecked == true)
                    {
                        URL = "AddRemoveSubKeys?User_ID=" + User_ID + "&Key_Identifier=" + SixthMAAppmyTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge));
                    }
                    else
                    {
                        URL = "AddRemoveSubKeys/RemoveKeyIdentifier?User_ID=" + User_ID + "&Key_Identifier=" + SixthMAAppmyTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge));
                    }
                    if (TORMainOperations.UsingTor == true)
                    {
                        SixthMAAppmyTBArray[2].Text = await TORProxyAddRemoveSubKeyIdentifiers(URL);
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync(URL);
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;

                                SixthMAAppmyTBArray[2].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                SixthMAAppmyTBArray[2].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    SixthMAAppmyTBArray[2].Text = "Please enter a key identifier in the given text box";
                }
            }
            else 
            {
                SixthMAAppmyTBArray[2].Text = "You have not yet register an account";
            }
        }
        else if (ManagementAppUIChooser == 7)
        {
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (LastMAAppmyTBArray[1].Text!=null && LastMAAppmyTBArray[1].Text.CompareTo("") != 0 && LastMAAppmyTBArray[2].Text!=null && LastMAAppmyTBArray[2].Text.CompareTo("") != 0 && LastMAAppmyTBArray[3].Text!=null && LastMAAppmyTBArray[3].Text.CompareTo("") != 0)
                {
                    LoginModels myLoginModel = new LoginModels();
                    LastMAAppmyTBArray[0].Text = User_ID;
                    String URL = "";
                    Byte[] Signed_Challenge = new Byte[] { };
                    Byte[] Challenge = new Byte[] { };
                    Byte[] UserSignedChallenge = new Byte[] { };
                    Byte[] Server_PublicKey = new Byte[] { };
                    Byte[] OldPrivateKey = File.ReadAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                    try
                    {
                        myLoginModel = await MasterChallengeRequestor.RequestMasterChallengeFromServer(User_ID);
                    }
                    catch
                    {
                        myLoginModel = await MasterChallengeRequestor.GetLostChallengeFromServer(User_ID);
                    }
                    Server_PublicKey = Convert.FromBase64String(myLoginModel.ServerECDSAPKBase64String);
                    Signed_Challenge = Convert.FromBase64String(myLoginModel.SignedRandomChallengeBase64String);
                    Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, Server_PublicKey);
                    if (OldPrivateKey.Length == 57)
                    {
                        UserSignedChallenge = SecureED448.GenerateSignatureMessage(OldPrivateKey, Challenge, new Byte[] { }, true);
                    }
                    else
                    {
                        UserSignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, OldPrivateKey, true);
                    }
                    if (LastMAAppmyRBArray[0].IsChecked == true)
                    {
                        URL = "AddRemoveSubKeys/AddSubKey?User_ID=" + User_ID + "&Key_Identifier=" + LastMAAppmyTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(LastMAAppmyTBArray[3].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(LastMAAppmyTBArray[2].Text);
                    }
                    else
                    {
                        URL = "AddRemoveSubKeys/ChangeSubKey?User_ID=" + User_ID + "&Key_Identifier=" + LastMAAppmyTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(LastMAAppmyTBArray[3].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(LastMAAppmyTBArray[2].Text);
                    }
                    if (TORMainOperations.UsingTor == true)
                    {
                        LastMAAppmyTBArray[4].Text = await TORProxyAddChangeSubKey(URL);
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync(URL);
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;

                                LastMAAppmyTBArray[4].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                LastMAAppmyTBArray[4].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    LastMAAppmyTBArray[4].Text = "Please enter data in the given text boxes";
                }
            }
            else 
            {
                LastMAAppmyTBArray[4].Text = "You have not yet register an account";
            }
        }
    }

    private async Task<String> TORProxySubmitInfo(String UserID, String Session_ID, String SignedPublicKey, String PublicKey)
    {
        var handler = new HttpClientHandler
        {
            Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
        };

        using (handler)
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("RegisterAccount?User_ID=" + UserID + "&Session_ID=" + Session_ID + "&URLEncoded_Master_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKey) + "&URLEncoded_Master_PK=" + System.Web.HttpUtility.UrlEncode(PublicKey));
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();

                var Result = readTask.Result;
                return Result.Substring(1, Result.Length - 2);
            }
            else
            {
                return "There's something wrong on the server side..";
            }
        }
    }

    private async Task<String> TORProxyChangeMasterKey(String User_ID, Byte[] UserSignedChallenge)
    {
        var handler = new HttpClientHandler
        {
            Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
        };

        using (handler)
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(FourthMAAppmyTBArray[2].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(FourthMAAppmyTBArray[1].Text));
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();

                var Result = readTask.Result;

                File.Delete(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                File.Delete(ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                File.Move(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                File.Move(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                return Result.Substring(1, Result.Length - 2);
            }
            else
            {
                return "There's something wrong on the server side..";
            }
        }
    }

    private async Task<String> TORProxyFetchDigest(String User_ID)
    {
        var handler = new HttpClientHandler
        {
            Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
        };

        using (handler)
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("UserPublicKeyDigest?User_ID=" + User_ID);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();

                var Result = readTask.Result;
                return Result.Substring(1, Result.Length - 2);
            }
            else
            {
                return "There's something wrong on the server side..";
            }
        }
    }

    private async Task<String> TORProxyAddRemoveSubKeyIdentifiers(String URL)
    {
        var handler = new HttpClientHandler
        {
            Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
        };

        using (handler)
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();

                var Result = readTask.Result;

                return Result.Substring(1, Result.Length - 2);
            }
            else
            {
                return "There's something wrong on the server side..";
            }
        }
    }

    private async Task<String> TORProxyAddChangeSubKey(String URL)
    {
        var handler = new HttpClientHandler
        {
            Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
        };

        using (handler)
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();

                var Result = readTask.Result;

                return Result.Substring(1, Result.Length - 2);
            }
            else
            {
                return "There's something wrong on the server side..";
            }
        }
    }
}
