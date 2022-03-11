
namespace BSC_log
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start_checkBox = new System.Windows.Forms.CheckBox();
            this.online_timer = new System.Windows.Forms.Timer(this.components);
            this.scan_block_end_textBox = new System.Windows.Forms.TextBox();
            this.scan_block_button = new System.Windows.Forms.Button();
            this.scan_block_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addLiquidity_checkBox = new System.Windows.Forms.CheckBox();
            this.lockTokens_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trading_checkBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // start_checkBox
            // 
            this.start_checkBox.AutoSize = true;
            this.start_checkBox.Location = new System.Drawing.Point(687, 12);
            this.start_checkBox.Name = "start_checkBox";
            this.start_checkBox.Size = new System.Drawing.Size(56, 17);
            this.start_checkBox.TabIndex = 0;
            this.start_checkBox.Text = "Online";
            this.start_checkBox.UseVisualStyleBackColor = true;
            this.start_checkBox.CheckedChanged += new System.EventHandler(this.start_checkBox_CheckedChanged);
            // 
            // online_timer
            // 
            this.online_timer.Interval = 1000;
            this.online_timer.Tick += new System.EventHandler(this.online_timer_Tick);
            // 
            // scan_block_end_textBox
            // 
            this.scan_block_end_textBox.Location = new System.Drawing.Point(151, 12);
            this.scan_block_end_textBox.Name = "scan_block_end_textBox";
            this.scan_block_end_textBox.Size = new System.Drawing.Size(74, 20);
            this.scan_block_end_textBox.TabIndex = 10;
            this.scan_block_end_textBox.Text = "13618739";
            // 
            // scan_block_button
            // 
            this.scan_block_button.Location = new System.Drawing.Point(230, 12);
            this.scan_block_button.Name = "scan_block_button";
            this.scan_block_button.Size = new System.Drawing.Size(85, 20);
            this.scan_block_button.TabIndex = 9;
            this.scan_block_button.Text = "Manual scan";
            this.scan_block_button.UseVisualStyleBackColor = true;
            this.scan_block_button.Click += new System.EventHandler(this.scan_block_button_Click);
            // 
            // scan_block_textBox
            // 
            this.scan_block_textBox.Location = new System.Drawing.Point(39, 12);
            this.scan_block_textBox.Name = "scan_block_textBox";
            this.scan_block_textBox.Size = new System.Drawing.Size(74, 20);
            this.scan_block_textBox.TabIndex = 8;
            this.scan_block_textBox.Text = "13618739";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "- End:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1383, 365);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // addLiquidity_checkBox
            // 
            this.addLiquidity_checkBox.AutoSize = true;
            this.addLiquidity_checkBox.Checked = true;
            this.addLiquidity_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addLiquidity_checkBox.Location = new System.Drawing.Point(1274, 11);
            this.addLiquidity_checkBox.Name = "addLiquidity_checkBox";
            this.addLiquidity_checkBox.Size = new System.Drawing.Size(86, 17);
            this.addLiquidity_checkBox.TabIndex = 15;
            this.addLiquidity_checkBox.Text = "Add Liquidity";
            this.addLiquidity_checkBox.UseVisualStyleBackColor = true;
            // 
            // lockTokens_checkBox
            // 
            this.lockTokens_checkBox.AutoSize = true;
            this.lockTokens_checkBox.Location = new System.Drawing.Point(1274, 34);
            this.lockTokens_checkBox.Name = "lockTokens_checkBox";
            this.lockTokens_checkBox.Size = new System.Drawing.Size(86, 17);
            this.lockTokens_checkBox.TabIndex = 16;
            this.lockTokens_checkBox.Text = "LockTokens";
            this.lockTokens_checkBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1207, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Visible if:";
            // 
            // trading_checkBox
            // 
            this.trading_checkBox.AutoSize = true;
            this.trading_checkBox.Location = new System.Drawing.Point(1274, 57);
            this.trading_checkBox.Name = "trading_checkBox";
            this.trading_checkBox.Size = new System.Drawing.Size(98, 17);
            this.trading_checkBox.TabIndex = 18;
            this.trading_checkBox.Text = "Trading Enable";
            this.trading_checkBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1387, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 470);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.trading_checkBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lockTokens_checkBox);
            this.Controls.Add(this.addLiquidity_checkBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scan_block_end_textBox);
            this.Controls.Add(this.scan_block_button);
            this.Controls.Add(this.scan_block_textBox);
            this.Controls.Add(this.start_checkBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "BSC_log";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox start_checkBox;
        private System.Windows.Forms.Timer online_timer;
        private System.Windows.Forms.TextBox scan_block_end_textBox;
        private System.Windows.Forms.Button scan_block_button;
        private System.Windows.Forms.TextBox scan_block_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox addLiquidity_checkBox;
        private System.Windows.Forms.CheckBox lockTokens_checkBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox trading_checkBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

