#definición de un diccionario

monedas={"Euro":"€","Dollar":"$","Yen":"¥"}

moneda=input("Introduce una moneda: ")

print(monedas.get(moneda.title(),"La divisa no está"))