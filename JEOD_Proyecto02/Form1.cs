using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JEOD_Proyecto02
{
    public partial class frm_neveria : Form
    {
        // Definición del struct con ID
        struct Helado
        {
            public int id;
            public string nombre;
            public string tipo;
            public int cantidad;
        }

        // Arreglo de inventario y contador
        Helado[] inventario = new Helado[50];
        int contador = 0;

        public frm_neveria()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frm_neveria_Paint);
            EstilizarControles();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgv_inventario.ReadOnly = true;
            dgv_inventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_inventario.RowHeadersVisible = false;
            dgv_inventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_inventario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);
            dgv_inventario.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv_inventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv_inventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 255);
            dgv_inventario.EnableHeadersVisualStyles = false;
            dgv_inventario.BackgroundColor = Color.FromArgb(250, 250, 255);
        }

        private void EstilizarControles()
        {
            // Título principal - Color helado profesional
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

            // Botón AGREGAR - Verde
            btn_agregar.FlatStyle = FlatStyle.Flat;
            btn_agregar.BackColor = Color.FromArgb(76, 175, 80);
            btn_agregar.ForeColor = Color.White;
            btn_agregar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_agregar.FlatAppearance.BorderSize = 0;
            btn_agregar.Cursor = Cursors.Hand;

            // Botón EDITAR - Azul
            btn_editar.FlatStyle = FlatStyle.Flat;
            btn_editar.BackColor = Color.FromArgb(33, 150, 243);
            btn_editar.ForeColor = Color.White;
            btn_editar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_editar.FlatAppearance.BorderSize = 0;
            btn_editar.Cursor = Cursors.Hand;

            // Botón ELIMINAR - Rojo
            btn_eliminar.FlatStyle = FlatStyle.Flat;
            btn_eliminar.BackColor = Color.FromArgb(244, 67, 54);
            btn_eliminar.ForeColor = Color.White;
            btn_eliminar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_eliminar.FlatAppearance.BorderSize = 0;
            btn_eliminar.Cursor = Cursors.Hand;

            // Botones de CONSULTA - Colores pastel
            btn_mostrar.FlatStyle = FlatStyle.Flat;
            btn_mostrar.BackColor = Color.FromArgb(227, 242, 253); // Azul claro
            btn_mostrar.ForeColor = Color.FromArgb(33, 33, 33);
            btn_mostrar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_mostrar.FlatAppearance.BorderColor = Color.FromArgb(200, 230, 255);
            btn_mostrar.Cursor = Cursors.Hand;

            btn_soloAgua.FlatStyle = FlatStyle.Flat;
            btn_soloAgua.BackColor = Color.FromArgb(225, 245, 254); // Celeste
            btn_soloAgua.ForeColor = Color.FromArgb(33, 33, 33);
            btn_soloAgua.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_soloAgua.FlatAppearance.BorderColor = Color.FromArgb(179, 229, 252);
            btn_soloAgua.Cursor = Cursors.Hand;

            btn_soloLeche.FlatStyle = FlatStyle.Flat;
            btn_soloLeche.BackColor = Color.FromArgb(255, 249, 196); // Amarillo pastel
            btn_soloLeche.ForeColor = Color.FromArgb(33, 33, 33);
            btn_soloLeche.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_soloLeche.FlatAppearance.BorderColor = Color.FromArgb(255, 245, 157);
            btn_soloLeche.Cursor = Cursors.Hand;

            btn_masCanti.FlatStyle = FlatStyle.Flat;
            btn_masCanti.BackColor = Color.FromArgb(232, 245, 233); // Verde claro
            btn_masCanti.ForeColor = Color.FromArgb(33, 33, 33);
            btn_masCanti.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_masCanti.FlatAppearance.BorderColor = Color.FromArgb(200, 230, 201);
            btn_masCanti.Cursor = Cursors.Hand;

            btn_menosCanti.FlatStyle = FlatStyle.Flat;
            btn_menosCanti.BackColor = Color.FromArgb(252, 228, 236); // Rosa claro
            btn_menosCanti.ForeColor = Color.FromArgb(33, 33, 33);
            btn_menosCanti.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_menosCanti.FlatAppearance.BorderColor = Color.FromArgb(248, 187, 208);
            btn_menosCanti.Cursor = Cursors.Hand;

            // TextBoxes
            txt_nombre.Font = new Font("Segoe UI", 10);
            txt_cantidad.Font = new Font("Segoe UI", 10);
        }

        private void frm_neveria_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(240, 248, 255),
                Color.FromArgb(255, 255, 255),
                90f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void frm_neveria_Load(object sender, EventArgs e)
        {
            CargarInventarioDesdeBD(); // Carga automática al iniciar
        }

        // =============== BOTONES ===============

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_cantidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_cantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rb_leche.Checked && !rb_agua.Checked)
            {
                MessageBox.Show("Seleccione el tipo de helado (Leche o Agua).", "Tipo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txt_nombre.Text.Trim();
            string tipo = rb_leche.Checked ? "Leche" : "Agua";

            string sql = "INSERT INTO helados (nombre, tipo, cantidad) VALUES (@nombre, @tipo, @cantidad)";
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.ExecuteNonQuery();

                    MessageBox.Show($"¡Helado agregado exitosamente!\n\nNombre: {nombre}\nTipo: {tipo}\nCantidad: {cantidad}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar desde la BD para mantener sincronización
                    CargarInventarioDesdeBD();
                    LimpiarCampos();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            // MODO 1: Si ya está en modo edición (guardar cambios)
            if (btn_editar.Tag != null)
            {
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

                int idModificar = (int)btn_editar.Tag;
                string nombre = txt_nombre.Text.Trim();
                string tipo = rb_leche.Checked ? "Leche" : "Agua";

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
            // MODO 2: Si está en modo normal (buscar por ID)
            else
            {
                // Solicitar el ID al usuario
                string inputId = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el ID del helado que desea modificar:",
                    "Buscar Helado por ID",
                    "",
                    -1, -1
                );

                // Validar que ingresó algo
                if (string.IsNullOrWhiteSpace(inputId))
                {
                    return; // Usuario canceló o no ingresó nada
                }

                // Validar que sea un número
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
                            // Helado encontrado - llenar los campos
                            txt_nombre.Text = reader.GetString("nombre");
                            txt_cantidad.Text = reader.GetInt32("cantidad").ToString();
                            string tipo = reader.GetString("tipo");
                            rb_leche.Checked = tipo == "Leche";
                            rb_agua.Checked = tipo == "Agua";

                            reader.Close();

                            // Confirmar si desea modificar
                            DialogResult resultado = MessageBox.Show(
                                $"Helado encontrado:\n\nNombre: {txt_nombre.Text}\nTipo: {tipo}\nCantidad: {txt_cantidad.Text}\n\n¿Desea modificar este registro?",
                                "Confirmar modificación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (resultado == DialogResult.Yes)
                            {
                                txt_nombre.Focus();
                                txt_nombre.SelectAll();
                                MessageBox.Show("Modifique los campos necesarios y presione 'Editar' nuevamente para guardar.", "Modo edición activado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Guardar el ID temporalmente y cambiar apariencia del botón
                                btn_editar.Tag = idBuscado;
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

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_inventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un helado para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgv_inventario.SelectedRows[0].Index;
            int idAEliminar = inventario[index].id;
            string nombreHelado = inventario[index].nombre;

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el helado '{nombreHelado}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
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

                        // Recargar desde la BD
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

        // CONSULTAS OPTIMIZADAS - Directamente desde la BD
        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            ConsultarPorTipo("Leche");
        }

        private void btn_consulta2_Click(object sender, EventArgs e)
        {
            ConsultarPorTipo("Agua");
        }

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

        private void btn_masCanti_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados ORDER BY cantidad DESC LIMIT 1";
            MostrarConsultaEspecial(sql, "Mayor cantidad");
        }

        private void btn_menosCanti_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id, nombre, tipo, cantidad FROM helados ORDER BY cantidad ASC LIMIT 1";
            MostrarConsultaEspecial(sql, "Menor cantidad");
        }

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

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            CargarInventarioDesdeBD();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =============== MÉTODOS AUXILIARES ===============

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

                    contador = 0;
                    dgv_inventario.Rows.Clear();

                    while (reader.Read() && contador < inventario.Length)
                    {
                        inventario[contador] = new Helado
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            tipo = reader.GetString("tipo"),
                            cantidad = reader.GetInt32("cantidad")
                        };

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

        private void LimpiarCampos()
        {
            txt_nombre.Clear();
            txt_cantidad.Clear();
            rb_leche.Checked = false;
            rb_agua.Checked = false;
            txt_nombre.Focus();
        }

        private void dgv_inventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_inventario.SelectedRows.Count > 0)
            {
                int index = dgv_inventario.SelectedRows[0].Index;

                if (index < contador)
                {
                    txt_nombre.Text = inventario[index].nombre;
                    txt_cantidad.Text = inventario[index].cantidad.ToString();
                    rb_leche.Checked = inventario[index].tipo == "Leche";
                    rb_agua.Checked = inventario[index].tipo == "Agua";
                }
            }
        }
    }
}