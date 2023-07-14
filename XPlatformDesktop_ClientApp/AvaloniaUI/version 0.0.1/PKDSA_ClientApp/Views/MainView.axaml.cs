﻿using ASodium;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using BCASodium;
using Org.BouncyCastle.Asn1.Cmp;
using PKDSA_ClientApp.Helper;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
    private static RadioButton[] myRBArray = new RadioButton[] { };
    private static TextBlock[] myTextBlockArray = new TextBlock[] { };
    private static TextBox[] myTBArray = new TextBox[] { };
    private static ComboBox[] myCBArray = new ComboBox[] { };
    private static Button[] myButtonArray = new Button[] { };
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
                myTextBlockArray = new TextBlock[3];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[0].Text = "Choose a Digital Signature Algorithm";
                myTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                myTextBlockArray[2].Text = "Digital Signature Key Pair Generation Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[2];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[1].IsReadOnly = true;
                myTBArray[0].AcceptsReturn = true;
                myTBArray[1].AcceptsReturn = true;
                myTBArray[0].Height = 50;
                myTBArray[1].Height = 50;
                myTBArray[0].TextWrapping = TextWrapping.Wrap;
                myTBArray[1].TextWrapping = TextWrapping.Wrap;
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "CurveTypes";
                myRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "CurveTypes";
                myRBArray[1].Content = "Curve448 - ED448 (Stable)";
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Generate Key Pair";
                myButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(myRBArray[0]);
                SigningAppLowerRightSP.Children.Add(myRBArray[1]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(myTBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(myTBArray[1]);
                SigningAppLowerRightSP.Children.Add(myButtonArray[0]);
                HasUIRendered = true;
            }            
        }
        else if (SigningAppUIChooser == 2)
        {
            if (HasUIRendered == false) 
            {
                myTextBlockArray = new TextBlock[5];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[0].Text = "Select a sub key identifier";
                myTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                myTextBlockArray[2].Text = "Corresponding Public Key (Base64) (Read Only)";
                myTextBlockArray[3].Text = "Corresponding Signed Public Key (Base64) (Read Only)";
                myTextBlockArray[4].Text = "View sub key identifier error (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                myCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                myTBArray = new TextBox[4];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[1].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[3].IsReadOnly = true;
                myTBArray[0].AcceptsReturn = true;
                myTBArray[1].AcceptsReturn = true;
                myTBArray[2].AcceptsReturn = true;
                myTBArray[0].Height = 75;
                myTBArray[1].Height = 75;
                myTBArray[2].Height = 75;
                myTBArray[0].Width = 370;
                myTBArray[1].Width = 370;
                myTBArray[2].Width = 370;
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "View Public Keys";
                myButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(myCBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(myTBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(myTBArray[1]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[3]);
                SigningAppLowerRightSP.Children.Add(myTBArray[2]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[4]);
                SigningAppLowerRightSP.Children.Add(myTBArray[3]);
                SigningAppLowerRightSP.Children.Add(myButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 3)
        {
            if (HasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[3];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[0].Text = "Select a sub key identifier";
                myTextBlockArray[1].Text = "Choose a digital signature algorithm";
                myTextBlockArray[2].Text = "Change Digital Signature Key Pair Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                myCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "CurveTypes";
                myRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "CurveTypes";
                myRBArray[1].Content = "Curve448 - ED448 (Stable)";
                myTBArray = new TextBox[1];
                myTBArray[0] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Change Digital Signature Key Pair";
                myButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(myCBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(myRBArray[0]);
                SigningAppLowerRightSP.Children.Add(myRBArray[1]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(myTBArray[0]);
                SigningAppLowerRightSP.Children.Add(myButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 4)
        {
            if (HasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[2];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[0].Text = "Select a sub key identifier";
                myTextBlockArray[1].Text = "Delete Digital Signature Key Pair Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                myCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                myTBArray = new TextBox[1];
                myTBArray[0] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Delete Digital Signature Key Pair";
                myButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(myCBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(myTBArray[0]);
                SigningAppLowerRightSP.Children.Add(myButtonArray[0]);
                HasUIRendered = true;
            }
        }
        else if (SigningAppUIChooser == 5)
        {
            if (HasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[6];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[5] = new TextBlock();
                myTextBlockArray[0].Text = "Select a sub key identifier";
                myTextBlockArray[1].Text = "Sub Key Identifier (Read Only)";
                myTextBlockArray[2].Text = "Challenge (Base64) From Provider";
                myTextBlockArray[3].Text = "Local Signed Challenge (Base64) (Read Only)";
                myTextBlockArray[4].Text = "Digital Signature Key Pair Curve Type (Read Only)";
                myTextBlockArray[5].Text = "Sign Challenge Error Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                LoadSigningAppSubKeyIdentifiers();
                myCBArray[0].SelectionChanged += SigningAppComboBoxSelectedItemsChanged;
                myTBArray = new TextBox[5];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[4] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[3].IsReadOnly = true;
                myTBArray[4].IsReadOnly = true;
                myTBArray[0].AcceptsReturn = true;
                myTBArray[1].AcceptsReturn = true;
                myTBArray[2].AcceptsReturn = true;
                myTBArray[0].Height = 75;
                myTBArray[1].Height = 75;
                myTBArray[2].Height = 75; 
                myTBArray[0].Width = 370;
                myTBArray[1].Width = 370;
                myTBArray[2].Width = 370;
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Sign Challenge";
                myButtonArray[0].Click += SigningAppBTN_Click;
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[0]);
                SigningAppLowerRightSP.Children.Add(myCBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[1]);
                SigningAppLowerRightSP.Children.Add(myTBArray[0]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[2]);
                SigningAppLowerRightSP.Children.Add(myTBArray[1]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[3]);
                SigningAppLowerRightSP.Children.Add(myTBArray[2]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[4]);
                SigningAppLowerRightSP.Children.Add(myTBArray[3]);
                SigningAppLowerRightSP.Children.Add(myTextBlockArray[5]);
                SigningAppLowerRightSP.Children.Add(myTBArray[4]);
                SigningAppLowerRightSP.Children.Add(myButtonArray[0]);
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
        if (myCBArray[0].SelectedIndex != -1) 
        {
            if (SigningAppUIChooser == 2 || SigningAppUIChooser == 5)
            {
                myTBArray[0].Text = myCBArray[0].SelectedItem.ToString();
            }
        }
    }

    private void LoadSigningAppSubKeyIdentifiers()
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
        myCBArray[0].Items.Clear();
        Loop = 0;
        while (Loop < Sub_Key_Identifiers_FullPath.Length)
        {
            myCBArray[0].Items.Add(Sub_Key_Identifiers[Loop]);
            Loop += 1;
        }
        if (SigningAppUIChooser == 2 || SigningAppUIChooser == 5) 
        {
            if (myTBArray.Length != 0) 
            {
                myTBArray[0].Text = "";
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
        myRBArray = new RadioButton[] { };
        myTextBlockArray = new TextBlock[] { };
        myTBArray = new TextBox[] { };
        myCBArray = new ComboBox[] { };
        myButtonArray = new Button[] { };
        HasUIRendered = false;
    }

    private void ResetSigningAppUITB() 
    {
        SigningAppUIChooser = 0;
        SigningAppLowerRightSP.Children.Clear();
        myRBArray = new RadioButton[] { };
        myTextBlockArray = new TextBlock[] { };
        myTBArray = new TextBox[] { };
        myCBArray = new ComboBox[] { };
        myButtonArray = new Button[] { };
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
            if (myRBArray[0].IsChecked == true)
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
            myTBArray[0].Text = Sub_Key_Identifier;
            myTBArray[1].Text = "The signature keypairs have been created";
            MyED448KeyPair.Clear();
            MyED25519KeyPair.Clear();
        }
        else if (SigningAppUIChooser == 2)
        {
            Byte[] PublicKey = new Byte[] { };
            Byte[] SignedPublicKey = new Byte[] { };
            String Sub_Key_Identifier = myCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                myTBArray[3].Text = "There's no keypairs created or you have not choose any keypairs";
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
                    myTBArray[1].Text = Convert.ToBase64String(PublicKey);
                    myTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                }
                else
                {
                    myTBArray[3].Text = "The specified sub key identifier can't be found";
                }
            }
        }
        else if (SigningAppUIChooser == 3)
        {
            if (myCBArray[0].SelectedIndex != -1)
            {
                String Sub_Key_Identifier = myCBArray[0].SelectedItem.ToString();
                RevampedKeyPair MyED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                ED448RevampedKeyPair MyED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                Byte[] SignedPublicKey = new Byte[] { };
                if (myRBArray[0].IsChecked == true)
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
                myTBArray[0].Text = "The signature keypair in specified sub key identifier has been changed";
                MyED448KeyPair.Clear();
                MyED25519KeyPair.Clear();
            }
        }
        else if (SigningAppUIChooser == 4)
        {
            String Sub_Key_Identifier = myCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                myTBArray[0].Text = "There's no keypairs created or you have not choose any keypairs";
            }
            else
            {
                if (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
                {
                    Directory.Delete(SigningAppRootFolder + Sub_Key_Identifier, true);
                    myTBArray[0].Text = "The specified sub key identifier has been deleted";
                }
                else
                {
                    myTBArray[0].Text = "The specified sub key identifier can't be found";
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
            String ChallengeString = myTBArray[1].Text;
            String Sub_Key_Identifier = myCBArray[0].SelectedItem.ToString();
            if (String.IsNullOrEmpty(Sub_Key_Identifier))
            {
                myTBArray[4].Text = "There's no keypairs created or you have not choose any keypairs";
            }
            else
            {
                if (Directory.Exists(SigningAppRootFolder + Sub_Key_Identifier) == true)
                {
                    if (String.IsNullOrEmpty(ChallengeString) == true)
                    {
                        myTBArray[4].Text = "Please get the base 64 encoded challenge from provider";
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
                                myTBArray[2].Text = Convert.ToBase64String(SignedChallenge);
                                myTBArray[3].Text = CurveDeterminer;
                            }
                            else if (CurveDeterminer.CompareTo("IsCurve448") == 0)
                            {
                                SignedChallenge = SecureED448.GenerateSignatureMessage(PrivateKey, Challenge, new Byte[] { });
                                myTBArray[2].Text = Convert.ToBase64String(SignedChallenge);
                                myTBArray[3].Text = CurveDeterminer;
                            }
                            else
                            {
                                myTBArray[4].Text = "Something's wrong with the Curve Type File";
                            }
                            SodiumSecureMemory.SecureClearBytes(PrivateKey);
                        }
                        else
                        {
                            myTBArray[4].Text = "This is not a valid Base 64 encoded string/challenge";
                        }
                    }
                }
                else
                {
                    myTBArray[4].Text = "The specified sub key identifier can't be found";
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
        myRBArray = new RadioButton[] { };
        myTextBlockArray = new TextBlock[] { };
        myTBArray = new TextBox[] { };
        myCBArray = new ComboBox[] { };
        myButtonArray = new Button[] { };
        MAHasUIRendered = false;
    }

    private void ResetManagementAppUITB()
    {
        ManagementAppUIChooser = 0;
        ManagementAppLowerRightLPSP.Children.Clear();
        myRBArray = new RadioButton[] { };
        myTextBlockArray = new TextBlock[] { };
        myTBArray = new TextBox[] { };
        myCBArray = new ComboBox[] { };
        myButtonArray = new Button[] { };
        MAHasUIRendered = false;
    }

    private void ManagementAppDrawUI()
    {
        if (ManagementAppUIChooser == 1)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[2];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[0].Text = "Choose an action";
                myTextBlockArray[1].Text = "TOR Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                myCBArray[0].Items.Add("1. Download TOR");
                myCBArray[0].Items.Add("1/2. Start TOR");
                myCBArray[0].Items.Add("2/3. Stop TOR");
                myTBArray = new TextBox[1];
                myTBArray[0] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[0].Height = 75;
                myTBArray[0].Width = 370;
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "TOR operation action";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 2)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[3];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[0].Text = "The server IP address of PKDSA provider";
                myTextBlockArray[1].Text = "Choose an action";
                myTextBlockArray[2].Text = "Server IP address status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[2];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[1].IsReadOnly = true;
                myTBArray[0].AcceptsReturn = true;
                myTBArray[1].AcceptsReturn = true;
                myTBArray[0].Height = 75;
                myTBArray[1].Height = 75;
                myTBArray[0].Height = 100;
                myTBArray[1].Height = 100;
                myTBArray[0].TextWrapping = TextWrapping.Wrap;
                myTBArray[1].TextWrapping = TextWrapping.Wrap;
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                myCBArray[0].Items.Add("1. Add provider IP");
                myCBArray[0].Items.Add("1/2. Establish a connection with provider IP");
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Set or establish server connection";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 3)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[7];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[5] = new TextBlock();
                myTextBlockArray[6] = new TextBlock();
                myTextBlockArray[0].Text = "Randomly generated user ID (Read only)";
                myTextBlockArray[1].Text = "Randomly generated public key (Read Only)";
                myTextBlockArray[2].Text = "Randomly generated signed public key (Read Only)";
                myTextBlockArray[3].Text = "Session messenger user ID (Hexa)";
                myTextBlockArray[4].Text = "Choose a digital signature algorithm";
                myTextBlockArray[5].Text = "Choose an action";
                myTextBlockArray[6].Text = "Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[6].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[5];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[4] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[1].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[4].IsReadOnly = true;
                myTBArray[0].Height = 50;
                myTBArray[0].Width = 370;
                myTBArray[1].Height = 50;
                myTBArray[1].Width = 370;
                myTBArray[2].Height = 50;
                myTBArray[2].Width = 370;
                myTBArray[3].Height = 50;
                myTBArray[3].Width = 370;
                myTBArray[4].Height = 100;
                myTBArray[4].Width = 370;
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                myCBArray[0].Items.Add("1. Generate Keys Locally");
                myCBArray[0].Items.Add("2. Register an account");
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "CurveTypes";
                myRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "CurveTypes";
                myRBArray[1].Content = "Curve448 - ED448 (Stable)";
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Generate or submit information";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(myCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[6]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 4)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[6];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[5] = new TextBlock();
                myTextBlockArray[0].Text = "Randomly generated user ID (Read only)";
                myTextBlockArray[1].Text = "Randomly generated public key (Read Only)";
                myTextBlockArray[2].Text = "Randomly generated signed public key (Read Only)";
                myTextBlockArray[3].Text = "Choose a digital signature algorithm";
                myTextBlockArray[4].Text = "Choose an action";
                myTextBlockArray[5].Text = "Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[4];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[1].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[3].IsReadOnly = true;
                myTBArray[0].Height = 50;
                myTBArray[0].Width = 370;
                myTBArray[1].Height = 50;
                myTBArray[1].Width = 370;
                myTBArray[2].Height = 50;
                myTBArray[2].Width = 370;
                myTBArray[3].Height = 50;
                myTBArray[3].Width = 370;
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                myCBArray[0].Items.Add("1. Generate Keys Locally");
                myCBArray[0].Items.Add("2. Change master key");
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "CurveTypes";
                myRBArray[0].Content = "Curve25519 - ED25519 (Stable)";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "CurveTypes";
                myRBArray[1].Content = "Curve448 - ED448 (Stable)";
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Generate or change information";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;                
            }
        }
        else if (ManagementAppUIChooser == 5)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[6];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[5] = new TextBlock();
                myTextBlockArray[0].Text = "User ID (Read only)";
                myTextBlockArray[1].Text = "Device public key digest (Read Only)";
                myTextBlockArray[2].Text = "Server public key digest (Read Only)";
                myTextBlockArray[3].Text = "Session messenger contact (Read Only)";
                myTextBlockArray[4].Text = "Choose an action";
                myTextBlockArray[5].Text = "Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[5];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[4] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[1].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[3].IsReadOnly = true;
                myTBArray[4].IsReadOnly = true;
                myTBArray[0].Height = 50;
                myTBArray[0].Width = 370;
                myTBArray[1].Height = 50;
                myTBArray[1].Width = 370;
                myTBArray[2].Height = 50;
                myTBArray[2].Width = 370;
                myTBArray[3].Height = 50;
                myTBArray[3].Width = 370;
                myTBArray[4].Height = 50;
                myTBArray[4].Width = 370;
                myTBArray[3].Text = "05573054e242144d0df881e763d4806d9eee207a81900d790d49401b5bd2f44c36";
                myCBArray = new ComboBox[1];
                myCBArray[0] = new ComboBox();
                myCBArray[0].Items.Add("1/2. Compute pub key digest");
                myCBArray[0].Items.Add("1/2. Fetch pub key digest");
                myCBArray[0].Items.Add("3. Compare digests");
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Fetch and compare digest";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myCBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 6)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[4];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[0].Text = "User ID (Read only)";
                myTextBlockArray[1].Text = "SApp key identifier";
                myTextBlockArray[2].Text = "Choose an action";
                myTextBlockArray[3].Text = "Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[3];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[2].IsReadOnly = true;
                myTBArray[0].Height = 50;
                myTBArray[0].Width = 370;
                myTBArray[1].Height = 50;
                myTBArray[1].Width = 370;
                myTBArray[2].Height = 50;
                myTBArray[2].Width = 370;
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "KeyIdentifierAction";
                myRBArray[0].Content = "Add sub key identifier";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "KeyIdentifierAction";
                myRBArray[1].Content = "Remove sub key identifier";
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Add/remove key identifier";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else if (ManagementAppUIChooser == 7)
        {
            if (MAHasUIRendered == false)
            {
                myTextBlockArray = new TextBlock[6];
                myTextBlockArray[0] = new TextBlock();
                myTextBlockArray[1] = new TextBlock();
                myTextBlockArray[2] = new TextBlock();
                myTextBlockArray[3] = new TextBlock();
                myTextBlockArray[4] = new TextBlock();
                myTextBlockArray[5] = new TextBlock();
                myTextBlockArray[0].Text = "User ID (Read only)";
                myTextBlockArray[1].Text = "SApp key identifier";
                myTextBlockArray[2].Text = "SApp public key";
                myTextBlockArray[3].Text = "SApp signed public key";
                myTextBlockArray[4].Text = "Choose an action";
                myTextBlockArray[5].Text = "Status (Read Only)";
                myTextBlockArray[1].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[2].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[3].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[4].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTextBlockArray[5].Margin = Avalonia.Thickness.Parse("0, 10, 0, 0");
                myTBArray = new TextBox[5];
                myTBArray[0] = new TextBox();
                myTBArray[1] = new TextBox();
                myTBArray[2] = new TextBox();
                myTBArray[3] = new TextBox();
                myTBArray[4] = new TextBox();
                myTBArray[0].IsReadOnly = true;
                myTBArray[4].IsReadOnly = true;
                myTBArray[0].Height = 50;
                myTBArray[0].Width = 370;
                myTBArray[1].Height = 50;
                myTBArray[1].Width = 370;
                myTBArray[2].Height = 50;
                myTBArray[2].Width = 370;
                myTBArray[3].Height = 50;
                myTBArray[3].Width = 370;
                myTBArray[4].Height = 50;
                myTBArray[4].Width = 370;
                myRBArray = new RadioButton[2];
                myRBArray[0] = new RadioButton();
                myRBArray[1] = new RadioButton();
                myRBArray[0].GroupName = "KeyIdentifierAction";
                myRBArray[0].Content = "Add sub key";
                myRBArray[0].IsChecked = true;
                myRBArray[1].GroupName = "KeyIdentifierAction";
                myRBArray[1].Content = "Change sub key";
                myButtonArray = new Button[1];
                myButtonArray[0] = new Button();
                myButtonArray[0].Margin = Avalonia.Thickness.Parse("0,10,0,0");
                myButtonArray[0].Content = "Add or change sub key";
                myButtonArray[0].Click += ManagementAppBTN_Click;
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[2]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[3]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[0]);
                ManagementAppLowerRightLPSP.Children.Add(myRBArray[1]);
                ManagementAppLowerRightLPSP.Children.Add(myTextBlockArray[5]);
                ManagementAppLowerRightLPSP.Children.Add(myTBArray[4]);
                ManagementAppLowerRightLPSP.Children.Add(myButtonArray[0]);
                MAHasUIRendered = true;
            }
        }
        else
        {
            ResetManagementAppUI();
        }
    }

    private async void ManagementAppBTN_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ManagementAppUIChooser == 1)
        {
            int ComboBoxIndex = myCBArray[0].SelectedIndex;
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
                myTBArray[0].Text= TORDownloadStatus;
            }
            else if (ComboBoxIndex == 1)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == false || Directory.Exists(ManagementAppTORRootFolder + "Extracted") == false)
                {
                    myTBArray[0].Text = "You have not downloaded the TOR software";
                }
                else
                {
                    TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                    String TORStartStatus = await TORMainOperations.StartTOR();
                    myTBArray[0].Text = TORStartStatus;
                }
            }
            else if (ComboBoxIndex == 2)
            {
                if (Directory.Exists(ManagementAppTORRootFolder + "Zipped") == false || Directory.Exists(ManagementAppTORRootFolder + "Extracted") == false)
                {
                    myTBArray[0].Text = "You have not downloaded the TOR software";
                }
                else
                {
                    TORMainOperations.SetToolsDirectory(ManagementAppTORRootFolder + "Zipped", ManagementAppTORRootFolder + "Extracted");
                    String TORStopStatus = TORMainOperations.StopTOR();
                    myTBArray[0].Text = TORStopStatus;
                }
            }
        }
        else if (ManagementAppUIChooser == 2)
        {
            int ComboBoxIndex = myCBArray[0].SelectedIndex;
            if (ComboBoxIndex == 0)
            {
                String ServerIP = "";
                ServerIP = myTBArray[0].Text;
                if (String.IsNullOrEmpty(ServerIP) == true)
                {
                    myTBArray[1].Text = "Please enter a valid server IP address";
                }
                else
                {
                    File.WriteAllText(ManagementAppServerRootFolder + "IP.txt", ServerIP);
                    myTBArray[1].Text = "The server IP address has been recorded";
                }
            }
            else if (ComboBoxIndex == 1)
            {
                EstablishConnection.CreateLinkWithServer();
                myTBArray[1].Text = EstablishConnection.ConnectionStatus;
            }
        }
        else if (ManagementAppUIChooser == 3)
        {
            int ComboBoxIndex = myCBArray[0].SelectedIndex;
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
                    myTBArray[0].Text = User_ID;
                    if (myRBArray[0].IsChecked == true)
                    {
                        RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                        myTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        myTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                    else
                    {
                        ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "PrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey, MyKeyPair.PublicKey, new Byte[] { });
                        myTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        myTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                }
                else
                {
                    myTBArray[4].Text = "If you want to have multiple account that resides within this device," + Environment.NewLine +
                        "kindly copies the folder without all the data and paste it other location" + Environment.NewLine +
                        "within this device."+Environment.NewLine+
                        "This might have some security risks that you need to accept"+Environment.NewLine+
                        "because you're storing the essential and private information that used in other sites"+
                        Environment.NewLine+"authentication and the server side only stores the public information";
                }
            }
            else if (ComboBoxIndex == 1)
            {
                String UserID = myTBArray[0].Text;
                String PublicKey = myTBArray[1].Text;
                String SignedPublicKey = myTBArray[2].Text;
                String Session_ID = myTBArray[3].Text;
                if ((UserID!=null && UserID.CompareTo("") != 0) && (PublicKey!=null &&PublicKey.CompareTo("") != 0) && (SignedPublicKey!=null && SignedPublicKey.CompareTo("") != 0) && (Session_ID!=null && Session_ID.CompareTo("") != 0))
                {
                    if (TORMainOperations.UsingTor == true)
                    {
                        String ResultText = await TORProxySubmitInfo(UserID, Session_ID, SignedPublicKey, PublicKey);
                        myTBArray[4].Text = ResultText;
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
                                myTBArray[4].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                myTBArray[4].Text="There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    myTBArray[4].Text="You didn't generate keys locally or fill in the required information";
                }
            }
        }
        else if (ManagementAppUIChooser == 4)
        {
            int ComboBoxIndex = myCBArray[0].SelectedIndex;
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (ComboBoxIndex == 0)
                {
                    myTBArray[0].Text = User_ID;
                    if (myRBArray[0].IsChecked == true)
                    {
                        RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                        myTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        myTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
                        MyKeyPair.Clear();
                    }
                    else
                    {
                        ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", MyKeyPair.PublicKey);
                        File.WriteAllBytes(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", MyKeyPair.PrivateKey);
                        Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey, MyKeyPair.PublicKey, new Byte[] { });
                        myTBArray[1].Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                        myTBArray[2].Text = Convert.ToBase64String(SignedPublicKey);
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
                        myTBArray[3].Text = await TORProxyChangeMasterKey(User_ID, UserSignedChallenge);
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            var response = client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[2].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[1].Text));
                            response.Wait();
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;

                                myTBArray[3].Text = Result.Substring(1, Result.Length - 2);

                                File.Delete(ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                                File.Delete(ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                                File.Move(ManagementAppMasterKeyRootFolder + "NewPublicKey.txt", ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                                File.Move(ManagementAppMasterKeyRootFolder + "NewPrivateKey.txt", ManagementAppMasterKeyRootFolder + "PrivateKey.txt");
                            }
                            else
                            {
                                myTBArray[3].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
            }
            else 
            {
                myTBArray[3].Text = "You have not yet register an account";
            }            
        }
        else if (ManagementAppUIChooser == 5)
        {
            int ComboBoxIndex = myCBArray[0].SelectedIndex;
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (ComboBoxIndex == 0)
                {
                    myTBArray[0].Text = User_ID;
                    Byte[] MasterPublicKey = File.ReadAllBytes(ManagementAppMasterKeyRootFolder + "PublicKey.txt");
                    Byte[] MasterPublicKeyDigest = SodiumGenericHash.ComputeHash(64, MasterPublicKey);
                    myTBArray[1].Text = Convert.ToBase64String(MasterPublicKeyDigest);
                }
                else if (ComboBoxIndex == 1)
                {
                    if (TORMainOperations.UsingTor == true)
                    {
                        myTBArray[2].Text = await TORProxyFetchDigest(User_ID);
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
                                myTBArray[2].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                myTBArray[4].Text="There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else if (ComboBoxIndex == 2) 
                {
                    String SystemMasterPublicKeyDigest = myTBArray[1].Text;
                    String ServerMasterPublicKeyDigest = myTBArray[2].Text;
                    if (SystemMasterPublicKeyDigest.CompareTo("") != 0 && ServerMasterPublicKeyDigest.CompareTo("") != 0)
                    {
                        //Not really that important if it's constant time compare
                        //Ultimately these are publicly disclosable data
                        //The digest of public keys are as well
                        Boolean Comparison = SystemMasterPublicKeyDigest.CompareTo(ServerMasterPublicKeyDigest) == 0;
                        if (Comparison == true)
                        {
                            myTBArray[4].Text= "Both digest matched.. Yay..";
                        }
                        else
                        {
                            myTBArray[4].Text= "Please refer to the GUI for more information";
                        }
                    }
                    else
                    {
                        myTBArray[4].Text="If you don't fetch the digest from server and compute a digest locally, comparison operations couldn't be done";
                    }
                }
            }
            else 
            {
                myTBArray[4].Text = "You have not yet register an account";
            }
        }
        else if (ManagementAppUIChooser == 6)
        {
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (myTBArray[1].Text!=null && myTBArray[1].Text.CompareTo("") != 0)
                {
                    LoginModels myLoginModel = new LoginModels();
                    myTBArray[0].Text = User_ID;
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
                    if (myRBArray[0].IsChecked == true)
                    {
                        URL = "AddRemoveSubKeys?User_ID=" + User_ID + "&Key_Identifier=" + myTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge));
                    }
                    else
                    {
                        URL = "AddRemoveSubKeys/RemoveKeyIdentifier?User_ID=" + User_ID + "&Key_Identifier=" + myTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge));
                    }
                    if (TORMainOperations.UsingTor == true)
                    {
                        myTBArray[2].Text = await TORProxyAddRemoveSubKeyIdentifiers(URL);
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

                                myTBArray[2].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                myTBArray[2].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    myTBArray[2].Text = "Please enter a key identifier in the given text box";
                }
            }
            else 
            {
                myTBArray[2].Text = "You have not yet register an account";
            }
        }
        else if (ManagementAppUIChooser == 7)
        {
            if (File.Exists(ManagementAppUserRootFolder + "User_ID.txt") == true)
            {
                String User_ID = File.ReadAllText(ManagementAppUserRootFolder + "User_ID.txt");
                if (myTBArray[1].Text!=null && myTBArray[1].Text.CompareTo("") != 0 && myTBArray[2].Text!=null && myTBArray[2].Text.CompareTo("") != 0 && myTBArray[3].Text!=null && myTBArray[3].Text.CompareTo("") != 0)
                {
                    LoginModels myLoginModel = new LoginModels();
                    myTBArray[0].Text = User_ID;
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
                    if (myRBArray[0].IsChecked == true)
                    {
                        URL = "AddRemoveSubKeys/AddSubKey?User_ID=" + User_ID + "&Key_Identifier=" + myTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[3].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[2].Text);
                    }
                    else
                    {
                        URL = "AddRemoveSubKeys/ChangeSubKey?User_ID=" + User_ID + "&Key_Identifier=" + myTBArray[1].Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[3].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[2].Text);
                    }
                    if (TORMainOperations.UsingTor == true)
                    {
                        myTBArray[4].Text = await TORProxyAddChangeSubKey(URL);
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

                                myTBArray[4].Text = Result.Substring(1, Result.Length - 2);
                            }
                            else
                            {
                                myTBArray[4].Text = "There's something wrong on the server side..";
                            }
                        }
                    }
                }
                else
                {
                    myTBArray[4].Text = "Please enter data in the given text boxes";
                }
            }
            else 
            {
                myTBArray[4].Text = "You have not yet register an account";
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
            var response = await client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[2].Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(myTBArray[1].Text));
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