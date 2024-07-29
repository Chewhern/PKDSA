# Problem statement
For details, [click here.](https://github.com/Chewhern/PKDSA/blob/main/Problem_Statement.md)

# Licenses
To avoid confusions, anything within [web consumptions](https://github.com/Chewhern/PKDSA/tree/main/Web%20consumption) will be considered as using MIT/ISC/Unlicensed open source licenses.

In [here](https://github.com/Chewhern/PKDSA/tree/main/XPlatformDesktop_ClientApp/AvaloniaUI/), the template zip file and its content was considered as MIT/ISC/Unlicensed open source licenses.

As long as it's anything other than the stated files/repository here, they are all considered as AGPL licensed.

**I will find some time to update some minor codes in the server side and there will be a rework on license requirements & exclusions.**

# PKDSA
This repository will be storing the code required in allowing public key authentication.

This application uses **web of trust** instead of **trust model** in **PKI**.

**Trust model** can be seen in current HTTPS or CA certificate where businesses or individuals have to trust the providers or CAs to let the connections from client to web server to be secure.

**Web of trust** can be described with I know Alice from my school or she's my friend, so she belongs to the lists of people I trust, the same goes to Alice when dealing with Bob and both of them dealing with CAs as well.

**PKI at its simplest form, is 3 parties mutually verifying with each other to ensure there's no MITM, this is also consider as a web of trust. However with such assumption, PKI can't be fully implemented and our current digital world may be flawed.**

# Important notice
Since there're 3 applications here, there's client(2 applications type) and server application. The server application was hosted on a **pure unmanaged Ubuntu VPS**.

**Since AvaloniaUI works, Management Applications and Signing Applications have been combined into AvaloniaUI project. You can look at it via "XPlatformDesktopClientApp/AvaloniaUI"**

**Future applications will be all under XPlatform_*,since it needs to support other desktop OS(s). For mobile applications, I will think how to support on Android
and IOS. I wish can support other custom rom of mobile phone OS but it's a completely new area for me and that might need other contributors helps.**

**Management Application and Signing Application will now act as a draft before the existence XPlatform_*, those will still be used but a better version will be cross platform applications.**

**All of the components here are from open source with exceptions of IDE such as Visual Studio.**

**The flow and logic behind "5." in Management Application is now being demonstrated by using ASP.Net Core (6) Razor pages..**

**When you're using TOR within this full stack application, try to ensure your CPU was freed, TOR won't crash or the application won't crash as long as your CPU
which shown in task manager(Windows) are not more than 25%.**

# IP Address(temporary)

Currently the first version of the PKDSA is hosted under the IP address of
**https://chronops.xyz:5001/api/**

# ChangeLog
For detailed changelog, kindly refer to the following for the time being.

## Management Application (Windows Desktop)
[here](https://github.com/Chewhern/PKDSA/tree/main/Management_Applications/Community/Windows/PKDSA_UMWinClient)

## Server Application (Unmanaged Ubuntu VPS)
[here](https://github.com/Chewhern/PKDSA/tree/main/Server_Application/Community/Ubuntu)

## Signing Application (Windows Desktop)
There's no changelog here.

## Cross Platform Desktop Application 
[here](https://github.com/Chewhern/PKDSA/tree/main/XPlatformDesktop_ClientApp/AvaloniaUI)

The prerequisites to get a full and detailed picture to the features is to understand it first on Management Application and Server Application.

# Guides

I will be finding some time to talk solely on this project like how to install, run, customize to your own needs.

In the same time, I will also be informing you guys on what I know by either having comparison between passwords and digital signature
and what are the considerations,thoughts that people should have.

**Consent is only meaningful if it's well informed. - Edward Snowden**

For the time being, you may not understand anything that I have written.

## Basic Guide
[here](https://github.com/Chewhern/PKDSA/blob/main/Guides/Basic.txt)

#### Purposes
1. Allowing public to understand how public key authentication could be done on website or devices.
2. Allowing MySQL and PHPMyadmin developers to understand the logic behind public key authentication so that they could implement it into MySQL and PHPMyAdmin(Uncertain).
3. Serve as a platform/framework for passwordless authentication.
