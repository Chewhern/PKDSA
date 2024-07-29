# Server Application

## Credentials Handling
Credentials such as database credentials, certificate's private key information currently uses hardcoding or dynamic file information extraction as two of the common credentials handling methods. Common credentials handling method will have unsolvable issues, no matter what handling method you use, credential handling will not be triggered even if you switch from one method to another. 

## Server Status (Controller)
If you guys think that it's redundant to have this controller or this API endpoint, you can remove it from your end. Such a modification won't trigger AGPL V3.

The reason I put there was to have a blank API endpoint to check if the server was online or not really from API endpoint consumption.

## Register Account (Controller)

### Identity binding
PKDSA by default does not use any identity, if you wish to bind identity, such a modification will not trigger AGPL version 3. 

### Metadata and user account
PKDSA by default uses random ID for both user ID and ID for storing sub keys, these are privacy centric by default. If you wish to change it into something more
friendly to users, such a modification will not trigger AGPL version 3. 

# Client Application

## Memory disclosure attacks
Array that made up of specific data types such as Byte[], char[], uint_8[], int_8[], unsigned_char[] are the recommended approach in dealing with sensitive cryptographic information such as private and secret key. Pointers could also be used to deal with sensitive cryptographic information. While such approach is security guaranteed but they have portability issues and may not be easily process and stored by users or other programming languages. If you would want to use String[] or any other similar immutable data type array, such a modification in an exchange for addressing portability issue will not trigger AGPL version 3.

## Signing Application
The signing application by default uses cryptographic deterministic random number generator to produce random characters as key identifier, if you want to add
some features which allow the client to know this sub key was for what or other sorts of applicable functions. This again won't trigger AGPL V3.
