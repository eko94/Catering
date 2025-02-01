Feature: CancelarOrden

Se creará una nueva Orden de Trabajo y se cancelará una vez creada.

@CancelarOrden
Scenario: Crear Orden para cancelarla
	Given Datos para una nueva Orden de Trabajo para cancelar
		| Data              | Value                                      |
		| IdUsuarioCocinero | d19a0e52-cf2a-45cb-a99f-7343afb296b4       |
		| IdReceta          | f57a6be5-585b-4b28-88df-6ed1cd2b6ef0       |
		| Cantidad          | 5                                          |
		| Clientes          | [ "9b971b55-e539-4939-9240-825a48402329" ] |
	When Crear Orden de Trabajos
	Then Orden de Trabajo creado con exito para cancelar

Scenario: Cancelar Orden creada
	Given Orden de Trabajo creado para cancelar
	When Cancelar la Orden creada
	Then Orden cancelada con éxito
