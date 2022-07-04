
# Super Example Game
***
## Instrucciones para probar la API

* Configurar correctamente la cadena de conexión en el archivo appsettings.json.
* Al iniciarse el proyecto se creará la base llamada "GameDB" y se ingresaran automaticamente los datos iniciales y de prueba.
* Se puede probar el endpoint por swagger ingresando en la ruta el id 1 de item y en el cuerpo repitiendo el mismo valor para item y el id 1 de guerrero. Se debe obtener un resultado 200 OK la primera vez, con una respuesta en formato JSON como en este ejemplo:
```json
{
  "usuarioId": 1,
  "oro": 400,
  "diamantes": 400,
  "guerreroId": 1,
  "destrezas": [
    {
      "nombre": "Velocidad",
      "nivel": "Bronce",
      "grado": 1
    },
    {
      "nombre": "Fuerza",
      "nivel": "Bronce",
      "grado": 2
    },
    {
      "nombre": "Resistencia",
      "nivel": "Bronce",
      "grado": 2
    }
  ]
}
```

* Se pueden probar tambien distintos casos de error, ingresando id no validos y realizando la compra nuevamente para la que no habría recursos suficientes.

***

## Tareas pendientes

* Realizar validaciones de datos antes de guardar en la base de datos.
* Agregar middleware de manejo de errores para devolver respuestas estandarizadas y atrapar errores no manejados.
* Refactorizar handler de compra para facilitar la lectura y reutilización del código.
* Agregar endpoint para visualizar items disponibles.
* Realizar tests unitarios
***
## Detalle de datos inicales

```json
[
	{
		"destrezas": [
			"Velocidad",
			"Fuerza",
			"Resistencia"
		]
	},
	{
		"niveles": [
			"Bronce",
			"Plata",
			"Oro",
			"Platino",
			"Titanio"
		]
	},
	{
		"usuario": {
			"Oro": 1000,
			"Diamantes": 1000
		}
	},
	{
		"guerrero": {
			"usuarioId": "usuario"
		}
	},
	{
		"destrezasGuerrero": [
			{
				"destreza": "Velocidad",
				"nivel": "bronce",
				"grado": 1,
				"guerreroId": "guerrero"
			},
			{
				"destreza": "Fuerza",
				"nivel": "bronce",
				"grado": 1,
				"guerreroId": "guerrero"
			},
			{
				"destreza": "Resistencia",
				"nivel": "bronce",
				"grado": 1,
				"guerreroId": "guerrero"
			}
		]
	},
	{
		"Item": {
			"Nombre": "Espada",
			"CostoDiamante": 600,
			"CostoOro": 600,
			"destrezas": [
				"Fuerza",
				"Resistencia"
			]
		}
	}
]
```
