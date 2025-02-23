namespace CounterExample.Views
{
    partial class CounterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIncrement = new Button();
            lblCount = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIncrement
            // 
            btnIncrement.Dock = DockStyle.Fill;
            btnIncrement.Font = new Font("Segoe UI", 20F);
            btnIncrement.Location = new Point(3, 3);
            btnIncrement.Name = "btnIncrement";
            btnIncrement.Size = new Size(794, 219);
            btnIncrement.TabIndex = 0;
            btnIncrement.Text = "Increment";
            btnIncrement.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Dock = DockStyle.Fill;
            lblCount.Font = new Font("Segoe UI", 20F);
            lblCount.Location = new Point(3, 225);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(794, 225);
            lblCount.TabIndex = 1;
            lblCount.Text = "Counter";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnIncrement, 0, 0);
            tableLayoutPanel1.Controls.Add(lblCount, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // CounterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "CounterForm";
            Text = "Counter Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIncrement;
        private Label lblCount;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
