﻿namespace modbus_test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.IN_IP = new System.Windows.Forms.TextBox();
            this.IN_PROT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.线圈DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.输入状态DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.保持寄存器DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.输入寄存器DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modbusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.my_DBDataSet = new modbus_test.my_DBDataSet();
            this.modbusTableAdapter = new modbus_test.my_DBDataSetTableAdapters.modbusTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modbusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_DBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IN_IP
            // 
            this.IN_IP.Location = new System.Drawing.Point(64, 38);
            this.IN_IP.Name = "IN_IP";
            this.IN_IP.Size = new System.Drawing.Size(119, 21);
            this.IN_IP.TabIndex = 1;
            // 
            // IN_PROT
            // 
            this.IN_PROT.Location = new System.Drawing.Point(247, 38);
            this.IN_PROT.Name = "IN_PROT";
            this.IN_PROT.Size = new System.Drawing.Size(58, 21);
            this.IN_PROT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(216, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.线圈DataGridViewCheckBoxColumn,
            this.输入状态DataGridViewCheckBoxColumn,
            this.保持寄存器DataGridViewTextBoxColumn,
            this.输入寄存器DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.modbusBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(37, 65);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(687, 573);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.my_tes);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView_Cellvalidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataError_handle);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // 线圈DataGridViewCheckBoxColumn
            // 
            this.线圈DataGridViewCheckBoxColumn.DataPropertyName = "线圈";
            this.线圈DataGridViewCheckBoxColumn.HeaderText = "线圈";
            this.线圈DataGridViewCheckBoxColumn.Name = "线圈DataGridViewCheckBoxColumn";
            // 
            // 输入状态DataGridViewCheckBoxColumn
            // 
            this.输入状态DataGridViewCheckBoxColumn.DataPropertyName = "输入状态";
            this.输入状态DataGridViewCheckBoxColumn.HeaderText = "输入状态";
            this.输入状态DataGridViewCheckBoxColumn.Name = "输入状态DataGridViewCheckBoxColumn";
            // 
            // 保持寄存器DataGridViewTextBoxColumn
            // 
            this.保持寄存器DataGridViewTextBoxColumn.DataPropertyName = "保持寄存器";
            this.保持寄存器DataGridViewTextBoxColumn.HeaderText = "保持寄存器";
            this.保持寄存器DataGridViewTextBoxColumn.Name = "保持寄存器DataGridViewTextBoxColumn";
            // 
            // 输入寄存器DataGridViewTextBoxColumn
            // 
            this.输入寄存器DataGridViewTextBoxColumn.DataPropertyName = "输入寄存器";
            this.输入寄存器DataGridViewTextBoxColumn.HeaderText = "输入寄存器";
            this.输入寄存器DataGridViewTextBoxColumn.Name = "输入寄存器DataGridViewTextBoxColumn";
            // 
            // modbusBindingSource
            // 
            this.modbusBindingSource.DataMember = "modbus";
            this.modbusBindingSource.DataSource = this.my_DBDataSet;
            // 
            // my_DBDataSet
            // 
            this.my_DBDataSet.DataSetName = "my_DBDataSet";
            this.my_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // modbusTableAdapter
            // 
            this.modbusTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 673);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IN_PROT);
            this.Controls.Add(this.IN_IP);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "MODBUS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modbusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_DBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox IN_IP;
        private System.Windows.Forms.TextBox IN_PROT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private my_DBDataSet my_DBDataSet;
        private System.Windows.Forms.BindingSource modbusBindingSource;
        private my_DBDataSetTableAdapters.modbusTableAdapter modbusTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 线圈DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 输入状态DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 保持寄存器DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 输入寄存器DataGridViewTextBoxColumn;
    }
}

