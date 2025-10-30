# Heladeria
# 🍦 Sistema de Inventario de Nevería - Documentación Técnica

## 📋 Tabla de Contenidos
1. [Descripción del Proyecto](#descripción-del-proyecto)
2. [Características Principales](#características-principales)
3. [Tecnologías Utilizadas](#tecnologías-utilizadas)
4. [Requisitos del Sistema](#requisitos-del-sistema)
5. [Instalación y Configuración](#instalación-y-configuración)
6. [Estructura de la Base de Datos](#estructura-de-la-base-de-datos)
7. [Funcionalidades Detalladas](#funcionalidades-detalladas)
8. [Manual de Usuario](#manual-de-usuario)
9. [Estructura del Código](#estructura-del-código)
10. [Solución de Problemas](#solución-de-problemas)

---

## 📖 Descripción del Proyecto

**Sistema de Inventario de Nevería** es una aplicación de escritorio desarrollada en C# con Windows Forms que permite gestionar el inventario de helados de una nevería. El sistema almacena la información en una base de datos MySQL y proporciona una interfaz intuitiva para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los productos.

**Desarrollado por:** Jose  
**Curso:** JEOD_Proyecto02  
**Fecha:** 2024

---

## ⭐ Características Principales

### Gestión de Helados
- ✅ **Agregar** nuevos helados al inventario
- ✏️ **Editar** información de helados existentes
- 🗑️ **Eliminar** helados del inventario
- 👁️ **Visualizar** todo el inventario en tiempo real

### Consultas Especializadas
- 🥛 Filtrar helados de **leche**
- 💧 Filtrar helados de **agua**
- 📈 Mostrar helado con **mayor cantidad**
- 📉 Mostrar helado con **menor cantidad**

### Características Técnicas
- 🔄 Sincronización automática con base de datos
- ✅ Validación de datos en tiempo real
- 🎨 Interfaz moderna y amigable
- 💾 Persistencia de datos en MySQL
- 🔍 Búsqueda por ID para edición

---

## 🛠️ Tecnologías Utilizadas

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| C# | .NET Framework 4.7+ | Lenguaje de programación |
| Windows Forms | - | Framework de interfaz gráfica |
| MySQL | 5.7+ | Sistema de gestión de base de datos |
| MySql.Data | 8.0+ | Conector MySQL para .NET |
| Visual Studio | 2019/2022 | IDE de desarrollo |

---

## 💻 Requisitos del Sistema

### Hardware Mínimo
- Procesador: Intel Core i3 o equivalente
- RAM: 4 GB
- Espacio en disco: 100 MB

### Software Requerido
- Windows 7/8/10/11
- .NET Framework 4.7 o superior
- MySQL Server 5.7 o superior
- Conector MySQL para .NET (MySql.Data)

---

## 📥 Instalación y Configuración

### 1. Configuración de la Base de Datos

```sql
-- Crear la base de datos
CREATE DATABASE neveria_db;
USE neveria_db;

-- Crear la tabla de helados
CREATE TABLE helados (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(10) NOT NULL,
    cantidad INT NOT NULL,
    CHECK (tipo IN ('Leche', 'Agua')),
    CHECK (cantidad >= 0)
);

-- Insertar datos de ejemplo (opcional)
INSERT INTO helados (nombre, tipo, cantidad) VALUES
('Vainilla', 'Leche', 50),
('Chocolate', 'Leche', 45),
('Fresa', 'Agua', 30),
('Limón', 'Agua', 25);
```

### 2. Configuración de la Conexión

Actualizar el archivo `Conexion.cs` con los datos de tu servidor MySQL:

```csharp
public class Conexion
{
    public static MySqlConnection conexion()
    {
        string servidor = "localhost";
        string bd = "neveria_db";
        string usuario = "root";
        string password = "tu_password";
        
        string cadenaConexion = $"server={servidor};database={bd};Uid={usuario};pwd={password};";
        
        try
        {
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            return conexionBD;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Error de conexión: " + ex.Message);
            return null;
        }
    }
}
```

### 3. Instalación del Conector MySQL

**Opción A: NuGet Package Manager**
```
Install-Package MySql.Data
```

**Opción B: Visual Studio**
1. Click derecho en el proyecto → Manage NuGet Packages
2. Buscar: `MySql.Data`
3. Instalar la versión más reciente

### 4. Agregar Referencia a Microsoft.VisualBasic

1. Solution Explorer → References → Add Reference
2. Buscar: `Microsoft.VisualBasic`
3. Marcar la casilla y dar OK

---

## 🗄️ Estructura de la Base de Datos

### Tabla: `helados`

| Campo | Tipo | Descripción | Restricciones |
|-------|------|-------------|---------------|
| `id` | INT | Identificador único | PRIMARY KEY, AUTO_INCREMENT |
| `nombre` | VARCHAR(100) | Nombre del helado | NOT NULL |
| `tipo` | VARCHAR(10) | Tipo de helado | NOT NULL, CHECK ('Leche', 'Agua') |
| `cantidad` | INT | Cantidad en inventario | NOT NULL, CHECK (>= 0) |

**Índices:**
- PRIMARY KEY en `id`

**Ejemplo de registro:**
```
id: 1
nombre: "Vainilla"
tipo: "Leche"
cantidad: 50
```

---

## 🔧 Funcionalidades Detalladas

### 1. Agregar Helado

**Descripción:** Permite agregar un nuevo helado al inventario.

**Proceso:**
1. Usuario ingresa nombre del helado
2. Selecciona tipo (Leche o Agua)
3. Ingresa cantidad
4. Click en botón "Agregar ✓"
5. Sistema valida los datos
6. Guarda en la base de datos
7. Actualiza la vista del inventario

**Validaciones:**
- ✅ Nombre no puede estar vacío
- ✅ Cantidad debe ser un número entero positivo
- ✅ Debe seleccionar un tipo (Leche o Agua)

**Código SQL ejecutado:**
```sql
INSERT INTO helados (nombre, tipo, cantidad) 
VALUES (@nombre, @tipo, @cantidad)
```

---

### 2. Editar Helado

**Descripción:** Permite modificar la información de un helado existente mediante búsqueda por ID.

**Proceso:**
1. Usuario click en botón "Editar"
2. Sistema solicita ID del helado
3. Busca el helado en la base de datos
4. Muestra información en los campos
5. Usuario modifica los campos deseados
6. Click en "💾 Guardar"
7. Sistema actualiza en la base de datos
8. Botón regresa a estado "Editar"

**Validaciones:**
- ✅ ID debe ser un número válido
- ✅ Helado debe existir en la base de datos
- ✅ Campos editados deben cumplir validaciones

**Códigos SQL ejecutados:**
```sql
-- Búsqueda
SELECT id, nombre, tipo, cantidad 
FROM helados WHERE id = @id

-- Actualización
UPDATE helados 
SET nombre = @nombre, tipo = @tipo, cantidad = @cantidad 
WHERE id = @id
```

**Estados del botón:**
- **Normal:** "Editar" (azul) → Busca por ID
- **Edición:** "💾 Guardar" (naranja) → Guarda cambios

---

### 3. Eliminar Helado

**Descripción:** Permite eliminar un helado seleccionado del inventario.

**Proceso:**
1. Usuario selecciona un helado en la tabla
2. Click en botón "Eliminar ×"
3. Sistema pide confirmación
4. Si confirma, elimina de la base de datos
5. Actualiza la vista del inventario

**Validaciones:**
- ✅ Debe haber un helado seleccionado
- ✅ Solicita confirmación antes de eliminar

**Código SQL ejecutado:**
```sql
DELETE FROM helados WHERE id = @id
```

---

### 4. Consultas Filtradas

#### 4.1 Mostrar Todo
Muestra todos los helados ordenados por ID.

```sql
SELECT id, nombre, tipo, cantidad 
FROM helados 
ORDER BY id
```

#### 4.2 Helados de Leche
Filtra solo helados base leche.

```sql
SELECT id, nombre, tipo, cantidad 
FROM helados 
WHERE tipo = 'Leche' 
ORDER BY nombre
```

#### 4.3 Helados de Agua
Filtra solo helados base agua.

```sql
SELECT id, nombre, tipo, cantidad 
FROM helados 
WHERE tipo = 'Agua' 
ORDER BY nombre
```

#### 4.4 Mayor Cantidad
Muestra el helado con más cantidad en inventario.

```sql
SELECT id, nombre, tipo, cantidad 
FROM helados 
ORDER BY cantidad DESC 
LIMIT 1
```

#### 4.5 Menor Cantidad
Muestra el helado con menos cantidad en inventario.

```sql
SELECT id, nombre, tipo, cantidad 
FROM helados 
ORDER BY cantidad ASC 
LIMIT 1
```

---

## 👤 Manual de Usuario

### Interfaz Principal

```
┌─────────────────────────────────────────────────────┐
│       🍦 INVENTARIO DE LA NEVERÍA DE JOSE          │
├──────────────────┬──────────────────────────────────┤
│  DATOS           │    TABLA DE INVENTARIO          │
│                  │                                  │
│  Nombre: [____]  │  ID | Nombre | Tipo | Cantidad │
│  Tipo: ○ ○       │  ──────────────────────────────  │
│  Cantidad: [__]  │  (Registros del inventario)     │
│                  │                                  │
│  [✓] [✏] [×]     │                                  │
├──────────────────┴──────────────────────────────────┤
│  [Todo] [Agua] [Leche] [↑Max] [↓Min]               │
└─────────────────────────────────────────────────────┘
```

### Paso a Paso: Agregar un Helado

1. **Llenar campos:**
   - Nombre: "Chocolate"
   - Tipo: Seleccionar "Leche"
   - Cantidad: "50"

2. **Click en botón verde "Agregar ✓"**

3. **Confirmación:**
   - Aparece mensaje: "¡Helado agregado exitosamente!"
   - El nuevo helado aparece en la tabla

### Paso a Paso: Editar un Helado

1. **Click en botón azul "Editar"**

2. **Ingresar ID:**
   - Aparece ventana: "Ingrese el ID del helado"
   - Escribir el ID (ejemplo: 5)

3. **Confirmar edición:**
   - Sistema muestra información encontrada
   - Click en "Sí" para editar

4. **Modificar campos:**
   - Cambiar nombre, tipo o cantidad según necesite
   - El botón ahora dice "💾 Guardar" (naranja)

5. **Click en "💾 Guardar"**

6. **Confirmación:**
   - Mensaje: "¡Helado modificado correctamente!"
   - Botón regresa a "Editar"

### Paso a Paso: Eliminar un Helado

1. **Seleccionar fila en la tabla**
   - Click sobre el helado a eliminar

2. **Click en botón rojo "Eliminar ×"**

3. **Confirmar eliminación:**
   - Aparece pregunta de confirmación
   - Click en "Sí" para confirmar

4. **Confirmación:**
   - Mensaje: "Helado eliminado correctamente"
   - Desaparece de la tabla

### Uso de Consultas

**Mostrar Todo:** Click en botón blanco "Mostrar todo"  
**Solo Leche:** Click en botón amarillo "Helados de leche"  
**Solo Agua:** Click en botón azul "Helados de agua"  
**Mayor Cantidad:** Click en botón verde "Helados con más cantidad"  
**Menor Cantidad:** Click en botón rosa "Helados con menos cantidad"

---

## 🏗️ Estructura del Código

### Arquitectura del Proyecto

```
JEOD_Proyecto02/
│
├── frm_neveria.cs          # Lógica del formulario
├── frm_neveria.Designer.cs # Diseño de la interfaz
├── Conexion.cs             # Clase de conexión a BD
└── Program.cs              # Punto de entrada
```

### Estructura de Datos

```csharp
struct Helado
{
    public int id;         // ID único en BD
    public string nombre;  // Nombre del helado
    public string tipo;    // "Leche" o "Agua"
    public int cantidad;   // Cantidad en inventario
}
```

### Variables Globales

```csharp
Helado[] inventario = new Helado[50];  // Arreglo en memoria
int contador = 0;                       // Cantidad de helados
```

### Métodos Principales

| Método | Descripción | Retorno |
|--------|-------------|---------|
| `btn_agregar_Click()` | Agrega helado a BD | void |
| `btn_editar_Click()` | Edita helado (2 modos) | void |
| `btn_eliminar_Click()` | Elimina helado de BD | void |
| `CargarInventarioDesdeBD()` | Carga datos desde BD | void |
| `ConsultarPorTipo()` | Filtra por tipo | void |
| `MostrarConsultaEspecial()` | Consultas max/min | void |
| `LimpiarCampos()` | Limpia formulario | void |
| `EstilizarControles()` | Aplica estilos visuales | void |

### Flujo de Datos

```
Usuario → Formulario → Validación → MySQL → Actualización Vista
                          ↓
                    Error Handler
```

---

## 🎨 Diseño de la Interfaz

### Paleta de Colores

| Elemento | Color RGB | Hex | Uso |
|----------|-----------|-----|-----|
| Título | `255, 107, 157` | #FF6B9D | Rosa helado |
| Agregar | `76, 175, 80` | #4CAF50 | Verde éxito |
| Editar | `33, 150, 243` | #2196F3 | Azul información |
| Guardar | `255, 152, 0` | #FF9800 | Naranja advertencia |
| Eliminar | `244, 67, 54` | #F44336 | Rojo peligro |
| Mostrar Todo | `227, 242, 253` | #E3F2FD | Azul pastel |
| Agua | `225, 245, 254` | #E1F5FE | Celeste pastel |
| Leche | `255, 249, 196` | #FFF9C4 | Amarillo pastel |
| + Cantidad | `232, 245, 233` | #E8F5E9 | Verde pastel |
| - Cantidad | `252, 228, 236` | #FCE4EC | Rosa pastel |

### Tipografía

- **Título:** Segoe UI, 16pt, Bold
- **Botones:** Segoe UI, 9pt, Bold
- **TextBox:** Segoe UI, 10pt
- **DataGridView:** Segoe UI, 9pt

---

## 🐛 Solución de Problemas

### Problema: No se conecta a la base de datos

**Síntoma:** Error "Unable to connect to any of the specified MySQL hosts"

**Soluciones:**
1. Verificar que MySQL Server esté corriendo
2. Confirmar credenciales en `Conexion.cs`
3. Verificar que el puerto 3306 esté abierto
4. Comprobar firewall de Windows

```bash
# Verificar estado de MySQL
mysql --version
mysql -u root -p
```

---

### Problema: Error al editar helado

**Síntoma:** Botón "Guardar" no funciona

**Soluciones:**
1. Verificar que `Microsoft.VisualBasic` esté referenciado
2. Comprobar evento Click del botón en Designer
3. Verificar que `btn_editar.Tag` se establezca correctamente

```csharp
// Verificar en Properties del botón
Events → Click → btn_editar_Click
```

---

### Problema: Datos no se actualizan

**Síntoma:** Cambios no aparecen en la tabla

**Soluciones:**
1. Verificar que `CargarInventarioDesdeBD()` se llame después de cada operación
2. Comprobar que la conexión no se cierre prematuramente
3. Revisar logs de errores en MessageBox

---

### Problema: Validaciones no funcionan

**Síntoma:** Se permiten datos inválidos

**Soluciones:**
1. Verificar que las validaciones estén antes de la consulta SQL
2. Usar `int.TryParse()` para validar números
3. Verificar estados de RadioButtons con `.Checked`

---

## 📊 Casos de Prueba

### CP-01: Agregar Helado Válido

| Paso | Acción | Resultado Esperado |
|------|--------|-------------------|
| 1 | Ingresar "Vainilla" | Campo lleno |
| 2 | Seleccionar "Leche" | Radio marcado |
| 3 | Ingresar "50" | Campo lleno |
| 4 | Click "Agregar" | Éxito, aparece en tabla |

---

### CP-02: Agregar Helado Inválido

| Paso | Acción | Resultado Esperado |
|------|--------|-------------------|
| 1 | Dejar nombre vacío | - |
| 2 | Ingresar cantidad "-5" | - |
| 3 | Click "Agregar" | Error: "Complete todos los campos" |

---

### CP-03: Editar Helado

| Paso | Acción | Resultado Esperado |
|------|--------|-------------------|
| 1 | Click "Editar" | Pide ID |
| 2 | Ingresar ID "1" | Carga datos |
| 3 | Modificar cantidad a "100" | Campo actualizado |
| 4 | Click "💾 Guardar" | Éxito, BD actualizada |

---

### CP-04: Eliminar Helado

| Paso | Acción | Resultado Esperado |
|------|--------|-------------------|
| 1 | Seleccionar fila | Fila resaltada |
| 2 | Click "Eliminar" | Pide confirmación |
| 3 | Click "Sí" | Helado eliminado |

---

### CP-05: Consultas

| Consulta | Acción | Resultado Esperado |
|----------|--------|-------------------|
| Todos | Click "Mostrar todo" | Todos los helados |
| Leche | Click "Helados de leche" | Solo tipo Leche |
| Agua | Click "Helados de agua" | Solo tipo Agua |
| Max | Click "Más cantidad" | Helado con max |
| Min | Click "Menos cantidad" | Helado con min |

---

## 📝 Notas de Versión

### Versión 1.0 (2024)

**Características Iniciales:**
- ✅ CRUD completo de helados
- ✅ Conexión a MySQL
- ✅ Interfaz gráfica con Windows Forms
- ✅ Validaciones de datos
- ✅ Consultas filtradas
- ✅ Búsqueda por ID para edición

**Mejoras Implementadas:**
- 🎨 Interfaz moderna con colores pastel
- 🔄 Sincronización automática con BD
- 💾 Sistema de edición en dos pasos
- ✅ Confirmaciones antes de eliminar
- 📊 DataGridView estilizado

---

## 🔮 Mejoras Futuras Sugeridas

1. **Búsqueda por nombre** en lugar de solo ID
2. **Reportes en PDF** del inventario
3. **Gráficas** de cantidad por tipo
4. **Control de usuarios** con login
5. **Historial de cambios** (auditoría)
6. **Alertas** de stock bajo
7. **Backup automático** de BD
8. **Exportar a Excel** la tabla
9. **Modo oscuro** para la interfaz
10. **Búsqueda predictiva** en tiempo real

---

## 👨‍💻 Contacto y Soporte

**Desarrollador:** Jose  
**Proyecto:** JEOD_Proyecto02  

Para reportar bugs o sugerir mejoras, por favor contactar al desarrollador.

---

## 📄 Licencia

Este proyecto fue desarrollado con fines educativos.

---

**Última actualización:** Octubre 2024  
**Versión del documento:** 1.0
