using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JEOD_Proyecto02
{
    /// <summary>
    /// Formulario principal para la gestión del inventario de helados de la nevería
    /// Permite agregar, modificar, eliminar y consultar helados en la base de datos
    /// </summary>
    public partial class frm_neveria : Form
    {
        #region Estructuras y Variables Globales

        /// <summary>
        /// Estructura que representa un helado con sus propiedades
        /// </summary>
        struct Helado
        {
            public int id;          // Identificador único en la base de datos
            public string nombre;   // Nombre del sabor del helado
            public string tipo;     // Tipo: "Leche" o "Agua"
            public int cantidad;    // Cantidad disponible en inventario
        }

        // Arreglo para almacenar el inventario en memoria (máximo 50 helados)
        Helado[] inventario = new Helado[50];

        // Contador de helados actualmente en el inventario
        int contador = 0;

        #endregion

        #region Constructor e Inicialización

        /// <summary>
        /// Constructor del formulario - Inicializa los componentes y aplica estilos
        /// </summary>
        public frm_neveria()
        {
            InitializeComponent();

            // Registrar evento para pintar el fondo degradado
            this.Paint += new PaintEventHandler(frm_neveria_Paint);

            // Aplicar estilos personalizados a los controles
            EstilizarControles();

            // Configurar la tabla de inventario
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Configura las propiedades visuales del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgv_inventario.ReadOnly = true;  // Solo lectura, no editable directamente
            dgv_inventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Selección de fila completa
            dgv_inventario.RowHeadersVisible = false;  // Ocultar columna de encabezados de fila
            dgv_inventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Ajustar columnas al ancho

            // Colores alternados para mejor legibilidad
            dgv_inventario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);

            // Fuentes y estilos
            dgv_inventario.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv_inventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv_inventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 255);
            dgv_inventario.EnableHeadersVisualStyles = false;  // Permitir estilos personalizados
            dgv_inventario.BackgroundColor = Color.FromArgb(250, 250, 255);
        }

        /// <summary>
        /// Aplica estilos personalizados a todos los botones y controles del formulario
        /// Establece colores, fuentes y apariencia visual
        /// </summary>
        private void EstilizarControles()
        {
            // ===== TÍTULO PRINCIPAL =====
            if (this.Controls.ContainsKey("lbl_titulo"))
            {
                var titulo = this.Controls["lbl_titulo"] as Label;
                if (titulo != null)
                {
                    titulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                    titulo.ForeColor = Color.White;
                    titulo.BackColor = Color.FromArgb(255, 107, 157); // Rosa helado
                    titulo.Padding = new Padding(15, 10, 15, 10);
                    titulo.TextAlign = ContentAlignment.MiddleCenter;
                }
            }

            // ===== BOTÓN AGREGAR - Verde =====
            btn_agregar.FlatStyle = FlatStyle.Flat;
            btn_agregar.BackColor = Color.FromArgb(76, 175, 80);
            btn_agregar.ForeColor = Color.White;
            btn_agregar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_agregar.FlatAppearance.BorderSize = 0;
            btn_agregar.Cursor = Cursors.Hand;

            // ===== BOTÓN EDITAR - Azul =====
            btn_editar.FlatStyle = FlatStyle.Flat;
            btn_editar.BackColor = Color.FromArgb(33, 150, 243);
            btn_editar.ForeColor = Color.White;
            btn_editar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_editar.FlatAppearance.BorderSize = 0;
            btn_editar.Cursor = Cursors.Hand;

            // ===== BOTÓN ELIMINAR - Rojo =====
            btn_eliminar.FlatStyle = FlatStyle.Flat;
            btn_eliminar.BackColor = Color.FromArgb(244, 67, 54);
            btn_eliminar.ForeColor = Color.White;
            btn_eliminar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_eliminar.FlatAppearance.BorderSize = 0;
            btn_eliminar.Cursor = Cursors.Hand;

            // ===== BOTONES DE CONSULTA - Colores Pastel =====

            // Botón Mostrar Todo - Azul claro
            btn_mostrar.FlatStyle = FlatStyle.Flat;
            btn_mostrar.BackColor = Color.FromArgb(227, 242, 253);
            btn_mostrar.ForeColor = Color.FromArgb(33, 33, 33);
            btn_mostrar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_mostrar.FlatAppearance.BorderColor = Color.FromArgb(200, 230, 255);
            btn_mostrar.Cursor = Cursors.Hand;

            // Botón Solo Agua - Celeste
            btn_soloAgua.FlatStyle = FlatStyle.Flat;
            btn_soloAgua.BackColor = Color.FromArgb(225, 245, 254);
            btn_soloAgua.ForeColor = Color.FromArgb(33, 33, 33);
            btn_soloAgua.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_soloAgua.FlatAppearance.BorderColor = Color.FromArgb(179, 229, 252);
            btn_soloAgua.Cursor = Cursors.Hand;

            // Botón Solo Leche - Amarillo pastel
            btn_soloLeche.FlatStyle = FlatStyle.Flat;
            btn_soloLeche.BackColor = Color.FromArgb(255, 249, 196);
            btn_soloLeche.ForeColor = Color.FromArgb(33, 33, 33);
            btn_soloLeche.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_soloLeche.FlatAppearance.BorderColor = Color.FromArgb(255, 245, 157);
            btn_soloLeche.Cursor = Cursors.Hand;

            // Botón Más Cantidad - Verde claro
            btn_masCanti.FlatStyle = FlatStyle.Flat;
            btn_masCanti.BackColor = Color.FromArgb(232, 245, 233);
            btn_masCanti.ForeColor = Color.FromArgb(33, 33, 33);
            btn_masCanti.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_masCanti.FlatAppearance.BorderColor = Color.FromArgb(200, 230, 201);
            btn_masCanti.Cursor = Cursors.Hand;

            // Botón Menos Cantidad - Rosa claro
            btn_menosCanti.FlatStyle = FlatStyle.Flat;
            btn_menosCanti.BackColor = Color.FromArgb(252, 228, 236);
            btn_menosCanti.ForeColor = Color.FromArgb(33, 33, 33);
            btn_menosCanti.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_menosCanti.FlatAppearance.BorderColor = Color.FromArgb(248, 187, 208);
            btn_menosCanti.Cursor = Cursors.Hand;

            // ===== CAJAS DE TEXTO =====
            txt_nombre.Font = new Font("Segoe UI", 10);
            txt_cantidad.Font = new Font("Segoe UI", 10);
        }

        /// <summary>
        /// Pinta el fondo del formulario con un degradado suave
        /// </summary>
        private void frm_neveria_Paint(object sender, PaintEventArgs e)
        {
            // Crear un degradado vertical de azul claro a blanco
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(240, 248, 255),  // Color inicial (azul claro)
                Color.FromArgb(255, 255, 255),  // Color final (blanco)
                90f))  // Ángulo de 90 grados (vertical)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario
        /// Carga automáticamente el inventario desde la base de datos
        /// </summary>
        private void frm_neveria_Load(object sender, EventArgs e)
        {
            CargarInventarioDesdeBD();
        }

        #endregion

        #region Eventos de Botones - CRUD

        /// <summary>
        /// Botón AGREGAR: Inserta un nuevo helado en la base de datos
        /// Valida los campos antes de guardar
        /// </summary>
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            // ===== VALIDACIONES =====

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_cantidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la cantidad sea un número positivo
            if (!int.TryParse(txt_cantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya seleccionado un tipo
            if (!rb_leche.Checked && !rb_agua.Checked)
            {
                MessageBox.Show("Seleccione el tipo de helado (Leche o Agua).", "Tipo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== PREPARAR DATOS =====
            string nombre = txt_nombre.Text.Trim();
            string tipo = rb_leche.Checked ? "Leche" : "Agua";

            // ===== INSERTAR EN BASE DE DATOS =====
            string sql = "INSERT INTO helados (nombre, tipo, cantidad) VALUES (@nombre, @tipo, @cantidad)";
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);

                    // Agregar parámetros para prevenir SQL Injection
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

                    comando.ExecuteNonQuery();

                    // Mensaje de éxito
                    MessageBox.Show($"¡Helado agregado exitosamente!\n\nNombre: {nombre}\nTipo: {tipo}\nCantidad: {cantidad}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el inventario para mostrar el nuevo registro
                    CargarInventarioDesdeBD();
                    LimpiarCampos();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Botón EDITAR: Modifica un helado existente
        /// Funciona en dos modos:
        /// 1. Buscar por ID (solicita ID y carga datos)
        /// 2. Guardar cambios (actualiza en la BD)
        /// </summary>
        private void btn_editar_Click(object sender, EventArgs e)
        {
            // ===== MODO 1: GUARDAR CAMBIOS =====
            // Si el botón tiene un ID guardado en Tag, significa que ya se buscó el helado
            if (btn_editar.Tag != null)
            {
                // Validar campos antes de actualizar
                if (string.IsNullOrWhiteSpace(txt_nombre.Text) || !int.TryParse(txt_cantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Complete los campos correctamente.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rb_leche.Checked && !rb_agua.Checked)
                {
                    MessageBox.Show("Seleccione el tipo de helado.", "Tipo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el ID guardado temporalmente
                int idModificar = (int)btn_editar.Tag;
                string nombre = txt_nombre.Text.Trim();
                string tipo = rb_leche.Checked ? "Leche" : "Agua";

                // Actualizar en la base de datos
                string sql = "UPDATE helados SET nombre = @nombre, tipo = @tipo, cantidad = @cantidad WHERE id = @id";
                using (MySqlConnection conexionBD = Conexion.conexion())
                {
                    try
                    {
                        conexionBD.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@cantidad", cantidad);
                        comando.Parameters.AddWithValue("@id", idModificar);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("¡Helado modificado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Restaurar el botón a su estado normal
                        btn_editar.Tag = null;
                        btn_editar.Text = "Editar";
                        btn_editar.BackColor = Color.FromArgb(33, 150, 243);

                        CargarInventarioDesdeBD();
                        LimpiarCampos();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al actualizar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // ===== MODO 2: BUSCAR POR ID =====
            else
            {
                // Solicitar el ID del helado a modificar
                string inputId = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el ID del helado que desea modificar:",
                    "Buscar Helado por ID",
                    "",
                    -1, -1
                );

                // Si el usuario canceló, salir
                if (string.IsNullOrWhiteSpace(inputId))
                {
                    return;
                }

                // Validar que el ID sea un número válido
                if (!int.TryParse(inputId, out int idBuscado))
                {
                    MessageBox.Show("El ID debe ser un número válido.", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buscar el helado en la base de datos
                string sqlBuscar = "SELECT id, nombre, tipo, cantidad FROM helados WHERE id = @id";
                using (MySqlConnection conexionBD = Conexion.conexion())
                {
                    try
                    {
                        conexionBD.Open();
                        MySqlCommand comando = new MySqlCommand(sqlBuscar, conexionBD);
                        comando.Parameters.AddWithValue("@id", idBuscado);
                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.Read())
                        {
                            // Helado encontrado - llenar los campos del formulario
                            txt_nombre.Text = reader.GetString("nombre");
                            txt_cantidad.Text = reader.GetInt32("cantidad").ToString();
                            string tipo = reader.GetString("tipo");
                            rb_leche.Checked = tipo == "Leche";
                            rb_agua.Checked = tipo == "Agua";

                            reader.Close();

                            // Preguntar al usuario si desea continuar con la modificación
                            DialogResult resultado = MessageBox.Show(
                                $"Helado encontrado:\n\nNombre: {txt_nombre.Text}\nTipo: {tipo}\nCantidad: {txt_cantidad.Text}\n\n¿Desea modificar este registro?",
                                "Confirmar modificación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (resultado == DialogResult.Yes)
                            {
                                // Enfocar el campo nombre para facilitar la edición
                                txt_nombre.Focus();
                                txt_nombre.SelectAll();

                                MessageBox.Show("Modifique los campos necesarios y presione 'Editar' nuevamente para guardar.", "Modo edición activado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Guardar el ID temporalmente en la propiedad Tag del botón
                                btn_editar.Tag = idBuscado;

                                // Cambiar apariencia del botón para indicar modo "guardar"
                                btn_editar.Text = "💾 Guardar";
                                btn_editar.BackColor = Color.FromArgb(255, 152, 0); // Naranja
                            }
                            else
                            {
                                LimpiarCampos();
                            }
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show($"No se encontró ningún helado con el ID {idBuscado}.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al buscar el helado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Botón ELIMINAR: Elimina un helado seleccionado de la tabla
        /// Solicita confirmación antes de eliminar
        /// </summary>
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya una fila seleccionada
            if (dgv_inventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un helado para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del helado seleccionado
            int index = dgv_inventario.SelectedRows[0].Index;
            int idAEliminar = inventario[index].id;
            string nombreHelado = inventario[index].nombre;

            // Solicitar confirmación al usuario
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el helado '{nombreHelado}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                // Eliminar de la base de datos
                string sql = "DELETE FROM helados WHERE id = @id";
                using (MySqlConnection conexionBD = Conexion.conexion())
                {
                    try
                    {
                        conexionBD.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.Parameters.AddWithValue("@id", idAEliminar);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Helado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar inventario actualizado
                        CargarInventarioDesdeBD();
                        LimpiarCampos();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al eliminar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Eventos de Botones - CONSULTAS

        /// <summary>
        /// Botón CONSULTA: Mostrar solo helados de LECHE
        /// </summary>
        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            ConsultarPorTipo("Leche");
        }

        /// <summary>
        /// Botón CONSULTA: Mostrar solo helados de AGUA
        /// </summary>
        private void btn_consulta2_Click(object sender, EventArgs e)
        {
            ConsultarPorTipo("Agua");
        }

        /// <summary>
        /// Método auxiliar para consultar helados por tipo (Leche o Agua)
        /// Ejecuta una consulta SQL con filtro WHERE
        /// </summary>
        /// <param name="tipo">Tipo de helado: "Leche" o "Agua"</param>
        private void ConsultarPorTipo(string tipo)
        {
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados WHERE tipo = @tipo ORDER BY nombre";
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    MySqlDataReader reader = comando.ExecuteReader();

                    dgv_inventario.Rows.Clear();
                    int registros = 0;

                    // Leer todos los registros que coincidan
                    while (reader.Read())
                    {
                        dgv_inventario.Rows.Add(
                            reader.GetInt32("id"),
                            reader.GetString("nombre"),
                            reader.GetString("tipo"),
                            reader.GetInt32("cantidad")
                        );
                        registros++;
                    }
                    reader.Close();

                    // Si no hay resultados, informar al usuario
                    if (registros == 0)
                    {
                        MessageBox.Show($"No hay helados de tipo '{tipo}' en el inventario.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error en la consulta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Botón CONSULTA: Mostrar el helado con MAYOR cantidad
        /// </summary>
        private void btn_masCanti_Click(object sender, EventArgs e)
        {
            // Consulta SQL que ordena por cantidad descendente y toma el primero
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados ORDER BY cantidad DESC LIMIT 1";
            MostrarConsultaEspecial(sql, "Mayor cantidad");
        }

        /// <summary>
        /// Botón CONSULTA: Mostrar el helado con MENOR cantidad
        /// </summary>
        private void btn_menosCanti_Click(object sender, EventArgs e)
        {
            // Consulta SQL que ordena por cantidad ascendente y toma el primero
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados ORDER BY cantidad ASC LIMIT 1";
            MostrarConsultaEspecial(sql, "Menor cantidad");
        }

        /// <summary>
        /// Método auxiliar para mostrar consultas especiales (mayor/menor cantidad)
        /// </summary>
        /// <param name="sql">Consulta SQL a ejecutar</param>
        /// <param name="titulo">Título descriptivo para mostrar en la tabla</param>
        private void MostrarConsultaEspecial(string sql, string titulo)
        {
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    MySqlDataReader reader = comando.ExecuteReader();

                    dgv_inventario.Rows.Clear();

                    if (reader.Read())
                    {
                        // Mostrar el resultado con un título descriptivo
                        dgv_inventario.Rows.Add(
                            reader.GetInt32("id"),
                            $"{titulo}: {reader.GetString("nombre")}",
                            reader.GetString("tipo"),
                            reader.GetInt32("cantidad")
                        );
                    }
                    else
                    {
                        MessageBox.Show("No hay helados en el inventario.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error en la consulta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Botón MOSTRAR TODO: Recarga el inventario completo desde la base de datos
        /// </summary>
        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            CargarInventarioDesdeBD();
        }

        /// <summary>
        /// Botón SALIR: Cierra el formulario
        /// </summary>
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Carga todos los helados desde la base de datos al arreglo en memoria
        /// y los muestra en el DataGridView
        /// Se ejecuta al iniciar la aplicación y después de cada modificación
        /// </summary>
        private void CargarInventarioDesdeBD()
        {
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados ORDER BY id";
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    MySqlDataReader reader = comando.ExecuteReader();

                    // Reiniciar contador y limpiar tabla
                    contador = 0;
                    dgv_inventario.Rows.Clear();

                    // Leer cada registro de la base de datos
                    while (reader.Read() && contador < inventario.Length)
                    {
                        // Guardar en el arreglo en memoria
                        inventario[contador] = new Helado
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            tipo = reader.GetString("tipo"),
                            cantidad = reader.GetInt32("cantidad")
                        };

                        // Agregar fila al DataGridView
                        dgv_inventario.Rows.Add(
                            inventario[contador].id,
                            inventario[contador].nombre,
                            inventario[contador].tipo,
                            inventario[contador].cantidad
                        );

                        contador++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el inventario:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario y devuelve el foco al nombre
        /// </summary>
        private void LimpiarCampos()
        {
            txt_nombre.Clear();
            txt_cantidad.Clear();
            rb_leche.Checked = false;
            rb_agua.Checked = false;
            txt_nombre.Focus();  // Devolver el foco al primer campo
        }

        /// <summary>
        /// Evento que se dispara cuando se selecciona una fila diferente en el DataGridView
        /// Llena automáticamente los campos del formulario con los datos del helado seleccionado
        /// </summary>
        private void dgv_inventario_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgv_inventario.SelectedRows.Count > 0)
            {
                int index = dgv_inventario.SelectedRows[0].Index;

                // Validar que el índice esté dentro del rango del arreglo
                if (index < contador)
                {
                    // Llenar los campos con los datos del helado seleccionado
                    txt_nombre.Text = inventario[index].nombre;
                    txt_cantidad.Text = inventario[index].cantidad.ToString();
                    rb_leche.Checked = inventario[index].tipo == "Leche";
                    rb_agua.Checked = inventario[index].tipo == "Agua";
                }
            }
        }

        #endregion
    }
}