# Server Application

Any other non stated stuffs, if you want to be sure, kindly asks via the issue as I will be more active there instead of my email or Session messenger. 

**There're numerous ways to provide database credentials or certificate from(CA) to the application, what I am showing here is just the way that I do things
which is more or less consider to be dynamic in my eyes.**

**Files that store credentials (default)/hardcoding/using other servers to provide the credentials, all have their security and programming pros and cons, if you use any
of these, again it won't trigger AGPL. Since I believe it is something that can't be partially solve(address) or solve.**

## Server Status (Controller)
If you guys think that it's redundant to have this controller or this API endpoint, you can remove it from your end. Such a modification won't trigger AGPL V3.

The reason I put there was to have a blank API endpoint to check if the server was online or not really from API endpoint consumption.

## Register Account (Controller)

### Identity binding
If you guys don't want to use Session messenger user ID as a way to communicate with the supposedly rightful owner of the public keys, you can use something like
Discord's user ID, emails and phone numbers. In the case you stay default, which is Session messenger user ID, you can wait for me to come up with some tools to
verify the owner behind the ID.

If you modify it to use emails/phone numbers then you might need to come up with some ways to verify with the supposedly rightful owner of the public keys. However,
in either of one of these mechanisms, the change of the registered master key of the client needs to be done either manually or in a semi-automatic way.

Changing it to use Discord's user ID, emails, phone numbers or some other applicable channels such as ATox or QTox is also fine and such modification won't trigger
AGPL V3.

### Metadata and user account
If you think the current default random user ID as their user account is not user friendly, you can change it to either email/phone number/Discord's user ID/username.

However, these kinds of changes were not considered by me because it exposes the information regarding the client or user which may not be great from a privacy point
of view or assumed leakage point of view (Post-compromise security or zero trust security).

These changes again won't trigger AGPL V3.

Similar situation applies to the **key identifiers** in the client application.

# Client Application

**The client application uses mutable data type or raw binary streams of data in read or write in files.**

Ordinary certificate public key and private key or cryptographic keys usually stores in hexadecimal or base64 encoding or as ASCII. I was not really sure about the reasons
behind them but perhaps it's easier to check the private and public keys information due to unicode or ASCII encoding instead of raw binary data which fails to
be encoded by unicode or ASCII. 

If anyone want to change the current raw streams of binary data, it's fine but I do it with a reason that needs to utilize the pointer in C# along with mutable data
type such as Byte[] to essentially address on **data lifetime issue** faced by not immediately clearing the private/secret keys in memory after use. If we use 
something like String or String[], they again belongs to immutable data type or immutable data type array which has an issue that we can't be sure whether the keys
have been cleared in memory after calling the **zero memory** function from any cryptographic purpose in any of the major operating system such as **Windows, MacOS
and Linux**.

In a way, if you look at the native cryptographic zero memory function in any common OS, you should be able to find something like void** or pointers in them. For
this particular reasons, cryptographic or security related systems or software may need to use something that has both mutable data type which allows raw streams
of binary data read and write in files and pointers. Without these, perhaps the application itself may not really able to consider as addressed on data lifetime
issue or a form of memory security.

This has produces a give and take situation and if you stick with default which clears cryptographic keys in memory after use then you have to accept its drawbacks.
The same goes to storing it in ASCII/Unicode/Base64. 

This again won't trigger AGPL V3 no matter what you choose as each of them is essentially like picking a poison.

**It's also a reason in my humble opinion that security related software or cryptographic related software, it's best to develop in either C or C++ or slightly
easier language such as C# or Java. However, there may be other applicable languages which suits cryptographic security or security related security requirements.
I am just not sure other than C# or Java, what else can someone use or can use.**

## Signing Application
The signing application by default uses cryptographic deterministic random number generator to produce random characters as key identifier, if you want to add
some features which allow the client to know this sub key was for what or other sorts of applicable functions. This again won't trigger AGPL V3.
