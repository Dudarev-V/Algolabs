
namespace ListCompare
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ChooseBox = new System.Windows.Forms.ComboBox();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.tst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(13, 13);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(475, 424);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // ChooseBox
            // 
            this.ChooseBox.FormattingEnabled = true;
            this.ChooseBox.Items.AddRange(new object[] {
            "Получение",
            "Присваивание",
            "Удаление"});
            this.ChooseBox.Location = new System.Drawing.Point(574, 13);
            this.ChooseBox.Name = "ChooseBox";
            this.ChooseBox.Size = new System.Drawing.Size(121, 24);
            this.ChooseBox.TabIndex = 1;
            // 
            // ComputeButton
            // 
            this.ComputeButton.Location = new System.Drawing.Point(574, 377);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(162, 61);
            this.ComputeButton.TabIndex = 2;
            this.ComputeButton.Text = "Рассчитать";
            this.ComputeButton.UseVisualStyleBackColor = true;
            this.ComputeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // tst
            // 
            this.tst.Location = new System.Drawing.Point(589, 112);
            this.tst.Name = "tst";
            this.tst.Size = new System.Drawing.Size(100, 22);
            this.tst.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tst);
            this.Controls.Add(this.ComputeButton);
            this.Controls.Add(this.ChooseBox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Lists";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox ChooseBox;
        private System.Windows.Forms.Button ComputeButton;
        private System.Windows.Forms.TextBox tst;
    }
}

