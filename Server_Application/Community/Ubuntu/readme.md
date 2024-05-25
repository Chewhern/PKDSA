# Version 0.0.1
- Enabling people to know the potential logic behind **challenge and respond with digital signature"** and how to implement them.

# Version 0.0.2
- Added **Session's messenger user ID** as a form of **"Medium of conversation"** to address on data integrity issues but this addressing of data integrity
is a semi-automatic process. It's not fully automated and it can't be automated.
- Minor response string messages modification.

# Version 0.0.3
- Removed **RegisterModel** and corresponding user registration in controllers have been modified slightly.
- Added **UserPublicKeyDigest** in **Controllers**. The purpose was to allow the user to check their master public key digest with the server stored
master public key digest. 

# Version 0.0.4
- Added support for provider's local support without reliance on out of band data such as Session Messenger's user ID, email and phone number.
- Switches from out of band communication to offline generated key pair.

Key Pair A (Offline from both the provider and Client) -> Key Pair B (Main) -> Key Pair Cs (Sub)

Key Pair A and B only able to have 1 key pair for each anonymous users. 
