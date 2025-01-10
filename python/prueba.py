print("{nombre} quiere comer {comida}".format(nombre="Bob", comida="lasaña"))



# Creemos una variable para experimentar
una_variable = 5

# Aquí está una declaración de un 'if'. ¡La indentación es significativa en Python!
# imprime "una_variable es menor que 10"
if una_variable > 10:
	print("una_variable es completamente mas grande que 10.")
elif una_variable < 10:	# Este condición 'elif' es opcional.
	print("una_variable es mas chica que 10.")
else:       	# Esto también es opcional.
	print("una_variable es de hecho 10.")
