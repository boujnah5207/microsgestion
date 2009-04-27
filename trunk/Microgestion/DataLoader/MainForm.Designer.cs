namespace SysQ.Microgestion.DataLoader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvItemTypes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvMeasurements = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.importStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.importStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementSimbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movesStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimumStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.importStatusDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtFile.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtFile.Location = new System.Drawing.Point(66, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(633, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(705, 11);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Examinar...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(15, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 485);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previsualización de Resultados";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvItems);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(759, 466);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvItemTypes);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvMeasurements);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Size = new System.Drawing.Size(759, 193);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvItemTypes
            // 
            this.dgvItemTypes.AllowUserToAddRows = false;
            this.dgvItemTypes.AllowUserToDeleteRows = false;
            this.dgvItemTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemTypes.AutoGenerateColumns = false;
            this.dgvItemTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.importDataGridViewCheckBoxColumn,
            this.importStatusDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn});
            this.dgvItemTypes.DataSource = this.itemTypeRecordBindingSource;
            this.dgvItemTypes.Location = new System.Drawing.Point(6, 24);
            this.dgvItemTypes.MultiSelect = false;
            this.dgvItemTypes.Name = "dgvItemTypes";
            this.dgvItemTypes.ReadOnly = true;
            this.dgvItemTypes.RowHeadersVisible = false;
            this.dgvItemTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemTypes.Size = new System.Drawing.Size(364, 166);
            this.dgvItemTypes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rubros:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unidades de Medida:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.itemNameDataGridViewTextBoxColumn,
            this.internalCodeDataGridViewTextBoxColumn,
            this.externalCodeDataGridViewTextBoxColumn,
            this.itemTypeNameDataGridViewTextBoxColumn,
            this.measurementNameDataGridViewTextBoxColumn,
            this.measurementSimbolDataGridViewTextBoxColumn,
            this.movesStockDataGridViewTextBoxColumn,
            this.minimumStockDataGridViewTextBoxColumn,
            this.actualStockDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.importDataGridViewCheckBoxColumn1,
            this.importStatusDataGridViewTextBoxColumn2,
            this.messageDataGridViewTextBoxColumn2});
            this.dgvItems.DataSource = this.importDataBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(6, 21);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(750, 245);
            this.dgvItems.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Artículos:";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(602, 531);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(97, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Cargar Datos";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.Location = new System.Drawing.Point(15, 531);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(117, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Previsualizar Datos";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(705, 531);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgvMeasurements
            // 
            this.dgvMeasurements.AllowUserToAddRows = false;
            this.dgvMeasurements.AllowUserToDeleteRows = false;
            this.dgvMeasurements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMeasurements.AutoGenerateColumns = false;
            this.dgvMeasurements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasurements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.symbolDataGridViewTextBoxColumn,
            this.importDataGridViewCheckBoxColumn2,
            this.importStatusDataGridViewTextBoxColumn1,
            this.messageDataGridViewTextBoxColumn1});
            this.dgvMeasurements.DataSource = this.measurementRecordBindingSource;
            this.dgvMeasurements.Location = new System.Drawing.Point(6, 24);
            this.dgvMeasurements.MultiSelect = false;
            this.dgvMeasurements.Name = "dgvMeasurements";
            this.dgvMeasurements.ReadOnly = true;
            this.dgvMeasurements.RowHeadersVisible = false;
            this.dgvMeasurements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeasurements.Size = new System.Drawing.Size(373, 166);
            this.dgvMeasurements.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importDataGridViewCheckBoxColumn
            // 
            this.importDataGridViewCheckBoxColumn.DataPropertyName = "Import";
            this.importDataGridViewCheckBoxColumn.HeaderText = "Import";
            this.importDataGridViewCheckBoxColumn.Name = "importDataGridViewCheckBoxColumn";
            this.importDataGridViewCheckBoxColumn.ReadOnly = true;
            this.importDataGridViewCheckBoxColumn.Visible = false;
            // 
            // importStatusDataGridViewTextBoxColumn
            // 
            this.importStatusDataGridViewTextBoxColumn.DataPropertyName = "ImportStatus";
            this.importStatusDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.importStatusDataGridViewTextBoxColumn.Name = "importStatusDataGridViewTextBoxColumn";
            this.importStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Mensaje";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemTypeRecordBindingSource
            // 
            this.itemTypeRecordBindingSource.DataSource = typeof(SysQ.Microgestion.DataLoader.ItemTypeRecord);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // symbolDataGridViewTextBoxColumn
            // 
            this.symbolDataGridViewTextBoxColumn.DataPropertyName = "Symbol";
            this.symbolDataGridViewTextBoxColumn.HeaderText = "Abreviatura";
            this.symbolDataGridViewTextBoxColumn.Name = "symbolDataGridViewTextBoxColumn";
            this.symbolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importDataGridViewCheckBoxColumn2
            // 
            this.importDataGridViewCheckBoxColumn2.DataPropertyName = "Import";
            this.importDataGridViewCheckBoxColumn2.HeaderText = "Import";
            this.importDataGridViewCheckBoxColumn2.Name = "importDataGridViewCheckBoxColumn2";
            this.importDataGridViewCheckBoxColumn2.ReadOnly = true;
            this.importDataGridViewCheckBoxColumn2.Visible = false;
            // 
            // importStatusDataGridViewTextBoxColumn1
            // 
            this.importStatusDataGridViewTextBoxColumn1.DataPropertyName = "ImportStatus";
            this.importStatusDataGridViewTextBoxColumn1.HeaderText = "Estado";
            this.importStatusDataGridViewTextBoxColumn1.Name = "importStatusDataGridViewTextBoxColumn1";
            this.importStatusDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn1
            // 
            this.messageDataGridViewTextBoxColumn1.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn1.HeaderText = "Mensaje";
            this.messageDataGridViewTextBoxColumn1.Name = "messageDataGridViewTextBoxColumn1";
            this.messageDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // measurementRecordBindingSource
            // 
            this.measurementRecordBindingSource.DataSource = typeof(SysQ.Microgestion.DataLoader.MeasurementRecord);
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idDataGridViewTextBoxColumn2.Visible = false;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // internalCodeDataGridViewTextBoxColumn
            // 
            this.internalCodeDataGridViewTextBoxColumn.DataPropertyName = "InternalCode";
            this.internalCodeDataGridViewTextBoxColumn.HeaderText = "Codigo Interno";
            this.internalCodeDataGridViewTextBoxColumn.Name = "internalCodeDataGridViewTextBoxColumn";
            this.internalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // externalCodeDataGridViewTextBoxColumn
            // 
            this.externalCodeDataGridViewTextBoxColumn.DataPropertyName = "ExternalCode";
            this.externalCodeDataGridViewTextBoxColumn.HeaderText = "Codigo Externo";
            this.externalCodeDataGridViewTextBoxColumn.Name = "externalCodeDataGridViewTextBoxColumn";
            this.externalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemTypeNameDataGridViewTextBoxColumn
            // 
            this.itemTypeNameDataGridViewTextBoxColumn.DataPropertyName = "ItemTypeName";
            this.itemTypeNameDataGridViewTextBoxColumn.HeaderText = "Rubro";
            this.itemTypeNameDataGridViewTextBoxColumn.Name = "itemTypeNameDataGridViewTextBoxColumn";
            this.itemTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // measurementNameDataGridViewTextBoxColumn
            // 
            this.measurementNameDataGridViewTextBoxColumn.DataPropertyName = "MeasurementName";
            this.measurementNameDataGridViewTextBoxColumn.HeaderText = "Unidad de Medida";
            this.measurementNameDataGridViewTextBoxColumn.Name = "measurementNameDataGridViewTextBoxColumn";
            this.measurementNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // measurementSimbolDataGridViewTextBoxColumn
            // 
            this.measurementSimbolDataGridViewTextBoxColumn.DataPropertyName = "MeasurementSimbol";
            this.measurementSimbolDataGridViewTextBoxColumn.HeaderText = "MeasurementSimbol";
            this.measurementSimbolDataGridViewTextBoxColumn.Name = "measurementSimbolDataGridViewTextBoxColumn";
            this.measurementSimbolDataGridViewTextBoxColumn.ReadOnly = true;
            this.measurementSimbolDataGridViewTextBoxColumn.Visible = false;
            // 
            // movesStockDataGridViewTextBoxColumn
            // 
            this.movesStockDataGridViewTextBoxColumn.DataPropertyName = "MovesStock";
            this.movesStockDataGridViewTextBoxColumn.HeaderText = "Mueve Stock";
            this.movesStockDataGridViewTextBoxColumn.Name = "movesStockDataGridViewTextBoxColumn";
            this.movesStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // minimumStockDataGridViewTextBoxColumn
            // 
            this.minimumStockDataGridViewTextBoxColumn.DataPropertyName = "MinimumStock";
            this.minimumStockDataGridViewTextBoxColumn.HeaderText = "Stock Minimo";
            this.minimumStockDataGridViewTextBoxColumn.Name = "minimumStockDataGridViewTextBoxColumn";
            this.minimumStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actualStockDataGridViewTextBoxColumn
            // 
            this.actualStockDataGridViewTextBoxColumn.DataPropertyName = "ActualStock";
            this.actualStockDataGridViewTextBoxColumn.HeaderText = "Stock Actual";
            this.actualStockDataGridViewTextBoxColumn.Name = "actualStockDataGridViewTextBoxColumn";
            this.actualStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importDataGridViewCheckBoxColumn1
            // 
            this.importDataGridViewCheckBoxColumn1.DataPropertyName = "Import";
            this.importDataGridViewCheckBoxColumn1.HeaderText = "Import";
            this.importDataGridViewCheckBoxColumn1.Name = "importDataGridViewCheckBoxColumn1";
            this.importDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.importDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // importStatusDataGridViewTextBoxColumn2
            // 
            this.importStatusDataGridViewTextBoxColumn2.DataPropertyName = "ImportStatus";
            this.importStatusDataGridViewTextBoxColumn2.HeaderText = "Estado";
            this.importStatusDataGridViewTextBoxColumn2.Name = "importStatusDataGridViewTextBoxColumn2";
            this.importStatusDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn2
            // 
            this.messageDataGridViewTextBoxColumn2.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn2.HeaderText = "Mensaje";
            this.messageDataGridViewTextBoxColumn2.Name = "messageDataGridViewTextBoxColumn2";
            this.messageDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // importDataBindingSource
            // 
            this.importDataBindingSource.DataSource = typeof(SysQ.Microgestion.DataLoader.ImportData);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "Carga de Datos";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource itemTypeRecordBindingSource;
        private System.Windows.Forms.DataGridView dgvItemTypes;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource importDataBindingSource;
        private System.Windows.Forms.BindingSource measurementRecordBindingSource;
        private System.Windows.Forms.DataGridView dgvMeasurements;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn importDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn importDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn importStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn internalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementSimbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movesStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimumStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn importDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn importStatusDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn2;

    }
}