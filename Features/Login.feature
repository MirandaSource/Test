Feature: Login
	

@Miranda
Scenario: El actor ingresa a la url dando un usuario de alta
	Given El actor ingresa a la URL del portal
	Given El actor da de alta un usuario
	Given El actor inicia y cierra sesíon con el usuario creado
	Given El actor agrega una laptop al carrito de compras
	Then EL actor valida que el producto se agrego correctamente