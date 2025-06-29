Feature: EmpaquetarComidaSinPreparar

Se generará una nueva Orden de Trabajo, donde se creará una orden y se intentará empaquetar sin haber preparado la receta.

@GenerarOrdenCompleta 
Scenario: Crear Orden
	Given Datos para una nueva Orden de Trabajo para empaquetar
		| Data              | Value                                      |
		| IdUsuarioCocinero | d19a0e52-cf2a-45cb-a99f-7343afb296b4       |
		| IdReceta          | f57a6be5-585b-4b28-88df-6ed1cd2b6ef0       |
		| Cantidad          | 5                                          |
		| Cliente           | 9b971b55-e539-4939-9240-825a48402329       |
		| Contrato          | 5faf7842-e7b5-4a3f-96c8-7719d01748b9       |
	When Crear Orden de Trabajo para empaquetar
	Then Orden de Trabajo creado con exito para empaquetar

Scenario: Empaquetar Comidas
	Given Orden de Trabajo creado sin preparado
	When Empaquetar las Comidas de la Orden sin preparar
	Then No se puede empaquetar una comidas sin preparar