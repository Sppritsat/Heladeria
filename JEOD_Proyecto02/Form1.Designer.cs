namespace JEOD_Proyecto02
{
    partial class frm_neveria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_neveria));
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_nomHel = new System.Windows.Forms.Label();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.rb_agua = new System.Windows.Forms.RadioButton();
            this.rb_leche = new System.Windows.Forms.RadioButton();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.btn_menosCanti = new System.Windows.Forms.Button();
            this.btn_masCanti = new System.Windows.Forms.Button();
            this.btn_soloLeche = new System.Windows.Forms.Button();
            this.lbl_consultas = new System.Windows.Forms.Label();
            this.btn_soloAgua = new System.Windows.Forms.Button();
            this.dgv_inventario = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.BackColor = System.Drawing.Color.BlueViolet;
            this.lbl_titulo.Font = new System.Drawing.Font("Malgun Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.Black;
            this.lbl_titulo.Location = new System.Drawing.Point(14, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(682, 45);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "🍦 INVENTARIO DE LA NEVERÍA DE JOSE";
            // 
            // lbl_nomHel
            // 
            this.lbl_nomHel.AutoSize = true;
            this.lbl_nomHel.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomHel.ForeColor = System.Drawing.Color.Black;
            this.lbl_nomHel.Location = new System.Drawing.Point(3, 29);
            this.lbl_nomHel.Name = "lbl_nomHel";
            this.lbl_nomHel.Size = new System.Drawing.Size(138, 38);
            this.lbl_nomHel.TabIndex = 2;
            this.lbl_nomHel.Text = "Nombre: ";
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cantidad.ForeColor = System.Drawing.Color.Black;
            this.lbl_cantidad.Location = new System.Drawing.Point(9, 177);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(132, 38);
            this.lbl_cantidad.TabIndex = 4;
            this.lbl_cantidad.Text = "Cantidad";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_editar);
            this.groupBox1.Controls.Add(this.btn_eliminar);
            this.groupBox1.Controls.Add(this.btn_agregar);
            this.groupBox1.Controls.Add(this.rb_agua);
            this.groupBox1.Controls.Add(this.rb_leche);
            this.groupBox1.Controls.Add(this.txt_cantidad);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Controls.Add(this.lbl_cantidad);
            this.groupBox1.Controls.Add(this.lbl_tipo);
            this.groupBox1.Controls.Add(this.lbl_nomHel);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 370);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Helados";
            // 
            // btn_editar
            // 
            this.btn_editar.BackColor = System.Drawing.Color.MediumPurple;
            this.btn_editar.ForeColor = System.Drawing.Color.Black;
            this.btn_editar.Location = new System.Drawing.Point(313, 257);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(120, 65);
            this.btn_editar.TabIndex = 12;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.MediumPurple;
            this.btn_eliminar.Location = new System.Drawing.Point(169, 257);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(120, 65);
            this.btn_eliminar.TabIndex = 11;
            this.btn_eliminar.Text = "Eliminar ×";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.MediumPurple;
            this.btn_agregar.Location = new System.Drawing.Point(16, 257);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(120, 65);
            this.btn_agregar.TabIndex = 10;
            this.btn_agregar.Text = "Agregar ✓";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // rb_agua
            // 
            this.rb_agua.AutoSize = true;
            this.rb_agua.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_agua.ForeColor = System.Drawing.Color.Black;
            this.rb_agua.Location = new System.Drawing.Point(259, 111);
            this.rb_agua.Name = "rb_agua";
            this.rb_agua.Size = new System.Drawing.Size(89, 35);
            this.rb_agua.TabIndex = 9;
            this.rb_agua.TabStop = true;
            this.rb_agua.Text = "Agua";
            this.rb_agua.UseVisualStyleBackColor = true;
            // 
            // rb_leche
            // 
            this.rb_leche.AutoSize = true;
            this.rb_leche.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_leche.ForeColor = System.Drawing.Color.Black;
            this.rb_leche.Location = new System.Drawing.Point(125, 108);
            this.rb_leche.Name = "rb_leche";
            this.rb_leche.Size = new System.Drawing.Size(94, 35);
            this.rb_leche.TabIndex = 8;
            this.rb_leche.TabStop = true;
            this.rb_leche.Text = "Leche";
            this.rb_leche.UseVisualStyleBackColor = true;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad.Location = new System.Drawing.Point(159, 177);
            this.txt_cantidad.Multiline = true;
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(58, 38);
            this.txt_cantidad.TabIndex = 7;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(145, 29);
            this.txt_nombre.Multiline = true;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(288, 38);
            this.txt_nombre.TabIndex = 5;
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipo.ForeColor = System.Drawing.Color.Black;
            this.lbl_tipo.Location = new System.Drawing.Point(3, 105);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(79, 38);
            this.lbl_tipo.TabIndex = 3;
            this.lbl_tipo.Text = "Tipo:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_mostrar);
            this.groupBox2.Controls.Add(this.btn_menosCanti);
            this.groupBox2.Controls.Add(this.btn_masCanti);
            this.groupBox2.Controls.Add(this.btn_soloLeche);
            this.groupBox2.Controls.Add(this.lbl_consultas);
            this.groupBox2.Controls.Add(this.btn_soloAgua);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1311, 150);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultas";
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.BackColor = System.Drawing.Color.White;
            this.btn_mostrar.ForeColor = System.Drawing.Color.Black;
            this.btn_mostrar.Location = new System.Drawing.Point(12, 71);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(250, 45);
            this.btn_mostrar.TabIndex = 13;
            this.btn_mostrar.Text = "Mostrar todo";
            this.btn_mostrar.UseVisualStyleBackColor = false;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btn_menosCanti
            // 
            this.btn_menosCanti.BackColor = System.Drawing.Color.White;
            this.btn_menosCanti.ForeColor = System.Drawing.Color.Black;
            this.btn_menosCanti.Location = new System.Drawing.Point(1036, 71);
            this.btn_menosCanti.Name = "btn_menosCanti";
            this.btn_menosCanti.Size = new System.Drawing.Size(250, 45);
            this.btn_menosCanti.TabIndex = 15;
            this.btn_menosCanti.Text = "Helados con menos cantidad";
            this.btn_menosCanti.UseVisualStyleBackColor = false;
            this.btn_menosCanti.Click += new System.EventHandler(this.btn_menosCanti_Click);
            // 
            // btn_masCanti
            // 
            this.btn_masCanti.BackColor = System.Drawing.Color.White;
            this.btn_masCanti.ForeColor = System.Drawing.Color.Black;
            this.btn_masCanti.Location = new System.Drawing.Point(780, 71);
            this.btn_masCanti.Name = "btn_masCanti";
            this.btn_masCanti.Size = new System.Drawing.Size(250, 45);
            this.btn_masCanti.TabIndex = 14;
            this.btn_masCanti.Text = "Helados con mas cantidad";
            this.btn_masCanti.UseVisualStyleBackColor = false;
            this.btn_masCanti.Click += new System.EventHandler(this.btn_masCanti_Click);
            // 
            // btn_soloLeche
            // 
            this.btn_soloLeche.BackColor = System.Drawing.Color.White;
            this.btn_soloLeche.ForeColor = System.Drawing.Color.Black;
            this.btn_soloLeche.Location = new System.Drawing.Point(524, 71);
            this.btn_soloLeche.Name = "btn_soloLeche";
            this.btn_soloLeche.Size = new System.Drawing.Size(250, 45);
            this.btn_soloLeche.TabIndex = 13;
            this.btn_soloLeche.Text = "Helados de leche";
            this.btn_soloLeche.UseVisualStyleBackColor = false;
            this.btn_soloLeche.Click += new System.EventHandler(this.btn_consulta1_Click);
            // 
            // lbl_consultas
            // 
            this.lbl_consultas.AutoSize = true;
            this.lbl_consultas.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_consultas.ForeColor = System.Drawing.Color.Black;
            this.lbl_consultas.Location = new System.Drawing.Point(6, 26);
            this.lbl_consultas.Name = "lbl_consultas";
            this.lbl_consultas.Size = new System.Drawing.Size(138, 28);
            this.lbl_consultas.TabIndex = 12;
            this.lbl_consultas.Text = "Mostrar solo: ";
            // 
            // btn_soloAgua
            // 
            this.btn_soloAgua.BackColor = System.Drawing.Color.White;
            this.btn_soloAgua.ForeColor = System.Drawing.Color.Black;
            this.btn_soloAgua.Location = new System.Drawing.Point(268, 71);
            this.btn_soloAgua.Name = "btn_soloAgua";
            this.btn_soloAgua.Size = new System.Drawing.Size(250, 45);
            this.btn_soloAgua.TabIndex = 0;
            this.btn_soloAgua.Text = "Helados de agua";
            this.btn_soloAgua.UseVisualStyleBackColor = false;
            this.btn_soloAgua.Click += new System.EventHandler(this.btn_consulta2_Click);
            // 
            // dgv_inventario
            // 
            this.dgv_inventario.AllowDrop = true;
            this.dgv_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_nombre,
            this.col_tipo,
            this.col_cantidad});
            this.dgv_inventario.GridColor = System.Drawing.Color.Black;
            this.dgv_inventario.Location = new System.Drawing.Point(610, 71);
            this.dgv_inventario.Name = "dgv_inventario";
            this.dgv_inventario.RowHeadersWidth = 51;
            this.dgv_inventario.RowTemplate.Height = 24;
            this.dgv_inventario.Size = new System.Drawing.Size(553, 370);
            this.dgv_inventario.TabIndex = 7;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "Codigo";
            this.col_id.MinimumWidth = 6;
            this.col_id.Name = "col_id";
            this.col_id.Width = 125;
            // 
            // col_nombre
            // 
            this.col_nombre.HeaderText = "Nombre del helado";
            this.col_nombre.MinimumWidth = 6;
            this.col_nombre.Name = "col_nombre";
            this.col_nombre.Width = 125;
            // 
            // col_tipo
            // 
            this.col_tipo.HeaderText = "Tipo";
            this.col_tipo.MinimumWidth = 6;
            this.col_tipo.Name = "col_tipo";
            this.col_tipo.Width = 125;
            // 
            // col_cantidad
            // 
            this.col_cantidad.HeaderText = "Cantidad";
            this.col_cantidad.MinimumWidth = 6;
            this.col_cantidad.Name = "col_cantidad";
            this.col_cantidad.Width = 125;
            // 
            // frm_neveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1325, 594);
            this.Controls.Add(this.dgv_inventario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_neveria";
            this.Text = "Neveria de Jose";
            this.Load += new System.EventHandler(this.frm_neveria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_nomHel;
        private System.Windows.Forms.Label lbl_cantidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.RadioButton rb_agua;
        private System.Windows.Forms.RadioButton rb_leche;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_soloAgua;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.Button btn_menosCanti;
        private System.Windows.Forms.Button btn_masCanti;
        private System.Windows.Forms.Button btn_soloLeche;
        private System.Windows.Forms.Label lbl_consultas;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.DataGridView dgv_inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cantidad;
    }
}

