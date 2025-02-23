#cryptography
#pycryptodome

from Cryptodome.Cipher import AES  
from cryptography.hazmat.primitives.asymmetric import rsa
from cryptography.hazmat.primitives import serialization
import os

print("Menu Scripting Cifrado")

print("###########################################################")

print("1.Cifrado con AES")
print("2.Cifrado con RSA")

print("###########################################################")

k = input("Elige una opción:")

if k == "1":
    print("Cifrado con AES")
    Clave = input("Escribe la clave: ")
    key = Clave.encode('utf-8')
    key = key + b'0' * (32 - len(key))
    key = key[:32]
    
    cipher = AES.new(key, AES.MODE_EAX)
    
    text = input("Escribe el texto a cifrar: ")
    plaintext = text.encode('utf-8')

    ciphertext, tag = cipher.encrypt_and_digest(plaintext)

    print("Contenido cifrado: ", ciphertext.hex())

elif k == "2":
    print("Cifrado con RSA")

    private_key = rsa.generate_private_key(
        public_exponent=65537,
        key_size=2048
    )
    public_key = private_key.public_key()

    private_pem = private_key.private_bytes(
        encoding=serialization.Encoding.PEM,  
        format=serialization.PrivateFormat.TraditionalOpenSSL,
        encryption_algorithm=serialization.NoEncryption()
    )

    public_pem = public_key.public_bytes(
        encoding=serialization.Encoding.PEM,
        format=serialization.PublicFormat.SubjectPublicKeyInfo,
    )

    print("Clave privada: ", private_pem.decode())
    print("Clave publica: ", public_pem.decode())