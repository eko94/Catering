Feature: GenerarOrdenCompleta

Se generará una nueva Orden de Trabajo, donde se procesará a todos los estados a seguir, que serían:
	- Crear Orden de Trabajo
	- Preparar Receta
	- Empaquetar Comidas
	- Etiquetar Comidas

@GenerarOrdenCompleta 
Scenario: Crear Orden
	Given Datos para una nueva Orden de Trabajo
		| Data              | Value                                      |
		| IdUsuarioCocinero | d19a0e52-cf2a-45cb-a99f-7343afb296b4       |
		| IdReceta          | f57a6be5-585b-4b28-88df-6ed1cd2b6ef0       |
		| Cantidad          | 5                                          |
		| Cliente           | 9b971b55-e539-4939-9240-825a48402329       |
		| Contrato          | 5faf7842-e7b5-4a3f-96c8-7719d01748b9       |
	When Crear Orden de Trabajo
	Then Orden de Trabajo creado con exito

Scenario: Preparar Receta
	Given Orden de Trabajo creado
	When Preparar la Receta de la Orden
	Then Receta preparada con éxito

Scenario: Empaquetar Comidas
	Given Orden de Trabajo preparado
	When Empaquetar las Comidas de la Orden
	Then Comidas empaquetadas con éxito

Scenario: Etiquetar Comidas
	Given Comidas empaquetadas
	When Etiquetar las Comidas de la Orden
	Then Comidas etiquetadas con éxito