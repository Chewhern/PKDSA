# Important
The UI will only look **nice** if it's any device that has the screen resolution of **1920*1080** or minimum screen resolution of **1440*900**.

The UI has only been tested on **Endeavour OS** an **arch linux** distro and **Windows**.

AvaloniaUI uses **Skia** an open source project which uses permissive license such as **OpenBSD** from **Google** and it generally can runs on these OS(s).

**Previously the application won't properly work on certain function due to I use the same array variable and shares/use that variable on 12 different UI.**

**Now it should have no issues.. And it should work properly but please do note I just address on the bugs.. I hope they're gone**

**AvaloniaUI by default uses dotnet 6.0 but for some reasons, the project that I created was using dotnet 7.0. If you want to change to dotnet 6.0 kindly changes them in the csproj of both PKDSA_ClientApp and PKDSA_ClientApp.Desktop as Microsoft's dotnet 7.0 have a shorter timespan compare to dotnet 6.0**

## Linux
1. Debian 9 (Stretch)+
2. Ubuntu 16.04+
3. Fedora 30+

## MacOS
1. macOS High Sierra 10.13+

## Android
1. Android 5.0+ (API 21)

# Version

## 0.0.1
- Combined Management Application and Signing Application into a application.
- Removed **UserLoginUsingSubKeys** as it's redundant and it has been shown in **Web Consumption** with **ASP.Net Core 6/7 Web API**.

### Requirements
1. Need to download both dotnet-runtime and dotnet-sdk from Microsoft [Preferably install 6 and 7](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu).
2. Install both dotnet items on your device.

Note: On Linux, one needs to get dotnet from packamange manager (may have many variations).

**Arch Linux**

Super user
```
sudo pacman -S dotnet-runtime-6.0
sudo pacman -S dotnet-sdk-6.0
```

Root user
```
pacman -S dotnet-runtime-7.0
pacman -S dotnet-runtime-7.0
```

### Instruction to compile (Both folders must exist)
1. First navigate to PKDSA_ClientApp then do **/dotnet build**
2. Then navigate to PKDSA_ClietnApp.Desktop then do **/dotnet build**
3. The compiled application will reside within **PKDSA_ClientApp.Desktop/bin/Debug**

### Running on Windows
1. Simply navigate to **PKDSA_ClientApp.Desktop/bin/Debug/Download_Link.txt**.
2. Download and unzip.
3. Double click on PKDSA_ClientApp.Desktop.exe

### Running and troubleshooting on Windows/Linux/MacOS
1. Same first and 2nd step.
2. Open command prompt(Windows) or Terminal/Console(Linux/MacOS) then navigate to the unzipped applications.
3. Do **dotnet PKDSA_ClientApp.Desktop.dll**
4. A GUI applications should come out.

## 0.0.2
1. Added support for provider's own **local support without reliance on out of band** such as email, phone number, Session Messenger User's ID. (Need to pair with Command Line Tool)
2. Users can request for support by either using out of band communication or local support without reliance on out of band via sign up's generated out of band digital signature keypair. (Need to pair with Out Of Band Application created by the author)
3. Removed the Session Messenger user ID's account binding.
4. Added support for AvaloniaUI template with author's self integration of PKDSA safe features. **Kindly check the template source code.**
5. Same like 0.0.1. 

### Template's License
The template named **PKDSA_CA_Template** will be using MIT/ISC as license.
