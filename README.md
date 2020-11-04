# CodingChallenge
Aplicación contactos


Dentro de la aplicacion se encuentra la APIRESTfull con NET Core 3.1 y la vista relizada en ASP.NET Web Applications MVC.

---------------------------------------------------------------------------------

Para la parte de la Base de Datos, la hice en Sql server, 
Contiene una entidad Contacto, la cual tiene una relación con la entidad Direccion. Por otro lado, cree otras dos entidades llamadas
Provincia y Ciudad, las cuales la entidad Direccion tiene una relacion con Ciudad y la Ciudad tiene una relación con Provincia, de este modo,
una Ciudad puede saber a que Provincia pertenece.

---------------------------------------------------------------------------------

Lo más desafiante del desarrollo realizado fue la creación de la APIRESTfull, siempre al hacer mantenimiento nunca había tenido la experiencia
de hacer una desde cero. De todos modos, la creación de todo el proyecto fue desafiante porque es una medida para mi para saber mis conocimientos
y poder reforzarlos como también poder adquirir nuevos.

---------------------------------------------------------------------------------

## GET /contacto
Path: https://localhost:44331/api/contacto?telefono=123456&email=juan@algo.com&provinciaId=2&ciudadId=3
Detalle: Este endpoint retorna una lista de contactos de acuerdo a los parametros asignados para busqueda, todos ellos son opcionales.
Parametros:
-telefono:string;
-email: string
-provinciaId: numero;
-ciudadId: numero;

Response: 200 OK
```
[
        {
        "contactoId": 11,
        "nombre": "Juan",
        "empresa": "soft",
        "email": "juan@algo.com",
        "fechaNacimiento": "01/02/1990",
        "telefono": "123456",
        "direccionId": 19,
        "imagenPerfil": null,
        "direccion": {
            "direccionId": 19,
            "ciudadId": 3,
            "calle": "1",
            "dpto": null,
            "piso": null,
            "numeroCasa": 123,
            "ciudad": {
                "ciudadId": 3,
                "nombre": "Cosquin",
                "provinciaId": 2,
                "codigoPostal": 123,
                "provincia": {
                    "provinciaId": 2,
                    "nombre": "Cordoba"
                }
            }
        }
    }
]
```
---------------------------------------------------------------------------------

## POST /contacto
Path: https://localhost:44331/api/contacto
Body:
```
{
    "nombre": "victorr",
    "empresa": "soft",
    "email": "test@gmail.com",
    "fechaNacimiento": "19/09/1995",
    "telefono": "12345678",
    "imagenPerfil": null,
    "direccion": {
        "ciudadId": 2,
        "calle": "27",
        "dpto": null,
        "piso": null,
        "numeroCasa": 772
    }
}
```

Response: 201 Created
```
{
    "contactoId": 13,
    "nombre": "Sofia",
    "empresa": "soft",
    "email": "sofi@algo.com",
    "fechaNacimiento": "19/09/1995",
    "telefono": "12345678",
    "direccionId": 21,
    "imagenPerfil": null,
    "direccion": {
        "direccionId": 21,
        "ciudadId": 2,
        "calle": "27",
        "dpto": null,
        "piso": null,
        "numeroCasa": 774,
        "ciudad": null
    }
}
```
Response Error: 400 Bad Request
```
{
    "errors": {
        "Nombre": [
            "The Nombre field is required."
        ]
    },
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "|9a14a138-4d1db5f1b77ca5b6."
}
```
---------------------------------------------------------------------------------

## PUT /contacto
Path: https://localhost:44331/api/contacto
Body: 
```
{
    "contactoId": 13,
    "nombre": "Sofia",
    "empresa": "soft",
    "email": "sofi@algo.com",
    "fechaNacimiento": "19/09/1995",
    "telefono": "12345678",
    "direccionId": 21,
    "imagenPerfil": null,
    "direccion": {
        "direccionId": 21,
        "ciudadId": 2,
        "calle": "27",
        "dpto": null,
        "piso": null,
        "numeroCasa": 774,
        "ciudad": null
    }
}
```
Response: 204 No Content

Error:
```
{
    "errors": {
        "Nombre": [
            "The Nombre field is required."
        ]
    },
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "|d31c4c73-461cc7bc50d2f06d."
}
```
---------------------------------------------------------------------------------
## DELETE /contacto/{id}
Path: https://localhost:44331/api/contacto/13

Response: 204 No Content

---------------------------------------------------------------------------------
## GET /contacto/{id}
Detalle: Este endpoint retorna un contacto de acuerdo al id pasado por parámetro
Parametros:
-id: int;
Path: https://localhost:44331/api/contacto/14

Response: 200 OK
```
{
    "contactoId": 14,
    "nombre": "Martin",
    "empresa": "soft",
    "email": "martin@algo.com",
    "fechaNacimiento": "19/09/1995",
    "telefono": "12345678",
    "direccionId": 22,
    "imagenPerfil": null,
    "direccion": {
        "direccionId": 22,
        "ciudadId": 2,
        "calle": "27",
        "dpto": null,
        "piso": null,
        "numeroCasa": 774,
        "ciudad": {
            "ciudadId": 2,
            "nombre": "Avellaneda",
            "provinciaId": 1,
            "codigoPostal": 1870,
            "provincia": {
                "provinciaId": 1,
                "nombre": "Buenos Aires"
            }
        }
    }
}
```
---------------------------------------------------------------------------------
## GET /ciudad
Detalle: Este endpoint retorna una lista de ciudades
Path: https://localhost:44331/api/ciudad

Response: 200 OK
```
[
    {
        "ciudadId": 2,
        "nombre": "Avellaneda",
        "provinciaId": 1,
        "codigoPostal": 1870,
        "provincia": null
    },
    {
        "ciudadId": 3,
        "nombre": "Cosquin",
        "provinciaId": 2,
        "codigoPostal": 123,
        "provincia": null
    },
    {
        "ciudadId": 1,
        "nombre": "La Plata",
        "provinciaId": 1,
        "codigoPostal": 1900,
        "provincia": null
    },
    {
        "ciudadId": 4,
        "nombre": "Villa Carlos Paz",
        "provinciaId": 2,
        "codigoPostal": 321,
        "provincia": null
    }
]
```
---------------------------------------------------------------------------------
## GET /ciudad/GetAllByProvinciaId?provId={id}
Detalle: Este endpoint retorna una lista de ciudades que pertenecen a una provincia. El id de la provincia es pasado por parámetro.
Path: https://localhost:44331/api/ciudad/GetAllByProvinciaId?provId=1
Parametros:
-provId: int

Response: 200 OK
```
[
    {
        "ciudadId": 2,
        "nombre": "Avellaneda",
        "provinciaId": 1,
        "codigoPostal": 1870,
        "provincia": null
    },
    {
        "ciudadId": 1,
        "nombre": "La Plata",
        "provinciaId": 1,
        "codigoPostal": 1900,
        "provincia": null
    }
]
```
---------------------------------------------------------------------------------
## GET /ciudad
Detalle: Este endpoint retorna una ciudad de acuerdo al id pasado por parámetro
Parametros:
-id: int;
Path: https://localhost:44331/api/ciudad/1

Response: 200 OK
```
{
    "ciudadId": 1,
    "nombre": "La Plata",
    "provinciaId": 1,
    "codigoPostal": 1900,
    "provincia": {
        "provinciaId": 1,
        "nombre": "Buenos Aires"
    }
}
```
---------------------------------------------------------------------------------
## GET /provincia
Detalle: Este endpoint retorna una lista de provincias
Path: https://localhost:44331/api/provincia

Response: 200 OK
```
[
    {
        "provinciaId": 1,
        "nombre": "Buenos Aires"
    },
    {
        "provinciaId": 2,
        "nombre": "Cordoba"
    }
]
```

