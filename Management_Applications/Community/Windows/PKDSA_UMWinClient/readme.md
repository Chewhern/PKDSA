# Version 0.0.1
- Uses CRNG in generating random user ID and all public key cryptography digital signature's keypairs.
- Enabling people to know the potential logic behind **challenge and respond with digital signature"** and how to implement them.

# Version 0.0.2
- Added **TOR** to the application. 
- Added **Session's messenger user ID** as a form of **"Medium of conversation"** to address on data integrity issues but this addressing of data integrity
is a semi-automatic process. It's not fully automated and it can't be automated.
- The compiled applications now need to be find under **bin->Debug**, there's a zip there. The upcoming versions will now follow the format of version 0.0.2.

# Version 0.0.3
- Removed RegisterModel in **Model**.
- Slight rework on user registration.
- Added server side and client side's master public key digest fetching/computation and comparison.
- There's instructions that exists in 3rd sub part and the menu. Hopefully these will help to explain something.

# Version 0.0.4
- Reworked on TOR Proxy.
- Web API calls now uses **async** and **await** to enable smoother UI but these changes only apply to web API that uses TOR proxy.
- There's some problems on TOR that I don't really know how to solve. I am sorry that you have to use TOR proxy in a slightly annoyed way.
