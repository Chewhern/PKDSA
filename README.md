# Problem statement
For details, [click here.](https://github.com/Chewhern/PKDSA/blob/main/Problem_Statement.md)

# Licenses
To avoid confusions, anything within [web consumptions](https://github.com/Chewhern/PKDSA/tree/main/Web%20consumption) will be considered as using MIT/ISC/Unlicensed open source licenses.

In [here](https://github.com/Chewhern/PKDSA/tree/main/XPlatformDesktop_ClientApp/AvaloniaUI/), the template zip file and its content was considered as MIT/ISC/Unlicensed open source licenses.

As long as it's anything other than the stated files/repository here, they are all considered as AGPL licensed.

There're certain requirements that one must follow [here](https://github.com/Chewhern/PKDSA/blob/main/License%20Requirements.md).

There're several exclusions that the author permits. For details, refer [here](https://github.com/Chewhern/PKDSA/blob/main/License%20exclusions.md).

In AGPL/GPL license, there's modification or derivate work concerns. For details on what's allowed and what's not allowed, refer [here](https://github.com/Chewhern/PKDSA/blob/main/Modified_Work.md).

# PKDSA
This repository will be storing the code required in allowing public key authentication.

This application uses **web of trust** instead of **trust model** in **PKI**.

**Trust model** can be seen in current HTTPS or CA certificate where businesses or individuals have to trust the providers or CAs to let the connections from client to web server to be secure.

**Web of trust** can be described with I know Alice from my school or she's my friend, so she belongs to the lists of people I trust, the same goes to Alice when dealing with Bob and both of them dealing with CAs as well.

**PKI at its simplest form, is 3 parties mutually verifying with each other to ensure there's no MITM, this is also consider as a web of trust. However with such assumption, PKI can't be fully implemented and our current digital world may be flawed.**

# Important notice
Since there're 3 applications here, there's client and server application. The server application was hosted on a **pure unmanaged Ubuntu VPS**.

**AvaloniaUI was used to create a better version (support multiple desktop OS) of deleted management and signing application which was previously coded and made only for Windows**

**All of the components here are from open source with exceptions of IDE such as Visual Studio.**

**The flow and logic on how it can be integrated on website has been demonstrated under web consumption.**

**When you're using TOR within this full stack application, try to ensure your CPU was freed, TOR won't crash or the application won't crash as long as your CPU
which shown in task manager(Windows) are not more than 25%.**

# IP Address(temporary)

**https://zeroaccesssecuritysolutions.com:5001/api/**

# ChangeLog
For detailed changelog, kindly refer to the following for the time being.

## Server Application (Unmanaged Ubuntu VPS)
[here](https://github.com/Chewhern/PKDSA/tree/main/Server_Application/Community/Ubuntu)

## Cross Platform Desktop Application 
[here](https://github.com/Chewhern/PKDSA/tree/main/XPlatformDesktop_ClientApp/AvaloniaUI)

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
2. Serve as a platform/framework for passwordless authentication.
3. Provide a privacy-centric identity framework that one can use without the reliance on identity with an assumption that out of band key pair was kept securely and privately. 
