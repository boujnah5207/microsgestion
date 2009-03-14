namespace Blackspot.Microgestion.Frontend.Forms
{
    partial class ItemEditor
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInternalCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExternalCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDefaultSalesAmount = new System.Windows.Forms.TextBox();
            this.chkMovesStock = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBaseMeasurement = new System.Windows.Forms.TextBox();
            this.btnLookupMeasurement = new System.Windows.Forms.Button();
            this.btnPrices = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMinimumStock = new System.Windows.Forms.TextBox();
            this.btnLookupItemType = new System.Windows.Forms.Button();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(276, 257);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "&Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // txtInternalCode
            // 
            this.txtInternalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInternalCode.Location = new System.Drawing.Point(120, 38);
            this.txtInternalCode.MaxLength = 50;
            this.txtInternalCode.Name = "txtInternalCode";
            this.txtInternalCode.Size = new System.Drawing.Size(312, 20);
            this.txtInternalCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Código Interno:";
            // 
            // txtExternalCode
            // 
            this.txtExternalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalCode.Location = new System.Drawing.Point(120, 64);
            this.txtExternalCode.MaxLength = 50;
            this.txtExternalCode.Name = "txtExternalCode";
            this.txtExternalCode.Size = new System.Drawing.Size(312, 20);
            this.txtExternalCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código Externo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Unidad de Medida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cantidad en Ventas:";
            // 
            // txtDefaultSalesAmount
            // 
            this.txtDefaultSalesAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultSalesAmount.Location = new System.Drawing.Point(120, 146);
            this.txtDefaultSalesAmount.MaxLength = 50;
            this.txtDefaultSalesAmount.Name = "txtDefaultSalesAmount";
            this.txtDefaultSalesAmount.Size = new System.Drawing.Size(108, 20);
            this.txtDefaultSalesAmount.TabIndex = 7;
            // 
            // chkMovesStock
            // 
            this.chkMovesStock.AutoSize = true;
            this.chkMovesStock.Location = new System.Drawing.Point(120, 202);
            this.chkMovesStock.Name = "chkMovesStock";
            this.chkMovesStock.Size = new System.Drawing.Size(13, 12);
            this.chkMovesStock.TabIndex = 10;
            this.chkMovesStock.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mueve Stock:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Stock Mínimo:";
            // 
            // txtBaseMeasurement
            // 
            this.txtBaseMeasurement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseMeasurement.BackColor = System.Drawing.SystemColors.Window;
            this.txtBaseMeasurement.Location = new System.Drawing.Point(120, 90);
            this.txtBaseMeasurement.MaxLength = 50;
            this.txtBaseMeasurement.Name = "txtBaseMeasurement";
            this.txtBaseMeasurement.ReadOnly = true;
            this.txtBaseMeasurement.Size = new System.Drawing.Size(288, 20);
            this.txtBaseMeasurement.TabIndex = 3;
            this.txtBaseMeasurement.TabStop = false;
            // 
            // btnLookupMeasurement
            // 
            this.btnLookupMeasurement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLookupMeasurement.Location = new System.Drawing.Point(408, 90);
            this.btnLookupMeasurement.Name = "btnLookupMeasurement";
            this.btnLookupMeasurement.Size = new System.Drawing.Size(24, 20);
            this.btnLookupMeasurement.TabIndex = 4;
            this.btnLookupMeasurement.Text = "...";
            this.btnLookupMeasurement.UseVisualStyleBackColor = true;
            // 
            // btnPrices
            // 
            this.btnPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrices.Location = new System.Drawing.Point(408, 172);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(24, 20);
            this.btnPrices.TabIndex = 9;
            this.btnPrices.Text = "...";
            this.btnPrices.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Precio Actual:";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrice.Location = new System.Drawing.Point(120, 172);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(288, 20);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.TabStop = false;
            // 
            // txtMinimumStock
            // 
            this.txtMinimumStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinimumStock.Location = new System.Drawing.Point(120, 221);
            this.txtMinimumStock.MaxLength = 50;
            this.txtMinimumStock.Name = "txtMinimumStock";
            this.txtMinimumStock.Size = new System.Drawing.Size(108, 20);
            this.txtMinimumStock.TabIndex = 11;
            // 
            // btnLookupItemType
            // 
            this.btnLookupItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLookupItemType.Location = new System.Drawing.Point(408, 118);
            this.btnLookupItemType.Name = "btnLookupItemType";
            this.btnLookupItemType.Size = new System.Drawing.Size(24, 20);
            this.btnLookupItemType.TabIndex = 6;
            this.btnLookupItemType.Text = "...";
            this.btnLookupItemType.UseVisualStyleBackColor = true;
            // 
            // txtItemType
            // 
            this.txtItemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemType.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemType.Location = new System.Drawing.Point(120, 118);
            this.txtItemType.MaxLength = 50;
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.ReadOnly = true;
            this.txtItemType.Size = new System.Drawing.Size(288, 20);
            this.txtItemType.TabIndex = 5;
            this.txtItemType.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Rubro:";
            // 
            // ItemEditor
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 292);
            this.ControlBox = false;
            this.Controls.Add(this.btnLookupItemType);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMinimumStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPrices);
            this.Controls.Add(this.btnLookupMeasurement);
            this.Controls.Add(this.txtBaseMeasurement);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkMovesStock);
            this.Controls.Add(this.txtDefaultSalesAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExternalCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInternalCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "ItemEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Artículo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInternalCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExternalCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDefaultSalesAmount;
        private System.Windows.Forms.CheckBox chkMovesStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBaseMeasurement;
        private System.Windows.Forms.Button btnLookupMeasurement;
        private System.Windows.Forms.Button btnPrices;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMinimumStock;
        private System.Windows.Forms.Button btnLookupItemType;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.Label label7;
    }
}