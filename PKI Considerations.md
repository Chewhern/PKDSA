# Cryptography Key Issue
Cryptography keys by their own by default don't really specify what are the rightful owner behind those keys. It affects both public key cryptography and
symmetric encryption. However, for this project, we need to specifically aim for public key cryptography. If cryptography key issue left unchecked,
potential MITM (Man In the Middle) attacks could be performed. 

# Public Key Issue
Public key issue refers to an issue whereby it's a mixture of these issues. Some of them could be partially solved(addressed) and some of them couldn't be addressed
at all.

1. Centralized Key Management

In this setup, public keys are mostly stored on a server and typically a centralized server that holds by a single entity. This is the most common setup
however it arises some questions.. Can we really trust the provider? Because the provider is still prone to both outsider and insider's attack. How can
one make sure under such circumstance, the public keys stored don't have data integrity issues.

This is an interesting debate and there's not really that much solution in using centralized ways of doing things. In recent years, there're a lot of
reasons, signs and observable news hinted that centralized should not be the way to go. 

2. Data Integrity And Account Integrity

It becomes an issue that in CIA triads which stands for confidentiality, integrity and availability. The integrity which sources from both data and account
as an issue exists some approaches to address on these issues. However, I believe information security or cryptography community as a whole could
understand or had already come to an agreement that account integrity issues couldn't be solved or even addressed. There's a reason why account integrity
issues are a billion dollar or perhaps trillion dollar issue.

There's no such thing as one solution that fits for all purposes. In this particular case, the primary focus should be on how the provider ensures the
submitted contacting information from users don't have data integrity issues on the provider side. When this was done, other possible approaches could be
using something like hashing from cryptography to address on data integrity issues primarily on public key.

3. Decentralization

Decentralization is a very fascinating idea in which it tries to deliver the control back to the users. However, decentralization is a germination tech
as currently it raises a lot of controversies and debates because the most common form of decentralization is by requiring to use a server of some sort.
Who really owns those servers? Can they ensure neutrality? Are they pros towards censorship? Decentralization as a tech currently have these observable
issues that none could really provide an answer to at this point of time and many organizations or corporates or companies are less inclined to trust
decentralization due to their nature. One may argue that they want more control but the potential reasons behind it could be summarized as potentially
tip of the iceberg?

# PKI and its levels

PKI stands for public key infrastructure. The concept of PKI may not vanish even in post quantum computer era. However, the components within PKI may change
its form. Perhaps people may opt for decentralized version of CA (Certificate Authority) in near future because of numerous reasons.

In PKDSA, recent versions will be using a very layman understanding of PKI which sources from SecureMetric (Youtube -> https://www.youtube.com/watch?v=i-rtxrEz_E8)
and LinkedIn's Alexandre BLANC Cyber Security (https://www.linkedin.com/in/alexandre-blanc-cyber-security-88569022/).

In upcoming update of PKDSA, the most simplest and easiest version of PKI will be implemented but it won't be full PKI until I can really figured out whether a
full simplest PKI is required and whether it's really possible to translate those non code-able requirements of PKI into PKDSA. I really thank these experts,
one from LinkedIn, one from Youtube in completely jamming my brain. It's a very fascinating and interesting torture.

If you think you require to implement more advanced version of PKI, you are free to do so as touching the simplest version of PKI is already scratching my head
and brain. You're free to do so like a child without any guidance. 🤣🤣🤣
