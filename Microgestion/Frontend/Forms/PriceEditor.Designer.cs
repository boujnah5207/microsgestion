﻿namespace SysQ.Microgestion.Frontend.Forms
{
    partial class PriceEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtNew = new Xceed.Editors.WinNumericTextBox();
            this.dropDownButton1 = new Xceed.Editors.WinButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).BeginInit();
            this.txtNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Precio Actual:";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(91, 14);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(138, 20);
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(73, 86);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "&Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // txtNew
            // 
            this.txtNew.Controls.Add(this.dropDownButton1);
            this.txtNew.DisplayFormatSpecifier = "c";
            this.txtNew.DropDownButton = this.dropDownButton1;
            // 
            // 
            // 
            this.txtNew.DropDownControl.CausesValidation = false;
            this.txtNew.DropDownControl.Size = new System.Drawing.Size(135, 110);
            this.txtNew.DropDownControl.TabIndex = 0;
            this.txtNew.Location = new System.Drawing.Point(91, 44);
            this.txtNew.MinValue = 0;
            this.txtNew.Name = "txtNew";
            this.txtNew.NullValue = 0;
            this.txtNew.Size = new System.Drawing.Size(137, 20);
            this.txtNew.TabIndex = 1;
            // 
            // 
            // 
            this.txtNew.TextBoxArea.Name = "";
            this.txtNew.TextBoxArea.TabIndex = 0;
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.BackColor = System.Drawing.SystemColors.Control;
            this.dropDownButton1.ButtonType = new Xceed.Editors.ButtonType(Xceed.Editors.ButtonBackgroundImageType.Combo, Xceed.Editors.ButtonImageType.ScrollDown);
            this.dropDownButton1.CanSelect = false;
            this.dropDownButton1.CausesValidation = false;
            this.dropDownButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dropDownButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dropDownButton1.Location = new System.Drawing.Point(118, 0);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(17, 18);
            this.dropDownButton1.TabIndex = 1;
            // 
            // PriceEditor
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(241, 121);
            this.ControlBox = false;
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PriceEditor";
            this.ShowInTaskbar = false;
            this.Text = "Cambiar Precio";
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).EndInit();
            this.txtNew.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private Xceed.Editors.WinNumericTextBox txtNew;
        private Xceed.Editors.WinButton dropDownButton1;
    }
}