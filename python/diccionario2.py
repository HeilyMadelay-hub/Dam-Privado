nombre=input('¿Cómo te llamas?')
edad=input('¿Cuántos años tienes?')
direccion=input('¿Cuál es tu dirección?')
telefono=input('¿Cuál es tu teléfono?')
persona={'nombre':nombre,'edad':edad,'direccion':direccion,'telefono':telefono}
print(persona['nombre'],'tiene',persona['edad'],'años, vive en',persona['direccion'],'y su número de teléfono es',persona['telefono'])