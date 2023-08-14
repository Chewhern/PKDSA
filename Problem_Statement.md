**The problem statement will be separated into 2 different categories. The first one will be technicalities related problem statement.
The second one will be the overview of all problem statements.**

# Technicalities problem statement

## Justification for TOR deepweb
During the era of Covid-19, people used to wear masks.
When we look at a pair of eyes, the subjective mindsets of men will be changed to a mindset that feels positive towards such individuals.
However, when the masks were removed and the true face were shown to men. They may distant themselves from such individuals.
The characteristics or traits of men will indirectly or directly affect the perception of men towards one another.
This was called as halo effect in psychology.

In recent days, there’s war broke out between Ukraine and Russia.
In an attempt to stop the war, an open source JavaScript library had been turned into a protest-ware that targets on Belarus and Russia’s companies or individuals.
This may only worsen the conflict between Ukraine and Russia.
This kind of psychological act from the JavaScript library author may perhaps fall under stereotype and cognitive bias.
When the author made such an act towards Belarus or Russia,
the act was made with an assumption that all the citizens and companies within these countries wanted the conflict.

If humans have stereotype and cognitive bias towards one another or between nations, conflicts and chaos may never be stopped. 
(https://www.theregister.com/2022/03/18/protestware_javascript_node_ipc/)
Other applicable examples could be the MH370 incident from Malaysia and the colonial past of UK towards other nations.
Men in most cases don’t want similar acts conducted that has a similar characteristic like the protest-ware towards one another.
To address on the cognitive and stereotype bias along with the halo effect that affect perceptions of humans,
TOR deepweb need to be used to force people into having objective and moderation mindset towards one another.

## Addressing keylogger on password & passphrase
Keylogger is a piece of software that records the keystrokes on a keyboard or in some cases,
they can also be extended to be inserted in bank’s ATM machine as it typically requires men to type in their PIN in order to do bank related online transactions.
Since password and passphrase both requires to be typed on keyboard be it on Desktop OS or Mobile OS,
keylogger attack can be apply to both of them to bypass any sorts of authentication that were based on them.
To address on the problem of keylogger on password & passphrase,
challenge and response authentication that uses digital signature as a prompt could be used.

## Justification of the use of CRNG on weak entropy on password
Password typically have weak entropy due to human errors.
It is because human typically don’t follow the golden rules on choosing passwords.
These golden rules consist of choosing passwords that are long, choosing passwords that are not easily rememberable.
To address on the problems that arises when men choose passwords,
CRNG (Cryptographic deterministic random number generator or Cryptographic non-deterministic random number generator) needs to be used
in generating password instead of letting the users to choose the password by their own.
This can also be extended to the use of CRNG on cryptographic private keys as the authentication had been changed from
password based to challenge and response that uses digital signature as a prompt.

## Problems of password when dealt by developers
Golden rules in dealing with passwords typically consists of not storing the password as plaintext or exactly like the way how the user typed,
not encrypting them in database and not plainly applying hashing to them.
These approaches are common approaches that the developers used in dealing with passwords.
However, neither of these approaches are really acceptable if database leaked which it’s indeed a case that occurs daily.

## Problems of conflict of advice on dealing with passwords
Developers typically are advised to apply salt to their password before hashing.
However, questions remained, how do the developers generate the salt?
What format do the salt need to be in when storing in database?
Is it hexadecimal?
Is it truncated encoded ASCII characters?

Developers are also typically advised to use modern cryptographic hashing algorithms to hash the passwords and store them in database.
However, many may still stick to deprecated algorithms such as MD4,5 and SHA1, SHA256.
Some may opt for Blake2B or Keccak or SHAKE due to their similarities to that of MD4,5 and SHA1,SHA256 from the sight of developers
but the best recommended algorithms are PBKDF2 and Argon2.

## Problems of choosing and feeding secure parameters into PBKDF2 and Argon2
In recent Bitwarden incident, it’s already clear that password managers such as Bitwarden and other applicable password managers are struggling to choose
and feed secure parameters into PBKDF2 and Argon2 as their businesses are mostly authentication services which aims to help protect passwords and
secure passwords on user’s behalf.

From libsodium (https://libsodium.gitbook.io/doc/password_hashing/default_phf), there’s already several parameters there which are quite easy to mess up
from a novice or general developer or a novice/intermediate level of cryptography engineer.
The freedom and choice to choose memlimit and opslimit in most cases will result in choosing and feeding the insecure data to both of these parameters.
This could again affect the strength of KDF-ed private key or hashed password. 

## Problems of using secure parameters in Argon2 (Justification of Challenge and response with digital signature)
A secure setting for Argon2 or PBKDF2 often the case though they promised secure KDF-ed private key
or hashed password in terms of strength but the issues are perhaps performance.

They couldn’t outcompete the performance with challenge and response that uses digital signature as prompt.

## FIDO hardware keys and E-Wastes
In FIDO, there’s hardware such as USB which has been made to securely protect the digital signature keypair which later to be used in authenticating.

Although such a mechanism was secure but the USB after serving its life, it may end up in landfills which contributes to E-Wastes throughout the globe.

## Encodings, raw streams of byte data and passwords/passphrase
Common encodings usually consist of Unicode, ASCII, Base64 and Hexadecimal. 
Passwords and passphrase usually fall under ASCII encoding.
Due to computer interpretation, when one converts passwords and passphrase into raw streams of byte data and store 
it in any forms of mediums be it online or offline, the password/passphrase itself can be known by such medium.
For example, “Password123”, when one converts it into raw streams of byte data, it can still be interpreted by computer and
force it back into readable form such as Unicode or ASCII. 
Cryptographers or information security professionals usually stores the cryptographical keys (public, private and chain)
used in certificate in certain location within a server (can be physical or virtual).

Those keys will be stored under files that uses PEM format which use Base64 encoding as its core.
This has the same issue like password/passphrase regardless if they’re stored in files.
It’s just slightly harder to understand the keys or data.
The same keys or passwords exposure to the human eyes is still an issue here.

## Mutable, immutable data type, data lifetime issue and zero memory
Data lifetime issue refers to a very specific issue that it affects any systems or programs that deals with sensitive data.
How long it stays in memory before it being wipe out by any language’s garbage collector or any OS’s garbage collector.
Data lifetime issue directly links to memory exposure issue which is one of the memory security issues in cryptography. 

Immutable data type in all languages commonly consists of non-array data type, String and object.
Immutable data type has an issue in which data lifetime issue itself can’t be addressed.

This has something to do with immutable data type’s nature. 
(https://www.youtube.com/watch?v=RxlQAACpI1U)

The link below shows that Microsoft’s Windows library has a securezeromemory function/method which uses pointer along with some integers indicating the size of a memory address. Because of such nature in Windows and it might be the same to other main operating systems such as MacOS and Linux. A lot of the languages that we commonly use needs to be excluded. The safest languages in this kind of cases only consist of C#, Java, Ruby, C++ and C. They all have pointers and allow raw streams of byte data reading and writing into files. 
(https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa366877(v=vs.85))

## Fixed provider
In most cases, when we use any of the online services. The provider's IP address are mostly fixed.
Trusts should be given back to the people or users and they must be the one that choose the provider.

Fixing provider may not build trusts and in some cases, it will only worsen the trusts between one another.

## Elliptic Curve, its flexibility and biometrics
Elliptic curve is one of the public key cryptography, it's famous for its security and customization ability.
This is not like ordinary non elliptic curve based public key cryptography, one can take RSA for example. 
In RSA, P and Q needs to be prime numbers followed by a set of mathematical rules. 

Normal elliptic curve is still okay to be choosen for most people such as NIST curves but since NSA and NIST have some sort of relationship
as portrayed by Edward Snowden's leaks. It's not that good of an idea to really trust stuffs coming out from NIST blindly.

Curve25519 and Curve448 is primarily used here due to these curves are proven by the cryptography community and DJB himself.

Biometrics are good in providing recoverability towards private key or secret key but fingerprints, face and voice all have their pros and cons.
Considering that I myself along with other security folks may not be able to protect them well. Storing them could pose compliance related issues
and in the same time, there's also leakage/breaches risks and one need not to do that by applying the **zero trust or access** principles.

Biometrics not only poses security risks,issues, it also poses privacy risks and issues.

This is why in this framework(changeable), it uses CRNG (Cryptographic Deterministic random number generator).

# Overview of main problem statements
Passwords based authentication are incredibly difficult to make it secure.
There’re keyloggers issues and problems from both users and developers.
Let’s assume password authentication were indeed secure,
there’re performance related issues which comes from using secure PBKDF2 or Argon2 parameters. 

Password belongs to private key (public key cryptography) or secret key (symmetric encryption).
Information related to private key and secret key can be expose via encodings.
The use of immutable data type in handling cryptographical keys fail to address data lifetime issue which is one of the types of memory security
measures in cryptography. 

Humans are subject to Halo effect, stereotype and cognitive biases.
Enforcing neutrality and objectivity have become an issue which has been described by Covid-19 mask example and the JavaScript protest-ware library. 
